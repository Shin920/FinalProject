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
    public class CarriageDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("CarriageDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public CarriageDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<CarriageVO> GetCarriageHistory(string begDate, string endDate)    //대차 이력 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Hist_Seq, gh.GV_Code, GV_Name, gh.Workorderno, wo.Item_Code, Item_Name, Loading_Date, Loading_Qty, Loading_Wc, In_Time, Center_Time,
Out_Time, Unloading_Qty, Unloading_date, Unloading_datetime, gh.Unloading_wc, Target_GV, Clear_Date, Clear_Datetime, Clear_Qty, 
Clear_Cause, Clear_wc, Clear_Item, gh.Ins_Date, gh.Ins_Emp
from GV_History gh inner join WorkOrder wo on gh.Workorderno = wo.Workorderno
					inner join Item_Master im on wo.Item_Code = im.Item_Code
					inner join GV_Master gv on gh.GV_Code = gv.GV_Code
where Loading_Date between '" + begDate+"' and '"+endDate+"'";

                    List<CarriageVO> list = Helper.DataReaderMapToList<CarriageVO>(cmd.ExecuteReader());
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
        public List<CarriageVO> GetCarriageSmallList()    //대차코드, 이름 목록만 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select GV_Code, GV_Name from GV_Master order by GV_Code";

                    List<CarriageVO> list = Helper.DataReaderMapToList<CarriageVO>(cmd.ExecuteReader());
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

        public List<ItemVO> GetItemSmallList()    //품목코드, 이름 목록만 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Item_Code, Item_Name from Item_Master";

                    List<ItemVO> list = Helper.DataReaderMapToList<ItemVO>(cmd.ExecuteReader());
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

        public List<CarriageVO> GetCarriageGroupSmallList()    //대차그룹명, 대차이름 목록만 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select GV_Name, GV_Group from GV_Master";

                    List<CarriageVO> list = Helper.DataReaderMapToList<CarriageVO>(cmd.ExecuteReader());
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

        public List<CarriageVO> GetCarriageStatusList()    //대차 현황 목록
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select cs.GV_Code, GV_Group, GV_Name, wo.Item_Code, Item_Name, cs.Workorderno, GV_Qty, GV_Rest_Qty, Loading_date, Loading_time, Loading_Wc, Unloading_date, Unloading_time, In_Time, Center_Time, Out_Time,
case GV_Status when '0' then '빈대차'
				when '1' then '적재'
				when '2' then '언로딩'
				else '' end GV_Status
from GV_Current_Status cs inner join WorkOrder wo on cs.Workorderno = wo.Workorderno
							inner join Item_Master im on wo.Item_Code = im.Item_Code
							inner join GV_Master gm on cs.GV_Code = gm.GV_Code
							order by cs.GV_Code";

                    List<CarriageVO> list = Helper.DataReaderMapToList<CarriageVO>(cmd.ExecuteReader());
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

        public List<CarriageVO> GetCarriageList()      //대차정보 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select GV_Code, GV_Name, GV_Group, U.Userdefine_Mi_Name GV_Status, Unloading_Wc, M.Ins_Date, M.Use_YN from GV_Master M
inner join Userdefine_Mi_Master U on M.GV_Status = U.Userdefine_Mi_Code";

                    List<CarriageVO> list = Helper.DataReaderMapToList<CarriageVO>(cmd.ExecuteReader());

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

        public bool InsertCarriage(string code, string name, string group, string emp)       //대차정보 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into GV_Master (GV_Code, GV_Name, GV_Group, Ins_Date, Ins_Emp) values (@GV_Code, @GV_Name, @GV_Group, @Ins_Date, @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@GV_Code", code);
                    cmd.Parameters.AddWithValue("@GV_Name", name);
                    cmd.Parameters.AddWithValue("@GV_Group", group);
                    cmd.Parameters.AddWithValue("@Ins_Emp", emp);
                    cmd.Parameters.AddWithValue("@Ins_Date", DateTime.Now);


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
        public bool DeleteCarriage(string code)       //대차정보 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from GV_Master where GV_Code = @GV_Code";

                    cmd.Parameters.AddWithValue("@GV_Code", code);

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

        public bool UpdateCarriage(CarriageVO no)       //대차정보 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update GV_Master set GV_Name = @GV_Name, GV_Group = @GV_Group, Up_Date = GETDATE(), Up_Emp = @Up_Emp where GV_Code = @GV_Code";

                    cmd.Parameters.AddWithValue("@GV_Name", no.GV_Name);
                    cmd.Parameters.AddWithValue("@GV_Group", no.GV_Group);
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@GV_Code", no.GV_Code);

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

        public bool UseYNSwap(string useYN, string code)    //사용여부를 변경
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;


                    cmd.CommandText = "update GV_Master set Use_YN = @Use_YN where GV_Code = @GV_Code";
                    cmd.Parameters.AddWithValue("@Use_YN", useYN);
                    cmd.Parameters.AddWithValue("@GV_Code", code);



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
    }
}
