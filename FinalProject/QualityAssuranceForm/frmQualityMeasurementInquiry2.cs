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
    public partial class frmQualityMeasurementInquiry2 : FinalProject.List
    {
        frmMain frm = null;
        List<SpecificationVO> specList;

        bool isBookMark = false;
        public frmQualityMeasurementInquiry2()
        {
            InitializeComponent();
        }

        private void frmQualityMeasurementInquiry2_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvQualityCheckHistory);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "작업지시번호", "Workorderno", colWidth:140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "생산일", "Prd_Date", colWidth: 117, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "공정", "Process_Name", colWidth: 117, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "작업장", "Wc_Name", colWidth: 117, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "품목코드", "Item_Code", colWidth: 117, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "품목명", "Item_Name", colWidth: 120);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "측정항목", "Inspect_name", colWidth: 140);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "USL", "USL", colWidth: 117, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "SL", "SL", colWidth: 117, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "LSL", "LSL", colWidth: 117, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "측정일시", "Inspect_date", colWidth: 117, align: DataGridViewContentAlignment.MiddleCenter);
            //CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "상세품목코드", "avgConVal");
            //CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "상세품목명", "Condition_Unit");
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "측정회차", "cntVal", colWidth: 117, align: DataGridViewContentAlignment.MiddleRight);
            //CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "측정순번", "Condition_Unit");
            CommonUtil.AddGridTextColumn(dgvQualityCheckHistory, "측정값", "avgVal", colWidth: 117, align: DataGridViewContentAlignment.MiddleRight);

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
                if (fr.GetType() == typeof(frmQualityMeasurementInquiry2) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmQualityMeasurementInquiry2");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmQualityMeasurementInquiry2");
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
            SpecificationsService service = new SpecificationsService();
            specList = service.GetFinishedInspectionList(begDate, endDate);

            dgvQualityCheckHistory.DataSource = null;
            dgvQualityCheckHistory.DataSource = specList;

            //dgvQualityCheckHistory.Paint += DgvQualityCheckHistory_Paint;
        }

        //private void DgvQualityCheckHistory_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvQualityCheckHistory.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvQualityCheckHistory.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvQualityCheckHistory.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmQualityMeasurementInquiry2) && frm.ActiveMdiChild == this)
                {
                    LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmQualityMeasurementInquiry2) && frm.ActiveMdiChild == this)
                {
                    SpecificationsService service = new SpecificationsService();
                    List<SpecificationVO> list = service.GetFinishedInspectionList(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

                    if (string.IsNullOrWhiteSpace(txtProcessCode.Text) && string.IsNullOrWhiteSpace(txtProcessName.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvQualityCheckHistory.DataSource = list;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text) && !string.IsNullOrWhiteSpace(txtProcessName.Text))
                    {
                        dgvQualityCheckHistory.DataSource = list.FindAll(x => x.Process_code.Contains(txtProcessCode.Text) && x.Process_Name.Contains(txtProcessName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && !string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvQualityCheckHistory.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text) && x.Wc_Name.Contains(txtWorkPlaceName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text))
                    {
                        dgvQualityCheckHistory.DataSource = list.FindAll(x => x.Process_code.Contains(txtProcessCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessName.Text))
                    {
                        dgvQualityCheckHistory.DataSource = list.FindAll(x => x.Process_Name.Contains(txtProcessName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text))
                    {
                        dgvQualityCheckHistory.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvQualityCheckHistory.DataSource = list.FindAll(x => x.Wc_Name.Contains(txtWorkPlaceName.Text));
                    }
                }
            }
        }

        private void btnProcessList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("공정");
            frm.Show();

            frm.CodeName += Frm_CodeName;
        }

        private void Frm_CodeName(object sender, CodeNameArgs e)
        {
            txtProcessCode.Text = e.Code;
            txtProcessName.Text = e.Name;
        }

        private void btnWorkPlaceList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("작업장");
            frm.Show();

            frm.CodeName += Frm_CodeName1;
        }

        private void Frm_CodeName1(object sender, CodeNameArgs e)
        {
            txtWorkPlaceCode.Text = e.Code;
            txtWorkPlaceName.Text = e.Name;
        }
    }
}
