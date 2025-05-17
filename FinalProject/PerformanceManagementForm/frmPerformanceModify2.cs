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
    public partial class frmPerformanceModify2 : FinalProject.Detail_Popup
    {
        public event EventHandler Clear;
        WorkOrderVO wv;
        public frmPerformanceModify2(WorkOrderVO wv)
        {
            InitializeComponent();

            this.wv = wv;
        }

        private void frmPerformanceModify2_Load(object sender, EventArgs e)
        {
            txtNumber.Text = "";        //아직 미정
            txtInstructionNum.Text = wv.Workorderno;
            txtInstructionDate.Text = wv.Plan_Date.ToString();
            txtInstructionCondition.Text = wv.Wo_Status;
            txtInsertQty.Text = wv.In_Qty_Main.ToString();
            txtCalcQty.Text = wv.Out_Qty_Main.ToString();
            txtProcessName.Text = wv.Process_Name;
            txtProductCode.Text = wv.Item_Code;
            txtProductName.Text = wv.Item_Name;
            txtResultQty.Text = wv.Prd_Qty.ToString();
            txtWorkPlace.Text = wv.Wc_Name;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtResultQty.Text))
            {
                MessageBox.Show("수정할 생산수량을 입력해주십시오.");
                return;
            }

            WorkOrderService service = new WorkOrderService();
            bool result = service.UpdatePrdQty(txtResultQty.Text, txtInstructionNum.Text);
            if (result)
            {
                MessageBox.Show("수정되었습니다.");               
                if(Clear != null)
                {
                    Clear(this, null);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("수정 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");               
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtResultQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
