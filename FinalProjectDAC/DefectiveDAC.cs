using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using FinalProjectVO;
using log4net.Core;

namespace FinalProjectDAC
{
    public class DefectiveDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("DefectiveDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public DefectiveDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<DefectiveVO> GetDefectiveList()      //불량현상 대분류 리스트 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Def_Ma_Code, Def_Ma_Name, Use_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp from Def_Ma_Master";

                    List<DefectiveVO> list = Helper.DataReaderMapToList<DefectiveVO>(cmd.ExecuteReader());
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

        public bool InsertDefective(string code, string name, string empName)       //불량현상 대분류 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into Def_Ma_Master (Def_Ma_Code, Def_Ma_Name, Ins_Date, Ins_Emp) values (@Def_Ma_Code, @Def_Ma_Name, @Ins_Date, @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Def_Ma_Code", code);
                    cmd.Parameters.AddWithValue("@Def_Ma_Name", name);
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

        public bool UpdateDefective(string name, string empName, string code)       //불량현상 대분류 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Def_Ma_Master set Def_Ma_Name = @Def_Ma_Name, Up_Date = getdate(), Up_Emp = @Up_Emp where Def_Ma_Code = @Def_Ma_Code";

                    cmd.Parameters.AddWithValue("@Def_Ma_Name", name);
                    cmd.Parameters.AddWithValue("@Up_Emp", empName);
                    cmd.Parameters.AddWithValue("@Def_Ma_Code", code);

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

        public bool DeleteDefective(string code)       //불량현상 대분류 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Def_Ma_Master where Def_Ma_Code = @Def_Ma_Code";

                    cmd.Parameters.AddWithValue("@Def_Ma_Code", code);


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
        public bool UseYNSwap(string useYN, string code, bool isDetail)    //특정 불량현상 대분류 사용여부를 변경. 대분류/상세분류 둘다 쓰여서 상세분류인지를 bool 타입으로 입력하게
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    if (!isDetail)
                    {
                        cmd.CommandText = "update Def_Ma_Master set Use_YN = @Use_YN where Def_Ma_Code = @Def_Ma_Code";
                        cmd.Parameters.AddWithValue("@Use_YN", useYN);
                        cmd.Parameters.AddWithValue("@Def_Ma_Code", code);
                    }
                    else if (isDetail)
                    {
                        cmd.CommandText = "update Def_Mi_Master set Use_YN = @Use_YN where Def_Mi_Code = @Def_Mi_Code";
                        cmd.Parameters.AddWithValue("@Use_YN", useYN);
                        cmd.Parameters.AddWithValue("@Def_Mi_Code", code);
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
        public List<DefectiveVO> GetDefDetailList()     //불량현상 상세분류 목록 조회
        {
            try
            {
                string sql = "select Def_Mi_Code, Def_Ma_Code, Def_Mi_Name, Use_YN, Remark, Ins_Date, Ins_Emp from Def_Mi_Master";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<DefectiveVO>(cmd.ExecuteReader());                   
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return null;
            }
        }

        public bool UpdateDefDetail(DefectiveVO df)       //불량현상 상세분류 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Def_Mi_Master set Def_Mi_Name = @Def_Mi_Name, Remark = @Remark, Up_Date = getdate(), Up_Emp = @Up_Emp where Def_Mi_Code = @Def_Mi_Code";

                    cmd.Parameters.AddWithValue("@Def_Mi_Name", df.Def_Mi_Name);
                    cmd.Parameters.AddWithValue("@Remark", df.Remark);
                    cmd.Parameters.AddWithValue("@Up_Emp", df.Up_Emp);
                    cmd.Parameters.AddWithValue("@Def_Mi_Code", df.Def_Mi_Code);

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

        public bool DeleteDefDetail(string code)       //불량현상 상세분류 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Def_Mi_Master where Def_Mi_Code = @Def_Mi_Code";

                    cmd.Parameters.AddWithValue("@Def_Mi_Code", code);                  

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

        public bool InsertDefDetail(DefectiveVO df)       //불량현상 상세분류 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Def_Mi_Master (Def_Mi_Code, Def_Ma_Code, Def_Mi_Name, Remark, Ins_Date, Ins_Emp)
values(@Def_Mi_Code, @Def_Ma_Code, @Def_Mi_Name, @Remark, getdate(), @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Def_Mi_Code", df.Def_Mi_Code);
                    cmd.Parameters.AddWithValue("@Def_Ma_Code", df.Def_Ma_Code);
                    cmd.Parameters.AddWithValue("@Def_Mi_Name", df.Def_Mi_Name);
                    cmd.Parameters.AddWithValue("@Remark", df.Remark);
                    cmd.Parameters.AddWithValue("@Ins_Emp", df.Ins_Emp);                

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

        public List<DefectiveVO> GetWorkOrderListwithBadCount(string begDate, string endDate)     //작업지시목록에 불량수량의 개수 포함된 목록
        {
            try
            {
                string sql = @"select Workorderno, wo.Item_Code, Item_Name, Wc_Name, Prd_Date, Prd_Qty, wo.Prd_Unit, Bad_Prd_Qty ,
	case wo.Wo_Status when 'WO_01' then '생산대기'
	when 'WO_02' then '생산중'
	when 'WO_03' then '생산중지'
	when 'WO_04' then '현장마감'
	when 'WO_05' then '작업지시마감'
	else '' end Wo_Status
from WorkOrder wo inner join Item_Master im on wo.Item_Code = im.Item_Code
					inner join WorkCenter_Master wm on wm.Wc_Code = wo.Wc_Code
where Prd_Date between '"+begDate+"' and '"+endDate+"'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<DefectiveVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return null;
            }
        }
        public List<DefectiveVO> GetDetailDefInWorkOrderNum(string workOrderNum)     //작업지시에 등록된 불량상세
        {
            try
            {
                string sql = @"select dh.Workorderno, wo.Item_Code, Item_Name, Def_Seq, Def_Ma_Name, Def_Mi_Name, Def_Date, Def_Qty, Def_Image_Name, Def_Image_Path , Def_Image_Binary from Def_History dh inner join WorkOrder wo on wo.Workorderno = dh.Workorderno
					inner join Item_Master im on wo.Item_Code = im.Item_Code
					inner join Def_Mi_Master mi on mi.Def_Mi_Code = dh.Def_Mi_Code
					inner join Def_Ma_Master ma on ma.Def_Ma_Code = mi.Def_Ma_Code
where dh.Workorderno = @Workorderno";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Workorderno", workOrderNum);

                    return Helper.DataReaderMapToList<DefectiveVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return null;
            }
        }
        public bool InsertDefImage(DefectiveVO df)       //불량이미지 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Def_History (Workorderno, Def_Seq, Def_Mi_Code, Def_Date, Def_Qty, Def_Image_Name, Def_Image_Path, Def_Image_Binary, Ins_Date, Ins_Emp) 
values (@Workorderno, @Def_Seq, @Def_Mi_Code, @Def_Date, @Def_Qty, @Def_Image_Name, @Def_Image_Path, @Def_Image_Binary, getdate(), @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Workorderno", df.Workorderno);
                    cmd.Parameters.AddWithValue("@Def_Seq", df.Def_Seq);
                    cmd.Parameters.AddWithValue("@Def_Mi_Code", df.Def_Mi_Code);
                    cmd.Parameters.AddWithValue("@Def_Date", df.Def_Date);
                    cmd.Parameters.AddWithValue("@Def_Qty", df.Def_Qty);
                    cmd.Parameters.AddWithValue("@Def_Image_Name", df.Def_Image_Name);
                    cmd.Parameters.AddWithValue("@Def_Image_Path", df.Def_Image_Path);
                    cmd.Parameters.AddWithValue("@Def_Image_Binary", df.Def_Image_Binary);
                    cmd.Parameters.AddWithValue("@Ins_Emp", df.Ins_Emp);

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
        public bool UpdateDefImage(DefectiveVO df)       //이미 등록된 불량이력에 불량이미지 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"update Def_History set Def_Image_Name = @Def_Image_Name, Def_Image_Binary = @Def_Image_Binary, Up_Date = getdate(), Up_Emp = @Up_Emp 
where Workorderno = @Workorderno and Def_Seq = @Def_Seq";

                    cmd.Parameters.AddWithValue("@Def_Image_Name", df.Def_Image_Name);
                    cmd.Parameters.AddWithValue("@Def_Image_Binary", df.Def_Image_Binary);
                    cmd.Parameters.AddWithValue("@Up_Emp", df.Up_Emp);
                    cmd.Parameters.AddWithValue("@Def_Seq", df.Def_Seq);
                    cmd.Parameters.AddWithValue("@Workorderno", df.Workorderno);


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
        public bool DeleteDefImage(DefectiveVO df)       //불량이력에 이미지와 이미지명만 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"update Def_History set Def_Image_Name = null, Def_Image_Binary = null, Up_Date = getdate(), Up_Emp = @Up_Emp 
where Workorderno = @Workorderno and Def_Seq = @Def_Seq";

                    cmd.Parameters.AddWithValue("@Up_Emp", df.Up_Emp);
                    cmd.Parameters.AddWithValue("@Def_Seq", df.Def_Seq);
                    cmd.Parameters.AddWithValue("@Workorderno", df.Workorderno);


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
