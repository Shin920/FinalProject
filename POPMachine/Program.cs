using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using System.Timers;
using System.Net.Sockets;
using POP;
using System.Net;

namespace POPMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1 service = new Service1();
            service.taskID = args[0];
            service.hostIP = args[1];
            service.hostPort = int.Parse(args[2]);
            //service.taskID = "MAC_05";
            //service.hostIP = "127.0.0.1";
            //service.hostPort = 8877;
            service.OnStart();

            Console.ReadLine();
        }
    }

    public class Service1
    {
        LoggingUtility loggingUtility;
        TcpListener listener;
        Timer timer1;
        TcpClient tc;
        NetworkStream stream;

        LoggingUtility Log { get { return loggingUtility; } }

        public string taskID { get; set; }
        public string hostIP { get; set; }
        public int hostPort { get; set; }

        public void OnStart()
        {
            loggingUtility = LoggingUtility.GetLoggingUtility(taskID, Level.Debug, 30);
            //IPEndPoint local = new IPEndPoint(IPAddress.Parse(hostIP), hostPort);

            Console.WriteLine("서비스 시작");
            Log.WriteInfo("서비스 시작");

            if (listener == null)
            {
                listener = new TcpListener(IPAddress.Parse(hostIP), hostPort);
                //listener = new TcpListener(IPAddress.Any, hostPort);
            }
            listener.Start();
            Console.WriteLine("리스너 시작");
            AsyncEchoServer();
        }

        private async void AsyncEchoServer()
        {
            //listener.Start();
            while (true)
            {
                tc = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                stream = tc.GetStream();

                Console.WriteLine("클라이언트 연결");

                timer1 = new Timer(3000);
                timer1.Elapsed += Timer1_Elapsed;
                timer1.Enabled = true;
                timer1.AutoReset = true;
                // await Task.Factory.StartNew(AsyncTcpProcess, tc);
            }
        }

        private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random rnd = new Random((int)DateTime.UtcNow.Ticks);
            //50|2 //양품/불량품 원래는 prd id/양품/불량품
            int good = rnd.Next(0, 2);
            string msg = $"{good}|{1- good}";
            byte[] buff = Encoding.Default.GetBytes(msg);

            stream.Write(buff, 0, buff.Length);
            Console.WriteLine(msg);
            Log.WriteInfo("데이터전송: " + msg);
        }

        public void OnStop()
        {
            listener.Stop();
        }
    }
}
