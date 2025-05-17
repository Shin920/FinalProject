using ClassLibrary1;
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
    public class UserDAC:IDisposable
    {
        SqlConnection conn;
        private static LoggingUtility log = new LoggingUtility("UserDAC", Level.Debug, 30);

        public static LoggingUtility Log { get { return log; } }
        public UserDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void  Dispose()
        {
            conn.Close();
        }
        public List<SearchLoginScreenHistoryVO> GetUser_Screen_Login(DateTime start, DateTime end, string screencode, string userid)// 기간별 사용자 화면 사용 로그인 내역
        {
            try
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = @"select User_Name, l.Session_ID, Type, Login_Date, Open_Date, um.User_id,  sm.Screen_Code,  lh.Ins_Date ,  lh.Up_Date 
 from Login_Screen_History lh inner join User_Master um on lh.User_id = um.User_id inner join ScreenItem_Master sm on lh.Screen_Code = sm.Screen_Code
 inner join Login_History l on lh.Session_ID = l.Session_ID
where user_id = @userid and Screen_Code = @screencode and Ins_Date =@start and Up_Date= @end ";
                    com.Parameters.AddWithValue("@User_ID", userid);
                    com.Parameters.AddWithValue("@start", start.ToShortDateString());
                    com.Parameters.AddWithValue("@end", end.ToShortDateString());
                    com.Parameters.AddWithValue("@Screen_Code", screencode);

                    com.Connection.Open();

                    SqlDataReader reader = com.ExecuteReader();
                    List<SearchLoginScreenHistoryVO> list = Helper.DataReaderMapToList<SearchLoginScreenHistoryVO>(reader);
                    com.Connection.Close();
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
            public bool InsertUser(UserInfoVO user)//유저저장
        {
            try
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = @"insert into User_Master (User_ID, User_Name, User_PW, Ins_Date, Ins_Emp) 
                        values (@User_ID, @User_Name, @User_PW, @Ins_Date, @Ins_Emp)";
                    com.Parameters.AddWithValue("@User_ID", user.User_ID);
                    com.Parameters.AddWithValue("@User_Name", user.User_Name);
                    com.Parameters.AddWithValue("@User_PW", user.User_PW);
                    com.Parameters.AddWithValue("@Ins_Date", user.Ins_Date);
                    com.Parameters.AddWithValue("@Ins_Emp", user.Ins_Emp);

                    com.Connection.Open();
                    int resault = Convert.ToInt32(com.ExecuteNonQuery());
                    com.Connection.Close();
                    return resault > 0;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return false;
            }
        }
        public bool DeleteUserInfoVO(string userid)// 사용자 삭제
        {
            try
            {
                string sql = "delete from User_Master where User_ID=@User_ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@User_ID", userid);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return false;
            }
        }

            public List<UserInfoVO> GetAllUser()// 유저전체목록
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select User_id, USER_NAME, Use_YN  from User_Master";
                  
                    List<UserInfoVO> list = Helper.DataReaderMapToList<UserInfoVO>(cmd.ExecuteReader());
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
            /// 로그인 체크
            /// </summary>
            /// <param name="id"></param>
            /// <param name="pw"></param>
            /// <returns>UserVO</returns>
            public UserVO GetUserIDName(string id, string pw)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select User_id, USER_NAME  from User_Master where user_id = @id and user_pw = @pw";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pw", pw);
                    List<UserVO> list = Helper.DataReaderMapToList<UserVO>(cmd.ExecuteReader());
                    return list[0];
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool UnAllocateWorkers(string worker, string managerid, string allocationdate, string hist_Seq, string detail_Seq, string wc_code)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_UNAllocateWorker";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", worker);
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@allocation_Datetime", Convert.ToDateTime(allocationdate));
                    cmd.Parameters.AddWithValue("@hist_seq", hist_Seq);
                    cmd.Parameters.AddWithValue("@Detail_Seq", detail_Seq);
                    cmd.Parameters.AddWithValue("@wc_code", wc_code);

                    int iRowAffected = cmd.ExecuteNonQuery();
                    return (iRowAffected > 0);
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
        /// 기계종료시에 작업자할당이력에 수량 등록
        /// </summary>
        /// <param name="workorderno"></param>
        /// <param name="goodqty"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool UpdateUserPrd(string workorderno, int goodqty, string managerid)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"update Emp_Allocation_History_Detail set prd_qty += @Good_Qty , prd_endtime = getdate(), up_date= getdate(), up_emp = @managerid
where workorderno = @workorderno and user_id 
in ( select  e.User_ID
from Emp_Wc_Allocation e inner join  Emp_Allocation_History_Detail ed on e.ins_date = ed.ins_date
where Release_datetime is null and workorderno = @workorderno)";
                    cmd.Parameters.AddWithValue("@Good_Qty", goodqty);
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);

                    int iRowAffected = cmd.ExecuteNonQuery();
                    return (iRowAffected > 0);
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool UnAllocateWorkers(List<UnAllocateVO> list, string managerid, string wc_code)
        {
            try
            {
                int iRowAffected = 0;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_UNAllocateWorker";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    for (int i = 0; i < list.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@userid", list[i].User_ID);
                        cmd.Parameters.AddWithValue("@managerid", managerid);
                        cmd.Parameters.AddWithValue("@allocation_Datetime", list[i].Allocation_date);
                        cmd.Parameters.AddWithValue("@hist_seq", list[i].hist_seq);
                        cmd.Parameters.AddWithValue("@Detail_Seq", list[i].Detail_Seq);
                        cmd.Parameters.AddWithValue("@wc_code", wc_code);
                        iRowAffected += cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    return (iRowAffected > 0);
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
        /// 작업자할당
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="manager"></param>
        /// <param name="workOrderNo"></param>
        /// <returns></returns>
        public bool SetWorker(string worker, string manager, string workOrderNo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_SetWorkers";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User_ID", worker);
                    cmd.Parameters.AddWithValue("@managerid", manager);
                    cmd.Parameters.AddWithValue("@workno", workOrderNo);

                    int iRowAffected = cmd.ExecuteNonQuery();
                    return (iRowAffected > 0);
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
        /// 특정 작업지시에 할당되어있는 작업자 조회
        /// </summary>
        /// <param name="workNO"></param>
        /// <returns></returns>
        public List<POPWorkerSetVO> GetAllocatedWorkers(string wcCode, string workNO)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"	  select ew.user_id, user_name, wc_Code, Workorderno, e.Allocation_datetime, Allocation_date, hist_seq, detail_Seq
					from Emp_Wc_Allocation ew inner join Emp_Allocation_History e on ew.Allocation_datetime = e.Allocation_datetime
					    
					inner join Emp_Allocation_History_Detail ed on e.User_ID = ed.User_ID and e.Ins_Date = ed.Ins_Date
						inner join User_Master u on ew.User_ID = u.User_ID
					where Wc_Code = @wc_code and Workorderno = @workno and ew.Release_datetime is null  ";

                    //                    cmd.CommandText = @"select wc_Code, user_id, allocation_datetime, release_Datetime
                    //from Emp_Wc_Allocation
                    //where wc_Code = @wc_Code and Release_datetime is null";
                    cmd.Parameters.AddWithValue("@wc_code", wcCode);
                    cmd.Parameters.AddWithValue("@workno", workNO);
                    List<POPWorkerSetVO> list = Helper.DataReaderMapToList<POPWorkerSetVO>(cmd.ExecuteReader());
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
        /// 할당 가능한 모든 작업자 조회
        /// </summary>
        /// <param name="workOrderNo"></param>
        /// <returns></returns>
        public List<POPWorkerSetVO> GetCanAllocateWorkers(string wcCode, string workOrderNo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    //예약하지 않는 경우(작업 시작시에 할당하는 경우의 작업자 목록(소성하고 포장의 경우 계획시작,종료 시간이 없어서..)
                    cmd.CommandText = @"-- 만약 그냥 작업시작시에 할당하고 바로 해제한다면(예약x), 최신 데이터에서 release_datetime이 null이 아닌것
	with temptbl 
	as(
	-- 할당되어있는 직원
	select User_ID , max(Allocation_datetime) Allocation_datetime
	from Emp_Wc_Allocation
	where Release_datetime is null
	group by User_ID 
	), tempnotnull
	as(	select User_ID , max(Allocation_datetime) Allocation_datetime
	from Emp_Wc_Allocation
	where Release_datetime is not null
	group by User_ID )
	

	select ew.User_ID, user_name,ew.Allocation_datetime, Release_datetime , ed.Workorderno ,wo.Plan_Starttime, wo.[Plan_Endtime], wo.Wc_Code
	from Emp_Wc_Allocation ew
	inner join [dbo].[Emp_Allocation_History_Detail] ed on ew.User_ID = ed.User_ID and ew.Ins_Date = ed.Ins_Date
	inner join [dbo].[WorkOrder] wo on ed.Workorderno = wo.Workorderno
	right outer join User_Master u on ew.User_ID = u.User_ID
	--inner join temptbl t on ew.User_ID = t.User_ID

	where Release_datetime is not null and ew.User_ID not in (select user_id from temptbl)
	and ew.Allocation_datetime = (select Allocation_datetime from tempnotnull where user_id =ew.User_ID)

	-- 할당된적 없는 직원
	union

	  select  u.User_ID, user_name, Allocation_date, Release_datetime, null [Workorderno], null Plan_Starttime, null [Plan_Endtime], null Wc_Code
	  from Emp_Allocation_History e right outer join User_Master u on e.User_ID = u.User_ID
	  where Allocation_date is null
";
                    
                    #region 사이시간에 할당되어있지 않은 작업자 목록
//                    cmd.CommandText = @"--이미 할당되어있는 직원, 작업지시번호 조회, 계획종료시간 조회 해서 계획 종료시간이 현재 작업지시 계획시간보다 빨리 끝나는 경우
//with temptbl as
//(
//-- 해당 작업지시 계획 일자에 해당하는 할당내역 조회
//SELECT ROW_NUMBER() over (order by allocation_date desc) number, e.user_id, Allocation_date, Release_datetime, w.Workorderno, w.Plan_Date, Plan_Starttime, Plan_Endtime, wc_code

//FROM [dbo].[Emp_Allocation_History] e
//inner join Emp_Allocation_History_Detail ed on e.User_ID = ed.User_ID and e.Ins_Date = ed.Ins_Date
//inner join WorkOrder w on ed.Workorderno = w.Workorderno
//where Plan_Date = (select plan_date from WorkOrder where Workorderno = @workno)              
//and  w.Workorderno <> @workno

//) , temp1 as
//(
//select * from temptbl where number in (select max(number) from temptbl group by user_id)
//)
//-- 해당 작업지시의 시작 시간에 할당되어 있지 않은 직원들 조회 
//-- 1) 하고있는 작업이 해당 작업 시작 전에 끝나는경우
//-- 2) 해당 작업 종료 시간이 예정된 작업 시작시간 이전에 끝나는 경우


//select t.user_id, t.Allocation_date, t.Release_datetime, t.Workorderno, t.Plan_Starttime, t.Plan_Endtime, t.wc_code
//from temp1 t 
//inner join [dbo].[Emp_Allocation_History] e on t.User_ID = e.User_ID and t.Allocation_date = e.Allocation_date
//inner join [dbo].[Emp_Allocation_History_Detail] ed on t.User_ID = ed.User_ID and ed.Ins_Date = e.Ins_Date
//inner join [dbo].[WorkOrder] wo on ed.Workorderno = wo.Workorderno
//where  t.Release_datetime is null 
//and ed.Workorderno <> @workno
//and t.user_id not in (select ew.user_id from Emp_Wc_Allocation ew inner join Emp_Allocation_History e on ew.Allocation_datetime = e.Allocation_datetime
					
//					inner join Emp_Allocation_History_Detail ed on e.User_ID = ed.User_ID and e.Ins_Date = ed.Ins_Date
//					where Wc_Code = @wc_Code and Workorderno = @workno and ew.Release_datetime is null )
//and t.[Plan_Endtime] < (select Plan_Starttime from WorkOrder where Workorderno =  @workno)
//and t.Plan_Starttime > (select Plan_Endtime from WorkOrder where Workorderno = @workno)
//and number in(select max(number) from temptbl group by user_id)

//-- 할당되어있지 않은 직원
//-- 해당 일자로 조회해서 해당 일자에 데이터가 없는 직원의 목록 출력
//-- 작업장 할당 이력
//--select *from Emp_Wc_Allocation

//union

//select ew.User_ID, Allocation_datetime, Release_datetime , ed.Workorderno ,wo.Plan_Starttime, wo.[Plan_Endtime], wo.Wc_Code
//from Emp_Wc_Allocation ew
//inner join [dbo].[Emp_Allocation_History_Detail] ed on ew.User_ID = ed.User_ID and ew.Ins_Date = ed.Ins_Date
//inner join [dbo].[WorkOrder] wo on ed.Workorderno = wo.Workorderno
//where convert(date,Release_datetime) <= (select plan_date from workorder where workorderno = @workno)
//and ew.User_ID not in (select user_id from Emp_Wc_Allocation where Release_datetime is null)

//-- 할당된적 없는 직원
//union

//  select  u.User_ID,  Allocation_date, Release_datetime, null [Workorderno], null Plan_Starttime, null [Plan_Endtime], null Wc_Code
//  from Emp_Allocation_History e right outer join User_Master u on e.User_ID = u.User_ID
//  where Allocation_date is null";
                    #endregion
                    cmd.Parameters.AddWithValue("@workno", workOrderNo);
                    cmd.Parameters.AddWithValue("@wc_Code", wcCode);
                    List<POPWorkerSetVO> list = Helper.DataReaderMapToList<POPWorkerSetVO>(cmd.ExecuteReader());
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
