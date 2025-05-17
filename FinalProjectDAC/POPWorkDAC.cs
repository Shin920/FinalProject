using ClassLibrary1;
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
    public class POPWorkDAC:IDisposable
    {
        SqlConnection conn;
        private static LoggingUtility log = new LoggingUtility("POPWorkDAC", Level.Debug, 30);

        public static LoggingUtility Log { get { return log; } }
        public POPWorkDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<CarListVO> GetLoadedCarList(string inputCase)
        {
            try
            {
                string sql = "";
                if(inputCase == "소성")
                {
                    sql = @"select Status_Seq, gv_name, gc.gv_code, gv_rest_qty , gc.workorderno , w.item_code, item_name, item_unit, Wo_Req_No, Req_Seq, wo_order, Line_Per_Qty
from GV_Current_Status  gc  join  gv_master gm on gm.GV_Code = gc.GV_Code
inner join WorkOrder w on gc.Workorderno = w.Workorderno
inner join item_master i on w.Item_Code = i.Item_Code
where gv_rest_qty > 0 and GV_Group = '건조' and Wo_Order = '3'
order by w.ins_date desc";
                }
                else if (inputCase == "포장")
                {
                    sql = @"select Status_Seq, gv_name, gc.gv_code, gv_rest_qty , gc.workorderno , w.item_code, item_name, item_unit, Wo_Req_No, Req_Seq, wo_order, Shot_Per_Qty
from GV_Current_Status  gc  join  gv_master gm on gm.GV_Code = gc.GV_Code
inner join WorkOrder w on gc.Workorderno = w.Workorderno
inner join item_master i on w.Item_Code = i.Item_Code
where gv_rest_qty > 0 and GV_Group = '소성' and Wo_Order = '4' and Wo_Status = 'WO_04'
order by w.ins_date desc";
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = sql;
                    List<CarListVO> list = Helper.DataReaderMapToList<CarListVO>(cmd.ExecuteReader());
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

        public int GetRemainQty(string workOrderNO)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select isnull(sum( prd_qty * in_qty) ,  0)
from Goods_In_History g inner join PALLETSIZE_MASTER p on g.Size_Code = p.size_code
where workorderno = @workOrderNO";
                    cmd.Parameters.AddWithValue("@workOrderNO", workOrderNO);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return -999;
            }
        }

        /// <summary>
        /// 작업지시번호에 대한 작업정보 가져오기
        /// </summary>
        /// <param name="workOrderNO"></param>
        /// <returns></returns>
        public POPWorkVO GetWorkOrderDetail(string workOrderNO)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //작업지시번호, 품목명, 작업지시일, 작업장, 실적수량, 단위
                    cmd.Connection = conn;
                    cmd.CommandText = @"select i.item_Code, workorderno, i.Item_Name, Plan_Date,  w.Wc_Code, i.Item_Unit,  w.Prd_Qty, Plan_Qty, wc_Name, in_qty_main
from WorkOrder w left outer join   Item_Master  i on w.Item_Code = i.Item_Code 
inner join WorkCenter_Master wc on w.Wc_Code = wc.Wc_Code
where w.Workorderno = @workNO
order by Plan_Date";
                    cmd.Parameters.AddWithValue("@workNO", workOrderNO);

                    List<POPWorkVO> list = Helper.DataReaderMapToList<POPWorkVO>(cmd.ExecuteReader());
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
        /// <summary>
        /// 기계 종료 버튼 클릭
        /// </summary>
        /// <param name="workOrderNO"></param>
        /// <param name="managerid"></param>
        /// <param name="goodQty"></param>
        /// <param name="badQty"></param>
        /// <returns></returns>
        public bool StopMachine(string workOrderNO, string managerid, int goodQty, int badQty)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;
                    //cmd.CommandText = @"update workorder set Wo_Status = 'WO_02', Wo_Order = '1', Prd_Endtime = getdate(), Bad_Prd_Qty += @Bad_Qty, Up_Date = getdate(), Up_Emp = @managerid where workorderno = @workorderno";
                    cmd.CommandText = @"update workorder set Wo_Status = 'WO_02', Wo_Order = '1', Prd_Endtime = getdate(), Prd_Qty += @Good_Qty,  Up_Date = getdate(), Up_Emp = @managerid where workorderno = @workorderno";
                    cmd.Parameters.AddWithValue("@workorderno", workOrderNO);
                    cmd.Parameters.AddWithValue("@Good_Qty", goodQty+ badQty);
                    cmd.Parameters.AddWithValue("@Bad_Qty", badQty);
                    cmd.Parameters.AddWithValue("@managerid", managerid);

                    int iRowAffect = cmd.ExecuteNonQuery();

                    cmd.CommandText = @"  update Emp_Allocation_History_Detail set Prd_Qty += @qty where user_id in (select ea.user_id 
  from Emp_Allocation_History ea inner join Emp_Allocation_History_Detail ed on ea.Ins_Date = ed.Ins_Date
  where workorderno = @workorderno and Release_datetime is null) ";
                    cmd.Parameters.AddWithValue("@qty", goodQty);

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
        
        /// <summary>
        /// 품질측정값 삭제
        /// </summary>
        /// <param name="inspect_measure_seq"></param>
        /// <returns></returns>
        public bool DeleteInspectValue(string inspect_measure_seq)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = @"delete from Inspect_Measure_History where Inspect_measure_seq = @Inspect_measure_seq";
                    cmd.Parameters.AddWithValue("@Inspect_measure_seq", inspect_measure_seq);

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
        /// 수량 받아오기
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public int GetPrdQty(string workorderno)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = @"select (good_prd_qty + BAD_PRD_QTY) QTY from workorder where workorderno = @workorderno";
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);

                    int prd_qty = Convert.ToInt32(cmd.ExecuteScalar());
                    return prd_qty;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return -999;
            }
        }

        /// <summary>
        /// 현장마감처리
        /// </summary>
        /// <param name="workorderno"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool SetClose(string workorderno, string managerid, string wc_code)
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

        /// <summary>
        /// 품질측정값업데이트
        /// </summary>
        /// <param name="inspect_measure_seq"></param>
        /// <param name="val"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool UpdateInspectValue(string inspect_measure_seq, string val, string managerid)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = @"update Inspect_Measure_History set Inspect_val = @Inspect_val, Up_Date = getdate(), Up_Emp = @managerid
where Inspect_measure_seq = @Inspect_measure_seq";
                    cmd.Parameters.AddWithValue("@Inspect_measure_seq", inspect_measure_seq);
                    cmd.Parameters.AddWithValue("@Inspect_val", val);
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
        /// <summary>
        /// 품질측정값등록
        /// </summary>
        /// <param name="qi"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool InsertInspectValue(POPQuailtyItemVO qi, string managerid)
        {
            try
            {
                //해당공정조건
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert Inspect_Measure_History (Item_code, Process_code, Inspect_code, Inspect_date, Inspect_datetime, Inspect_val, Workorderno, Ins_Date, Ins_Emp, Up_Date, Up_Emp)
values(@Item_code, @Process_code, @Inspect_code, convert(date,getdate()), getdate(), @Inspect_val, @Workorderno, getdate(), @managerid, getdate(), @managerid)";

                    cmd.Parameters.AddWithValue("@Item_code", qi.Item_code);
                    cmd.Parameters.AddWithValue("@Process_code", qi.Process_code);
                    cmd.Parameters.AddWithValue("@Inspect_code",qi.Inspect_code);
                    cmd.Parameters.AddWithValue("@Inspect_val", qi.Inspect_val);
                    cmd.Parameters.AddWithValue("@Workorderno", qi.Workorderno);
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
        /// <summary>
        /// 품질측정값 조회
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="processCdoe"></param>
        /// <param name="workOrderNO"></param>
        /// <returns></returns>
        public List<POPQuailtyItemVO> GetQualityInfo(string itemCode, string processCdoe, string workOrderNO)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select DISTINCT Inspect_measure_seq, im.Inspect_code, Inspect_datetime, Inspect_val
from Inspect_Measure_History im 
where im.Item_code = @Item_code  and im.Process_code= @Process_code and im.Workorderno = @Workorderno";
                    cmd.Parameters.AddWithValue("@Item_code", itemCode);
                    cmd.Parameters.AddWithValue("@Process_code", processCdoe);
                    cmd.Parameters.AddWithValue("@Workorderno", workOrderNO);
                    List<POPQuailtyItemVO> list = Helper.DataReaderMapToList<POPQuailtyItemVO>(cmd.ExecuteReader());
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
        /// 품질측정값 등록 목록 조회
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="wc_Code"></param>
        /// <returns></returns>
        public List<POPQualityCheckVO> GetQualityCheckList(string itemCode, string wc_Code)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    
                    cmd.CommandText = @"select DISTINCT inspect_code, inspect_name, USL, SL, LSL, Process_code
FROM Inspect_Spec_Master

where item_code = @item_code and process_code = (select process_code from workcenter_master where wc_code = @wc_code)";
                    cmd.Parameters.AddWithValue("@item_code", itemCode);
                    cmd.Parameters.AddWithValue("@wc_code", wc_Code);
                    List <POPQualityCheckVO> list = Helper.DataReaderMapToList<POPQualityCheckVO>(cmd.ExecuteReader());
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
        /// 작업지시상태를 03 (생산중단)로 바꿈
        /// </summary>
        /// <param name="workorderno"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool SetWostate03(string workorderno, string managerid, string inputcase, List<POPWorkerSetVO> list)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    int wo_order = 0;
                    if (inputcase == "성형") wo_order = 1;
                    else if (inputcase == "소성") wo_order = 4;
                    else if (inputcase == "포장") wo_order = 5;

                    cmd.Connection = conn;
                    cmd.CommandText = @"update workorder set Wo_Order = @wo_order,  Prd_endtime = getdate(), Up_Date = getdate(), up_emp = @managerid , Wo_Status = 'WO_03'
where workorderno = @workorderno";
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@wo_order", wo_order);
                    int iRowAffect = cmd.ExecuteNonQuery();

                    cmd.CommandText = @"
update Emp_Allocation_History_Detail set Prd_endtime = getdate(), Up_Date = getdate(), up_emp =@managerid
where workorderno = @workorderno and  user_id 
in ( select  e.User_ID
from Emp_Wc_Allocation e inner join  Emp_Allocation_History_Detail ed on e.ins_date = ed.ins_date
where Release_datetime is null and workorderno = @workorderno)";
                    iRowAffect += cmd.ExecuteNonQuery();


                    var seqlist = GetWorkSeq(list);
                    foreach (string workseq in seqlist)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = @"update Work_History set Work_EndTime = getdate(), Up_Date = getdate(), Up_Emp = @managerid, Work_Time = datediff(hour, (select Work_StartTime from Work_History where work_seq = @work_seq), getdate() )
where work_seq = @work_seq";
                        cmd.Parameters.AddWithValue("@work_seq", workseq);
                        cmd.Parameters.AddWithValue("@managerid", managerid);
                        iRowAffect += cmd.ExecuteNonQuery();

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

        public List<string> GetWorkSeq(List<POPWorkerSetVO> list)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    List<string> seqList = new List<string>();
                    cmd.Connection = conn;

                    cmd.CommandText = @"select work_seq from Work_History where user_id = @userid and Work_EndTime is null";
                    foreach (var worker in list)    
                    {
                        cmd.Parameters.AddWithValue("@userid", worker.User_ID);
        
                        if(cmd.ExecuteScalar()!= null)
                        {
                            seqList.Add(cmd.ExecuteScalar().ToString());
                        }
                        cmd.Parameters.Clear();
                    }

                    return seqList;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool StartMachine(string workOrderNo, string managerid, int prd_Qty, string gv_Code)
        {
            //직업순번 2번으로 변경, 작업시작시간 업데이트, 최종수정일자, 최종수정자 업데이트, Temp_Prd_Qty에 수량 등록
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_StartFormingWO";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@workorderno", workOrderNo);
                    cmd.Parameters.AddWithValue("@Temp_Prd_Qty", prd_Qty);
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@GV_CODE", gv_Code);
                   
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
        /// 작업시작버튼
        /// </summary>
        /// <param name="workOrderNo"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool OrderStart(string workOrderNo, string managerid, List<POPWorkerSetVO> list)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    
                    cmd.Connection = conn;
                    cmd.CommandText = @"update workorder set prd_Date = CONVERT(date,GETDATE()), Wo_Status = 'WO_02', Up_Date = getdate(), up_emp=@managerid , 
Prd_Starttime = case when (select Prd_Starttime from workorder where  workorderno = @workorderno) is null then getdate() else (select Prd_Starttime from workorder where  workorderno = @workorderno) end
where workorderno = @workorderno";
                    cmd.Parameters.AddWithValue("@workorderno", workOrderNo);
                    cmd.Parameters.AddWithValue("@managerid", managerid);

                    int iRowAffect = cmd.ExecuteNonQuery();

                    cmd.CommandText = @"update Emp_Allocation_History_Detail set Prd_Starttime = getdate(), Up_Date = getdate(), up_emp = @managerid
where workorderno = @workorderno and  Detail_Seq 
in ( select  Detail_Seq
from Emp_Wc_Allocation e inner join  Emp_Allocation_History_Detail ed on e.ins_date = ed.ins_date
where Release_datetime is null and workorderno = @workorderno)";
                    iRowAffect += cmd.ExecuteNonQuery();

                    foreach (var worker in list)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = @"insert Work_History (Work_Date, Process_Code, User_ID, Work_StartTime, Work_type, Ins_Date, Ins_Emp, Up_Date, Up_Emp)
values(getdate(), (select process_code from WorkCenter_Master wc inner join workorder w on wc.Wc_Code = w.Wc_Code where workorderno = @workorderno ), @userid, getdate(), 'WT_01', getdate(), @managerid, getdate(), @managerid)";
                        cmd.Parameters.AddWithValue("@userid", worker.User_ID);
                        cmd.Parameters.AddWithValue("@managerid", managerid);
                        cmd.Parameters.AddWithValue("@workorderno", workOrderNo);
                        iRowAffect += cmd.ExecuteNonQuery();
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
        /// 성형 작업지시 리스트 가져오기
        /// </summary>
        /// <returns></returns>
        public List<POPWorkVO> GetAllWorkODList(string Case)
        {
            string sql = @"
select u.Userdefine_Mi_Name, w.Workorderno,  Userdefine_Mi_Name, w.Item_Code, i.Item_Name, i.Item_Unit, w.Plan_Qty, w.Prd_Qty, w.Prd_Starttime, w.Prd_Endtime , wc_Code, wo_order, PrdQty_Per_Hour, Temp_Prd_Qty, (select top 1 gv_code from GV_Current_Status where Workorderno = w.Workorderno order by Ins_Date desc) gv_code,  (select top 1 hist_Seq from GV_History where Workorderno = w.Workorderno order by Ins_Date desc) hist_seq, bad_prd_qty, good_prd_qty

from WorkOrder w left outer join   Item_Master i on w.Item_Code = i.Item_Code
 left outer join Userdefine_Mi_Master u on w.Wo_Status = u.Userdefine_Mi_Code ";
            if(Case == "성형")
            {
                sql += @" where Wo_Order in(1,2,3,7) and wo_status in ('WO_01', 'WO_02', 'WO_03')";
            }
            else if(Case == "소성")
            {
                sql += @" where Wo_Order = 4 and wo_status in ('WO_01', 'WO_02', 'WO_03')";
            }
            else if(Case == "포장")
            {
                sql += @" where Wo_Order = 5 and wo_status in ('WO_01', 'WO_02', 'WO_03')";
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    //cmd.CommandText = "select * from temp_WorkOrder";
                    cmd.CommandText = sql;

                    List<POPWorkVO> list = Helper.DataReaderMapToList<POPWorkVO>(cmd.ExecuteReader());
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
