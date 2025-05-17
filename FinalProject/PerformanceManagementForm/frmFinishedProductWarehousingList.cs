using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmFinishedProductWarehousingList : FinalProject.List
    {
        //string strConn = ConfigurationManager.ConnectionStrings["team2"].ConnectionString;

        CheckBox chbox = new CheckBox();

        frmMain frm = null;
        List<BoxingVO_Finish> boxList;

        bool isBookMark = false;
        public frmFinishedProductWarehousingList()
        {
            InitializeComponent();
        }

        private void frmFinishedProductWarehousingList_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvCompleteProductList);

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvCompleteProductList.Columns.Add(chk);

            Point headerPoint = dgvCompleteProductList.GetCellDisplayRectangle(0, -1, true).Location;
            chbox.Location = new Point(headerPoint.X + 7, headerPoint.Y + 4);
            chbox.Size = new Size(18, 18);
            chbox.BackColor = Color.White;
            chbox.Click += Chbox_Click; ;
            dgvCompleteProductList.Controls.Add(chbox);

            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "생산일자", "Prd_Date", colWidth: 154, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "품목코드", "Item_Code", colWidth: 156, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "품목명", "Item_Name", colWidth: 154);
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "팔레트번호", "Pallet_No", colWidth: 154, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "입고수량", "In_Qty", colWidth: 154, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "마감시각", "Closed_Time", colWidth: 156, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "취소시각", "Cancel_Time", colWidth: 156, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "ERP 업로드여부", "Upload_Flag", colWidth: 154, align: DataGridViewContentAlignment.MiddleCenter);      //뭔지 아직 모르겠는데 없어도 될듯
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "작업지시번호", "Workorderno", colWidth: 154, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "작업지시상태", "Wo_Status", colWidth: 154);
            CommonUtil.AddGridTextColumn(dgvCompleteProductList, "바코드 번호", "Barcode_No", colWidth: 154, visibility:false);

            //생산일자/품목코드/품목명/팔레트번호/입고수량/마감시각/취소시각/ERP 업로드여부/작업지시번호/작업지시상태

            //포장실적이랑 작업지시랑 

            //입고수량은 생산수량인데 입고여부에서 입고되었으면 입고수량인듯 
            ucPeriodControl1.dtFrom = DateTime.Now.AddDays(-3).ToShortDateString();

            LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

            frm = (frmMain)this.MdiParent;

            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
            frm.BookMarkReg += Frm_BookMarkReg;

            //if (frm.BookMarkList != null)
            //{
            //    foreach (string r in frm.BookMarkList)
            //    {
            //        if (this.GetType().ToString().Split('.')[1].Trim() == r.Trim())     //그냥 getType으로 하면 클래스명까지 붙어서 .으로 잘라주고 trim을 양쪽다 안하니 안나와서
            //        {
            //            frm.btnBookMarkColor = Color.Yellow;
            //            isBookMark = true;
            //        }
            //        else
            //        {
            //            frm.btnBookMarkColor = Color.Transparent;   //다른 폼으로 갔는데 거기는 즐겨찾기 아니면 다시 원래 색으로
            //        }
            //    }
            //}
        }

        private void Frm_BookMarkReg(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmFinishedProductWarehousingList) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmFinishedProductWarehousingList");
                        if (result)
                        {
                            MessageBox.Show("즐겨찾기 등록되었습니다.");
                            isBookMark = true;
                            frm.btnBookMarkColor = Color.SteelBlue;
                        }
                        else
                            MessageBox.Show("즐겨찾기 등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }
                    else
                    {
                        MenuService service = new MenuService();
                        bool result = service.DeleteBookMark(frm.UserID, "frmFinishedProductWarehousingList");
                        if (result)
                        {
                            MessageBox.Show("즐겨찾기 해제되었습니다.");
                            isBookMark = false;
                            frm.btnBookMarkColor = Color.FromArgb(57, 61, 70);
                        }

                        else
                            MessageBox.Show("즐겨찾기 해제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }

                }
            }
        }

        private void Chbox_Click(object sender, EventArgs e)
        {
            dgvCompleteProductList.EndEdit();    //체크박스가 체크된걸 가져와야하는데 포커스가 떠나야 가져와져서 이렇게 수정을 마무리한다.

            foreach (DataGridViewRow row in dgvCompleteProductList.Rows)
            {
                DataGridViewCheckBoxCell checkBox = row.Cells["chk"] as DataGridViewCheckBoxCell;
                checkBox.Value = chbox.Checked;
            }
        }

        private void LoadData(string begDate, string endDate)
        {
            BoxingService service = new BoxingService();
            boxList = service.GetFinishedProductList(begDate, endDate);

            dgvCompleteProductList.DataSource = null;
            dgvCompleteProductList.DataSource = boxList;

            //dgvCompleteProductList.Paint += DgvCompleteProductList_Paint;
        }

        //private void DgvCompleteProductList_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvCompleteProductList.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvCompleteProductList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvCompleteProductList.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmFinishedProductWarehousingList) && frm.ActiveMdiChild == this)
                {
                    LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmFinishedProductWarehousingList) && frm.ActiveMdiChild == this)
                {
                    BoxingService service = new BoxingService();
                    List<BoxingVO_Finish> list = service.GetFinishedProductList(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

                    if (string.IsNullOrWhiteSpace(txtProductCode.Text) && string.IsNullOrWhiteSpace(txtProductName.Text))
                    {
                        dgvCompleteProductList.DataSource = list;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductCode.Text) && !string.IsNullOrWhiteSpace(txtProductName.Text))
                    {
                        dgvCompleteProductList.DataSource = list.FindAll(x => x.Item_Code.Contains(txtProductCode.Text) && x.Item_Name.Contains(txtProductName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductCode.Text))
                    {
                        dgvCompleteProductList.DataSource = list.FindAll(x => x.Item_Code.Contains(txtProductCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductName.Text))
                    {
                        dgvCompleteProductList.DataSource = list.FindAll(x => x.Item_Name.Contains(txtProductName.Text));
                    }
                  
                }
            }
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("품목");
            frm.Show();

            frm.CodeName += Frm_CodeName;
        }

        private void Frm_CodeName(object sender, CodeNameArgs e)
        {
            txtProductCode.Text = e.Code;
            txtProductName.Text = e.Name;
        }

        private void btnCreateBarcode_Click(object sender, EventArgs e)
        {
            //////그리드뷰에 체크박스 생성해놓자
           

            //DataBinding();

        }

        private void DataBinding()
        {
            throw new NotImplementedException();
        }

        private void btnOutputBarcode_Click(object sender, EventArgs e)
        {
            List<string> chkPList = new List<string>();           

            for (int i = 0; i < dgvCompleteProductList.Rows.Count; i++)
            {
                bool isCellChecked = (bool)dgvCompleteProductList.Rows[i].Cells[0].EditedFormattedValue;   //EditedFormattedValue 이걸 해줘야 지금 포커스가 가있어도 수정확인이 가능
                if (isCellChecked)
                {
                    chkPList.Add(dgvCompleteProductList.Rows[i].Cells[11].Value.ToString());
                    
                }
            }

            if (chkPList.Count == 0)
            {
                MessageBox.Show("출력할 바코드를 선택해주세요.");
                return;
            }

            string strCheck = string.Join("','", chkPList);

            BoxingService service = new BoxingService();
            DataTable dt = service.GetBarcodeList(strCheck);
            //string sql = @"select Workorderno,Pallet_No,Barcode_No from Goods_In_History where Workorderno in ('" + strCheckworkOrderNum + "') and Pallet_No in ('" + strCheckPalleteID + "')";

            //DataTable dt = new DataTable();
            //using (SqlConnection conn = new SqlConnection(strConn))
            //{
            //    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            //    {
            //        da.Fill(dt);
            //    }
            //}

            XtraReport1_Kim rpt = new XtraReport1_Kim();
            rpt.DataSource = dt;
            XtraRepotPreview_Kim frm = new XtraRepotPreview_Kim(rpt);
        }
    }
}
