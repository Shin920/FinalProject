using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using log4net.Core;
using System.Diagnostics;
using FinalProjectVO;
using System.Data;

namespace FinalProjectDAC
{
    public class NonOperationDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("NonOperationDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public NonOperationDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        
        public List<NonOperationVO> GetNonOperationGroupList()      //비가동 대분류 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Nop_Ma_Code, Nop_Ma_Name, Use_YN, Ins_Date from Nop_Ma_Master";

                    List<NonOperationVO> list = Helper.DataReaderMapToList<NonOperationVO>(cmd.ExecuteReader());

                    return list;
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public bool InsertNonOperation(string code, string name, string empName)       //비가동 대분류 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into Nop_Ma_Master (Nop_Ma_Code, Nop_Ma_Name, Ins_Date, Ins_Emp) values (@Nop_Ma_Code, @Nop_Ma_Name, @Ins_Date, @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Nop_Ma_Code", code);
                    cmd.Parameters.AddWithValue("@Nop_Ma_Name", name);
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
        public bool DeleteNonOperation(string code)       //비가동 대분류 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Nop_Ma_Master where Nop_Ma_Code = @Nop_Ma_Code";

                    cmd.Parameters.AddWithValue("@Nop_Ma_Code", code);                  

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

        public bool UseYNSwap(string useYN, string code, bool isDetail)    //특정 비가동 대분류 사용여부를 변경. 대분류/상세분류 둘다 쓰여서 상세분류인지를 bool 타입으로 입력하게
        {          
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    if(! isDetail)
                    {
                        cmd.CommandText = "update Nop_Ma_Master set Use_YN = @Use_YN where Nop_Ma_Code = @Nop_Ma_Code";
                        cmd.Parameters.AddWithValue("@Use_YN", useYN);
                        cmd.Parameters.AddWithValue("@Nop_Ma_Code", code);
                    }
                    else if (isDetail)
                    {
                        cmd.CommandText = "update Nop_Mi_Master set Use_YN = @Use_YN where Nop_Mi_Code = @Nop_Mi_Code";
                        cmd.Parameters.AddWithValue("@Use_YN", useYN);
                        cmd.Parameters.AddWithValue("@Nop_Mi_Code", code);
                    }


                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return false;
            }
        }

        public List<NonOperationVO> GetNopOperationDetailList()     //비가동 상세분류 목록 조회
        {         
            try
            {             
                string sql = "select Nop_Mi_Code, Nop_Mi_Name, Nop_Ma_Code, Use_YN, Remark, Ins_Date, Ins_Emp, Up_Date, Up_Emp from Nop_Mi_Master";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<NonOperationVO>(cmd.ExecuteReader());
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return null;
            }
        }

        public bool InsertDetailNop(NonOperationVO no)       //비가동 상세분류 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Nop_Mi_Master (Nop_Mi_Code, Nop_Mi_Name, Nop_Ma_Code, Remark, Ins_Date, Ins_Emp)
values(@Nop_Mi_Code, @Nop_Mi_Name, @Nop_Ma_Code, @Remark, GETDATE(), @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Nop_Mi_Code", no.Nop_Mi_Code);
                    cmd.Parameters.AddWithValue("@Nop_Mi_Name", no.Nop_Mi_Name);
                    cmd.Parameters.AddWithValue("@Nop_Ma_Code", no.Nop_Ma_Code);                   
                    cmd.Parameters.AddWithValue("@Remark", no.Remark);
                    cmd.Parameters.AddWithValue("@Ins_Emp", no.Ins_Emp);

                    return cmd.ExecuteNonQuery() > 0;
                    
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return false;
            }
        }



        /// <summary>
        /// 비가동 상세분류 삭제
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool DeleteDetailNop(string code)       //비가동 상세분류 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Nop_Mi_Master where Nop_Mi_Code = @Nop_Mi_Code";

                    cmd.Parameters.AddWithValue("@Nop_Mi_Code", code);

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



        public bool UpdateDetailNop(NonOperationVO no)       //비가동 상세분류 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Nop_Mi_Master set Nop_Mi_Name = @Nop_Mi_Name, Remark = @Remark, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Nop_Mi_Code = @Nop_Mi_Code";

                    cmd.Parameters.AddWithValue("@Nop_Mi_Name", no.Nop_Mi_Name);
                    cmd.Parameters.AddWithValue("@Remark", no.Remark);
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@Nop_Mi_Code", no.Nop_Mi_Code);

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
        public bool UpdateNonOperation(NonOperationVO no)       //비가동 대분류 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Nop_Ma_Master set Nop_Ma_Name = @Nop_Ma_Name, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Nop_Ma_Code = @Nop_Ma_Code";

                    cmd.Parameters.AddWithValue("@Nop_Ma_Name", no.Nop_Ma_Name);                
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@Nop_Ma_Code", no.Nop_Ma_Code);

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

        public List<NonOperationVO> GetNopHistory(string begDate, string endDate)      //비가동 이력 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Nop_Seq, Nop_Date, Nop_Happentime, Nop_Canceltime, nh.Wc_Code, Wc_Name, Nop_Ma_Name, Nop_Mi_Name, Nop_Type, Nop_Time, nh.Remark 
from Nop_History nh inner join Nop_Mi_Master mi on nh.Nop_Mi_Code = mi.Nop_Mi_Code
					inner join Nop_Ma_Master ma on mi.Nop_Ma_Code = ma.Nop_Ma_Code
					inner join WorkCenter_Master wm on nh.Wc_Code = wm.Wc_Code
where Nop_Date between '" + begDate+"' and '"+endDate+"'";
                    
                    List<NonOperationVO> list = Helper.DataReaderMapToList<NonOperationVO>(cmd.ExecuteReader());

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

        public bool RegisterNop(NonOperationVO nv)       //비가동 등록
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Nop_History (Nop_Date, Nop_Happentime, Nop_Canceltime, Wc_Code, Nop_Mi_Code, Nop_Type, Nop_Time, Remark, Ins_Date, Ins_Emp) 
values (convert(char(10),getdate(), 23), @Nop_Happentime, @Nop_Canceltime, @Wc_Code, @Nop_Mi_Code, @Nop_Type, @Nop_Time, @Remark, getdate(), @Ins_Emp)";
                    cmd.Parameters.AddWithValue("@Nop_Happentime", nv.Nop_Happentime);
                    cmd.Parameters.AddWithValue("@Nop_Canceltime", nv.Nop_Canceltime);
                    cmd.Parameters.AddWithValue("@Wc_Code", nv.Wc_Code);
                    cmd.Parameters.AddWithValue("@Nop_Mi_Code", nv.Nop_Mi_Code);
                    cmd.Parameters.AddWithValue("@Nop_Type", nv.Nop_Type);
                    cmd.Parameters.AddWithValue("@Nop_Time", nv.Nop_Time);
                    cmd.Parameters.AddWithValue("@Remark", nv.Remark);
                    cmd.Parameters.AddWithValue("@Ins_Emp", nv.Ins_Emp);

                    
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

        public List<NonOperationVO> GetNopDetailSmallList()     //비가동 상세분류명, 코드 목록만 조회
        {
            try
            {
                string sql = "select Nop_Mi_Code, Nop_Mi_Name from Nop_Mi_Master";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<NonOperationVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return null;
            }
        }
        public DataTable GetNonOperationList()
        {
            try
            {
                string sql = @"select wc_Name, nop_ma_Name, Nop_Mi_Name, Nop_Happentime, Nop_Canceltime, nh.wc_code, nop_seq, nop_time
from Nop_History nh
inner
join WorkCenter_Master wc on nh.Wc_Code = wc.Wc_Code
inner
join Nop_Mi_Master nmi on nh.Nop_Mi_Code = nmi.Nop_Mi_Code
inner
join Nop_Ma_Master nma on nmi.Nop_Ma_Code = nma.Nop_Ma_Code ";

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
                return null;
            }
        }
        /// <summary>
        /// 사용중인 대분류 목록 조회
        /// </summary>
        /// <returns></returns>
        public DataTable GetUseNonOperationMaList()      
        {
            try
            {
                string sql = "select Nop_Ma_Code, Nop_Ma_Name, Use_YN, Ins_Date from Nop_Ma_Master where Use_YN ='Y'";
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
        /// <summary>
        /// 사용중인 상세 목록 조회
        /// </summary>
        /// <returns></returns>
        public DataTable GetUseNopDetailMiList()     
        {
            try
            {
                string sql = "select Nop_Mi_Code, Nop_Mi_Name, Nop_Ma_Code from Nop_Mi_Master  where Use_YN ='Y'";

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
                return null;
            }
        }

        public bool UpdateNonOperationReason(string nop_mi_code, string managerid, string nop_seq)
        {
            try
            {
                string sql = @"update Nop_History set Nop_Mi_Code = @nop_mi_code, up_date = getdate(), up_emp = @managerid
where nop_seq = @nop_seq";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nop_mi_code", nop_mi_code);
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@nop_seq", nop_seq);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    return (iRowAffect > 0);
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return false;
            }
        }
    }
}
