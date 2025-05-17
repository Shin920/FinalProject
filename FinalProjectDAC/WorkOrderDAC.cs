using ClassLibrary1;
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
    public class WorkOrderDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("WorkOrderDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public WorkOrderDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }


        public void Dispose()
        {
            conn.Close();
        }

        public List<WorkOrderVO> GetWorkOrderHistory(string begDate, string endDate)        //기간 내 실적조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Prd_Date, Workorderno, pm.Process_code, Process_Name, wo.Item_Code, Item_Name, Wc_Name, Wo_Order, In_Qty_Main, Out_Qty_Main, Prd_Qty,
				case wo.Wo_Status when 'WO_01' then '생산대기' 
				when 'WO_02' then '생산중'
				when 'WO_03' then '생산중지'
				when 'WO_04' then '현장마감'
				when 'WO_05' then '작업지시마감'
				else '' end Wo_Status
from WorkOrder wo inner join WorkCenter_Master wm on wm.Wc_Code = wo.Wc_Code
					inner join Item_Master im on wo.Item_Code = im.Item_Code
					inner join Process_Master pm on wm.Process_Code = pm.Process_code  
where Prd_Date between '" + begDate + "' and '" + endDate + "' order by Prd_Date desc";

                    return Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public bool UpdatePrdQty(string prdQty, string workOrderCode)        //실적보정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update WorkOrder set Prd_Qty = @prd_Qty where Workorderno = @Workorderno";

                    cmd.Parameters.AddWithValue("@prd_Qty", prdQty);
                    cmd.Parameters.AddWithValue("@Workorderno", workOrderCode);

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

        public List<WorkOrderVO> GetWorkOrderHistoryInPallete(string begDate, string endDate)        //팔레트 마감폼에서의 기간 내 실적조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Prd_Date, Workorderno, wo.Item_Code, Item_Name, Wc_Name, In_Qty_Main, Out_Qty_Main, Prd_Qty,
case wo.Wo_Status when 'WO_01' then '생산대기'
					when 'WO_02' then '생산중'
					when 'WO_03' then '생산중지'
					when 'WO_04' then '현장마감'
					when 'WO_05' then '작업지시마감'
					else '' end Wo_Status
from WorkOrder wo inner join WorkCenter_Master wm on wm.Wc_Code = wo.Wc_Code
					inner join Item_Master im on wo.Item_Code = im.Item_Code			
where Prd_Date between '" + begDate + "' and '" + endDate + "'";

                    return Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public bool SetWoOrder7(string workOrderNum)
        {
            string sql = @"
				update workorder set wo_order = '7' where workorderno = @workorderno
				";

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@workorderno", workOrderNum);

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

        public bool CreateWorkOrder(string newOrderno, string oldOrderno, string item_code, string wc_code, int qty, string unit, string managerid, string process_code, string date, int Status_Seq, string GV_Code, string inputCase)
        {
            try
            {
                int wo = 0;
                string perqty = "";
                if (inputCase == "소성")
                {
                    wo = 4;
                    perqty = "line_per_qty";


                }
                else if (inputCase == "포장")
                {
                    wo = 5;
                    perqty = "Shot_Per_Qty";
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert workorder ([Workorderno], [Item_Code], [Wc_Code], [Plan_Qty], [Plan_Unit], [Plan_Date], [Wo_Status], [Wo_Order], [In_Qty_Main],  [Prd_Unit], [Wo_Req_No], [Req_Seq], [Ins_Date], [Ins_Emp], [Up_Date], [Up_Emp], out_qty_Main)
values(@newWORKORDERNO, @item_code, @wc_code, FLOOR((@qty / (select " + perqty + " from Item_Master where item_code = @item_code))), @unit, @date, 'WO_01', @wo_order , @QTY, @unit, (select[Wo_Req_No] from workorder where Workorderno = @oldWORKORDERNO), (select[Req_Seq] from workorder where workorderno = @oldWORKORDERNO), getdate(), @managerid, getdate(), @managerid, FLOOR((@qty / (select " + perqty+" from Item_Master where item_code = @item_code)))); select top 1 workorderno from workorder order by Ins_Date desc";

                    cmd.Parameters.AddWithValue("@wo_order", wo);
                    cmd.Parameters.AddWithValue("@oldWORKORDERNO", oldOrderno);
                    cmd.Parameters.AddWithValue("@newWORKORDERNO", newOrderno);
                    cmd.Parameters.AddWithValue("@item_code", item_code);
                    cmd.Parameters.AddWithValue("@wc_code", wc_code);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@processcode", process_code);
                    cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(date));

                    string newWorkOrder = cmd.ExecuteScalar().ToString();
                    conn.Close();

                    if (newOrderno != "")
                    {
                        conn.Open();
                        string sql = @"SP_AfterCreateFiringOrder";
                        SqlCommand cmd1 = new SqlCommand(sql, conn);
                        cmd1.CommandText = sql;
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@item_code", item_code);
                        cmd1.Parameters.AddWithValue("@wc_code", wc_code);
                        cmd1.Parameters.AddWithValue("@qty", qty);
                        cmd1.Parameters.AddWithValue("@unit", unit);
                        cmd1.Parameters.AddWithValue("@managerid", managerid);
                        cmd1.Parameters.AddWithValue("@Status_Seq", Status_Seq);
                        cmd1.Parameters.AddWithValue("@GV_CODE", GV_Code);
                        cmd1.Parameters.AddWithValue("@newWorkOrder", newWorkOrder);
                        cmd1.Parameters.AddWithValue("@WORKORDERNO", oldOrderno);

                        int iRowAffect = cmd1.ExecuteNonQuery();
                        return (iRowAffect > 0);
                    }
                    return false;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public bool SetWoOrder3(string workorderno, string managerid)
        {
            string sql = @"if((select Plan_Qty from WorkOrder where workorderno = @workorderno ) = (select sum(gv_qty) from GV_Current_Status where workorderno =  @workorderno  and Unloading_date is null))
begin
				update workorder set wo_order = '3' , up_date = getdate(), Up_Emp = @managerid
				where workorderno = @workorderno
				end";

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    cmd.Parameters.AddWithValue("@managerid", managerid);

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

        public bool RegLoadPerformance(string workOrderNO, string managerid, int qty)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = @"update workorder set  Prd_Qty += @Qty, Up_Date = getdate(), Up_Emp = @managerid
where workorderno = @workorderno";

                    cmd.Parameters.AddWithValue("@workorderno", workOrderNO);
                    cmd.Parameters.AddWithValue("@Qty", qty);
                    cmd.Parameters.AddWithValue("@managerid", managerid);

                    int iRowAffect = cmd.ExecuteNonQuery();

                    cmd.CommandText = @"  update Emp_Allocation_History_Detail set Prd_Qty += @Qty where user_id in (select ea.user_id 
  from Emp_Allocation_History ea inner join Emp_Allocation_History_Detail ed on ea.Ins_Date = ed.Ins_Date
  where workorderno = @workorderno and Release_datetime is null) and workorderno = @workorderno";
                    iRowAffect += cmd.ExecuteNonQuery();

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

        public List<WorkOrderVO> GetDailyWorkOrder()        //메인화면 용 당일 작업진행중인 목록
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Workorderno, item_name , Wc_Name, process_name, Prd_Starttime, 
case w.Wo_Status when 'WO_01' then '생산대기'
				when 'WO_02' then '생산중'
				when 'WO_03' then '생산중지'
				when 'WO_04' then '현장마감'
				when 'WO_05' then '작업지시마감'
				else '' end Wo_Status , Plan_Date
from workorder w
inner join item_master i on w.Item_Code = i.Item_Code
	inner join WorkCenter_Master wm on w.Wc_Code = wm.Wc_Code
		inner join Process_Master pm on wm.Process_Code = pm.Process_code
where CONVERT(CHAR(10), plan_date, 23) =  convert(varchar(10),GETDATE(),121) and  w.Wo_Status not in ('WO_04', 'WO_05')";

                    return Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }
        public DataTable GetUserDailyWorkOrder(string userId)        //사용자의 당일 할당작업 목록
        {
            try
            {
                string sql = @"select DISTINCT hd.Workorderno, Allocation_date,  Wc_Name, Item_Name, Process_name
from Emp_Allocation_History ah inner join Emp_Allocation_History_Detail hd on ah.User_ID = hd.User_ID
								inner join WorkOrder w on w.Workorderno = hd.Workorderno
								inner join WorkCenter_Master wm on w.Wc_Code = wm.Wc_Code
								inner join Item_Master im on im.Item_Code = w.Item_Code
								inner join Process_Master pm on wm.Process_Code = pm.Process_code
where ah.User_ID = @User_ID and Allocation_date = CONVERT(CHAR(10), getdate(), 23)";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();

                    da.SelectCommand.Parameters.AddWithValue("@User_ID", userId);
                    da.Fill(dt);

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


        public List<WorkOrderVO> GetWorkOrderList()        // 작업지시 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Wo_Req_No, Userdefine_Mi_Name Wo_Status, Workorderno, Plan_Date, wo.Item_Code, Item_Name, WC_Name, Plan_Qty, In_Qty_Main, Out_Qty_Main, Prd_Qty, wo.Remark, Plan_Unit, Prd_Date, Prd_Starttime, Prd_Endtime
		                                from WorkOrder wo inner join Item_Master IM on wo.Item_Code = IM.Item_Code
						                                  inner join WorkCenter_Master wc on wo.Wc_Code = wc.Wc_Code
						                                  inner join Userdefine_Mi_Master um on wo.Wo_Status = um.Userdefine_Mi_Code";

                    return Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public List<WorkOrderVO> SearchWorkOrderList(string begDate, string endDate)        // 작업지시 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Wo_Req_No, Userdefine_Mi_Name Wo_Status, Workorderno, Plan_Date, wo.Item_Code, Item_Name, WC_Name, Plan_Qty, In_Qty_Main, Out_Qty_Main, Prd_Qty, wo.Remark, Plan_Unit, Prd_Date, Prd_Starttime, Prd_Endtime
		                                from WorkOrder wo inner join Item_Master IM on wo.Item_Code = IM.Item_Code
						                                  inner join WorkCenter_Master wc on wo.Wc_Code = wc.Wc_Code
						                                  inner join Userdefine_Mi_Master um on wo.Wo_Status = um.Userdefine_Mi_Code
                                                          where Plan_Date between '" + begDate + "' and '" + endDate + "'";

                    return Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }
        
        public bool InsertWorkOrder(string workReqNo, string woNo, string code, string wcode, int pqty, string punit, DateTime date, int rseq, string remark, string emp)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into WorkOrder (Workorderno, Item_Code, Wc_Code, Plan_Qty, In_Qty_Main, Out_Qty_Main, Plan_Unit, Plan_Date, Wo_Status, 
                                        Wo_Order, Wo_Req_No, Req_Seq, Remark, Ins_Date, Ins_Emp)
                        values (@Workorderno, @Item_Code, @Wc_Code, @Plan_Qty, @In_Qty_Main, @Out_Qty_Main, @Plan_Unit, @Plan_Date, @Wo_Status,
                                        @Wo_Order, @Wo_Req_No, @Req_Seq, @Remark, @Ins_Date, @Ins_Emp)";
                    cmd.Parameters.AddWithValue("@Wo_Req_No", workReqNo);
                    cmd.Parameters.AddWithValue("@Workorderno", woNo);
                    cmd.Parameters.AddWithValue("@Item_Code", code);
                    cmd.Parameters.AddWithValue("@Wc_Code", wcode);
                    cmd.Parameters.AddWithValue("@Plan_Qty", pqty);
                    cmd.Parameters.AddWithValue("@In_Qty_Main", pqty);
                    cmd.Parameters.AddWithValue("@Out_Qty_Main", pqty);
                    cmd.Parameters.AddWithValue("@Plan_Unit", punit);
                    cmd.Parameters.AddWithValue("@Plan_Date", date);
                    cmd.Parameters.AddWithValue("@Wo_Status", "WO_01");
                    cmd.Parameters.AddWithValue("@Wo_Order", 1);
                    cmd.Parameters.AddWithValue("@Req_Seq", rseq);
                    cmd.Parameters.AddWithValue("@Remark", remark);
                    cmd.Parameters.AddWithValue("@Ins_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Ins_Emp", emp);

                    int iRowAffect = cmd.ExecuteNonQuery();

                    cmd.CommandText = "update Wo_Req set Req_Status = 'RE_02' where Wo_Req_No = @Wo_Req_No";
                    iRowAffect += cmd.ExecuteNonQuery();
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

        public bool UpdateWorkOrder(WorkOrderVO no)       //작업지시 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update WorkOrder set Plan_Date = @Plan_Date, Plan_Qty = @Plan_Qty, Plan_Unit = @Plan_Unit, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Workorderno = @Workorderno";

                    cmd.Parameters.AddWithValue("@Plan_Date", no.Plan_Date);
                    cmd.Parameters.AddWithValue("@Plan_Qty", no.Plan_Qty);
                    cmd.Parameters.AddWithValue("@Plan_Unit", no.Plan_Unit);
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@Workorderno", no.Workorderno);


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

        public bool FinishWorkOrder(string code)       //작업지시 마감
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update WorkOrder set Wo_Status = 'WO_05' where Workorderno = @Workorderno";

                    cmd.Parameters.AddWithValue("@Workorderno", code);

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

        public bool SetClose(string workorderno, string managerid, string wc_code) // 마감시 실행
        {
            //수량등록을..여기서 할지 결정해야함.. 작업자별 실적 등록도 여기서?
            //작업자별은 기계 종료할때 생산한 수량 += 해야할듯
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = @"update workorder 
set Wo_Status = 'WO_04', Worker_CloseTime = GETDATE(), UP_DATE = GETDATE(), UP_EMP = @MANAGERID
WHERE WORKORDERNO = @WORKORDERNO";
                    cmd.Parameters.AddWithValue("@MANAGERID", managerid);
                    cmd.Parameters.AddWithValue("@WORKORDERNO", workorderno);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    int iRowAffect = 0;
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        conn.Open();
                        cmd1.Connection = conn;
                        cmd1.CommandText = @"SP_AfterClosingForming";
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd1.Parameters.AddWithValue("@WORKORDERNO", workorderno);
                        cmd1.Parameters.AddWithValue("@MANAGERID", managerid);
                        cmd1.Parameters.AddWithValue("@wc_code", wc_code);

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

        public bool CancelFinish(string code)       //작업 마감취소
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update WorkOrder set Wo_Status = 'WO_04' where Workorderno = @Workorderno";

                    cmd.Parameters.AddWithValue("@Workorderno", code);

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

        public DataTable GetbyTime()        //시간대별 생산현황
        {
            try
            {
                string sql = @"Select DATEPART(dd, Prd_date) A, count(Prd_Qty) B From WorkOrder
group by DATEPART(dd, Prd_date)
order by DATEPART(dd, Prd_date)

";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                                        
                    da.Fill(dt);

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

        public string GetUserID(string wcode)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"select User_ID from Emp_Wc_Allocation ew inner join WorkOrder wo on ew.Wc_Code = wo.Wc_Code
                                    where wo.Wc_Code = @wcode; ";
                cmd.Parameters.AddWithValue("@wcode", wcode);
                return cmd.ExecuteScalar().ToString();
            }

        }
    }
}