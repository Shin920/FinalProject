using FinalProject.Service;
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
    public partial class frmEndTaskMgmt : FinalProject.List_b
    {
        frmMain frm;
        List<WorkOrderVO> list;
        List<WorkCenterVO> wlist;
        public frmEndTaskMgmt()
        {
            InitializeComponent();
        }

        private void frmEndTaskMgmt_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.UpDate += Frm_UpDate;
            frm.Refresh += Frm_Refresh;
            dtpFdate.Value = dtpLdate.Value.AddMonths(-1);

            CommonUtil.SetInitGridView(dgvOrder);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업지시상태", "Wo_Status", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업지시번호", "Workorderno", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "계획일자", "Plan_Date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "계획수량", "Plan_Qty", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "계획수량단위", "Plan_Unit", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "품목코드", "Item_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "품목명", "Item_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업장명", "Wc_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업일자", "Prd_Date", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업시작시간", "Prd_Starttime", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업종료시간", "Prd_Endtime", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "투입수량", "In_Qty_Main", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "산출수량", "Out_Qty_Main", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "생산수량", "Prd_Qty", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "생산의뢰순번", "Req_Seq", colWidth: 130);

            LoadData();
        }

        private void LoadData()
        {
            WorkOrderService service = new WorkOrderService();
            list = service.GetWorkOrderList();
            dgvOrder.DataSource = null;
            dgvOrder.DataSource = list;

            //WorkCenterService service2 = new WorkCenterService();
            //wlist = service2.GetWorkCenterList();
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmEndTaskMgmt) && frm.ActiveMdiChild == this)
                {
                    if (string.IsNullOrWhiteSpace(txtPlanUnit.Text))
                    {
                        MessageBox.Show("항목을 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "작업지시 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        WorkOrderService service = new WorkOrderService();
                        WorkOrderVO no = new WorkOrderVO()
                        {
                            Workorderno = txtUdtNo.Text,
                            Plan_Date = dtpUdtDate.Value,
                            Plan_Qty = Convert.ToInt32(nmcPlanQty.Value),
                            Plan_Unit = txtPlanUnit.Text,
                            Up_Emp = "로그인관리자"
                        };
                        bool result = service.UpdateWorkOrder(no);
                        if (result)
                        {
                            MessageBox.Show("수정되었습니다.");
                            LoadData();
                            CommonUtil.ClearTextBox(pnlCondition);
                        }
                        else
                            MessageBox.Show("수정 중 오류가 발생하였습니다.\n다시 시도하여 주십시오");
                    }
                }
            }
        }

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmEndTaskMgmt) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }

        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmEndTaskMgmt) && frm.ActiveMdiChild == this)
                {

                    WorkOrderService service = new WorkOrderService();
                    list = service.SearchWorkOrderList(dtpFdate.Value.ToString("yyyy-MM-dd"), dtpLdate.Value.ToString("yyyy-MM-dd"));
                    dgvOrder.DataSource = null;
                    dgvOrder.DataSource = list;

                }
            }
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentRow.Cells[0].Value.ToString() == "현장마감")
            {
                WorkOrderService service = new WorkOrderService();
                bool result = service.FinishWorkOrder(dgvOrder.CurrentRow.Cells[1].Value.ToString());


                WorkCenterVO vo = wlist.Find(x => x.Wc_Name.Equals(dgvOrder.CurrentRow.Cells[7].Value.ToString()));

                //string magid = service.GetUserID(vo.Wc_Code);
                WorkOrderVO no = list.Find(x => x.Workorderno.Equals(dgvOrder.CurrentRow.Cells[1].Value.ToString()));

                bool result2 = service.SetClose(dgvOrder.CurrentRow.Cells[1].Value.ToString(), no.Ins_Emp, vo.Wc_Code);
                if (result)
                {
                    MessageBox.Show("마감되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("마감 실패");
            }
            else
            {
                MessageBox.Show("현장마감된 작업지시만 마감할 수 있습니다.");
                return;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (dgvOrder.CurrentRow.Cells[0].Value.ToString() == "작업지시마감")
            {

                WorkOrderService service = new WorkOrderService();
                bool result = service.CancelFinish(dgvOrder.CurrentRow.Cells[1].Value.ToString());
                if (result)
                {
                    MessageBox.Show("취소되었습니다..");
                    LoadData();
                }
                else
                    MessageBox.Show("취소 실패");
            }
            else
            {
                MessageBox.Show("마감된 작업지시가 아닙니다.");
            }
        }

        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUdtNo.Text = dgvOrder.CurrentRow.Cells[1].Value.ToString();
            txtUdtCode.Text = dgvOrder.CurrentRow.Cells[5].Value.ToString();
            txtUdtName.Text = dgvOrder.CurrentRow.Cells[6].Value.ToString();
            dtpUdtDate.Value = (DateTime)dgvOrder.CurrentRow.Cells[2].Value;
            nmcPlanQty.Value = Convert.ToInt32(dgvOrder.CurrentRow.Cells[3].Value);
            txtPlanUnit.Text = dgvOrder.CurrentRow.Cells[4].Value.ToString();

        }
    }
}
