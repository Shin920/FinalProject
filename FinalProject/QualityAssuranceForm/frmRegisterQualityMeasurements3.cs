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
    public partial class frmRegisterQualityMeasurements3 : FinalProject.List_List
    {
        frmMain frm = null;
        List<ProcessVO> workOrderList;

        bool isBookMark = false;
        public frmRegisterQualityMeasurements3()
        {
            InitializeComponent();
        }

        private void frmRegisterQualityMeasurements3_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvInstrutionList);
            CommonUtil.AddGridTextColumn(dgvInstrutionList, "작업지시번호", "Workorderno", colWidth: 135, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInstrutionList, "생산일자", "Prd_Date", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInstrutionList, "공정", "Process_name", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInstrutionList, "작업장", "Wc_Name", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInstrutionList, "품목코드", "Item_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInstrutionList, "품목명", "Item_Name", colWidth: 135);
            CommonUtil.AddGridTextColumn(dgvInstrutionList, "공정코드", "Process_Code", visibility: false);
            CommonUtil.AddGridTextColumn(dgvInstrutionList, "작업장코드", "Wc_Code", visibility: false);

            //작업지시 목록에서 공정측정이 안된 애들을 보여줘야함

            CommonUtil.SetInitGridView(dgvCheckList);
            CommonUtil.AddGridTextColumn(dgvCheckList, "측정항목명", "Inspect_name", colWidth:143);
            CommonUtil.AddGridTextColumn(dgvCheckList, "기준값", "SL", colWidth: 123, align: DataGridViewContentAlignment.MiddleRight);

            CommonUtil.AddGridTextColumn(dgvCheckList, "측정항목코드", "Inspect_code", visibility: false);


            CommonUtil.SetInitGridView(dgvCheckResult);

            //CommonUtil.AddGridTextColumn(dgvCheckResult, "조건순번", "Condition_measure_seq", visibility: false);
            CommonUtil.AddGridTextColumn(dgvCheckResult, "측정일시", "Inspect_date", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCheckResult, "품목코드", "Item_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCheckResult, "품목명", "Item_Name");
            //CommonUtil.AddGridTextColumn(dgvCheckResult, "편차", "Item_Code");
            //측정회차를 추가할수록 컬럼이 하나씩 생성되게
            //CommonUtil.AddGridTextColumn(dgvCheckResult, "1", "Item_Name");
            //CommonUtil.AddGridTextColumn(dgvCheckResult, "2", "Wc_Name");
            //CommonUtil.AddGridTextColumn(dgvCheckResult, "3", "Prd_Qty");
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
                if (fr.GetType() == typeof(frmRegisterQualityMeasurements3) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmRegisterQualityMeasurements3");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmRegisterQualityMeasurements3");
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
            ProcessService service = new ProcessService();
            workOrderList = service.GetNotClearWorkOrderList(begDate, endDate);

            dgvInstrutionList.DataSource = null;
            dgvInstrutionList.DataSource = workOrderList;

            //dgvInstrutionList.Paint += DgvInstrutionList_Paint;

            dgvInstrutionList.Columns[0].Frozen = true;
        }

        //private void DgvInstrutionList_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvInstrutionList.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvInstrutionList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvInstrutionList.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmRegisterQualityMeasurements3) && frm.ActiveMdiChild == this)
                {
                    LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                    txtProcessCode.Text = txtProcessName.Text = txtWorkPlaceCode.Text = txtWorkPlaceName.Text = "";
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmRegisterQualityMeasurements3) && frm.ActiveMdiChild == this)
                {
                    ProcessService service = new ProcessService();
                    List<ProcessVO> list = service.GetNotClearWorkOrderList(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

                    if (string.IsNullOrWhiteSpace(txtProcessCode.Text) && string.IsNullOrWhiteSpace(txtProcessCode.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvInstrutionList.DataSource = list;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text) && !string.IsNullOrWhiteSpace(txtProcessName.Text))
                    {
                        dgvInstrutionList.DataSource = list.FindAll(x => x.Process_code.Contains(txtProcessCode.Text) && x.Process_name.Contains(txtProcessName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && !string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvInstrutionList.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text) && x.Wc_Name.Contains(txtWorkPlaceName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text))
                    {
                        dgvInstrutionList.DataSource = list.FindAll(x => x.Process_code.Contains(txtProcessCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessName.Text))
                    {
                        dgvInstrutionList.DataSource = list.FindAll(x => x.Process_name.Contains(txtProcessName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text))
                    {
                        dgvInstrutionList.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvInstrutionList.DataSource = list.FindAll(x => x.Wc_Name.Contains(txtWorkPlaceName.Text));
                    }
                }
            }
        }
        private void dgvInstrutionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SpecificationsService service = new SpecificationsService();

            dgvCheckList.DataSource = null;
            dgvCheckList.DataSource = service.GetInsSpectValueList(dgvInstrutionList[4, e.RowIndex].Value.ToString(), dgvInstrutionList[6, e.RowIndex].Value.ToString());

            //dgvCheckList.Paint += DgvCheckList_Paint;

            dgvCheckResult.DataSource = null;
            dgvCheckResult.Columns.Clear();

            lblWorkOrderNum.Text = dgvInstrutionList.CurrentRow.Cells[0].Value.ToString();
            lblProcessCode.Text = dgvInstrutionList.CurrentRow.Cells[6].Value.ToString();
            lblItemCode.Text = dgvInstrutionList.CurrentRow.Cells[4].Value.ToString();
            lblWcCode.Text = dgvInstrutionList.CurrentRow.Cells[7].Value.ToString();
            lblItemName.Text = dgvInstrutionList.CurrentRow.Cells[5].Value.ToString();
        }

        //private void DgvCheckList_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvCheckList.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvCheckList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvCheckList.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void dgvCheckList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoaddgvCheckList();
        }
        private void LoaddgvCheckList()
        {
            dgvCheckResult.DataSource = null;
            dgvCheckResult.Columns.Clear();

            CommonUtil.SetInitGridView(dgvCheckResult);
            //CommonUtil.AddGridTextColumn(dgvCheckResult, "조건순번", "Condition_measure_seq", visibility: false);
            CommonUtil.AddGridTextColumn(dgvCheckResult, "측정일시", "Inspect_date", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCheckResult, "품목코드", "Item_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCheckResult, "품목명", "Item_Name");

            SpecificationsService service = new SpecificationsService();
            DataTable dt = service.GetConditionValue(lblWorkOrderNum.Text, dgvCheckList.CurrentRow.Cells[2].Value.ToString());


            foreach (DataRow dr in dt.Rows)     //컬럼에 값이 존재하는만큼만 생성하려고
            {
                if (dt.Columns.Count > 4)
                {
                    for (int i = 4; i <= dt.Columns.Count; i++)
                    {

                        if (dr.IsNull(i - 1) == false)
                        {
                            CommonUtil.AddGridTextColumn(dgvCheckResult, $"{i - 3}", $"{i - 3}", align: DataGridViewContentAlignment.MiddleRight);

                        }
                    }
                }
                //k++;
            }

            dgvCheckResult.DataSource = dt;

            //dgvCheckResult.Paint += DgvCheckResult_Paint;

            dgvCheckResult.Columns[0].Frozen = true;
            dgvCheckResult.Columns[1].Frozen = true;
            dgvCheckResult.Columns[2].Frozen = true;
        }

        //private void DgvCheckResult_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvCheckResult.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvCheckResult.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvCheckResult.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

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

        private void btnAddCheck_Click(object sender, EventArgs e)
        {

            if (dgvCheckList.CurrentRow == null)
            {
                MessageBox.Show("측정값을 추가할 측정항목을 선택해주십시오.");
                return;
            }
            SpecificationVO pv = new SpecificationVO()
            {
                Item_Code = lblItemCode.Text,
                Process_code = lblProcessCode.Text,
                Workorderno = lblWorkOrderNum.Text,
                Inspect_code = dgvCheckList.CurrentRow.Cells[2].Value.ToString(),
                Wc_Code = lblWcCode.Text
            };
            frmRegisterQualityMeasurementsPopUp2 frm = new frmRegisterQualityMeasurementsPopUp2(pv);
            frm.Show();

            frm.ValueEvent += Frm_ValueEvent1;
            
        }

        private void Frm_ValueEvent1(object sender, frmRegisterQualityMeasurementsPopUp2.ConditionValueArgs e)
        {
            LoaddgvCheckList();
        }

        private void Frm_ValueEvent(object sender, ConditionValueArgs e)
        {
            
        }

        private void btnDelCheck_Click(object sender, EventArgs e)
        {
            if (dgvCheckResult.CurrentCell.ColumnIndex < 3 || dgvCheckResult.RowCount < 1)
            {
                MessageBox.Show("삭제할 측정값이 있는 셀을 선택해주십시오.");
                return;
            }
            int idx = dgvCheckResult.CurrentCell.ColumnIndex - 2;

            DialogResult result = MessageBox.Show("해당 측정값을 삭제하시겠습니까?", "측정값 삭제", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SpecificationsService service = new SpecificationsService();
                bool res = service.DeleteInsValue(idx, lblWorkOrderNum.Text);
                if (res)
                {
                    MessageBox.Show("삭제되었습니다.");
                    LoaddgvCheckList();
                }
                else
                    MessageBox.Show("삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }
    }
}
