using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POP
{
    public class TcpControl
    {
        //이건 약식으로 한것. 실제로 적용되는 애는 비동기로 하는게 좋다

        public TcpClient client;
        NetworkStream dataStream;
        //public TcpClient Client { get { return client; } }    //이걸 생략하고 변수를 퍼블릭으로 햇다. (Client라는 속성명이 겹쳐서 애매해질수있어서 이름 따로 안바꾸고 이렇게했다)
        public NetworkStream DataStream { get { return dataStream; } }

        public TcpControl(string host, int port)
        {
            client = new TcpClient(host, port);
            //IPEndPoint serverPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6688);  //서버의 ip, port


            //client.Connect(serverPoint);
            dataStream = client.GetStream();
        }

        /// <summary>
        /// 초기 연결 후, 접속상태 체크
        /// 1. BCL에 정의된 메서드와 상태값으로 체크
        /// 2. 클라이언트가 한번씩 체크플래그를 보내서 응답이 오는지 체크
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            bool bStatus = false;
            try
            {
                if (client != null && client.Client != null && client.Client.Connected)  //TcpClient의 Client 속성에 Connect는 현재 상태가 아니라 마지막 통신햇을때 상태를 반환해서 얘가
                                                                                         //true를 준다고 해서 절대 믿으면 안된다. 그래서 조건문을 하나 더 추가한다.
                {
                    if (client.Client.Available == 0 && client.Client.Poll(2000, SelectMode.SelectRead))
                    //클라이언트가 읽어들일 내용이 없으면(서버가 보내는 내용이 없다는것), Poll은 소켓의 상태 (x밀리세컨드동안 , 읽어들이기 모드로 하겠다)
                    //즉 2초동안 읽기모드인데(Poll 쪽) 읽어들일 내용이 없다면(Available쪽)~이라는 조건
                    //그래서 만약 읽을게 아무것도 없다는건 서버와 문제가 있다는것(0.3초마다 데이터를 보내라고 했는데 2초동안 아무것도 없으니까)
                    {
                        bStatus = false;
                    }
                    else
                        bStatus = true;
                }
                return bStatus;
            }
            catch
            {
                return false;
            }
        }

        public bool Send(byte[] data)
        {
            try
            {
                dataStream.Write(data, 0, data.Length);
                dataStream.Flush();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name} : {err.Message}");        //누가 지금 이 메서드를 호출했는데 어떤 오류가 났다.
                //이거처럼 라이브러리에 함수를 만들었을때 여러 군데에서 얘를 사용할텐데 어떤 애가 이 메서드를 사용하다가 에러가 났는지 알려주는.
                return false;
            }
        }
    }
}
