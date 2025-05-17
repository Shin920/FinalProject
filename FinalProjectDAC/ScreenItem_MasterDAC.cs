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
 public class ScreenItem_MasterDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("ScreenItem_MasterDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public ScreenItem_MasterDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }
        public void InsertUpdateScreenItem_Authority(List<ScreenItem_AuthorityVO> List)// 추가한 항목 저장
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                for (int i = 0; i < List.Count; i++)
                {
                    cmd.CommandText = @"insert into UserGroup_Master(UserGroup_Code, Screen_Code, Pre_Type, Ins_Date, Ins_Emp) 
  values(@UserGroup_Code, @Screen_Code, @Pre_Type, @Ins_Date, @Ins_Emp)"; 
                    cmd.Parameters.AddWithValue("@UserGroup_Code", List[i].UserGroup_Code);
                    cmd.Parameters.AddWithValue("@Screen_Code", List[i].Screen_Code);
                    cmd.Parameters.AddWithValue("@Pre_Type", List[i].Pre_Type);
                    cmd.Parameters.AddWithValue("@Ins_Date", List[i].Ins_Date);
                    cmd.Parameters.AddWithValue("@Ins_Emp", List[i].Ins_Emp);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Connection.Close();
                }
            }
        }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
         }
        public void DeleteGroupUseScreenItem_Authority(string group, List<ScreenItem_AuthorityVO> List)// 그룹에서 사용하던 화면을 더이상 사용하지않을때. Use_YN==N으로 변경
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                for (int i = 0; i < List.Count; i++)
                {
                    cmd.CommandText = @" delete from ScreenItem_Authority where Screen_Code = @Screen_Code;
                                insert into ScreenItem_Authority(Screen_Code, UserGroup_Code)
                                select @Screen_Code, item from dbo.SplitString(@UserGroup_Code, ',')";
                    cmd.Parameters.AddWithValue("@UserGroup_Code", group);
                    cmd.Parameters.AddWithValue("@Screen_Code", List[i].Screen_Code);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Connection.Close();
                }
            }
        }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
             }
         }
            public List<ScreenItem_AuthorityVO> GetNotUseGroupScreenItem(string groupCode)// 그룹에서 사용하지않는 화면
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                cmd.Connection = conn;
                cmd.CommandText = @"

select UserGroup_Code, UserGroup_Name, Admin, Use_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp
from UserGroup_Master
where  UserGroup_Code =@UserGroup_Code
 ";// Use_YN = 'n' and 
                    cmd.Parameters.AddWithValue("@UserGroup_Code", groupCode);
                    List<ScreenItem_AuthorityVO> list = Helper.DataReaderMapToList<ScreenItem_AuthorityVO>(cmd.ExecuteReader());

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
            public List<ScreenItem_AuthorityVO> GetUseGroupScreenItem(string groupCode)//그룹에서 사용하는 화면들
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"select Seq, Menu_Name, Screen_Code, Parent_Screen_Code, Sort_index, mt.Ins_Date,  mt.Ins_Emp,  mt.Up_Date,  mt.Up_Emp, Menu_level, Program_Name
from MenuTree_Master mt inner join UserGroup_Master  um on mt.Ins_Date=um.Ins_Date  
where UserGroup_Code= @UserGroup_Code";
               
                cmd.Parameters.AddWithValue("@UserGroup_Code", groupCode);

                List<ScreenItem_AuthorityVO> list = Helper.DataReaderMapToList<ScreenItem_AuthorityVO>(cmd.ExecuteReader());

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
        public bool UsedScreenItem_MasterVO(string screencode, string used)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"update ScreenItem_Master set Use_YN=@Use_YN where Screen_Code=@Screen_Code";

                    cmd.Parameters.AddWithValue("@Screen_Code", screencode);
                    cmd.Parameters.AddWithValue("@Use_YN", used);

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
        public List<ScreenItem_MasterVO> GetALLScreenItem()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Screen_Code, Type, Ins_Date,Screen_Path, Use_YN from ScreenItem_Master";

                    List<ScreenItem_MasterVO> list = Helper.DataReaderMapToList<ScreenItem_MasterVO>(cmd.ExecuteReader());
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
