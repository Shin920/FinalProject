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
    public partial class frmAnalysisOfAbsenteeism : FinalProject.List_List_h
    {
        frmMain frm = null;
        DataTable mainDT;

        bool isBookMark = false;
        public frmAnalysisOfAbsenteeism()
        {
            InitializeComponent();
        }

        private void frmAnalysisOfAbsenteeism_Load(object sender, EventArgs e)
        {
            //조회기간 설정한 만큼 근무일자 컬럼생성되게
            //CommonUtil.SetInitGridView(dgvWorkHistory);
            //CommonUtil.AddGridTextColumn(dgvWorkHistory, "사용자ID", "");
            //CommonUtil.AddGridTextColumn(dgvWorkHistory, "사용자명", "");
            //dtp로 지정한 날짜만큼 날짜 컬럼 추가되게
           


            CommonUtil.SetInitGridView(dgvDetailWorkHistory);
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "작업지시번호", "Workorderno", colWidth: 143, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "작업지시상태", "Wo_Status", colWidth: 143);   //없어도되는데 넣어도될듯
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "작업장코드", "Wc_Code", colWidth: 143, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "작업장명", "Wc_Name", colWidth: 143);
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "품목코드", "Item_Code", colWidth: 143, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "품목명", "Item_Name", colWidth: 143);
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "작업시작일시", "Prd_Starttime", colWidth: 142, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "작업종료일시", "Prd_Endtime", colWidth: 142, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "작업시간", "", colWidth: 142);     //없어도되는데 넣어도될듯
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "생산수량", "Prd_Qty", colWidth: 142, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvDetailWorkHistory, "할당작업자", "User_Name", colWidth: 142);

            ucPeriodControl1.dtFrom = DateTime.Now.AddDays(-3).ToShortDateString();
            LoadData();

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
                if (fr.GetType() == typeof(frmAnalysisOfAbsenteeism) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmAnalysisOfAbsenteeism");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmAnalysisOfAbsenteeism");
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

        private void LoadData()
        {
            dgvWorkHistory.Columns.Clear();
            CommonUtil.SetInitGridView(dgvWorkHistory);
            CommonUtil.AddGridTextColumn(dgvWorkHistory, "사용자ID", "User_ID");
            CommonUtil.AddGridTextColumn(dgvWorkHistory, "사용자명", "User_Name");

            DateTime dtFrom = Convert.ToDateTime(ucPeriodControl1.dtFrom);
            DateTime dtTo = Convert.ToDateTime(ucPeriodControl1.dtTo);
            while (dtFrom <= dtTo)
            {
                CommonUtil.AddGridTextColumn(dgvWorkHistory, dtFrom.ToShortDateString(), dtFrom.ToShortDateString());
                dtFrom = dtFrom.AddDays(1);
            }

            WorkHistoryService service = new WorkHistoryService();
            mainDT = service.GetWorkerHistoryPivot(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

            dgvWorkHistory.DataSource = null;
            dgvWorkHistory.DataSource = mainDT;

            //dgvWorkHistory.Paint += DgvWorkHistory_Paint;
            dgvWorkHistory.Columns[0].Frozen = true;
            dgvWorkHistory.Columns[1].Frozen = true;


        }

        //private void DgvWorkHistory_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvWorkHistory.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvWorkHistory.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvWorkHistory.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmAnalysisOfAbsenteeism) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmAnalysisOfAbsenteeism) && frm.ActiveMdiChild == this)
                {
                    
                    if (string.IsNullOrWhiteSpace(txtWorkerID.Text) && string.IsNullOrWhiteSpace(txtWorkerName.Text))
                    {
                        LoadData();
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkerID.Text) && !string.IsNullOrWhiteSpace(txtWorkerName.Text))
                    {
                        WorkHistoryService service = new WorkHistoryService();
                        mainDT = service.GetWorkerHistoryPivot(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);//날짜도 바꾸고 검색명도 입력했을수 있으니까 바뀐 날짜의 테이블을 새로 가져와서 거기서 다시 해야함                
                        
                        DataView dv = mainDT.DefaultView;
                        dv.RowFilter = $"User_Name = '{txtWorkerName.Text}' and User_ID = '{txtWorkerID.Text}'";
                        dgvWorkHistory.DataSource = dv;
                      
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkerID.Text))
                    {
                        WorkHistoryService service = new WorkHistoryService();
                        mainDT = service.GetWorkerHistoryPivot(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);//날짜도 바꾸고 검색명도 입력했을수 있으니까 바뀐 날짜의 테이블을 새로 가져와서 거기서 다시 해야함                

                        DataView dv = mainDT.DefaultView;
                        dv.RowFilter = $"User_ID = '{txtWorkerID.Text}'";
                        dgvWorkHistory.DataSource = dv;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkerName.Text))
                    {
                        WorkHistoryService service = new WorkHistoryService();
                        mainDT = service.GetWorkerHistoryPivot(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);//날짜도 바꾸고 검색명도 입력했을수 있으니까 바뀐 날짜의 테이블을 새로 가져와서 거기서 다시 해야함                

                        DataView dv = mainDT.DefaultView;
                        dv.RowFilter = $"User_Name = '{txtWorkerName.Text}'";
                        dgvWorkHistory.DataSource = dv;

                    }
                }
            }
        }

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

        private void dgvWorkHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 2 || e.RowIndex == -1)    //헤더셀을 클릭했을때 오류 발생함 .  -1로 하면 헤더셀쪽 로우로 인식하네
            {
                MessageBox.Show("조회할 날짜의 셀을 클릭해주십시오.");
                return;
            }

            WorkHistoryService service = new WorkHistoryService();
            List<WorkHistoryVO> list = service.GetWorkerDetailHistory(dgvWorkHistory.Columns[e.ColumnIndex].Name, dgvWorkHistory[0,e.RowIndex].Value.ToString());
            //더블클릭한 셀의 컬럼명이 날짜니까 그 날짜를 넣고 클릭한 로우의 사용자ID를 넣고
            dgvDetailWorkHistory.DataSource = list;
            for (int i = 0; i < list.Count; i++)
            {
                int time = (int)(list[i].Prd_Endtime - list[i].Prd_Starttime).TotalMinutes;
                string strTime = $"{time / 60}시간 {time % 60}분"; 
                dgvDetailWorkHistory[8, i].Value = strTime;
            }
                //8번 셀
           
        }

      
       
    }
}
