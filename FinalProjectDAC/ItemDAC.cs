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
    public class ItemDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("ItemDAC", Level.Debug, 30);
        public static LoggingUtility Log { get { return log; } }
        public ItemDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<ItemVO> GetItemList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand()) //품목정보 조회
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Item_Code, Item_Name, Item_Name_Eng, Item_Name_Eng_Alias, Item_Type, Item_Spec, Item_Unit, 
                                        Item_Stock, PrdQty_Per_Hour, PrdQTy_Per_Batch, Cavity, Line_Per_Qty, Shot_Per_Qty, Dry_GV_Qty, Heat_GV_Qty, Remark,
                                        Use_YN from Item_Master";

                    return Helper.DataReaderMapToList<ItemVO>(cmd.ExecuteReader());

                }
            }
            catch (Exception err)
            {

                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }

        public bool InsertItem(string code, string name, string ename, string alias, string type, string spec, string unit, decimal stock, decimal pph, decimal ppb, int cavity, int lpq, int spq, int dgq, int hgq, string lvl1, string lvl2, string lvl3, string lvl4, string lvl5, string emp)       //품목 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into Item_Master (Item_Code, Item_Name, Item_Name_Eng, Item_Name_Eng_Alias, Item_Type, Item_Spec, Item_Unit 
                                        Item_Stock, PrdQty_Per_Hour, PrdQTy_Per_Batch, Cavity, Line_Per_Qty, Shot_Per_Qty, Dry_GV_Qty, Heat_GV_Qty,
                                        Level1, Level2, Level3, Level4, Level5, Ins_Date, Ins_Emp)
                        values (@Item_Code, @Item_Name, @Item_Name_Eng, @Item_Name_Eng_Alias, @Item_Type, @Item_Spec, @Item_Unit 
                                        @Item_Stock, @PrdQty_Per_Hour, @PrdQTy_Per_Batch, @Cavity, @Line_Per_Qty, @Shot_Per_Qty, @Dry_GV_Qty, @Heat_GV_Qty,
                                        @Level1, @Level2, @Level3, @Level4, @Level5, @Ins_Date, @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Item_Code", code);
                    cmd.Parameters.AddWithValue("@Item_Name", name);
                    cmd.Parameters.AddWithValue("@Item_Name_Eng", ename);
                    cmd.Parameters.AddWithValue("@Item_Name_Eng_Alias", alias);
                    cmd.Parameters.AddWithValue("@Item_Type", type);
                    cmd.Parameters.AddWithValue("@Item_Spec", spec);
                    cmd.Parameters.AddWithValue("@Item_Unit", unit);
                    cmd.Parameters.AddWithValue("@Item_Stock", stock);
                    cmd.Parameters.AddWithValue("@PrdQty_Per_Hour", pph);
                    cmd.Parameters.AddWithValue("@PrdQTy_Per_Batch", ppb);
                    cmd.Parameters.AddWithValue("@Cavity", cavity);
                    cmd.Parameters.AddWithValue("@Line_Per_Qty", lpq);
                    cmd.Parameters.AddWithValue("@Shot_Per_Qty", spq);
                    cmd.Parameters.AddWithValue("@Dry_GV_Qty", dgq);
                    cmd.Parameters.AddWithValue("@Heat_GV_Qty", hgq);
                    cmd.Parameters.AddWithValue("@Level1", lvl1);
                    cmd.Parameters.AddWithValue("@Level2", lvl2);
                    cmd.Parameters.AddWithValue("@Level3", lvl3);
                    cmd.Parameters.AddWithValue("@Level4", lvl4);
                    cmd.Parameters.AddWithValue("@Level5", lvl5);
                    cmd.Parameters.AddWithValue("@Ins_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Ins_Emp", emp);

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

        public bool DeleteItem(string code)       //품목 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Item_Master where Item_Code = @Item_Code";

                    cmd.Parameters.AddWithValue("@Item_Code", code);

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

        public bool UpdateItem(ItemVO no)       //품목 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"update Item_Master set Cavity = @Cavity, Line_Per_Qty = @Line_Per_Qty, Shot_Per_Qty = @Shot_Per_Qty, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Item_Code = @Item_Code";

                    cmd.Parameters.AddWithValue("@Cavity", no.Cavity);
                    cmd.Parameters.AddWithValue("@Line_Per_Qty", no.Line_Per_Qty);
                    cmd.Parameters.AddWithValue("@Shot_Per_Qty", no.Shot_Per_Qty);                    
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    
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

        public bool UseYNSwapItem(string useYN, string code)    //품목 사용여부를 변경
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;


                    cmd.CommandText = "update Item_Master set Use_YN = @Use_YN where Item_Code = @Item_Code";
                    cmd.Parameters.AddWithValue("@Use_YN", useYN);
                    cmd.Parameters.AddWithValue("@Item_Code", code);



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

        public List<ComboItemVO> GetItemType()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand()) //품목정보 조회
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Userdefine_Mi_Code com_Code, Userdefine_Mi_Name com_Name from Userdefine_Mi_Master where Userdefine_Ma_Code = 'ITS'";

                    return Helper.DataReaderMapToList<ComboItemVO>(cmd.ExecuteReader());

                }
            }
            catch (Exception err)
            {

                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");
            }
        }


        public List<ItemLevelVO> GetItemLevelList()      //품목분류 목록조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Level_Code, Level_Name, Box_Qty, Pcs_Qty, Mat_Qty, Use_YN from Item_Level_Master";

                    List<ItemLevelVO> list = Helper.DataReaderMapToList<ItemLevelVO>(cmd.ExecuteReader());

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

        public bool InsertItemLevel(string code, string name, int bqty, int pqty, decimal mqty, string emp)       //품목분류 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into Item_Level_Master (Level_Code, Level_Name, Box_Qty, Pcs_Qty, Mat_Qty, Ins_Date, Ins_Emp) values (@Level_Code, @Level_Name, @Box_Qty, @Pcs_Qty, @Mat_Qty, @Ins_Date, @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Level_Code", code);
                    cmd.Parameters.AddWithValue("@Level_Name", name);
                    cmd.Parameters.AddWithValue("@Box_Qty", bqty);
                    cmd.Parameters.AddWithValue("@Pcs_Qty", pqty);
                    cmd.Parameters.AddWithValue("@Mat_Qty", mqty);
                    cmd.Parameters.AddWithValue("@Ins_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Ins_Emp", emp);



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
        public bool DeleteItemLevel(string code)       //품목분류 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Item_Level_Master where Level_Code = @Level_Code";

                    cmd.Parameters.AddWithValue("@Level_Code", code);

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

        public bool UpdateItemLevel(ItemLevelVO no)       //품목분류 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Item_Level_Master set Level_Name = @Level_Name, Box_Qty = @Box_Qty, Pcs_Qty = @Pcs_Qty, Mat_Qty = @Mat_Qty, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Level_Code = @Level_Code";

                    cmd.Parameters.AddWithValue("@Level_Name", no.Level_Name);
                    cmd.Parameters.AddWithValue("@Box_Qty", no.Box_Qty);
                    cmd.Parameters.AddWithValue("@Pcs_Qty", no.Pcs_Qty);
                    cmd.Parameters.AddWithValue("@Mat_Qty", no.Mat_Qty);
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@Level_Code", no.Level_Code);

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

        public bool UseYNSwap(string useYN, string code)    //품목분류 사용여부를 변경
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;


                    cmd.CommandText = "update Item_Level_Master set Use_YN = @Use_YN where Level_Code = @Level_Code";
                    cmd.Parameters.AddWithValue("@Use_YN", useYN);
                    cmd.Parameters.AddWithValue("@Level_Code", code);



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
