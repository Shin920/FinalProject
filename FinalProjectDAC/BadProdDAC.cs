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
   public  class BadProdDAC
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("BadProdDAC", Level.Debug, 30);


        public static LoggingUtility Log { get { return log; } }
        public BadProdDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<Def_Ma_Master> GetDefMaList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Def_Ma_Code, Def_Ma_Name from Def_Ma_Master where use_yn = 'Y'";

                    List<Def_Ma_Master> list = Helper.DataReaderMapToList<Def_Ma_Master>(cmd.ExecuteReader());
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

        public bool RegBadProdHistory(List<DefectiveVO> list, string managerid)
        {
            try
            {
                int iRowAffect = 0;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert Def_History (Workorderno, Def_Mi_Code, Def_Date, Def_Qty, Ins_Date, Ins_Emp, Up_Date, Up_Emp, Def_Image_Binary)
values (@Workorderno, @Def_Mi_Code, @Def_Date, @Def_Qty, getdate(), @managerid, getdate(), @managerid, @Def_Image_Binary)";
                    foreach (DefectiveVO item in list)
                    {
                        cmd.Parameters.AddWithValue("@Workorderno", item.Workorderno);
                        cmd.Parameters.AddWithValue("@Def_Mi_Code", item.Def_Mi_Code);
                        cmd.Parameters.AddWithValue("@Def_Date", item.Def_Date);
                        cmd.Parameters.AddWithValue("@Def_Qty", item.Def_Qty);
                        cmd.Parameters.AddWithValue("@managerid", managerid);
                        cmd.Parameters.AddWithValue("@Def_Image_Binary", item.Def_Image_Binary);
                        iRowAffect += cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    return (iRowAffect>0);
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public DataTable GetDefMiList()
        {
            try
            {
                string sql = @"select Def_Mi_Code, def_ma_code, def_mi_name from Def_Mi_Master where Use_YN = 'Y'";
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
    }
}
