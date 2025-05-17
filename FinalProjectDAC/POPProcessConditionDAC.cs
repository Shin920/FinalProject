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
    public class POPProcessConditionDAC:IDisposable
    {
        SqlConnection conn;
        private static LoggingUtility log = new LoggingUtility("POPProcessConditionDAC", Level.Debug, 30);

        public static LoggingUtility Log { get { return log; } }


        public POPProcessConditionDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }
        /// <summary>
        /// 공정조건목록조회
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="wc_Code"></param>
        /// <returns></returns>
        public List<POPProcessConditionVO> GetProcessConditionList(string itemCode, string wc_Code)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select  Condition_Code, Condition_Name, SL, USL, LSL  
FROM Condition_Spec_Master

where Item_Code = @item_code and Wc_Code = @wc_code";

                    cmd.Parameters.AddWithValue("@item_code", itemCode);
                    cmd.Parameters.AddWithValue("@wc_Code", wc_Code);
                    List<POPProcessConditionVO> list = Helper.DataReaderMapToList<POPProcessConditionVO>(cmd.ExecuteReader());
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
        /// 공정조건 삭제
        /// </summary>
        /// <param name="condition_measure_seq"></param>
        /// <returns></returns>
        public bool DeleteConditionValue(string condition_measure_seq)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"delete from Condition_Measure_History where condition_measure_seq = @condition_measure_seq";
      
                    cmd.Parameters.AddWithValue("@condition_measure_seq", condition_measure_seq);

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
        /// 공정조건 등록여부 확인
        /// </summary>
        /// <param name="wc_code"></param>
        /// <param name="item_code"></param>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public int IsConditionRegister(string wc_code, string item_code, string workorderno)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select count(*) from Condition_Measure_History where wc_Code = @wc_code and item_code = @item_code and workorderno= @workorderno";

                    cmd.Parameters.AddWithValue("@wc_code", wc_code);
                    cmd.Parameters.AddWithValue("@item_code", item_code);
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return 0;
            }
        }
        /// <summary>
        /// 품질측정값 등록여부 확인
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public int IsInspectRegisterd(string workorderno)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select count(*) from Inspect_Measure_History where workorderno= @workorderno";

                    cmd.Parameters.AddWithValue("@workorderno", workorderno);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return 0;
            }
        }

        /// <summary>
        /// 공정조건 업데이트
        /// </summary>
        /// <param name="condition_measure_seq"></param>
        /// <param name="Condition_Val"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool UpdateConditionValue(string condition_measure_seq, string Condition_Val,  string managerid)
        {
            try
            {
                //해당공정조건
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"update Condition_Measure_History set Condition_Val = @Condition_Val, Up_Date = @Up_Date, Up_Emp=@Up_Emp
where condition_measure_seq =@condition_measure_seq";

                    cmd.Parameters.AddWithValue("@Condition_Val", Condition_Val);
                    cmd.Parameters.AddWithValue("@Up_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Up_Emp", managerid);
                    cmd.Parameters.AddWithValue("@condition_measure_seq", condition_measure_seq);

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
        /// 공정조건등록
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
        public bool InsertConditionValue(POPMesuredConditionVO mc)
        {
            try
            {
                //해당공정조건
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert  Condition_Measure_History (Item_code, Wc_Code, Condition_Code, Condition_Date, Condition_Datetime, Condition_Val, Workorderno, Ins_Date, Ins_Emp, Up_Date, Up_Emp)
values (@Item_code, @Wc_Code, @Condition_Code, @Condition_Date, @Condition_Datetime, @Condition_Val, @Workorderno, @Ins_Date, @Ins_Emp, @Up_Date, @Up_Emp)";

                    cmd.Parameters.AddWithValue("@Item_code", mc.Item_code);
                    cmd.Parameters.AddWithValue("@Wc_Code", mc.Wc_Code);
                    cmd.Parameters.AddWithValue("@Condition_Code", mc.Condition_Code);
                    cmd.Parameters.AddWithValue("@Condition_Date", mc.Condition_Date);
                    cmd.Parameters.AddWithValue("@Condition_Datetime", mc.Condition_Datetime);
                    cmd.Parameters.AddWithValue("@Condition_Val", mc.Condition_Val);
                    cmd.Parameters.AddWithValue("@Workorderno", mc.Workorderno);
                    cmd.Parameters.AddWithValue("@Ins_Date", mc.Ins_Date);
                    cmd.Parameters.AddWithValue("@Ins_Emp", mc.Ins_Emp);
                    cmd.Parameters.AddWithValue("@Up_Date", mc.Up_Date);
                    cmd.Parameters.AddWithValue("@Up_Emp", mc.Up_Emp);

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
        /// 공정조건 별 측정값 조회
        /// </summary>
        /// <param name="condition_Code"></param>
        /// <param name="itemCode"></param>
        /// <param name="wc_Code"></param>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public List<POPMesuredConditionVO> GetMeasuredCondition(string condition_Code, string itemCode, string wc_Code, string workorderno)
        {
            try
            {
                //해당공정조건
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select distinct Condition_measure_seq, c.Condition_Code, Condition_Name, Condition_Val, Condition_Datetime		 
from Condition_Measure_History c 
INNER join Condition_Spec_Master cm on c.Condition_Code = cm.Condition_Code AND c.Wc_Code = cm.Wc_Code

where c.Item_code =@itemCode and c.wc_Code = @wcCode and Workorderno = @Workorderno and c.Condition_Code	=@Condition_Code	";

                    cmd.Parameters.AddWithValue("@Condition_Code", condition_Code);
                    cmd.Parameters.AddWithValue("@itemCode", itemCode);
                    cmd.Parameters.AddWithValue("@wcCode", wc_Code);
                    cmd.Parameters.AddWithValue("@Workorderno", workorderno);
                    List<POPMesuredConditionVO> list = Helper.DataReaderMapToList<POPMesuredConditionVO>(cmd.ExecuteReader());
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
