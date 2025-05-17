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
    public class LoginDAC : IDisposable
    {
        SqlConnection conn;
        private static LoggingUtility log = new LoggingUtility("LoginDAC", Level.Debug, 30);

        public static LoggingUtility Log { get { return log; } }
        public LoginDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public string IsUserLogin(string userid, string pwd)   //로그인 하는 사용자의 정보가 맞는지 확인하고 맞으면 사용자이름 넘겨준다
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select User_Name from User_Master where User_ID = @User_ID and User_PW = @User_PW";

                    cmd.Parameters.AddWithValue("@User_ID", userid);
                    cmd.Parameters.AddWithValue("@User_PW", pwd);

                    if (cmd.ExecuteScalar() != null)
                        return cmd.ExecuteScalar().ToString();
                    else
                        return null;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool UpdatePassWord(string id, string pwd)       //비밀번호 신규생성 한걸로 업데이트
        {
            try
            {
                string sql = "update User_Master set User_PW = @User_PW where User_ID = @User_ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@User_PW", pwd);
                cmd.Parameters.AddWithValue("@User_ID", id);

                return (cmd.ExecuteNonQuery() > 0);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool isOverlap(string id)       //아이디 중복체크
        {
            try
            {
                string sql = "select User_Name from User_Master where User_ID = @User_ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@User_ID", id);

                if (cmd.ExecuteScalar() == null)
                    return true;
                else
                    return false;
               
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool InsertNewUser(UserVO user)       //새 유저 등록
        {
            try
            {
                string sql = @"insert into User_Master (User_ID, User_Name, User_PW, Ins_Date, Ins_Emp, Email, Phone, AddrZip, Addr1, Addr2) 
values(@User_ID, @User_Name, @User_PW, getdate(), @Ins_Emp, @Email, @Phone, @AddrZip, @Addr1, @Addr2);
                insert into UserGroup_Mapping(UserGroup_Code, User_ID, Ins_Date, Ins_Emp) values(@UserGroup_Code, @User_ID, getdate(), @Ins_Emp)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@User_ID", user.User_ID);
                cmd.Parameters.AddWithValue("@User_Name", user.User_Name);
                cmd.Parameters.AddWithValue("@User_PW", user.User_PW);
                cmd.Parameters.AddWithValue("@Ins_Emp", user.Ins_Emp);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@AddrZip", user.AddrZip);
                cmd.Parameters.AddWithValue("@Addr1", user.Addr1);
                cmd.Parameters.AddWithValue("@Addr2", user.Addr2);
                cmd.Parameters.AddWithValue("@UserGroup_Code", user.UserGroup_Code);

                return cmd.ExecuteNonQuery() > 0;

            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public DataTable GetGroupList()       //그룹코드와 이름
        {
            try
            {
                string sql = @"select UserGroup_Code, UserGroup_Name from UserGroup_Master";
                DataTable dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {                  
                    da.Fill(dt);
                }
 
                return dt;

            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
    }
}
