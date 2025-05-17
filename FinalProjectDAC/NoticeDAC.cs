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
    public class NoticeDAC:IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("NoticeDAC", Level.Debug, 30);



        public static LoggingUtility Log { get { return log; } }
        public NoticeDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }



        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetSearchedNoticeList(string fromdate, string todate, string tag, char useYN)
        {
            try
            {
                string sql = @"SELECT SEQ, Notice_Date, Notice_End, TITLE, Description, USE_YN
where Notice_Date > '" + fromdate+ "' and Notice_End < '" + todate + "' and  (title like '%"+ tag + "%' or Description like '%" + tag + "%') and Use_YN = '"+useYN+"'";
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
        /// 전체 공지 조회
        /// </summary>
        /// <returns></returns>
        public DataTable GetNoticeList()
        {
            try
            {
                string sql = @"SELECT SEQ, Notice_Date, Notice_End, TITLE, Description, USE_YN, Rank() over(ORDER BY SEQ DESC) number 
FROM Sys_Notice 
where Notice_End >= getdate()";
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
        public List<NoticeVO> GetUsedNoticeList()
        {
            try
            {
                string sql = @"SELECT  Description FROM Sys_Notice where use_yn ='Y'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<NoticeVO> list = Helper.DataReaderMapToList<NoticeVO>(cmd.ExecuteReader());
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
        public bool InsertNotice(NoticeVO nv)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert Sys_Notice (Notice_Date, Notice_End, Title, Description,  Use_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp)
values(@Notice_Date, @Notice_End, @Title, @Description,  @Use_YN, getdate(), @Ins_Emp, getdate(), @Up_Emp)";
                    cmd.Parameters.AddWithValue("@Notice_Date", nv.Notice_Date);
                    cmd.Parameters.AddWithValue("@Notice_End", nv.Notice_End);
                    cmd.Parameters.AddWithValue("@Title", nv.Title);
                    cmd.Parameters.AddWithValue("@Description", nv.Description);
                    cmd.Parameters.AddWithValue("@Use_YN", nv.Use_YN);
                    cmd.Parameters.AddWithValue("@Ins_Emp", nv.Ins_Emp);
                    cmd.Parameters.AddWithValue("@Up_Emp", nv.Up_Emp);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    return (iRowAffect > 0);
                }
            }
            catch (Exception err)
            {

                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }
        public bool UpdateNotice(NoticeVO nv, int seq)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"update Sys_Notice set Notice_Date = @Notice_Date, Notice_End = @Notice_End, Title = @Title, Description = @Description ,Use_YN = @Use_YN, Up_Emp = @Up_Emp, Up_Date = getdate() 
where seq = @seq";
                    cmd.Parameters.AddWithValue("@Notice_Date", nv.Notice_Date);
                    cmd.Parameters.AddWithValue("@Notice_End", nv.Notice_End);
                    cmd.Parameters.AddWithValue("@Title", nv.Title);
                    cmd.Parameters.AddWithValue("@Description", nv.Description);
                    cmd.Parameters.AddWithValue("@Use_YN", nv.Use_YN);
                    cmd.Parameters.AddWithValue("@Up_Emp", nv.Up_Emp);
                    cmd.Parameters.AddWithValue("@seq", seq);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    return (iRowAffect > 0);
                }
            }
            catch (Exception err)
            {

                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public bool DeleteNotice(int seq)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"delete Sys_Notice where seq =@seq";
                    cmd.Parameters.AddWithValue("@seq", seq);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    return (iRowAffect > 0);
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
