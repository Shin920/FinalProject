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
    public partial class frmPerformanceCheck : FinalProject.List
    {
        frmMain frm = null;
        List<WorkOrderVO> wcList;

        bool isBookMark = false;
        public frmPerformanceCheck()
        {
            InitializeComponent();
        }

        private void frmPerformanceCheck_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvResult);
            CommonUtil.AddGridTextColumn(dgvResult, "작업지시일자", "Prd_Date", colWidth: 160, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvResult, "작업지시상태", "Wo_Status", colWidth: 131);
            CommonUtil.AddGridTextColumn(dgvResult, "작업지시번호", "Workorderno", colWidth: 160, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvResult, "품목코드", "Item_Code", colWidth: 160, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvResult, "품목명", "Item_Name", colWidth: 160);
            CommonUtil.AddGridTextColumn(dgvResult, "작업장", "Wc_Name", colWidth: 160);
            CommonUtil.AddGridTextColumn(dgvResult, "공정명", "Process_Name", colWidth: 160);
            CommonUtil.AddGridTextColumn(dgvResult, "투입수량", "In_Qty_Main", colWidth: 160, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvResult, "산출수량", "Out_Qty_Main", colWidth: 160, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvResult, "생산수량", "Prd_Qty", colWidth: 160, align: DataGridViewContentAlignment.MiddleRight);

            ucPeriodControl1.dtFrom = DateTime.Now.AddDays(-1).ToString();

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
                if (fr.GetType() == typeof(frmPerformanceCheck) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmPerformanceCheck");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmPerformanceCheck");
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
            WorkOrderService service = new WorkOrderService();
            wcList = service.GetWorkOrderHistory(begDate, endDate);

            dgvResult.DataSource = null;
            dgvResult.DataSource = wcList;

            //dgvResult.Paint += DgvResult_Paint;
        }

        //private void DgvResult_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvResult.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvResult.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvResult.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmPerformanceCheck) && frm.ActiveMdiChild == this)
                {
                    LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                }
            }
           
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmPerformanceCheck) && frm.ActiveMdiChild == this)
                {

                    WorkOrderService service = new WorkOrderService();
                    List<WorkOrderVO> list = service.GetWorkOrderHistory(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

                    if (string.IsNullOrWhiteSpace(txtProcessCode.Text) && string.IsNullOrWhiteSpace(txtProcessName.Text) && string.IsNullOrWhiteSpace(txtworkPlaceCode.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvResult.DataSource = list;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text) && !string.IsNullOrWhiteSpace(txtProcessName.Text))
                    {
                        dgvResult.DataSource = list.FindAll(x => x.Process_code.Contains(txtProcessCode.Text) && x.Process_Name.Contains(txtProcessName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtworkPlaceCode.Text) && !string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvResult.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtworkPlaceCode.Text) && x.Wc_Name.Contains(txtWorkPlaceName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text))
                    {
                        dgvResult.DataSource = list.FindAll(x => x.Process_code.Contains(txtProcessCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessName.Text))
                    {
                        dgvResult.DataSource = list.FindAll(x => x.Process_Name.Contains(txtProcessName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtworkPlaceCode.Text))
                    {
                        dgvResult.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtworkPlaceCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvResult.DataSource = list.FindAll(x => x.Wc_Name.Contains(txtWorkPlaceName.Text));
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
            txtworkPlaceCode.Text = e.Code;
            txtWorkPlaceName.Text = e.Name;
        }

        private void btnResultModify_Click(object sender, EventArgs e)
        {
            if(dgvResult.CurrentRow == null)
            {
                MessageBox.Show("실적보정할 항목을 선택해주십시오.");
                return;
            }

            WorkOrderVO wv = new WorkOrderVO()
            {
                Plan_Date = Convert.ToDateTime(dgvResult.CurrentRow.Cells[0].Value),
                Wo_Status = dgvResult.CurrentRow.Cells[1].Value.ToString(),
                Workorderno = dgvResult.CurrentRow.Cells[2].Value.ToString(),
                Item_Code = dgvResult.CurrentRow.Cells[3].Value.ToString(),
                Item_Name = dgvResult.CurrentRow.Cells[4].Value.ToString(),
                Wc_Name = dgvResult.CurrentRow.Cells[5].Value.ToString(),
                Process_Name = dgvResult.CurrentRow.Cells[6].Value.ToString(),
                In_Qty_Main = Convert.ToInt32(dgvResult.CurrentRow.Cells[7].Value),
                Out_Qty_Main = Convert.ToInt32(dgvResult.CurrentRow.Cells[8].Value),
                Prd_Qty = Convert.ToInt32(dgvResult.CurrentRow.Cells[9].Value)
            };

            frmPerformanceModify2 frm = new frmPerformanceModify2(wv);
            frm.Show();
            //이때 번호는 현재 이 폼 그리드뷰에 번호컬럼 추가할거면 주고 아니면 팝업창에 번호 텍스트박스도 없애기

            frm.Clear += Frm_Clear;
        }

        private void Frm_Clear(object sender, EventArgs e)
        {
            LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
        }
    }
}
