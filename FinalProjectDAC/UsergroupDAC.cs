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
  public  class UsergroupDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("UsergroupDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public UsergroupDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
           // conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }
      
        public List<UsergroupVO> GetAllUserGroup()// 그룹가져오기
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @" select UserGroup_Code, UserGroup_Name, Admin, Use_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp  
from UserGroup_Master";

                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<UsergroupVO> list = Helper.DataReaderMapToList<UsergroupVO>(reader);
                cmd.Connection.Close();
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
        public void InsertUpdateUserGroup_Mapping(List<UserGroup_MappingVO> List)// 추가한 항목 저장
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update UserGroup_Mapping set User_ID = @User_ID, Ins_Date = GETDATE(), Ins_Emp = @Ins_Emp where UserGroup_Code = @UserGroup_Code";

                    cmd.Parameters.Add(new SqlParameter("@UserGroup_Code", System.Data.SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@User_ID", System.Data.SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@Ins_Date", System.Data.SqlDbType.DateTime));
                    cmd.Parameters.Add(new SqlParameter("@Ins_Emp", System.Data.SqlDbType.NVarChar));

                    cmd.Connection.Open();                    

                    for (int i = 0; i < List.Count; i++)
                    {
                        cmd.Parameters["@UserGroup_Code"].Value =  List[i].UserGroup_Code;
                        cmd.Parameters["@User_ID"].Value = List[i].User_ID;
                        cmd.Parameters["@Ins_Date"].Value = List[i].Ins_Date;
                        cmd.Parameters["@Ins_Emp"].Value = List[i].Ins_Emp;
                                           
                        cmd.ExecuteNonQuery();                   
                    }
                    cmd.Connection.Close();
                }
        }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public void DeleteUserGroup_Mapping(List<UserGroup_MappingVO> List)// 그룹에서 사용하던 유저들을 더이상 사용하지않을때.
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from UserGroup_Mapping where UserGroup_Code = @UserGroup_Code, User_ID = @User_ID";
                    cmd.Parameters.Add(new SqlParameter("@UserGroup_Code", System.Data.SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@User_ID", System.Data.SqlDbType.NVarChar));               
                   cmd.Connection.Open();

                    for (int i = 0; i < List.Count; i++)
                    {
                        cmd.Parameters["@UserGroup_Code"].Value = List[i].UserGroup_Code;
                        cmd.Parameters["@User_ID"].Value = List[i].User_ID;
                        cmd.ExecuteNonQuery();         
                    }
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }
       
        public List<UserGroup_MappingVO> GetAllUserGroup_Mapping()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select UserGroup_Code, User_ID, Ins_Date, Ins_Emp, Up_Date, Up_Emp
  from UserGroup_Mapping";
                    cmd.Connection.Open();
                    List<UserGroup_MappingVO> list = Helper.DataReaderMapToList<UserGroup_MappingVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();
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
        public bool UPdateUsergroup(UsergroupVO list) // 수정 
        {
            try
            {
                string sql = @"UPDATE UserGroup_Master SET UserGroup_Name=@UserGroup_Name 
WHERE UserGroup_Code = @UserGroup_Code";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserGroup_Name", list.UserGroup_Name);
                    cmd.Parameters.AddWithValue("@UserGroup_Code", list.UserGroup_Code);

                    cmd.Connection.Open();
                    int iCnt = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return (iCnt > 0);
                }
            }
            catch (Exception err)
            {
                Log.WriteError(list.ToString(), err);
                return false;
            }
        }

        public bool UPdateUsergroupUseYN(string userGroupCode, string useYN) // 수정 
        {
            try
            {
                string sql = @"UPDATE UserGroup_Master SET Use_YN=@Use_YN WHERE UserGroup_Code = @UserGroup_Code";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Use_YN", useYN);
                    cmd.Parameters.AddWithValue("@UserGroup_Code", userGroupCode);

                    cmd.Connection.Open();
                    int iCnt = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return (iCnt > 0);
                }
            }
            catch (Exception err)
            {
                Log.WriteError(userGroupCode, err);
                return false;
            }
        }

        public UsergroupVO GetUsergroupInfo(string Usergroupcode) //셀클릭시 그 행의 재료 정보 조회
        {
            try
            {
                string sql = @"select UserGroup_Code, UserGroup_Name 
from UserGroup_Master where UserGroup_Code=@UserGroup_Code";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserGroup_Code", Usergroupcode);

                    cmd.Connection.Open();
                    List<UsergroupVO> list = Helper.DataReaderMapToList<UsergroupVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();
                    if (list != null && list.Count > 0)
                        return list[0];
                    else
                        return null;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                throw new Exception("처리되지 않은 오류 발생");
            }
        }
            public List<UsergroupVO> GetUsergroupList()  //사용자그룹 리스트 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select UserGroup_Code, UserGroup_Name, Admin, Use_YN, Ins_Date from UserGroup_Master";
                    cmd.Connection.Open();
                    List<UsergroupVO> list = Helper.DataReaderMapToList<UsergroupVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();
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
        public bool InsertUsergroup(UsergroupVO list) //사용자그룹 등록
        {
            try
            {
                string sql = @"	 insert into UserGroup_Master(UserGroup_Code, UserGroup_Name) 
  values(@UserGroup_Code, @UserGroup_Name)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserGroup_Code", list.UserGroup_Code);
                    cmd.Parameters.AddWithValue("@UserGroup_Name", list.UserGroup_Name);

                    cmd.Connection.Open();
                    int iCnt = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return iCnt > 0;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message);
                Debug.WriteLine(err.Message);
                return false;
            }
        }
      }
}
