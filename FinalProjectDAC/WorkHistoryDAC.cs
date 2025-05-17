using FinalProjectVO;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDAC
{
    public class WorkHistoryDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("WorkHistoryDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public WorkHistoryDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<WorkHistoryVO_Simple> GetWorkHistory(string begDate, string endDate)       //근무자들의 근무이력
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Work_Date, Wc_Name, User_Name, Work_StartTime, Work_EndTime, Work_Time, wh.User_ID
from Work_History wh inner join Emp_Allocation_History_Detail hd on wh.User_ID = hd.User_ID
						inner join WorkOrder wo on wo.Workorderno = hd.Workorderno
						inner join WorkCenter_Master wm on wo.Wc_Code = wm.Wc_Code
						inner join User_Master um on wh.User_ID = um.User_ID
where Work_Date between '" + begDate+"' and '"+endDate+"'";

                    List<WorkHistoryVO_Simple> list = Helper.DataReaderMapToList<WorkHistoryVO_Simple>(cmd.ExecuteReader());

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
        public List<UserVO> GetUserSmallList()       //근무자ID와 근무자명 목록만 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select User_ID, User_Name from User_Master";

                    List<UserVO> list = Helper.DataReaderMapToList<UserVO>(cmd.ExecuteReader());

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

        public DataTable GetWorkerHistoryPivot(string begDate, string endDate)       //근무자의 일별 근무정보 조회(Pivot)
        {
            try
            {
                
                DataTable dt = new DataTable();
                string sql = "SP_WorkHistory2";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@P_begDate", begDate);
                    da.SelectCommand.Parameters.AddWithValue("@P_endDate", endDate);

                    da.Fill(dt);

                    //List<WorkHistoryVO> list = Helper.DataTableMapToList<WorkHistoryVO>(dt);
                    return dt;
                }
             
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }
        public List<WorkHistoryVO> GetWorkerDetailHistory(string prdDate, string userID)       //특정 근무자의 일자별 상세근무내역
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select wo.Workorderno, User_Name, wo.Item_Code, Item_Name, wo.Wc_Code ,Wc_Name, Prd_Date, wo.Prd_Starttime, wo.Prd_Endtime, wo.Prd_Qty,
case wo.Wo_Status when 'WO_01' then '생산대기'
			when 'WO_02' then '생산중'
			when 'WO_03' then '생산중지'
			when 'WO_04' then '현장마감'
			when 'WO_05' then '작업지시마감'
			else '' end Wo_Status
from WorkOrder wo inner join Emp_Allocation_History_Detail hd on wo.Workorderno = hd.Workorderno
					inner join User_Master um on hd.User_ID = um.User_ID
					inner join WorkCenter_Master wm on wo.Wc_Code = wm.Wc_Code
					inner join Item_Master im on wo.Item_Code = im.Item_Code					 
where Prd_Date = @Prd_Date and hd.User_ID = @User_ID";

                    cmd.Parameters.AddWithValue("@Prd_Date", prdDate);
                    cmd.Parameters.AddWithValue("@User_ID", userID);

                    List<WorkHistoryVO> list = Helper.DataReaderMapToList<WorkHistoryVO>(cmd.ExecuteReader());

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
