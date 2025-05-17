using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmCarriageHistoryInquiry : FinalProject.List
    {
        frmMain frm = null;
        List<CarriageVO> crList;

        bool isBookMark = false;
        public frmCarriageHistoryInquiry()
        {
            InitializeComponent();
        }

        private void frmCarriageHistoryInquiry_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvCarriageHistory);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "대차코드", "GV_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "대차명", "GV_Name");
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "작업지시번호", "Workorderno",colWidth:140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "품목코드", "Item_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "품목명", "Item_Name");
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "로딩일자", "Loading_date", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "로딩수량", "Loading_Qty", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "로딩시간", "Loading_time", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "로딩작업장", "Loading_Wc", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "요입시간", "In_Time", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "중간시간", "Center_Time", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "요출시간", "Out_Time", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "언로딩수량", "Unloading_Qty", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "언로딩일자", "Unloading_date", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "언로딩일시", "Unloading_datetime", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "언로딩작업장", "Unloading_wc", align: DataGridViewContentAlignment.MiddleCenter);
            //CommonUtil.AddGridTextColumn(dgvCarriageHistory, "대상대차", ""); //뭔지 아직 모르겠어서 일단 제외
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "대차비우기 일자", "Clear_Date", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "대차비우기 일시", "Clear_Datetime", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "대차비우기 수량", "Clear_Qty", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "대차비우기 원인", "Clear_Cause");
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "대상작업장", "Clear_wc", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageHistory, "대상작업장 품목", "Clear_Item");

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


            //대차코드/대차명/작업지시번호/품목코드/품목명/로딩일자/로딩수량/로딩시간/로딩작업장/요입시간/중간시간/요출시간/언로딩수량/언로딩일자/언로딩일시/언로딩작업장/대상대차/대차비우기 일자/대차비우기일시/대차비우기수량/대차비우기원인/대상작업장/대상작업장품목
        }

        private void Frm_BookMarkReg(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCarriageHistoryInquiry) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmCarriageHistoryInquiry");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmCarriageHistoryInquiry");
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

        private void LoadData(string begDate, string endDate)
        {
            CarriageService service = new CarriageService();
            crList = service.GetCarriageHistory(begDate, endDate);

            dgvCarriageHistory.DataSource = null;
            dgvCarriageHistory.DataSource = crList;

            //dgvCarriageHistory.Paint += DgvCarriageHistory_Paint;
        }

        //private void DgvCarriageHistory_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvCarriageHistory.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvCarriageHistory.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvCarriageHistory.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCarriageHistoryInquiry) && frm.ActiveMdiChild == this)
                {
                    LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCarriageHistoryInquiry) && frm.ActiveMdiChild == this)
                {
                    CarriageService service = new CarriageService();
                    List<CarriageVO> list = service.GetCarriageHistory(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

                    if (string.IsNullOrWhiteSpace(txtCarriageCode.Text) && string.IsNullOrWhiteSpace(txtCarriageName.Text) && string.IsNullOrWhiteSpace(txtProductCode.Text) && string.IsNullOrWhiteSpace(txtProductName.Text))
                    {
                        dgvCarriageHistory.DataSource = list;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtCarriageCode.Text) && !string.IsNullOrWhiteSpace(txtCarriageName.Text))
                    {
                        dgvCarriageHistory.DataSource = list.FindAll(x => x.GV_Code.Contains(txtCarriageCode.Text) && x.GV_Name.Contains(txtCarriageName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductCode.Text) && !string.IsNullOrWhiteSpace(txtProductName.Text))
                    {
                        dgvCarriageHistory.DataSource = list.FindAll(x => x.Item_Code.Contains(txtProductCode.Text) && x.Item_Name.Contains(txtProductName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtCarriageCode.Text))
                    {
                        dgvCarriageHistory.DataSource = list.FindAll(x => x.GV_Code.Contains(txtCarriageCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtCarriageName.Text))
                    {
                        dgvCarriageHistory.DataSource = list.FindAll(x => x.GV_Name.Contains(txtCarriageName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductCode.Text))
                    {
                        dgvCarriageHistory.DataSource = list.FindAll(x => x.Item_Code.Contains(txtProductCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductName.Text))
                    {
                        dgvCarriageHistory.DataSource = list.FindAll(x => x.Item_Name.Contains(txtProductName.Text));
                    }
                }
            }
        }

        private void btnCarriageList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("대차");
            frm.Show();

            frm.CodeName += Frm_CodeName;
        }

        private void Frm_CodeName(object sender, CodeNameArgs e)
        {
            txtCarriageCode.Text = e.Code;
            txtCarriageName.Text = e.Name;
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("품목");
            frm.Show();

            frm.CodeName += Frm_CodeName1;
        }

        private void Frm_CodeName1(object sender, CodeNameArgs e)
        {
            txtProductCode.Text = e.Code;
            txtProductName.Text = e.Name;
        }
    }
}
