using log4net.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDAC
{
    public class ReportDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("BoxingDAC", Level.Debug, 30);

        public static LoggingUtility Log { get { return log; } }

        public ReportDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetMaterialList( )       //건조 리스트
        {
            string sql = @"select *, DATEDIFF(minute,Ins_Date,Unloading_datetime)
from GV_History 
where convert(varchar(10), Ins_Date, 23) = '2021-07-26'
and GV_Code in (select gv_code from GV_Master where gv_group= '건조' and use_Yn='Y')
and Target_GV in (select gv_code gv_2 from GV_Master where gv_group= '소성' and use_Yn='Y')";

            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
              
                da.Fill(dt);
            }

            return dt;
        }
        public DataTable GetPackingList(string date)       //포장 리스트
        {
            string sql = @"SELECT ROW_NUMBER() OVER(ORDER BY In_Date) AS Num,g.Workorderno,Item_Name,Pallet_No
,In_Date,g.Remark,Convert(Varchar,Prd_Endtime,8) Prd_Endtime FROM Goods_In_History g,WorkOrder w, Item_Master i, WorkCenter_Master wc where g.Workorderno=w.Workorderno 
and w.Item_Code=i.Item_Code and w.Wc_Code=wc.Wc_Code and wc.Process_Code ='PC10005' and In_Date = @In_Date";

            DataTable dt = new DataTable();
            
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@In_Date", date);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
