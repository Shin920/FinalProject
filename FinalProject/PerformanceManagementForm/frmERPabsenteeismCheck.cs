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
    public partial class frmERPabsenteeismCheck : FinalProject.List
    {
        frmMain frm = null;
        List<WorkHistoryVO_Simple> whList;
        //List<WorkHistoryVO> selectList = new List<WorkHistoryVO>();

        bool isBookMark = false;
        public frmERPabsenteeismCheck()
        {
            InitializeComponent();
        }

        private void frmERPabsenteeismCheck_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvWorkHistory);
            CommonUtil.AddGridTextColumn(dgvWorkHistory, "근무일", "Work_Date", colWidth: 262, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkHistory, "작업장", "Wc_Name", colWidth: 262, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkHistory, "작업자", "User_Name", colWidth: 262);
            CommonUtil.AddGridTextColumn(dgvWorkHistory, "근무시작시간", "Work_StartTime", colWidth: 262, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkHistory, "근무종료시간", "Work_EndTime", colWidth: 262, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkHistory, "근무시간", "Work_Time", colWidth: 262);

           
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
                if (fr.GetType() == typeof(frmERPabsenteeismCheck) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmERPabsenteeismCheck");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmERPabsenteeismCheck");
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

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmERPabsenteeismCheck) && frm.ActiveMdiChild == this)
                {
                    LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmERPabsenteeismCheck) && frm.ActiveMdiChild == this)
                {
                    WorkHistoryService service = new WorkHistoryService();
                    List<WorkHistoryVO_Simple> list = service.GetWorkHistory(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                    //if (selectList.Count > 0)
                    //{
                    //    selectList.Clear();
                    //}

                    //selectList = list;
                    dgvWorkHistory.DataSource = null;
                    dgvWorkHistory.DataSource = list;

                    if (string.IsNullOrWhiteSpace(txtWorkerID.Text) && string.IsNullOrWhiteSpace(txtWorkerName.Text))
                    {
                        dgvWorkHistory.DataSource = null;
                        dgvWorkHistory.DataSource = list;
                        //if (selectList.Count > 0)
                        //{
                        //    selectList.Clear();
                        //}
                        //selectList = list;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkerID.Text) && !string.IsNullOrWhiteSpace(txtWorkerName.Text))
                    {
                        //if (selectList.Count > 0)
                        //{
                        //    selectList.Clear();
                        //}
                        //selectList = list.FindAll(x => x.User_ID.Contains(txtWorkerID.Text) && x.User_Name.Contains(txtWorkerName.Text));
                        dgvWorkHistory.DataSource = null;
                        dgvWorkHistory.DataSource = list.FindAll(x => x.User_ID.Contains(txtWorkerID.Text) && x.User_Name.Contains(txtWorkerName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkerID.Text))
                    {
                        //if (selectList.Count > 0)
                        //{
                        //    selectList.Clear();
                        //}
                        //selectList = list.FindAll(x => x.User_ID.Contains(txtWorkerID.Text));
                        dgvWorkHistory.DataSource = null;
                        dgvWorkHistory.DataSource = list.FindAll(x => x.User_ID.Contains(txtWorkerID.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkerName.Text))
                    {
                        //if (selectList.Count > 0)
                        //{
                        //    selectList.Clear();
                        //}
                        //selectList = list.FindAll(x => x.User_Name.Contains(txtWorkerName.Text));
                        dgvWorkHistory.DataSource = null;
                        dgvWorkHistory.DataSource = list.FindAll(x => x.User_Name.Contains(txtWorkerName.Text));
                    }

                }
            }
        }

        private void LoadData(string begDate, string endDate)
        {
            WorkHistoryService service = new WorkHistoryService();
            whList = service.GetWorkHistory(begDate, endDate);

            dgvWorkHistory.DataSource = null;
            dgvWorkHistory.DataSource = whList;

           // dgvWorkHistory.Paint += DgvWorkHistory_Paint;
        }

        //private void DgvWorkHistory_Paint(object sender, PaintEventArgs e)
        //{
        //    //for (int i = 0; i < dgvWorkHistory.Rows.Count; i++)
        //    //{
        //    //    if (i % 2 != 0)
        //    //    {
        //    //        this.dgvWorkHistory.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //    //    }
        //    //    else
        //    //    {
        //    //        this.dgvWorkHistory.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //    //    }
        //    //}
        //}

        private void btnWorkerList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("근무자");
            frm.Show();

            frm.CodeName += Frm_CodeName;
        }

        private void Frm_CodeName(object sender, CodeNameArgs e)
        {
            txtWorkerID.Text = e.Code;
            txtWorkerName.Text = e.Name;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dlg = new SaveFileDialog();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    bool result = ExcelUtil.ExportExcelToList<WorkHistoryVO>(selectList, dlg.FileName, "Workers");
            //    //bool result = ExcelUtil.exp

            //    if (result)
            //    {
            //        MessageBox.Show("엑셀 다운로드 완료");
            //    }
            //    else
            //        MessageBox.Show("엑셀 다운로드 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            //}



        }
    }
}
