using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;
using FinalProject;

namespace POP
{
    /// <summary>
    /// TcpClient 연결 및 송수신을 담당하는 클래스
    /// </summary>
    public class ThreadMachineTask
    {
        public delegate void ReadDataEventHandler(object sender, ReadDataEventArgs e);
        public event ReadDataEventHandler ReadData;

        Thread m_thread;
       
        ManualResetEvent m_ThreadTerminateRequest = new ManualResetEvent(false); //Reset()를 호출해서 문을 닫고, 이후에 도착한 쓰레드들을 다시 대기토록 한다.

        SqlConnection conn;
        LoggingUtility _log;

        string hostIP, clientName, clientIP, workOrderNum;
        int taskID, hostPort, timer_Connector, timer_KeepAlive, timer_R_PLC;

        TcpControl client;
        NetworkStream recvdata;
        bool m_ConnetionSts = false;
        const string STR_Heart_Beat = "HeartBeat";

        Stopwatch m_AliveTimer = new Stopwatch();

        bool isStart;
        int totCnt = 0;
        int badTotCnt = 0;

        public bool Connection { get { return m_ConnetionSts; } }

        public ThreadMachineTask(SqlConnection conn, LoggingUtility _log, int taskID, string hostIP, int hostPort, int timer_Connector, int timer_KeepAlive, int timer_R_PLC, string clientName, string clientIP, string workOrderNum)
        {
            this.conn = conn;
            this._log = _log;
            this.taskID = taskID;
            this.hostIP = hostIP;
            this.hostPort = hostPort;
            this.timer_Connector = timer_Connector;
            this.timer_KeepAlive = timer_KeepAlive;
            this.timer_R_PLC = timer_R_PLC;
            this.clientName = clientName;
            this.clientIP = clientIP;
            this.workOrderNum = workOrderNum;

            m_AliveTimer.Stop();    //처음에는 시작x

            isStart = true;
        }

        public void ThreadStart()
        {
            m_ThreadTerminateRequest.Reset();
            m_thread = new Thread(ExecuteThreadJob);
            m_thread.Start();
        }
        public void ThreadStop()
        {
            if (client != null)
            {
                client.DataStream.Close();
                client.client.Close();
            }
        }

        private void ExecuteThreadJob()
        {
            while (!this.m_ThreadTerminateRequest.WaitOne(timer_R_PLC)) //무한루프 돌면서 여러개의 쓰레드가 있을떄 m_thread를 lock걸었다가 풀었다가 하는
            {
                try
                {
                    lock (m_thread)
                    {
                        // 실제 Thread에 필요한 코드 수행                        
                        DoingSchedule();
                    }
                }
                catch (Exception ex)
                {
                    _log.WriteError("쓰레드 실행 중 오류 : " + ex.Message);
                }
            }
        }
        private void DoingSchedule()
        {
            if(!m_ConnetionSts)
            {
                //연결
                client = new TcpControl(hostIP, hostPort);
                if (client.client.Connected)
                {
                    recvdata = client.DataStream;
                    m_ConnetionSts = true;
                    m_AliveTimer.Restart();     //처음 시작이라 Start도 되지만 Restart를 많이 쓴다고함    
                    _log.WriteInfo("서버접속");
                }
            }
            else
            {
                //timer컨트롤, Timer 클래스를 배웠었고 이번에는 Stopwatch라는 클래스가 있다
                //Restart()를 사용하면 멈췄다가 다시 하는게 가능하고 토탈세컨드 등을 구할수 있다.

                //Alive 체크
                if(! m_AliveTimer.IsRunning || m_AliveTimer.Elapsed.TotalMilliseconds > timer_KeepAlive)    //스탑워치가 작동중이지않거나 keepAlive보다 커졌다면
                {
                    _log.WriteInfo("재접속을 위한 연결종료");
                    client.client.Close();  //클라이언트를 클로즈하면 네트워크스트림도 close된다. 근데 스트림도 이전에 close해주면 더 안전한거고
                    m_ConnetionSts = false;

                    client = new TcpControl(hostIP, hostPort);
                    if (client.client.Connected)
                    {
                        recvdata = client.DataStream;
                        m_ConnetionSts = true;
                        m_AliveTimer.Restart();     
                        _log.WriteInfo("재접속 성공");
                    }
                }
                //수신
                OnRecive();
            }
        }
        private void OnRecive()
        {
            // 시간|MachineID|제품ID|생산수량|불량수량   근데 이게 시간|MachineID|제품ID|생산수량|불량수량시간|MachineID|제품ID|생산수량|불량수량 이렇게 연속된 데이터가 오면 혹시 합쳐지게 되면 어디서 끊어지는지 모르니까 시작에 STX, 마지막에 ETX 를 붙이기로한게 일반적인 통신프로그램의 약속이다.
            //STX시간|MachineID|제품ID|생산수량|불량수량ETXSTX시간|MachineID|제품ID|생산수량|불량수량ETX

            //STX (start of text, 아스키 2번, 0x02)
            //ETX (end of text, 아스키 3번, 0x03)
            //아스키기호로   -STX   ,    -ETX   (COM ANALYZER에서 바이너리를 아스키로 바꾸는 텍스트박스가 있는데 거기에 02, 03을 입력하고(기본 16진수라 0x 안해도됨) 엔터쳐보면 기호가 나온다.이런 기호가 될것)
            //50|20|249|30|5   이런식, HeartBeat

            //이걸 기계가 보내주지만 우리는 기계ㅔ가 없으니 COM ANALYZER에서 50|20|2 를 복사해서 서버 열고 보내는 데이터 라는 텍스트박스에 50|20|2를 붙여넣고 보내면
            //클라이언트에서도 받아지는게 확인할수있다.

            if (client.client.Available > 0)
            {

                byte[] rcvTemp = new byte[client.client.Available];     //초기 데이터를 받아들이는 임시배열
                byte[] rcvValue = new byte[client.client.Available];    //stx,stx를 때고 그 뒤에거부터 배열에 집어넣고 이런식으로떼고 만들 배열

                recvdata.Read(rcvTemp, 0, rcvTemp.Length);

                bool bFind = false;
                int vLoop = 0;
                for (int sCnt = 0; sCnt < rcvTemp.Length; sCnt++)   //받은 버퍼만큼 돌면서 stx,etx를 찾을예정
                {
                    //하나 받았다 안받았다는 앞에 stx가 잇고 뒤에 etx가 있어야하는
                    if (rcvTemp[sCnt] == 0x2)    // STX. STX를 찾으면 ETX를 찾으러갈것, 
                    {
                        for (int eCnt = sCnt + 1; eCnt < rcvTemp.Length; eCnt++) //그리고 STX 를 찾았으면 다음값부터 배열에 넣을것
                        {
                            if (rcvTemp[eCnt] == 0x3)  //ETX
                            {
                                bFind = true;   //처음부터 끝까지 다했다 라는것
                                break;
                            }
                            rcvValue[vLoop] = rcvTemp[eCnt];    //rcvValue의 0번째 배열부터 채워주고 ++해서 그다음에는 그다음 배열에 넣을수있게
                            vLoop++;
                        }
                        if (bFind)
                            break;
                    }
                }
                if (bFind)
                {
                    //근데 이 배열 두개를 선언할때 둘다 크기를 동일하게 했는데 rcvValue는 기호를 빼는데도 기호가 있는 애랑 배열크기가 동일하기때문에 중간중간 널이 섞일것이다.
                    //그러면 스트링으로 바꿀때 이상하게 나오기때문에 아스키코드를 보면 널은 0x00이다. 스페이스는 0x20이다.
                    //그래서 널문자를 (공백)스페이스로 바꾸고 ( 0x00 => 0x20), 변환된 문자열에서 공백제거(trim)

                    for (int i = 0; i < rcvValue.Length; i++)
                    {
                        if (rcvValue[i] == 0x0)
                            rcvValue[i] = 0x20;
                    }
                    string readData = Encoding.UTF8.GetString(rcvValue).Replace(" ", ""); //혹시나 앞뒤가 아닌 중간에 공백이 있는 경우는 트림이 안되기때문에 replace로 했다.
                    _log.WriteInfo("데이터 수신:" + readData);
                    //HeartBeat를 수신한 경우 stopwatch를 재시작하고 빠져나간다.
                    if(readData.Contains(STR_Heart_Beat))
                    {
                        m_AliveTimer.Restart();
                        readData = readData.Replace(STR_Heart_Beat, "");    //만약 HeartBeat랑 데이터랑 붙어서 왔을시에 하트비트를 지우고 데이터만
                    }
                    readData = readData.Trim();
                    if (readData.Length < 1) return;    //데이터가 없으면 return처리

                    //readData = "50|20|2";
                    string[] arrData = readData.Split('|');
                    if (arrData.Length == 2)
                    {
                        //이벤트 발생
                        if(ReadData != null)
                        {
                            ReadDataEventArgs args = new ReadDataEventArgs();
                            args.Data = readData;
                            ReadData(null, args);
                        }
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            //마지막 수량을 생산할때는 종료시간까지 추가한걸로 해야한다
                            cmd.Connection = conn;
                            if (isStart)
                            {
                                cmd.CommandText = @"update WorkOrder set good_prd_qty = @Prd_Qty, Bad_Prd_Qty = @Bad_Prd_Qty, Prd_Starttime = getdate(),Prd_Endtime = getdate(), Up_Date = getdate() where Workorderno = @Workorderno";
                            }
                           
                            else
                            {
                                cmd.CommandText = @"update WorkOrder set good_prd_qty = @Prd_Qty, Bad_Prd_Qty = @Bad_Prd_Qty, Up_Date = getdate(), Prd_Endtime = getdate() where Workorderno = @Workorderno";
                            }
                            totCnt += Convert.ToInt32(arrData[0]);
                            badTotCnt += Convert.ToInt32(arrData[1]);
                            cmd.Parameters.AddWithValue("@Prd_Qty", totCnt);
                            cmd.Parameters.AddWithValue("@Bad_Prd_Qty", badTotCnt);
                            cmd.Parameters.AddWithValue("@Using_Machine", taskID);
                            cmd.Parameters.AddWithValue("@Workorderno", workOrderNum);

                            cmd.ExecuteNonQuery();
                            isStart = false;        //초기값을 트루로 했으니 처음에만 start로 되고 그 다음부터는 아랫줄로 실행될것
                        }
                    }
                }
            }
        }

    }

    public class ReadDataEventArgs : EventArgs
    {
        public string Data { get; set; }
    }
}
