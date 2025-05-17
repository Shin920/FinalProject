using FinalProject;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP
{
    public partial class frmMachineTask : Form
    {
        public event EventHandler Del;
        public bool IsDel { get; set; }
        string hostIP;
        int hostPort, taskID;
        string clientName, clientIP;    //클라이언트의 PC명과 IP를 저장
        int timer_KeepAlive, timer_R_PLC, timer_Connector;
        string workOrderNum;
        int prdCnt;
        int cnt;
        int process_ID;

        TcpControl client;

        public bool TaskExit { get; set; }      //종료하는지

        SqlConnection conn;

      
        LoggingUtility _log;

        ThreadMachineTask m_thread;

       

        public frmMachineTask(string taskId, string ip, string port, string workOrderNum, int prdCnt, string machineName, int processID)
        {
            InitializeComponent();

            this.workOrderNum = workOrderNum;
            this.prdCnt = prdCnt;
            ////////////////
            hostIP = ip;
            hostPort = int.Parse(port);
            string strTaskID = taskId;
            taskID = int.Parse(strTaskID.Replace("MAC_", ""));
            this.process_ID = processID;


            timer_Connector = int.Parse(ConfigurationManager.AppSettings["timer_Connect"]);
            timer_KeepAlive = int.Parse(ConfigurationManager.AppSettings["timer_KeepAlive"]);
            timer_R_PLC = int.Parse(ConfigurationManager.AppSettings["timer_R_PLC"]);

            timer_Connect.Interval = timer_Connector;

            this.Text = strTaskID;
            lblMachineName.Text = machineName;
            lblIP.Text = hostIP;
            lblPort.Text = hostPort.ToString();

            clientName = Dns.GetHostName();   //이러면 내 컴퓨터 이름이 넘어간다(DESKTOP-178Kfq 이런식). Dns는 도메인이름
            IPAddress[] locals = Dns.GetHostAddresses(clientName);  //실행중인 컴퓨터의 IP정보
            if (locals.Length > 0)
            {
                clientIP = locals[1].ToString();    //중단점 찍고 locals의 데이터를 보면 0번째는 이상한 거고 1번째가 IP가 되는걸 확인할수 있다.
            }

            Assembly assembly = Assembly.GetExecutingAssembly();    //내가 실행중인 PLCTask가 되는것
           /* lblVersion.Text = File.GetLastWriteTime(assembly.Location).ToString("yyyy.MM.dd");         *///AccessTime은 실행할때마다 달라지는거고 Write는 작성(수정)한것

            _log = new LoggingUtility(strTaskID, Level.Debug, 30);        //프로그램명을 줄것

            this.Height = 150;  //처음 폼 생성되었을때는 작은 모드로 열리게

            TaskExit = false;
        }

        
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMachineTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();

            ////소켓 종료g
            ////근데 전역으로 선언만 해놨기때문에 null일 가능성이 있고 접속실패했을수도 있기때문에 널체크
            //if (client != null)
            //{
            //    client.DataStream.Close();
            //    client.client.Close();
            //}     //이 소켓통신에 대한걸 아래 m_thread의 클래스에 정의햇다

            m_thread.ThreadStop();

            //load data 되게
            IsDel = true;
            if (Del != null)
            {
                Del(this, null);
            }

        }

        private void frmMachineTask_Load(object sender, EventArgs e)
        {
            try
            {
                _log.WriteInfo("DB에 연결");     //info와 debug는 별 차이없지만 info는 어디까지 진행햇는지 진행단계를 찍을때 쓰고 debug는 어떤 데이터값을 확인할때 쓰자고 구분해서 쓰기도한다.

                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);  //커넥션을 
                conn.Open();    //로드될때 커넥션을 오픈해놓고 (왜냐면 밑에 타이머에 정의하면 0.3초마다 커넥션 열고닫고 해야하니까, 그리고 웹과 다르게 윈폼은 특정사용자에 한하는 성향이 있기때문에
                                //이렇게 열어놀수있다.

                /////멀티스레드로 하면ㄴ
                m_thread = new ThreadMachineTask(conn, _log, taskID, hostIP, hostPort, timer_Connector, timer_KeepAlive, timer_R_PLC, clientName, clientIP, workOrderNum);
                m_thread.ReadData += M_thread_ReadData;
                m_thread.ThreadStart();

                ///////
                timer_Connect.Start();  //네트워크 통신연결시작




            }
            catch (Exception err)
            {
                _log.WriteError(err.Message);
            }

        }

        private void M_thread_ReadData(object sender, ReadDataEventArgs e)
        {
          

            
               // if (listBox1.Items.Count > 50)
                  //  listBox1.Items.Clear();     //어차피 로그파일에 기록되게 할거기때문에 화면에 너무 부하를 주지않기위해서 일정량 이상 쌓이면 삭제



                this.Invoke((MethodInvoker)(() => listBox1.Items.Add($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] :{e.Data}")));
                this.Invoke((MethodInvoker)(() => listBox1.SelectedIndex = listBox1.Items.Count - 1)); //얘가 값을 읽어올때마다 계속 늘어나는데 리스트박스에 많이 적혀지면 스크롤이 생기지만
                                                                                                       //맨 마지막 데이터가 있는 끝쪽으로 자동으로 내려가지지는 않는다. 그래서 마지막 데이터를 선택되게해서
            this.Invoke((MethodInvoker)(() => lblcount.Text = listBox1.Items.Count.ToString()));                                                                           //스크롤이 자동으로 내려가지게

            string[] arr = e.Data.Split('|');
            cnt += (Convert.ToInt32(arr[0])+ Convert.ToInt32(arr[1]));    //생산수량

            if (cnt >  prdCnt)
            {
                conn.Close();

                
                m_thread.ThreadStop();
                cnt = 0;
                //frm.TaskExit = true;
                //frm.Close();

                //IsTaskEnable = false;

                //프로세스 중지(설비 중지)
                //프로세스ID를 기준으로 Kill을 한다
                foreach (Process pro in Process.GetProcesses())       //GetProcesses는 지금 실행중인 프로세스를 다 가져오고 GetProcessesbyID는 id를 내가 알때
                {
                    if (pro.Id.Equals(process_ID))
                    {
                        pro.Kill();
                        break;
                    }
                }
                WorkOrderService service = new WorkOrderService();
                bool result = service.SetWoOrder7(workOrderNum);
                
                frmForming frm = (frmForming)this.Owner;
                frm.LoadData();
                this.Close();
            }
            
        }



        private void timer_Connect_Tick(object sender, EventArgs e)
        {
            try
            {

                if (m_thread.Connection) //연결되었으면
                {
                    lblState.BackColor = Color.Green;

                }
                else
                {
                    lblState.BackColor = Color.Red;
                }
            }
            catch (Exception err)
            {
                _log.WriteError(err.Message);
            }
        }
        private void frmMachineTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            //X버튼을 눌러도 닫히는게 아닌 통신은 계속되게 하려고 모습만 숨기는것 ( 아예 닫아서 통신이 끝나는건 중지 버튼으로 할 생각이니까)
            if (!TaskExit)
            {
                this.Hide();    //안보이게 하고
                e.Cancel = true;    //Closed가 일어나지 않게 하는것(closing을 취소하는것) 
            }
        }

    }
}
