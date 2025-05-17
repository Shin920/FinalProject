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
    public class AnalyseDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("AnalyseDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public AnalyseDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<AnalyseVO> GetPkgMonthly(string mon)      //월별 포장실적 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select w.Item_Code ,Item_Name, In_Date, In_Qty , sum(In_Qty) over(partition by w.Item_Code order by Barcode_No) totQty
from Goods_In_History gh inner join WorkOrder w on w.Workorderno = gh.Workorderno
						 inner join Item_Master im on w.Item_Code = im.Item_Code
where DATEPART(yyyy, In_Date) = '2021' and DatePart(MM, In_Date) = @mon
group by Barcode_No, w.Item_Code, Item_Name, In_date, In_Qty";

                    cmd.Parameters.AddWithValue("@mon", mon);

                    List<AnalyseVO> list = Helper.DataReaderMapToList<AnalyseVO>(cmd.ExecuteReader());

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

        public List<AnalysePrdVO> GetPrdMonthly(string mon)      //월별 생산 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT Process_Name, Wc_Name, Item_Name, Plan_Qty This_Goal_Qty, Prd_Qty as This_Prd_Qty, DATEDIFF(hour, Prd_Starttime, Prd_Endtime ) as This_Prd_Hour, CAST(CAST(Prd_Qty AS FLOAT)/CAST(Plan_Qty AS FLOAT)*100 AS DECIMAL) as This_Goal_Rate, Prd_Qty as Plus_Minus
from WorkOrder wo inner join Item_Master im on wo.Item_Code = im.Item_Code
				  inner join WorkCenter_Master wm on wo.Wc_Code = wm.Wc_Code
				  inner join Process_Master pm on wm.Process_Code = pm.Process_code
where DatePart(MM, wo.Ins_Date) = @mon and Prd_Endtime is not null and Prd_Starttime is not null";

                    cmd.Parameters.AddWithValue("@mon", mon);

                    List<AnalysePrdVO> list = Helper.DataReaderMapToList<AnalysePrdVO>(cmd.ExecuteReader());

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
