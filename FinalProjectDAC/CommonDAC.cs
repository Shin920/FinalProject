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
 public  class CommonDAC: IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("CommonDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public CommonDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<ComboItemVO> GetMold_CategoryCode() //금형 콤보박스로가져오기
        {
            try
            {
                string sql = @"select cast(Mold_Code as varchar(50)) com_Code, Mold_Name com_Name, 'GetMold_CategoryCode' com_Category 
	from  Mold_Master";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<ComboItemVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return null;
            }

        }
            public List<ComboItemVO> GetUserGroup_CategoryCode() //회원 그룹 코드 콤보박스로가져오기
        {
            try
            {
                string sql = @"	select cast(UserGroup_Code as varchar(50)) com_Code, UserGroup_Name com_Name, 'GetUserGroup_CategoryCode' com_Category 
	from  UserGroup_Master";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<ComboItemVO>(cmd.ExecuteReader());
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
