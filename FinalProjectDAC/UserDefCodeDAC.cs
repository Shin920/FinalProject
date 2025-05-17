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
    public class UserDefCodeDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("UserDefCodeDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public UserDefCodeDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }


        public List<UserDefCodeVO> GetUserDefCodeList()      //사용자 정의코드 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Userdefine_Ma_Code, Userdefine_Ma_Name, Remark, Use_YN, Ins_Date from Userdefine_Ma_Master";

                    List<UserDefCodeVO> list = Helper.DataReaderMapToList<UserDefCodeVO>(cmd.ExecuteReader());

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

        public bool InsertUserDefCode(string code, string name, string remark, string empName)       //사용자 정의코드 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into Userdefine_Ma_Master (Userdefine_Ma_Code, Userdefine_Ma_Name, Remark, Ins_Date, Ins_Emp) values (@Userdefine_Ma_Code, @Userdefine_Ma_Name, @Remark, @Ins_Date, @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Userdefine_Ma_Code", code);
                    cmd.Parameters.AddWithValue("@Userdefine_Ma_Name", name);
                    cmd.Parameters.AddWithValue("@Remark", remark);
                    cmd.Parameters.AddWithValue("@Ins_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Ins_Emp", empName);

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
        public bool DeleteUserDefCode(string code)       //사용자 정의코드 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Userdefine_Ma_Master where Userdefine_Ma_Code = @Userdefine_Ma_Code";

                    cmd.Parameters.AddWithValue("@Userdefine_Ma_Code", code);

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

        public bool UpdateUserDefCode(UserDefCodeVO no)       //사용자 정의코드 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Userdefine_Ma_Master set Userdefine_Ma_Name = @Userdefine_Ma_Name, Remark = @Remark, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Userdefine_Ma_Code = @Userdefine_Ma_Code";

                    cmd.Parameters.AddWithValue("@Userdefine_Ma_Name", no.Userdefine_Ma_Name);
                    cmd.Parameters.AddWithValue("@Remark", no.Remark);
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@Userdefine_Ma_Code", no.Userdefine_Ma_Code);

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

        public bool UseYNSwap(string useYN, string code, bool isDetail)    //특정 대분류 사용여부를 변경. 대분류/상세분류 둘다 쓰여서 상세분류인지를 bool 타입으로 입력하게
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    if (!isDetail)
                    {
                        cmd.CommandText = "update Userdefine_Ma_Master set Use_YN = @Use_YN where Userdefine_Ma_Code = @Userdefine_Ma_Code";
                        cmd.Parameters.AddWithValue("@Use_YN", useYN);
                        cmd.Parameters.AddWithValue("@Userdefine_Ma_Code", code);
                    }
                    else if (isDetail)
                    {
                        cmd.CommandText = "update Userdefine_Mi_Master set Use_YN = @Use_YN where Userdefine_Mi_Code = @Userdefine_Mi_Code";
                        cmd.Parameters.AddWithValue("@Use_YN", useYN);
                        cmd.Parameters.AddWithValue("@Userdefine_Mi_Code", code);
                    }


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

        public List<UserDefCodeVO> GetUserDefCodeDetailList()     //사용자정의코드 상세분류 목록 조회
        {
            try
            {
                string sql = "select Userdefine_Mi_Code, Userdefine_Mi_Name, Userdefine_Ma_Code, Use_YN, Remark, Ins_Date, Ins_Emp, Up_Date, Up_Emp from Userdefine_Mi_Master";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<UserDefCodeVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return null;
            }
        }

        public bool InsertUserDefCodeDetail(UserDefCodeVO no)       //사용자정의코드 상세분류 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Userdefine_Mi_Master (Userdefine_Mi_Code, Userdefine_Mi_Name, Userdefine_Ma_Code, Remark, Ins_Date, Ins_Emp)
values (@Userdefine_Mi_Code, @Userdefine_Mi_Name, @Userdefine_Ma_Code, @Remark, GETDATE(), @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Userdefine_Mi_Code", no.Userdefine_Mi_Code);
                    cmd.Parameters.AddWithValue("@Userdefine_Mi_Name", no.Userdefine_Mi_Name);
                    cmd.Parameters.AddWithValue("@Userdefine_Ma_Code", no.Userdefine_Ma_Code);
                    cmd.Parameters.AddWithValue("@Remark", no.Remark);
                    cmd.Parameters.AddWithValue("@Ins_Emp", no.Ins_Emp);

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

        
        public bool DeleteUserDefCodeDetail(string code)       //사용자정의코드 상세분류 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Userdefine_Mi_Master where Userdefine_Mi_Code = @Userdefine_Mi_Code";

                    cmd.Parameters.AddWithValue("@Userdefine_Mi_Code", code);

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


        public bool UpdateDetail(UserDefCodeVO no)       //사용자정의코드 상세분류 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Userdefine_Mi_Master set Userdefine_Mi_Name = @Userdefine_Mi_Name, Remark = @Remark, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Userdefine_Mi_Code = @Userdefine_Mi_Code";

                    cmd.Parameters.AddWithValue("@Userdefine_Mi_Name", no.Userdefine_Mi_Name);
                    cmd.Parameters.AddWithValue("@Remark", no.Remark);
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@Userdefine_Mi_Code", no.Userdefine_Mi_Code);

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
