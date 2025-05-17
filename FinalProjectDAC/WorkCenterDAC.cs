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
    public class WorkCenterDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("WorkCenterDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }

        public WorkCenterDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<WorkCenterVO> GetWorkCenterList()      //작업장정보 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Wc_Code, Wc_Name, WC.Process_Code, Process_name, Wo_Status, Last_Cnt_Time, Prd_Req_Type, Pallet_YN, Item_Code
                                        Prd_Unit, Mold_Setup_YN, WC.Use_YN, WC.Remark from WorkCenter_Master WC inner join Process_Master P on WC.Process_Code = P.Process_code";

                    List<WorkCenterVO> list = Helper.DataReaderMapToList<WorkCenterVO>(cmd.ExecuteReader());

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

        public bool InsertWorkCenter(string code, string name, string pcode, string remark, string emp)       //작업장정보 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into WorkCenter_Master (Wc_Code, Wc_Name, Process_Code, Remark, Ins_Date, Ins_Emp) values (@Wc_Code, @Wc_Name, @Process_Code, @Remark, @Ins_Date, @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Wc_Code", code);
                    cmd.Parameters.AddWithValue("@Wc_Name", name);
                    cmd.Parameters.AddWithValue("@Process_Code", pcode);
                    cmd.Parameters.AddWithValue("@Remark", remark);
                    cmd.Parameters.AddWithValue("@Ins_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Ins_Emp", emp);

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
        public bool DeleteWorkCenter(string code)       //작업장정보 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from WorkCenter_Master where Wc_Code = @Wc_Code";

                    cmd.Parameters.AddWithValue("@Wc_Code", code);

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

        public bool UpdateWorkCenter(WorkCenterVO no)       //작업장정보 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update WorkCenter_Master set Wc_Name = @Wc_Name, Process_Code = @Process_Code, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Wc_Code = @Wc_Code";

                    cmd.Parameters.AddWithValue("@Wc_Name", no.Wc_Name);
                    cmd.Parameters.AddWithValue("@Process_Code", no.Process_Code);
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@Wc_Code", no.Wc_Code);

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

        public bool UseYNSwap(string useYN, string code)    //사용여부를 변경
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;


                    cmd.CommandText = "update WorkCenter_Master set Use_YN = @Use_YN where Wc_Code = @Wc_Code";
                    cmd.Parameters.AddWithValue("@Use_YN", useYN);
                    cmd.Parameters.AddWithValue("@Process_code", code);



                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return false;
            }
        }

        public List<WorkCenterVO> GetWorkCenterSmallList()      //작업장명과 코드 목록만 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Wc_Code, Wc_Name from WorkCenter_Master";

                    List<WorkCenterVO> list = Helper.DataReaderMapToList<WorkCenterVO>(cmd.ExecuteReader());

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
    }
}
