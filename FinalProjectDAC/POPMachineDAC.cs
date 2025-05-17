using FinalProjectVO;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDAC
{
    public class POPMachineDAC : IDisposable
    {
        SqlConnection conn;
        private static LoggingUtility log = new LoggingUtility("POPMachineDAC", Level.Debug, 30);

        public static LoggingUtility Log { get { return log; } }
        public POPMachineDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<WorkOrderVO> GetUsingMachine()  //사용중인 기계목록을 가져온다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select Using_Machine from WorkOrder where wo_status in ('WO_01', 'WO_02', 'WO_03')";


                    List<WorkOrderVO> list = Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                    return list;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool InsertUsingMachine(string macName, string workOrderNum)  //작업지시에 기계를 사용등록한다.
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "update WorkOrder set Using_Machine = @Using_Machine where Workorderno = @Workorderno";
                    cmd.Parameters.AddWithValue("@Using_Machine", macName);
                    cmd.Parameters.AddWithValue("@Workorderno", workOrderNum);

                    return cmd.ExecuteNonQuery() > 0;
             
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return false;
            }
        }
    }
}
