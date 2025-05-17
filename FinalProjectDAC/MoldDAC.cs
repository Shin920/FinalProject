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
    public class MoldDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("MoldDAC", Level.Debug, 30);



        public static LoggingUtility Log { get { return log; } }
        public MoldDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }
        public List<MoldVO> SelectMoldGroup()// 금형그룹 조회
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "select distinct Mold_Group from Mold_Master";
                List<MoldVO> list = Helper.DataReaderMapToList<MoldVO>(cmd.ExecuteReader());

                return list;
            }
        }
        public List<Mold_J_Item_Wc_MuseVO> SelectMold_Item_Wc_Muse()// 금형사용정보조회
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"Select  Prd_Date, mu.Mold_Code, Mold_Name, wo.Workorderno, im.Item_Code ,Item_Name, wo.Wc_Code , Wc_Name, Mold_Shot_Cnt, Mold_Prd_Qty, Use_Starttime, Use_Endtime, Last_Setup_Time
from Mold_Use_History mu inner join Mold_Master m on mu.Mold_Code = m.Mold_Code 
inner join  WorkOrder wo on mu.Workorderno=wo.Workorderno 
inner join WorkCenter_Master wm on wo.Wc_Code=wm.Wc_Code
inner join Item_Master im on wo.Item_Code = im.Item_Code";


                List<Mold_J_Item_Wc_MuseVO> list = Helper.DataReaderMapToList<Mold_J_Item_Wc_MuseVO>(cmd.ExecuteReader());

                return list;
            }
        }
        /// <summary>
        /// 작업종료시에 금형사용이력과 금형정보에 수량 등록
        /// </summary>
        /// <param name="workorderno"></param>
        /// <param name="good"></param>
        /// <param name="bad"></param>
        /// <param name="managerid"></param>
        /// <param name="moldList"></param>
        /// <returns></returns>
        public bool UpdateMoldPrd(string workorderno, int good, int bad, string managerid, List<MoldVO> moldList)
        {
            try
            {
                int iRowAffect = 0;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_UpdateMoldPrdQty";
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < moldList.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@workorderno", workorderno);
                        cmd.Parameters.AddWithValue("@good_qty", good);
                        cmd.Parameters.AddWithValue("@bad_qty", bad);
                        cmd.Parameters.AddWithValue("@managerid", managerid);
                        cmd.Parameters.AddWithValue("@mold_code", moldList[i].Mold_Code);

                        iRowAffect += cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                return (iRowAffect > 0);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public DataSet MoldWorkCenter()// 금형정보 등록에 필요한 작업장정보 조회
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection())
                {
                    string sql = "select Wc_Code, Wc_Name from WorkCenter_Master'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    conn.Open();
                    da.Fill(ds);
                    conn.Close();
                }
                return ds;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }
        public List<MoldVO> GetMoldList()  //금형정보 리스트 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Mold_ID, Mold_Code, Mold_Name, Mold_Group, Mold_Status, Cum_Shot_Cnt, Cum_Prd_Qty, Cum_Time, Guar_Shot_Cnt, 
Purchase_Amt, In_Date, Last_Setup_Time, Wc_Code, Remark, Use_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp  
from Mold_Master";

                    List<MoldVO> list = Helper.DataReaderMapToList<MoldVO>(cmd.ExecuteReader());
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

        public int IsMoldSetted(string workOrderNo)
        {
            //select count(*) from Mold_Use_History where workorderno = @workorderno and Use_Endtime is null
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select count(*) from Mold_Use_History where workorderno = @workorderno and Use_Endtime is null";
                    cmd.Parameters.AddWithValue("@workorderno", workOrderNo);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }

        }

        public MoldVO GetMoldInfo(int mold_code) //셀클릭시 그 행의 금형 정보 조회
        {
            try
            {
                string sql = @"select  Mold_Code, Mold_Name, Mold_Group, Mold_Status, Cum_Shot_Cnt, Cum_Prd_Qty, Cum_Time, Guar_Shot_Cnt, 
Purchase_Amt, In_Date, Last_Setup_Time, Wc_Code, Remark, Use_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp  
from Mold_Master where Mold_Code=@Mold_Code";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Mold_Code", mold_code);

                    List<MoldVO> list = Helper.DataReaderMapToList<MoldVO>(cmd.ExecuteReader());

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
        public bool InsertMold(MoldVO minfo)// 금형정보등록
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Mold_Master( Mold_Code,Mold_Name,Mold_Group,Mold_Status,Cum_Shot_Cnt,Cum_Prd_Qty
      ,Cum_Time,Guar_Shot_Cnt,Purchase_Amt,In_Date,Last_Setup_Time,Wc_Code,Remark
      ,Use_YN,Ins_Date,Ins_Emp,Up_Date,Up_Emp) values ( @Mold_Code, @Mold_Name, @Mold_Group, @Mold_Status, @Cum_Shot_Cnt, @Cum_Prd_Qty
      , @Cum_Time, @Guar_Shot_Cnt, @Purchase_Amt, @In_Date, @Last_Setup_Time, @Wc_Code,@Remark
      , @Use_YN, SYSDATETIME(),'홍길동', SYSDATETIME(),'홍길동')";

                    cmd.Parameters.AddWithValue("@Mold_Code", minfo.Mold_Code);
                    cmd.Parameters.AddWithValue("@Mold_Name", minfo.Mold_Name);
                    cmd.Parameters.AddWithValue("@Mold_Group", minfo.Mold_Group);
                    cmd.Parameters.AddWithValue("@Mold_Status", minfo.Mold_Status);
                    cmd.Parameters.AddWithValue("@Cum_Shot_Cnt", minfo.Cum_Shot_Cnt);
                    cmd.Parameters.AddWithValue("@Cum_Prd_Qty", minfo.Cum_Prd_Qty);
                    cmd.Parameters.AddWithValue("@Cum_Time", minfo.Cum_Time);
                    cmd.Parameters.AddWithValue("@Guar_Shot_Cnt", minfo.Guar_Shot_Cnt);
                    cmd.Parameters.AddWithValue("@Purchase_Amt", minfo.Purchase_Amt);
                    cmd.Parameters.AddWithValue("@In_Date", minfo.In_Date);
                    cmd.Parameters.AddWithValue("@Last_Setup_Time", minfo.Last_Setup_Time);
                    cmd.Parameters.AddWithValue("@Wc_Code", minfo.Wc_Code);
                    cmd.Parameters.AddWithValue("@Remark", minfo.Remark);
                    cmd.Parameters.AddWithValue("@Use_YN", minfo.Use_YN);

                    cmd.Connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return result > 0;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                throw new Exception("처리되지 않은 오류 발생");
            }
        }
        public bool DeleteMold(string code)  //금형정보 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "Delete from Mold_Master where Mold_Code = @Mold_Code";

                    cmd.Parameters.AddWithValue("@Mold_Code", code);

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
        /// <summary>
        /// 장착 금형 목록
        /// </summary>
        /// <param name="workOrderNo"></param>
        /// <returns></returns>
        public List<MoldVO> GetSettedMoldList(string workOrderNo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select use_Seq, m.mold_code, mold_name, mold_group 
from mold_master m inner join  Mold_Use_History mh on m.Mold_Code = mh.Mold_Code
where mold_status = 'O' and  workorderno = @workorderno and use_endtime is null";
                    cmd.Parameters.AddWithValue("@workorderno", workOrderNo);
                    List<MoldVO> list = Helper.DataReaderMapToList<MoldVO>(cmd.ExecuteReader());
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
        /// <summary>
        /// 장착 대상 금형목록
        /// </summary>
        /// <returns></returns>
        public List<MoldVO> GetCanSetMoldList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Mold_Code, Mold_Name, Mold_Group from Mold_Master where Mold_Status = 'S'";

                    List<MoldVO> list = Helper.DataReaderMapToList<MoldVO>(cmd.ExecuteReader());
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
        /// <summary>
        /// 금형 장착
        /// </summary>
        /// <param name="mold"></param>
        /// <param name="manager"></param>
        /// <param name="workOrderNO"></param>
        /// <returns></returns>
        public bool SetMold(string mold, string manager, string workOrderNO, string wc_Code)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_SetMold";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MOLD_CODE", mold);
                    cmd.Parameters.AddWithValue("@WORKORDERNO", workOrderNO);
                    cmd.Parameters.AddWithValue("@MANAGERID", manager);
                    cmd.Parameters.AddWithValue("@WC_CODE", wc_Code);

                    int iRowAffected = cmd.ExecuteNonQuery();
                    return (iRowAffected > 0);
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return false;
            }
        }
        /// <summary>
        /// 금형 해제
        /// </summary>
        /// <param name="mold"></param>
        /// <param name="manager"></param>
        /// <param name="workOrderNO"></param>
        /// <returns></returns>
        public bool UnSetMold(string mold, string manager, string workOrderNO)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_UnSetMold";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MOLD_CODE", mold);
                    cmd.Parameters.AddWithValue("@WORKORDERNO", workOrderNO);
                    cmd.Parameters.AddWithValue("@MANAGERID", manager);

                    int iRowAffected = cmd.ExecuteNonQuery();
                    return (iRowAffected > 0);
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return false;
            }
        }
    }
}

