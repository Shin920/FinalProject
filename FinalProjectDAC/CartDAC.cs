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
    public class CartDAC
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("CartDAC", Level.Debug, 30);


        public static LoggingUtility Log { get { return log; } }
        public CartDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }
        /// <summary>
        /// 사용가능한 성형대차 목록조회
        /// </summary>
        /// <returns></returns>
        public List<CartVO> GetFormingCarList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select GV_CODE, GV_NAME from GV_Master where GV_Group = '성형' AND GV_STATUS = '0' AND Use_YN = 'Y'";

                    List<CartVO> list = Helper.DataReaderMapToList<CartVO>(cmd.ExecuteReader());
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
        /// <summary>
        /// 공정리스트 조회
        /// </summary>
        /// <param name="inputCase"></param>
        /// <returns></returns>
        public List<ProcessVO> GetProcessList(string inputCase)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select process_code, process_name from Process_Master where Process_Group = @inputCase  AND Use_YN = 'Y'";

                    cmd.Parameters.AddWithValue("@inputCase", inputCase);

                    List<ProcessVO> list = Helper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());
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

/// <summary>
/// 작업장조회
/// </summary>
/// <param name="inputCase"></param>
/// <returns></returns>
        public List<WorkCenterVO> GetCenterList(string inputCase)
        {
            try
            {
                string wcG = "";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select wc_code, wc_name
from WorkCenter_Master
where Wc_Group = @inputCase and Wo_Status = 'RUN' AND Use_YN = 'Y'";

                    if(inputCase == "소성")
                    {
                        wcG = "소성작업장";
                    }
                    else if(inputCase == "포장")
                    {
                        wcG = "포장작업장";
                    }
                    cmd.Parameters.AddWithValue("@inputCase", wcG);

                    List<WorkCenterVO> list = Helper.DataReaderMapToList<WorkCenterVO>(cmd.ExecuteReader());
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
        /// <summary>
        /// 해당 작업지시번호로 요출시간이 기록되지 않은 소성대차 목록 조회
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public int GetUnOutCarCount(string workorderno)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select count(*)
from GV_Current_Status GC INNER JOIN GV_Master G ON GC.GV_Code = G.GV_Code
where workorderno = @workorderno AND GV_Group = '소성' AND GV_Rest_Qty > 0 and Out_Time is null";
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return 9999;
            }
        }
        /// <summary>
        /// 작업지시번호로 등록된 잔여수량있는 소성대차 존재 여부
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public int IsFireCarExist(string workorderno)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select count(*) from GV_Current_Status 
where workorderno = @workorderno and GV_Rest_Qty > 0 ";
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return 9999;
            }
        }


        /// <summary>
        /// 해당 작업지시번호 중 소성작업에 등록되지 않은 건조대차 목록 조회
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public int GetRestDryCarListCount(string workorderno)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select  count(*)
from GV_Current_Status GC INNER JOIN GV_Master G ON GC.GV_Code = G.GV_Code
where workorderno = @workorderno AND GV_Group = '건조' AND GV_Rest_Qty > 0";
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return 9999;
            }
        }

        /// <summary>
        /// 대차비우기
        /// </summary>
        /// <param name="gv_code"></param>
        /// <param name="qty"></param>
        /// <param name="reason"></param>
        /// <param name="wc_code"></param>
        /// <param name="item_code"></param>
        /// <param name="hist_seq"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool VacateCar(string gv_code, int qty, string wc_code, string item_code, string hist_seq, string managerid , string workorderno, string reason = "기타")
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"SP_AfterVacateCar";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@gv_code", gv_code);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    int iRowAffect = 0;
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        conn.Open();
                        cmd1.Connection = conn;
                        cmd1.CommandText = @"SP_VacateCar";
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd1.Parameters.AddWithValue("@gv_code", gv_code);
                        cmd1.Parameters.AddWithValue("@qty", qty);
                        cmd1.Parameters.AddWithValue("@managerid", managerid);
                        cmd1.Parameters.AddWithValue("@wc_code", wc_code);
                        cmd1.Parameters.AddWithValue("@reason", reason);
                        cmd1.Parameters.AddWithValue("@item_code", item_code);
                        cmd1.Parameters.AddWithValue("@histseq", hist_seq);
                        iRowAffect = cmd1.ExecuteNonQuery();
                    }
                    return (iRowAffect > 0);
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        /// <summary>
        /// 요입/요출
        /// </summary>
        /// <param name="gv_code"></param>
        /// <param name="hist_seq"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool SetCartInOut(string gv_code, string hist_seq, string managerid, string inputCase)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    if (inputCase == "요입")
                    {
                        cmd.CommandText = @"update gv_current_status set in_time = case when (select in_time from GV_Current_Status where GV_Code = @gv_code) is null then getdate() else (select in_time from GV_Current_Status where GV_Code = @gv_code) end, out_time = null, up_date = getdate(), up_emp = @managerid
where gv_code = @gv_code

update gv_history set in_time = case when (select in_time from gv_history where GV_Code = @gv_code) is null then getdate() else (select in_time from GV_Current_Status where GV_Code = @gv_code) end, out_time = null, up_date = getdate(), up_emp = @managerid
where hist_seq = @histseq";
                    }
                    else if (inputCase == "요출")
                    {
                        cmd.CommandText = @"update gv_current_status set OUT_time = getdate(), up_date = getdate(), up_emp = @managerid
where gv_code = @gv_code

update gv_history set out_time = getdate(), up_date = getdate(), up_emp = @managerid
where hist_seq = @histseq";
                    }

                    cmd.Parameters.AddWithValue("@gv_code", gv_code);
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@histseq", hist_seq);
                    int iRowAffect = cmd.ExecuteNonQuery();
                    return (iRowAffect > 0);
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        /// <summary>
        /// 사용가능한 소성대차 목록조회
        /// </summary>
        /// <returns></returns>
        public List<CartVO> GetFiringCarList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select GV_CODE, GV_NAME from GV_Master where GV_Group = '소성' AND GV_STATUS = '0' AND Use_YN = 'Y'";

                    List<CartVO> list = Helper.DataReaderMapToList<CartVO>(cmd.ExecuteReader());
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

        public bool CarLoadingUnloading(string managerid, string WorkOrderNO, string dry_Gv_Code, string origin_Gv_Code, int qty, int status_seq, long hist_seq, string inputCase)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"SP_LoadingUnloading";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@workorderno", WorkOrderNO);
                    cmd.Parameters.AddWithValue("@TARGET_GV_CODE", dry_Gv_Code);
                    cmd.Parameters.AddWithValue("@QTY", qty);
                    cmd.Parameters.AddWithValue("@STATUS_SEQ", status_seq);
                    cmd.Parameters.AddWithValue("@ORIGIN_GV_CODE", origin_Gv_Code);
                    cmd.Parameters.AddWithValue("@Hist_Seq", hist_seq);
                    cmd.Parameters.AddWithValue("@inputCase", inputCase);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    return (iRowAffect > 0);
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        /// <summary>
        /// 작업지시번호로 적재되어있는 성형대차/건조대차 목록 조회
        /// </summary>
        /// <returns></returns>
        public List<CartVO> GetOriginCarList(string workorderno, string inputCase)
        {
            try
            {
                string sql = @"				select Hist_seq, Status_Seq, gc.gv_code, gv_name, Convert(datetime, (Convert(nvarchar(20), gc.Loading_Date)+ ' ' + CONVERT(CHAR(12),loading_time,14))) loading_time, GV_Rest_Qty, gc.workorderno, gc.in_time, gc.out_time , item_name, w.item_code
from GV_Current_Status gc inner join gv_master g on gc.GV_Code = g.GV_Code
inner join GV_History gh on gc.GV_Code = gh.GV_Code and gc.Workorderno = gh.Workorderno
inner join workorder w on gc.Workorderno = w.Workorderno
inner join Item_Master i on w.Item_Code = i.Item_Code";

                if (inputCase == "성형")
                {
                    sql += @" WHERE gv_group = '성형' and gv_status between '1' and '2' and g.Use_YN ='Y' AND GV_Rest_Qty > 0 and gc.workorderno = @workorderno  and gv_qty = Loading_Qty";
                }
                else if (inputCase == "건조")
                {
                    sql += @" WHERE gv_group = '건조' and gv_status between '1' and '2' and g.Use_YN ='Y' AND GV_Rest_Qty > 0 and gc.workorderno = @workorderno  and gv_qty = Loading_Qty";
                }
                else if (inputCase == "소성")
                {
                    sql += @" WHERE gv_group = '소성' and gv_status between '1' and '2' and g.Use_YN ='Y' AND GV_Rest_Qty > 0 and gc.workorderno = @workorderno  and gv_qty = Loading_Qty";
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    List<CartVO> list = Helper.DataReaderMapToList<CartVO>(cmd.ExecuteReader());
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
        /// <summary>
        /// 사용가능한 건조대차/소성대차 목록 조회
        /// </summary>
        /// <returns></returns>
        public List<CartVO> GetTargetCarList(string inputCase)
        {
            try
            {
                string sql = @"select gv_code, gv_name from gv_master";

                if (inputCase == "건조")
                {
                    sql += " where gv_group = '건조' and gv_status = '0' and Use_YN ='Y'";
                }
                else if (inputCase == "소성")
                {
                    sql += " where gv_group = '소성' and gv_status = '0' and Use_YN ='Y'";
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = sql;

                    List<CartVO> list = Helper.DataReaderMapToList<CartVO>(cmd.ExecuteReader());
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
    }
}
