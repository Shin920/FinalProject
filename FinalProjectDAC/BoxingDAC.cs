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
    public class BoxingDAC : IDisposable
    {
        SqlConnection conn;

        private static LoggingUtility log = new LoggingUtility("BoxingDAC", Level.Debug, 30);



        public static LoggingUtility Log { get { return log; } }
        public BoxingDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }



        public void Dispose()
        {
            conn.Close();
        }

        public List<BoxingVO_Finish> GetFinishedProductList(string begDate, string endDate)  //완제품 입고리스트 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select gi.Workorderno, prd_Date, wo.Item_Code, Item_Name, Pallet_No, In_Qty, Upload_Flag, Barcode_No, Closed_Time, Cancel_Time, 
case Wo_Status when 'WO_01' then '생산대기'
				when 'WO_02' then '생산중'
				when 'WO_03' then '생산중지'
				when 'WO_04' then '현장마감'
				when 'WO_05' then '작업지시마감'
				else '' end Wo_Status
from Goods_In_History gi inner join WorkOrder wo on gi.Workorderno = wo.Workorderno
							inner join Item_Master im on wo.Item_Code = im.Item_Code
where In_YN = 'Y' and Wo_Status in ('WO_04', 'WO_05') and prd_Date between '" + begDate + "' and '" + endDate + "'";

                    List<BoxingVO_Finish> list = Helper.DataReaderMapToList<BoxingVO_Finish>(cmd.ExecuteReader());

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



        public List<BoxingVO_Info> GetUsedPalleteList(string workOrderNum)  //포장작업에 사용된 팔레트 정보
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"select Pallet_No, Grade_Code, Grade_Detail_Code, Grade_Detail_Name, In_Qty, Upload_Flag, In_YN
from Goods_In_History
where Workorderno = @Workorderno";

                    cmd.Parameters.AddWithValue("@Workorderno", workOrderNum);

                    List<BoxingVO_Info> list = Helper.DataReaderMapToList<BoxingVO_Info>(cmd.ExecuteReader());

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



        public bool FinishPallete(string workOrderNum, string palletNum, string upEmp)  //팔레트 마감
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Goods_In_History set In_YN = 'Y', Closed_Time = getdate(), Up_Date = getdate(), Up_Emp = @Up_Emp where Workorderno = @Workorderno and Pallet_No in (" + palletNum + ")";

                    cmd.Parameters.AddWithValue("@Workorderno", workOrderNum);
                    cmd.Parameters.AddWithValue("@Up_Emp", upEmp);
                    //cmd.Parameters.AddWithValue("@Pallet_No", palleteNum);


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


        public bool FinishWorkOrder(string workOrderNum)  //작업지시 마감
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update WorkOrder set Wo_Status = 'WO_05', Closed_Time = getdate(), Manager_CloseTime = getdate() where Workorderno = @Workorderno";

                    cmd.Parameters.AddWithValue("@Workorderno", workOrderNum);


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



        public bool UpdatePalleteGrade(BoxingVO box)  //팔레트 등급상세 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update Goods_In_History set Grade_Detail_Name = @Grade_Detail_Name where Workorderno = @Workorderno and Pallet_No = @Pallet_No";

                    cmd.Parameters.AddWithValue("@Grade_Detail_Name", box.Grade_Detail_Name);
                    cmd.Parameters.AddWithValue("@Workorderno", box.Workorderno);
                    cmd.Parameters.AddWithValue("@Pallet_No", box.Pallet_No);


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

        public List<BoxingVO> GetPkgDetail()  // 포장등급상세 조회
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select Boxing_Grade_Code, Grade_Detail_Code, Grade_Detail_Name, Ins_Date, Use_YN from BoxingGrade_Detail_Master";

                    List<BoxingVO> list = Helper.DataReaderMapToList<BoxingVO>(cmd.ExecuteReader());

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

        public bool InsertPkgDetail(string code, string name, string grade, string emp)       //포장등급상세 추가
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert into BoxingGrade_Detail_Master (Grade_Detail_Code, Grade_Detail_Name, Boxing_Grade_Code, Ins_Date, Ins_Emp)
                                        values (@Grade_Detail_Code, @Grade_Detail_Name, @Boxing_Grade_Code, @Ins_Date, @Ins_Emp)";

                    cmd.Parameters.AddWithValue("@Grade_Detail_Code", code);
                    cmd.Parameters.AddWithValue("@Grade_Detail_Name", name);
                    cmd.Parameters.AddWithValue("@Boxing_Grade_Code", grade);
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
        public bool DeletePkgDetail(string code)       //포장등급상세 삭제
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from BoxingGrade_Detail_Master where Grade_Detail_Code = @Grade_Detail_Code";

                    cmd.Parameters.AddWithValue("@Grade_Detail_Code", code);

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

        public bool UpdatePkgDetail(BoxingVO no)       //포장등급상세 수정
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update BoxingGrade_Detail_Master set Grade_Detail_Name = @Grade_Detail_Name, Boxing_Grade_Code = @Boxing_Grade_Code, Up_Date = GETDATE(), Up_Emp = @Up_Emp where Grade_Detail_Code = @Grade_Detail_Code";

                    cmd.Parameters.AddWithValue("@Grade_Detail_Name", no.Grade_Detail_Name);
                    cmd.Parameters.AddWithValue("@Boxing_Grade_Code", no.Boxing_Grade_Code);
                    cmd.Parameters.AddWithValue("@Up_Emp", no.Up_Emp);
                    cmd.Parameters.AddWithValue("@Grade_Detail_Code", no.Grade_Detail_Code);

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


                    cmd.CommandText = "update BoxingGrade_Detail_Master set Use_YN = @Use_YN where Grade_Detail_Code = @Grade_Detail_Code";
                    cmd.Parameters.AddWithValue("@Use_YN", useYN);
                    cmd.Parameters.AddWithValue("@Grade_Detail_Code", code);



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
        public bool FinishAllCheckList(string str)        //체크한 모든 작업지시에 대해 마감한다(팔레트가 마감이 안되있으면 팔레트도 마감시킨다)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = conn;

                    cmd.CommandText = "update Goods_In_History set In_YN = 'Y', Closed_Time = getdate() where Workorderno in (" + str + ")";
                    //cmd.Parameters.AddWithValue("@Workorderno", str);               

                    cmd.Transaction = trans;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update WorkOrder set Wo_Status = 'WO_05', Manager_CloseTime = getdate() where Workorderno in (" + str + ")";

                    cmd.Transaction = trans;
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    return true;

                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                Log.WriteError(err.Message);
                return false;
            }
        }

        /// <summary>
        /// 포장등급 리스트 조회
        /// </summary>
        /// <returns></returns>
        public DataTable GetPackGradeList()
        {
            try
            {
                string sql = @"select Grade_Detail_Code, Grade_Detail_Name, Boxing_Grade_Code from BoxingGrade_Detail_Master where Use_YN = 'Y'";
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
        /// 작업지시번호로 등록된 팔레트 번호 목록 조회
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public List<BoxingVO> GetPalNoList(string workorderno)
        {
            try
            {
                string sql = @"select Pallet_No, Size_Code from Goods_In_History where workorderno = @workorderno";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);


                    List<BoxingVO> list = Helper.DataReaderMapToList<BoxingVO>(cmd.ExecuteReader());
                    return list;
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
        /// 팔레트번호 신규생성
        /// </summary>
        /// <returns></returns>
        public string CreateNewPalNo(string workorderno)
        {
            try
            {
                string sql = @"select top 1  Convert(int, SUBSTRING( Pallet_No, 2, 5)) + 1 pn from Goods_In_History where workorderno =@workorderno order by  pn desc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    string newPalNo = "";
                    if (cmd.ExecuteScalar() != null)
                    {
                        newPalNo = cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        newPalNo = "10001";
                    }
                    return newPalNo;
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
        /// 포장실적등록
        /// </summary>
        /// <param name="bv"></param>
        /// <returns></returns>
        public bool InsertPackHistory(BoxingVO bv)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"insert Goods_In_History (Workorderno, Pallet_No, Grade_Code, Grade_Detail_Code, Size_Code, Grade_Detail_Name, In_Qty, F_In_Qty, Print_Date, In_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp)
values(@workorderno, @pallet_no,  @Grade_Code, @Grade_Detail_Code, @Size_Code, @Grade_Detail_Name, @In_Qty, @F_In_Qty, Convert(date, @Print_Date), @In_YN, @Ins_Date, @Ins_Emp, @Up_Date, @Up_Emp);select @@identity";
                    cmd.Parameters.AddWithValue("@workorderno", bv.Workorderno);
                    cmd.Parameters.AddWithValue("@pallet_no", bv.Pallet_No);
                    cmd.Parameters.AddWithValue("@Grade_Code", bv.Grade_Code);
                    cmd.Parameters.AddWithValue("@Grade_Detail_Code", bv.Grade_Detail_Code);
                    cmd.Parameters.AddWithValue("@Size_Code", bv.Size_Code);
                    cmd.Parameters.AddWithValue("@Grade_Detail_Name", bv.Grade_Detail_Name);
                    cmd.Parameters.AddWithValue("@In_Qty", bv.In_Qty);
                    cmd.Parameters.AddWithValue("@F_In_Qty", bv.F_In_Qty);
                    cmd.Parameters.AddWithValue("@Print_Date", bv.Print_Date);
                    cmd.Parameters.AddWithValue("@In_YN", bv.In_YN);
                    cmd.Parameters.AddWithValue("@Ins_Date", bv.Ins_Date);
                    cmd.Parameters.AddWithValue("@Ins_Emp", bv.Ins_Emp);
                    cmd.Parameters.AddWithValue("@Up_Date", bv.Up_Date);
                    cmd.Parameters.AddWithValue("@Up_Emp", bv.Up_Emp);

                    string barcodeno = cmd.ExecuteScalar().ToString();
                    int iRowAffect = 0;
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = conn;
                        cmd1.CommandText = @"insert pallet_detail(barcode_no,  tot_qty, rest_Qty)
values(@barcode_no,  @tot_qty, @rest_Qty)";
                        cmd1.Parameters.AddWithValue("@barcode_no", barcodeno);
                        cmd1.Parameters.AddWithValue("@tot_qty", bv.Prd_Qty);
                        cmd1.Parameters.AddWithValue("@rest_Qty", bv.Prd_Qty);
                        for (int i = 0; i < bv.In_Qty; i++)
                        {
                            iRowAffect += cmd1.ExecuteNonQuery();
                        }
                    }
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
        /// <summary>
        /// 작업지시번호로 등록된 팔레트 목록 조회
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public List<BoxingVO> GetPalList(string workorderno)
        {
            try
            {
                string sql = @"select Pallet_No , item_name, Grade_Detail_Name, In_Qty, Grade_Code, Grade_Detail_Code, g.Size_Code, Barcode_No, Size_Name, p.Prd_Qty, g.ins_date
from Goods_In_History g inner join WorkOrder w on g.Workorderno = w.Workorderno
inner join Item_Master i on w.Item_Code = i.Item_Code
inner join PALLETSIZE_MASTER p on g.Size_Code = p.size_code
where g.workorderno = @workorderno order by g.up_date";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);

                    List<BoxingVO> list = Helper.DataReaderMapToList<BoxingVO>(cmd.ExecuteReader());
                    return list;
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
        /// 팔레트 수량 업데이트
        /// </summary>
        /// <param name="barcodeno"></param>
        /// <param name="qty"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool UpdatePal(string barcodeno, int qty, int canPrdQty, string managerid)
        {
            try
            {
                string sql = @"UPDATE Goods_In_History SET In_Qty += @qty , Up_Date = getdate() , Up_Emp = @managerid
where Barcode_No =@Barcode_No";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Barcode_No", barcodeno);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@managerid", managerid);

                    cmd.ExecuteNonQuery();

                    int iRowAffect = 0;
                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        cmd1.Connection = conn;
                        for (int i = 0; i < qty; i++)
                        {

                            cmd1.CommandText = @"insert pallet_detail(barcode_no, tot_qty, rest_Qty)
values(@barcode_no, @tot_qty, @rest_Qty)";
                            cmd1.Parameters.AddWithValue("@barcode_no", barcodeno);
                            cmd1.Parameters.AddWithValue("@tot_qty", canPrdQty);
                            cmd1.Parameters.AddWithValue("@rest_Qty", canPrdQty);

                            iRowAffect += cmd1.ExecuteNonQuery();
                        }
                    }
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
        /// <summary>
        /// 팔레트삭제
        /// </summary>
        /// <param name="barcodeNo"></param>
        /// <returns></returns>
        public bool DelPal(string barcodeNo)
        {
            try
            {
                string sql = @"delete from Goods_In_History where Barcode_No = @Barcode_No";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Barcode_No", barcodeNo);

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

        //public List<BoxingVO> CreateBarcode()  // 바코드 생성
        //{
        //    try
        //    {
        //        string sql = "update Goods_In_History set Barcode_No = @Barcode_No where Workorderno = @Workorderno and Pallet_No = @Pallet_No";


        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Barcode_No", Convert.ToInt32(cboProduct.SelectedValue));
        //            cmd.Parameters.AddWithValue("@Workorderno", dgvCompleteProductList.cur);//8
        //            cmd.Parameters.AddWithValue("@Pallet_No", txtQty.Text);//3

        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //        }

        //    }
        //    catch (Exception err)
        //    {
        //        Debug.WriteLine(err.Message);
        //        Log.WriteError(err.Message);
        //        throw new Exception("처리되지 않은 예외 발생");

        //    }
        //}

        public DataTable GetBarcodeList(string barcode)  // 바코드가 있는 목록
        {
            try
            {

                string sql = @"select gh.Workorderno,Pallet_No,Barcode_No ,Item_Name
					from Goods_In_History gh inner join WorkOrder w on gh.Workorderno = w.Workorderno
					inner join Item_Master im on im.Item_Code = w.Item_Code where Barcode_No in ('" + barcode + "')";

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
                Log.WriteError(err.Message);
                throw new Exception("처리되지 않은 예외 발생");

            }
        }
        public DataTable GetBarcodeInfo(string barcodeno)
        {
            try
            {

                string sql = @"select Pallet_No, g.workorderno, item_name, Grade_Detail_Name, In_Qty, Concat(g.Barcode_No, '/', p.seq) barseq
from Goods_In_History g inner join workorder w on g.Workorderno = w.Workorderno
inner join Item_Master i on i.Item_Code = w.Item_Code
inner join pallet_detail p on g.Barcode_No = p.barcode_no
where g.Barcode_No = '" + barcodeno + "'";
                DataTable dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
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
        public DataTable GetPalSize(string unit)
        {
            try
            {
                string sql = @"SELECT size_code, prd_Qty, concat(size_name, ' (',prd_Qty,')' ) size_name, prd_unit FROM PALLETSIZE_MASTER
where Prd_Unit = '" + unit + "'";
                DataTable dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
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
        public DataTable GetPalletList(string workorderno)
        {
            try
            {
                string sql = @"select pallet_no, SEQ, g.barcode_no, TOT_QTY, REsT_QTY , g.size_code, size_name
from pallet_detail pd 
inner join Goods_In_History g on pd.barcode_no = g.Barcode_No
inner join palletsize_master pm on g.Size_Code = pm.size_code
where g.Workorderno = '" + workorderno + "'  and REsT_QTY > 0";
                DataTable dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
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
        /// 팔레트에 제품 언로딩
        /// </summary>
        /// <param name="managerid"></param>
        /// <param name="workorderno"></param>
        /// <param name="tARGET_Barcodeno"></param>
        /// <param name="qty"></param>
        /// <param name="status_Seq"></param>
        /// <param name="oRIGIN_GV_CODE"></param>
        /// <param name="hist_Seq"></param>
        /// <param name="sEQ"></param>
        /// <returns></returns>
        public bool UnloadingToPallet(string managerid, string workorderno, int tARGET_Barcodeno, int qty, int status_Seq, string oRIGIN_GV_CODE, long hist_Seq, int sEQ)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_PackUnloadingToPallet";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    cmd.Parameters.AddWithValue("@tARGET_Barcodeno", tARGET_Barcodeno);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@status_Seq", status_Seq);
                    cmd.Parameters.AddWithValue("@oRIGIN_GV_CODE", oRIGIN_GV_CODE);
                    cmd.Parameters.AddWithValue("@hist_Seq", hist_Seq);
                    cmd.Parameters.AddWithValue("@sEQ", sEQ);

                    int iRowAffect = cmd.ExecuteNonQuery();

                    cmd.CommandText = @"update Emp_Allocation_History_Detail set Prd_Qty += @qty where user_id in (select ea.user_id 
  from Emp_Allocation_History ea inner join Emp_Allocation_History_Detail ed on ea.Ins_Date = ed.Ins_Date
  where workorderno = @workorderno and Release_datetime is null) and workorderno =@workorderno";
                    cmd.CommandType = CommandType.Text;

                    iRowAffect += cmd.ExecuteNonQuery();

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
        public DataTable LoadPalList(string workorderno)
        {
            try
            {
                string sql = @"select g.Barcode_No, seq,  Pallet_No, g.WorkOrderno, item_name, (TOT_qTY - Rest_Qty) QTY, Grade_Detail_Name, wc_name
from Goods_In_History g inner join Pallet_Detail pd on g.Barcode_No = pd.Barcode_No
inner join workorder w on g.Workorderno = w.Workorderno
inner join item_master i on w.Item_Code = i.Item_Code
inner join WorkCenter_Master wc on w.Wc_Code = wc.Wc_Code
WHERE G.WORKORDERNO = '" + workorderno  + "' AND Tot_Qty != Rest_Qty and pd.in_yn = 'N'";
                DataTable dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
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


        public bool InPallet(string barcodeno, string seq, string managerid)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SP_InPallet";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@managerid", managerid);
                    cmd.Parameters.AddWithValue("@seq", seq);
                    cmd.Parameters.AddWithValue("@barcode_no", barcodeno);

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
        /// <summary>
        /// 작업지시번호로 등록된 팔레트 입고 안된거 있는지 여부 확인
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        public int IsPalletDone(string workorderno)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = @"select count(*) from Goods_In_History where workorderno = @workorderno and In_YN = 'N'";
                    cmd.Parameters.AddWithValue("@workorderno", workorderno);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
                Debug.WriteLine(err.Message);
                return 9999;
            }
        }

        public DataTable GetLOTList(string year)        //년도별 LOT
        {
            try
            {
                string sql = @"select Item_Code, Item_Name, Item_Spec, Item_Unit, LotSize,
			case Item_Type when 'PR' then '완제품'
						when 'PT' then '자재'
						when 'SA' then '반제품'
						else '' end Item_Type
from Item_Master where DATEPART(yyyy, Ins_Date) = @Ins_Date";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();

                    da.SelectCommand.Parameters.AddWithValue("@Ins_Date", year);

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
    }
}
