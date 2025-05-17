using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using FinalProjectVO;
using log4net.Core;
using System.Data;

namespace FinalProjectDAC
{
    public class SpecificationDAC : IDisposable
    {
        SqlConnection conn;
        private static LoggingUtility log = new LoggingUtility("SpecificationDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public SpecificationDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }

        public List<SpecificationVO> GetProductList()   //품목리스트에서 품목명과 품목코드 리스트만 가져온다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Item_Code, Item_Name from Item_Master";

                    List<SpecificationVO> list = Helper.DataReaderMapToList<SpecificationVO>(cmd.ExecuteReader());

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
        public void Dispose()
        {
            conn.Close();
        }

        public List<SpecificationVO> GetSpecList()   //모든 품질규격을 가져온다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select ism.Item_Code, ISM.Process_code, Process_name ,Inspect_code, Inspect_name, USL, SL, LSL, Sample_size, Inspect_Unit, ism.Use_YN, ism.Remark
from Inspect_Spec_Master ISM inner join Process_Master PM on ISM.Process_code = PM.Process_code";


                    List<SpecificationVO> list = Helper.DataReaderMapToList<SpecificationVO>(cmd.ExecuteReader());

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

        public int CopySpec(List<SpecificationVO> list)   //복사한 규격들을 품목에 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //이게 foreach 돌면서 파라미터를 주고 실행시키는데 clear로 파라미터 클리어하고 addWithValue말고 Add로 했던 방식이 있는데 그걸로 해야하는거같은데
                    //기억이 안난다. 찾아보기
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Inspect_Spec_Master (Item_Code, Process_code, Inspect_code, Inspect_name, Spec_Desc, USL, SL, LSL, Sample_size, Inspect_Unit, Use_YN, Remark, Ins_Date, Ins_Emp)
select @New_Item_Code, Process_code, Inspect_code, Inspect_name, Spec_Desc, USL, SL, LSL, Sample_size, Inspect_Unit, Use_YN, 
	Remark , getdate(), @Ins_Emp from Inspect_Spec_Master
	where Item_Code = @Item_Code and Process_code = @Process_code and Inspect_code = @Inspect_code";

                    int cnt = 0;
                    cmd.Parameters.Add("@New_Item_Code", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Ins_Emp", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Item_Code", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Process_code", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Inspect_code", System.Data.SqlDbType.NVarChar);
                    //cmd.Parameters.Add("@New_Inspect_code", System.Data.SqlDbType.NVarChar);
                    foreach (SpecificationVO sv in list)
                    {

                        cmd.Parameters["@New_Item_Code"].Value = sv.New_Item_Code;
                        cmd.Parameters["@Ins_Emp"].Value = sv.Ins_Emp;
                        cmd.Parameters["@Item_Code"].Value = sv.Item_Code;
                        cmd.Parameters["@Process_code"].Value = sv.Process_code;
                        cmd.Parameters["@Inspect_code"].Value = sv.Inspect_code;
                        //cmd.Parameters["@New_Inspect_code"].Value = sv.New_Inspect_code;

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

        public bool InsertNewSpec(SpecificationVO sv)     //새 품질규격을 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Inspect_Spec_Master (Item_Code, Process_code, Inspect_code, Inspect_name, Spec_Desc, USL, SL, LSL, Sample_size, Inspect_Unit, Remark, Ins_Date, Ins_Emp) 
values (@Item_Code, @Process_code, @Inspect_code, @Inspect_name, @Spec_Desc, @USL, @SL, @LSL, @Sample_size, @Inspect_Unit, @Remark, getdate(), @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Item_Code", sv.Item_Code);
                    cmd.Parameters.AddWithValue("@Process_code", sv.Process_code);
                    cmd.Parameters.AddWithValue("@Inspect_code", sv.Inspect_code);
                    cmd.Parameters.AddWithValue("@Inspect_name", sv.Inspect_name);
                    cmd.Parameters.AddWithValue("@Spec_Desc", sv.Spec_Desc);
                    cmd.Parameters.AddWithValue("@USL", sv.USL);
                    cmd.Parameters.AddWithValue("@SL", sv.SL);
                    cmd.Parameters.AddWithValue("@LSL", sv.LSL);
                    cmd.Parameters.AddWithValue("@Sample_size", sv.Sample_size);
                    cmd.Parameters.AddWithValue("@Inspect_Unit", sv.Inspect_Unit);
                    cmd.Parameters.AddWithValue("@Remark", sv.Remark);
                    cmd.Parameters.AddWithValue("@Ins_Emp", sv.Ins_Emp);

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

        public bool DeleteSpec(SpecificationVO sv)   //품질규격 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"delete from Inspect_Spec_Master where Item_Code = @Item_Code and Process_code = @Process_code and Inspect_code = @Inspect_code";

                    cmd.Parameters.AddWithValue("@Item_Code", sv.Item_Code);
                    cmd.Parameters.AddWithValue("@Process_code", sv.Process_code);
                    cmd.Parameters.AddWithValue("@Inspect_code", sv.Inspect_code);

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
        public List<SpecificationVO> GetInspectionList()   //등록된 품질규격 목록을 가져온다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select distinct Inspect_code,Inspect_name from Inspect_Spec_Master";


                    List<SpecificationVO> list = Helper.DataReaderMapToList<SpecificationVO>(cmd.ExecuteReader());

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

        public List<SpecificationVO> GetFinishedInspectionList(string begDate, string endDate)   //측정한 품질규격값에 대한 목록
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Inspect_measure_seq, mh.Item_code, Item_Name, mh.Process_code, Process_Name, Wc_Name, mh.Inspect_code, Prd_Date, Inspect_date, Inspect_name, USL, SL, LSL, COUNT(Inspect_val) cntVal, AVG(Inspect_val) avgVal, mh.Workorderno
from Inspect_Measure_History mh inner join Inspect_Spec_Master sm on mh.Item_code = sm.Item_Code 
and mh.Process_code = sm.Process_code and mh.Inspect_code = sm.Inspect_code
				inner join WorkOrder w on mh.Workorderno = w.Workorderno
				inner join Process_Master pm on mh.Process_code = pm.Process_code
				inner join WorkCenter_Master wm on w.Wc_Code = wm.Wc_Code
				inner join Item_Master im on mh.Item_code = im.Item_Code
				where w.Wo_Status in ('WO_04','WO_05') and Prd_Date between '" + begDate+"' and '"+endDate+ "' group by Inspect_measure_seq, mh.Item_code, Item_Name, mh.Process_code, Process_Name, Wc_Name, mh.Inspect_code, Prd_Date, Inspect_date, Inspect_name, USL, SL, LSL, Inspect_val, mh.Workorderno order by Prd_Date desc";


                    List<SpecificationVO> list = Helper.DataReaderMapToList<SpecificationVO>(cmd.ExecuteReader());

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
        public DataTable GetConditionValue(string workOrderNum, string inspectCode)      //품질측정값 추가한 목록을 가져온다
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SP_SpecValue";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@P_WorkOrderNum", workOrderNum);
                    da.SelectCommand.Parameters.AddWithValue("@P_Inspect_code", inspectCode);

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
        public List<SpecificationVO> GetInsSpectValueList(string itemCode, string processCode)      //작업지시 품목의 품질측정 기본값 목록을 가져온다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Inspect_code, Inspect_name, SL from Inspect_Spec_Master where Item_Code = @Item_Code and Process_code = @Process_code";
                    cmd.Parameters.AddWithValue("@Item_Code", itemCode);
                    cmd.Parameters.AddWithValue("@Process_code", processCode);

                    List<SpecificationVO> list = Helper.DataReaderMapToList<SpecificationVO>(cmd.ExecuteReader());

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

        public bool InsertNewInsValue(SpecificationVO pc)    //품질측정 값 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;


                    cmd.CommandText = @"insert into Inspect_Measure_History (Item_code, Process_code, Inspect_code, Inspect_date, Inspect_datetime, Inspect_val, Workorderno, Ins_Date, Ins_Emp) 
values (@Item_code, @Process_code, @Inspect_code, GETDATE(), GETDATE(), @Inspect_val, @Workorderno, GETDATE(), @Ins_Emp)";


                    cmd.Parameters.AddWithValue("@Item_Code", pc.Item_Code);
                    cmd.Parameters.AddWithValue("@Process_code", pc.Process_code);
                    cmd.Parameters.AddWithValue("@Wc_Code", pc.Wc_Code);
                    cmd.Parameters.AddWithValue("@Inspect_code", pc.Inspect_code);
                    cmd.Parameters.AddWithValue("@Inspect_val", pc.Inspect_val);
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
        public bool DeleteInsValue(int rownNum, string workOrderNum)    //품질측정 값 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"delete from Inspect_Measure_History where Inspect_measure_seq = (
 select Inspect_measure_seq from (select ROW_NUMBER() OVER(order by Inspect_measure_seq) rowNum ,Inspect_measure_seq from Inspect_Measure_History 
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
        public string GetLastCode()   //가장 최근 등록된 코드명을 가져온다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select distinct top 1 Inspect_code from Inspect_Spec_Master order by Inspect_code desc";

                    string str = cmd.ExecuteScalar().ToString();

                    return str;
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
