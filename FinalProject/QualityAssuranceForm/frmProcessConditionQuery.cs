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
    public partial class frmProcessConditionQuery : FinalProject.List
    {
        frmMain frm = null;
        List<ProcessVO> prList;

        bool isBookMark = false;
        public frmProcessConditionQuery()
        {
            InitializeComponent();
        }

        private void frmProcessConditionQuery_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvProcessList);
            CommonUtil.AddGridTextColumn(dgvProcessList, "작업지시번호", "Workorderno", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcessList, "생산일", "Prd_Date", colWidth: 110, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcessList, "공정", "Process_Name", colWidth: 110);
            CommonUtil.AddGridTextColumn(dgvProcessList, "작업장", "Wc_Name", colWidth: 110);
            CommonUtil.AddGridTextColumn(dgvProcessList, "품목코드", "Item_Code", colWidth: 110, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcessList, "품목명", "Item_Name", colWidth: 110);
            CommonUtil.AddGridTextColumn(dgvProcessList, "측정항목", "Condition_Name", colWidth: 110);
            CommonUtil.AddGridTextColumn(dgvProcessList, "USL", "USL", colWidth: 110, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcessList, "SL", "SL", colWidth: 110, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcessList, "LSL", "LSL", colWidth: 110, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcessList, "측정일시", "Condition_Date", colWidth: 110, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcessList, "측정회차", "cntConVal", colWidth: 110, align: DataGridViewContentAlignment.MiddleRight);  //일자인거 같은데 일시랑 동일하니 없어도될듯
            CommonUtil.AddGridTextColumn(dgvProcessList, "평균 측정값", "avgConVal", colWidth: 110, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcessList, "단위", "Condition_Unit", colWidth: 110);

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
                if (fr.GetType() == typeof(frmProcessConditionQuery) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmProcessConditionQuery");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmProcessConditionQuery");
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
            //마감한 작업지시
            ProcessService service = new ProcessService();
            prList = service.GetFinishedConditionValue(begDate, endDate);

            dgvProcessList.DataSource = null;
            dgvProcessList.DataSource = prList;

            /*dgvProcessList.Paint += DgvProcessList_Paint; */  //그냥 로우에 색상을 주려니까 자꾸 안먹어서 paint - 그리드뷰를 그리는 이벤트에서 코드를 넣었더니 잘된다

        }

        //private void DgvProcessList_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvProcessList.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvProcessList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvProcessList.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }

            
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmProcessConditionQuery) && frm.ActiveMdiChild == this)
                {
                    LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmProcessConditionQuery) && frm.ActiveMdiChild == this)
                {
                    ProcessService service = new ProcessService();
                    List<ProcessVO> list = service.GetFinishedConditionValue(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

                    if (string.IsNullOrWhiteSpace(txtProcessCode.Text) && string.IsNullOrWhiteSpace(txtProcessName.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvProcessList.DataSource = list;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text) && !string.IsNullOrWhiteSpace(txtProcessName.Text))
                    {
                        dgvProcessList.DataSource = list.FindAll(x => x.Process_code.Contains(txtProcessCode.Text) && x.Process_Name.Contains(txtProcessName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && !string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvProcessList.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text) && x.Wc_Name.Contains(txtWorkPlaceName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text))
                    {
                        dgvProcessList.DataSource = list.FindAll(x => x.Process_code.Contains(txtProcessCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessName.Text))
                    {
                        dgvProcessList.DataSource = list.FindAll(x => x.Process_Name.Contains(txtProcessName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text))
                    {
                        dgvProcessList.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvProcessList.DataSource = list.FindAll(x => x.Wc_Name.Contains(txtWorkPlaceName.Text));
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
