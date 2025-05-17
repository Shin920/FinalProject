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
    public class MainFormDAC
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("MainFormDAC", Level.Debug, 30);


        public static LoggingUtility Log { get { return log; } }
        public MainFormDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }
        public DataTable GetMenuList() //트리뷰방법2
        {
            string sql = @"select Seq, Menu_Name, Menu_level, Parent_Screen_Code,
Program_Name, Sort_index from MenuTree_Master order by Parent_Screen_Code, Sort_index";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public List<MenuTreeMasterVO> GetAll_MenuTree_Master()// 메뉴 정보
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand()) 
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Seq, Menu_Name, Menu_level, Parent_Screen_Code, Program_Name, 
 Sort_index from MenuTree_Master order by Parent_Screen_Code, Sort_index";
                    return Helper.DataReaderMapToList<MenuTreeMasterVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }    
        }

        public bool UpdateManu(string parent, string son)    // 메뉴 부모 변경
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"update MenuTree_Master set Screen_Code = @Screen_Code where Parent_Screen_Code = @Parent_Screen_Code";

                    cmd.Parameters.AddWithValue("@Parent_Screen_Code", parent);
                    cmd.Parameters.AddWithValue("@Screen_Code", son);

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

        public bool InsertMenuTree_Master_VO(MenuTreeMasterVO menu)  // 메뉴 부모,자식 추가
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;

                comm.CommandText = "InsertMenuTree_Master_VO";
             
                comm.Parameters.AddWithValue("@Parent_Screen_Code", menu.Parent_Screen_Code);
                comm.Parameters.AddWithValue("@Screen_Code", menu.Screen_Code);
                comm.Parameters.AddWithValue("@Screen_Name", menu.Screen_Name);
                comm.Parameters.AddWithValue("@Ins_Emp", menu.Ins_Emp);
                comm.Connection.Open();
                int result = comm.ExecuteNonQuery();

                comm.Connection.Close();

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
  
        public bool DeleteMenuTree_Master_VO(string check, string parent, string code)   // 메뉴 부모,자식 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from MenuTree_Master where Parent_Screen_Code = @Parent_Screen_Code, Screen_Code= @Screen_Code, Check=@Check";

                    cmd.Parameters.AddWithValue("@Parent_Screen_Code", parent);
                    cmd.Parameters.AddWithValue("@Screen_Code", code);
                    cmd.Parameters.AddWithValue("@Check", check);

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
     
    }
}
