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
    public class ProcessDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("ProcessDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public ProcessDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<ProcessVO> GetProcessList()      //공정정보 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Process_code, Process_name, Remark, Use_YN, Ins_Date from Process_Master";

                    List<ProcessVO> list = Helper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());

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

        public bool InsertProcess(string code, string name, string remark, string emp)       //공정정보 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into Process_Master (Process_code, Process_name, Remark, Ins_Date, Ins_Emp) values (@Process_code, @Process_name, @Remark, @Ins_Date, @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Process_code", code);
                    cmd.Parameters.AddWithValue("@Process_name", name);
                    cmd.Parameters.AddWithValue("@Remark", remark);
                    cmd.Parameters.AddWithValue("@Ins_Emp", emp);
                    cmd.Parameters.AddWithValue("@Ins_Date", DateTime.Now);


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
        public bool DeleteProcess(string code)       //공정정보 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Process_Master where Process_code = @Process_code";

                    cmd.Parameters.AddWithValue("@Process_code", code);

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

        public bool UpdateProcess(ProcessVO no)       //공정정보 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Process_Master set Process_name = @Process_name, Remark = @Remark, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Process_code = @Process_code";

                    cmd.Parameters.AddWithValue("@Process_name", no.Process_name);
                    cmd.Parameters.AddWithValue("@Remark", no.Remark);
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@Process_code", no.Process_code);

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


                    cmd.CommandText = "update Process_Master set Use_YN = @Use_YN where Process_code = @Process_code";
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
        public List<ProcessVO> GetProcessSmallList()      //공정정보의 코드와 이름목록만 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Process_code, Process_name from Process_Master";

                    List<ProcessVO> list = Helper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());

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

        public List<ProcessVO> GetProcessConditionList()      //품목들의 공정조건의 설정값을 가져온다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Item_Code, Wc_Code, Condition_Code, Condition_Name, Spec_Desc, SL, USL, LSL, Condition_Unit, Remark
from Condition_Spec_Master";


                    List<ProcessVO> list = Helper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());

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
        public bool UpdateProcCondition(ProcessVO pc)    //공정조건 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;


                    cmd.CommandText = @"update Condition_Spec_Master set Condition_Name = @Condition_Name, SL = @SL, USL = @USL, LSL = @LSL, 
Condition_Unit = @Condition_Unit, Remark = @Remark, Up_Date = getdate(), Up_Emp = @Up_Emp
where Item_Code = @Item_Code and Wc_Code = @Wc_Code and Condition_Code = @Condition_Code";

                    cmd.Parameters.AddWithValue("@Condition_Name", pc.Condition_Name);
                    cmd.Parameters.AddWithValue("@SL", pc.SL);
                    cmd.Parameters.AddWithValue("@USL", pc.USL);
                    cmd.Parameters.AddWithValue("@LSL", pc.LSL);
                    cmd.Parameters.AddWithValue("@Condition_Unit", pc.Condition_Unit);
                    cmd.Parameters.AddWithValue("@Remark", pc.Remark);
                    cmd.Parameters.AddWithValue("@Up_Emp", pc.Up_Emp);
                    cmd.Parameters.AddWithValue("@Item_Code", pc.Item_Code);
                    cmd.Parameters.AddWithValue("@Wc_Code", pc.Wc_Code);
                    cmd.Parameters.AddWithValue("@Condition_Code", pc.Condition_Code);



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

        public bool DeleteProcCondition(ProcessVO pc)    //공정조건 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;


                    cmd.CommandText = "delete from Condition_Spec_Master where Item_Code = @Item_Code and Wc_Code = @Wc_Code and Condition_Code = @Condition_Code";

                    cmd.Parameters.AddWithValue("@Item_Code", pc.Item_Code);
                    cmd.Parameters.AddWithValue("@Wc_Code", pc.Wc_Code);
                    cmd.Parameters.AddWithValue("@Condition_Code", pc.Condition_Code);


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

        public bool InsertProcCondition(ProcessVO pc)    //공정조건 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;


                    cmd.CommandText = @"insert into Condition_Spec_Master (Item_Code, Wc_Code, Condition_Code, Condition_Name, SL, USL, LSL, Condition_Unit, Remark, Ins_Date, Ins_Emp) 
values (@Item_Code, @Wc_Code, @Condition_Code, @Condition_Name, @SL, @USL, @LSL, @Condition_Unit,  @Remark, getdate(), @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Item_Code", pc.Item_Code);
                    cmd.Parameters.AddWithValue("@Wc_Code", pc.Wc_Code);
                    cmd.Parameters.AddWithValue("@Condition_Code", pc.Condition_Code);
                    cmd.Parameters.AddWithValue("@Condition_Name", pc.Condition_Name);
                    //cmd.Parameters.AddWithValue("@Spec_Desc", pc.Spec_Desc);
                    cmd.Parameters.AddWithValue("@SL", pc.SL);
                    cmd.Parameters.AddWithValue("@USL", pc.USL);
                    cmd.Parameters.AddWithValue("@LSL", pc.LSL);
                    cmd.Parameters.AddWithValue("@Condition_Unit", pc.Condition_Unit);
                    //cmd.Parameters.AddWithValue("@Condition_Group", pc.Condition_Group);
                    cmd.Parameters.AddWithValue("@Remark", pc.Remark);
                    cmd.Parameters.AddWithValue("@Ins_Emp", pc.Ins_Emp);

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

        public int CopyProcCondition(List<ProcessVO> list)   //복사한 규격들을 품목에 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Condition_Spec_Master (Item_Code, Wc_Code, Condition_Code, Condition_Name, Spec_Desc, SL, USL, LSL, Condition_Unit, Condition_Group, Remark, Ins_Date, Ins_Emp)
select @New_Item_Code, Wc_Code, Condition_Code, Condition_Name, Spec_Desc, SL, USL, LSL, Condition_Unit, Condition_Group, Remark, getdate(), @Ins_Emp
from Condition_Spec_Master where Item_Code = @Item_Code and Wc_Code = @Wc_Code and Condition_Code = @Condition_Code";

                    int cnt = 0;
                    cmd.Parameters.Add("@New_Item_Code", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Ins_Emp", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Item_Code", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Wc_Code", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Condition_Code", System.Data.SqlDbType.NVarChar);
                    foreach (ProcessVO sv in list)
                    {

                        cmd.Parameters["@New_Item_Code"].Value = sv.New_Item_Code;
                        cmd.Parameters["@Ins_Emp"].Value = sv.Ins_Emp;
                        cmd.Parameters["@Item_Code"].Value = sv.Item_Code;
                        cmd.Parameters["@Wc_Code"].Value = sv.Wc_Code;
                        cmd.Parameters["@Condition_Code"].Value = sv.Condition_Code;

                        cnt += cmd.ExecuteNonQuery();
                    }


                    return cnt;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");

            }
        }
        public List<ProcessVO> GetNotClearWorkOrderList(string begDate, string endDate)      //관리자마감하지않은 작업지시의 목록을 가져온다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select wo.Workorderno, wo.Item_Code, Item_Name ,wm.Process_Code, Process_Name, wo.Wc_Code, Wc_Name, Prd_Date, Prd_Qty
from WorkOrder wo 	inner join WorkCenter_Master wm on wo.Wc_Code = wm.Wc_Code
					inner join Process_Master pm on pm.Process_code = wm.Process_Code
					inner join Item_Master im on im.Item_Code = wo.Item_Code
where Manager_CloseTime is null and Prd_Date between '" + begDate + "' and '" + endDate + "' order by Prd_Date desc";


                    List<ProcessVO> list = Helper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());

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

        public List<ProcessVO> GetConditionSpecList(string itemCode, string wcCode)      //작업지시 품목의 공정기본값 목록을 가져온다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Condition_Name, Condition_Code, SL from Condition_Spec_Master where Item_Code = @Item_Code and Wc_Code = @Wc_Code";
                    cmd.Parameters.AddWithValue("@Item_Code", itemCode);
                    cmd.Parameters.AddWithValue("@Wc_Code", wcCode);

                    List<ProcessVO> list = Helper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());

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
        public bool InsertNewConditionValue(ProcessVO pc)    //공정조건 값 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;


                    cmd.CommandText = @"insert into Condition_Measure_History 
(Item_code, Wc_Code, Condition_Code, Condition_Date, Condition_Datetime, Condition_Val, Workorderno, Ins_Date, Ins_Emp)
values (@Item_code, @Wc_Code, @Condition_Code, GETDATE(), GETDATE(), @Condition_Val, @Workorderno, GETDATE(), @Ins_Emp)";


                    cmd.Parameters.AddWithValue("@Item_Code", pc.Item_Code);
                    cmd.Parameters.AddWithValue("@Wc_Code", pc.Wc_Code);
                    cmd.Parameters.AddWithValue("@Condition_Code", pc.Condition_Code);
                    cmd.Parameters.AddWithValue("@Condition_Val", pc.Condition_Val);
                    cmd.Parameters.AddWithValue("@Workorderno", pc.Workorderno);
                    cmd.Parameters.AddWithValue("@Ins_Emp", pc.Ins_Emp);


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

        public DataTable GetConditionValue(string workOrderNum, string conditionCode)      //공정조건값 추가한 목록을 가져온다
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SP_ConditionValue2";

                using (SqlDataAdapter da = new SqlDataAdapter(sql,conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@P_WorkOrderNum", workOrderNum);
                    da.SelectCommand.Parameters.AddWithValue("@P_Condition_Code", conditionCode);

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
        public bool DeleteConditionValue(int rownNum,string workOrderNum)    //공정조건 값 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @" delete from Condition_Measure_History where Condition_measure_seq = (
 select Condition_measure_seq from (select ROW_NUMBER() OVER(order by Condition_measure_seq) rowNum ,Condition_measure_seq from Condition_Measure_History 
 where Workorderno = @WorkOrderNum) A where rowNum = @rowNum)";

                    cmd.Parameters.AddWithValue("@rowNum", rownNum);
                    cmd.Parameters.AddWithValue("@WorkOrderNum", workOrderNum);

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

        public List<ProcessVO> GetFinishedConditionValue(string begDate, string endDate)      //마감된 작업지시의 공정조건 측정값에 대한 목록
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"
select w.Workorderno, cs.Item_Code, item_Name, Prd_Date, cs.Wc_Code, w.Wo_Status, Wc_Name, wm.Process_Code, Process_Name, cs.Condition_Code, Condition_Unit, Condition_Name, SL, USL, LSL ,count(Condition_Val) cntConVal, AVG(Condition_Val) avgConVal, Condition_Date
from Condition_Spec_Master cs inner join WorkOrder w on cs.Item_Code = w.Item_Code and cs.Wc_Code = w.Wc_Code
								inner join WorkCenter_Master wm on w.Wc_Code = wm.Wc_Code
								inner join Process_Master pm on wm.Process_Code = pm.Process_code
								left outer join Condition_Measure_History mh on cs.Condition_Code = mh.Condition_Code and w.Item_Code = mh.Item_code
					and w.Wc_Code = mh.Wc_Code and w.Workorderno = mh.Workorderno
					inner join Item_Master im on cs.Item_Code = im.Item_Code
					where w.Wo_Status in ('WO_05', 'WO_04') and  Prd_Date between '" + begDate+"' and '"+endDate+ "' group by w.Workorderno, cs.Item_Code, item_Name, cs.Wc_Code, Wc_Name, wm.Process_Code, Process_Name, Prd_Date, w.Wo_Status,cs.Condition_Code , Condition_Unit, Condition_Name, SL, USL, LSL, Condition_Date order by Prd_Date desc";

                    
                    List<ProcessVO> list = Helper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());

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

        public List<ProcessVO> GetConditionList()       //등록한 공정조건들의 목록
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select distinct Condition_Code, Condition_Name from Condition_Spec_Master";


                    List<ProcessVO> list = Helper.DataReaderMapToList<ProcessVO>(cmd.ExecuteReader());

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
