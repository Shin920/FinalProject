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
    public class WorkReqDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("WorkReqDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public WorkReqDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<WorkReqVO> GetWorkReqList()      //생산의뢰 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select ROW_NUMBER() over(order by Req_Seq) as Num, Wo_Req_No, WR.Ins_Date, WR.Item_Code, Item_Name, Req_Qty, Project_Name, Cust_Name, Sale_Emp, UM.Userdefine_Mi_Name Req_Status, Prd_Plan_Date, Item_Unit
                                        from Wo_Req WR inner join Item_Master I on WR.Item_Code = I.Item_Code
                                                       inner join Userdefine_Mi_Master UM on WR.Req_Status = UM.Userdefine_Mi_Code";

                    List<WorkReqVO> list = Helper.DataReaderMapToList<WorkReqVO>(cmd.ExecuteReader());

                    return list;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public List<WorkReqVO> SearchWorkReqList(string begDate, string endDate)      //생산의뢰 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select ROW_NUMBER() over(order by Req_Seq) as Num, Wo_Req_No, WR.Ins_Date, WR.Item_Code, Item_Name, Req_Qty, Project_Name, Cust_Name, Sale_Emp, UM.Userdefine_Mi_Name Req_Status, Prd_Plan_Date, Item_Unit
                                        from Wo_Req WR inner join Item_Master I on WR.Item_Code = I.Item_Code
                                                       inner join Userdefine_Mi_Master UM on WR.Req_Status = UM.Userdefine_Mi_Code
                                                       where WR.Ins_Date between '" + begDate + "' and '" + endDate + "'";

                    List<WorkReqVO> list = Helper.DataReaderMapToList<WorkReqVO>(cmd.ExecuteReader());

                    return list;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }
        
        public bool FinishWorkReq(string code)       //생산의뢰 마감
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Wo_Req set Req_Status = 'RE_03' where Wo_Req_No = @Wo_Req_No";

                    cmd.Parameters.AddWithValue("@Wo_Req_No", code);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }



        }
    }
}
