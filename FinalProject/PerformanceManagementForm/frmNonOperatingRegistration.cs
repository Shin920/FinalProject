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
    public partial class frmNonOperatingRegistration : FinalProject.List
    {
        frmMain frm = null;
        List<NonOperationVO> nopList;

        bool isBookMark = false;
        public frmNonOperatingRegistration()
        {
            InitializeComponent();
        }

        private void frmNonOperatingRegistration_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvNopHistory);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "비가동일자", "Nop_Date", colWidth:157, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "작업장코드", "Wc_Code", colWidth: 157, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "작업장명", "Wc_Name", colWidth: 157);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "비가동대분류", "Nop_Ma_Name", colWidth: 157);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "비가동상세분류", "Nop_Mi_Name", colWidth: 157);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "비가동발생시각", "Nop_Happentime", colWidth: 157, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "비가동종료시각", "Nop_Canceltime", colWidth: 157, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "비가동시간", "Nop_Time", colWidth: 157);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "비고", "Remark", colWidth: 157);
            CommonUtil.AddGridTextColumn(dgvNopHistory, "발생유형", "Nop_Type", colWidth: 157);

            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.Insert += Frm_Insert;
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


            //수정,삭제는 버튼 Enable false로 하기 (이 로드 이벤트에 이폼이 mdi자식에 맨 앞에 있는 폼인지 확인하고 그러면 두개의 버튼 enable=false => mdi쪽에서 이 폼열때 코딩해야할수도
            ucPeriodControl1.dtFrom = DateTime.Now.AddDays(-3).ToShortDateString();

            LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
        }

        private void Frm_BookMarkReg(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperatingRegistration) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmNonOperatingRegistration");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmNonOperatingRegistration");
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
            NonOperationService service = new NonOperationService();
            nopList = service.GetNopHistory(begDate, endDate);

            dgvNopHistory.DataSource = null;
            dgvNopHistory.DataSource = nopList;

            //dgvNopHistory.Paint += DgvNopHistory_Paint;
        }

        //private void DgvNopHistory_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvNopHistory.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvNopHistory.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvNopHistory.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperatingRegistration) && frm.ActiveMdiChild == this)
                {
                    LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                }
            }
        }
        
        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperatingRegistration) && frm.ActiveMdiChild == this)
                {
                    frmNonOperatingRegistrationPopUp2 frm = new frmNonOperatingRegistrationPopUp2();
                    frm.Show();

                    frm.SaveEvent += Frm_SaveEvent;

                    break;
                }
            }
        }

        private void Frm_SaveEvent(object sender, EventArgs e)
        {
            LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperatingRegistration) && frm.ActiveMdiChild == this)
                {
                    NonOperationService service = new NonOperationService();
                    nopList = service.GetNopHistory(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

                    if (string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                        dgvNopHistory.DataSource = nopList;
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && !string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                        dgvNopHistory.DataSource = nopList.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text) && x.Wc_Name.Contains(txtWorkPlaceName.Text));
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text))
                        dgvNopHistory.DataSource = nopList.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text));
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                        dgvNopHistory.DataSource = nopList.FindAll(x => x.Wc_Name.Contains(txtWorkPlaceName.Text));
                }
            }
        }
      

        private void btnWorkPlaceList_Click(object sender, EventArgs e)
        {
            //열때 code랑 name이 있는 리스트를 넘겨서 거기서 보여줄수있게
            //여기서 작업장코드,이름 조회해오는 service 사용해서 List를 만들어서 생성자로 보내주고
            //열리는 폼에서는 그리드뷰에 이 List를 바인딩해서 보여주기만 하면됨. 그리고
            //거기서 어떤 로우를 더블클릭햇으면 그 정보를 이벤트로 MDI타고 여기로 보내주면 된다.
        
            frmGridPopUp frm = new frmGridPopUp("작업장");
            frm.Show();

            frm.CodeName += Frm_CodeName;
        }

        private void Frm_CodeName(object sender, CodeNameArgs e)
        {
            txtWorkPlaceCode.Text = e.Code;
            txtWorkPlaceName.Text = e.Name;
        }
    }
}
