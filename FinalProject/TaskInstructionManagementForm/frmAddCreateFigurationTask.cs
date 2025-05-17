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
    public partial class frmAddCreateFigurationTask : FinalProject.Detail_Popup
    {
        List<WorkCenterVO> list;
        

        public WorkReqVO selWorkReq; 
        public frmAddCreateFigurationTask()
        {
            InitializeComponent();
        }

        private void frmAddCreateFigurationTask_Load(object sender, EventArgs e)
        {
            WorkCenterService service = new WorkCenterService();
            list = service.GetWorkCenterList();

            

            lblWoNo.Text = "WK" + DateTime.Now.ToString("yyyyMMddHHmmss");
            txtOrder.Text = selWorkReq.Req_Seq.ToString();
            txtReqNo.Text = selWorkReq.Wo_Req_No.ToString();
            txtICode.Text = selWorkReq.Item_Code;
            txtIName.Text = selWorkReq.Item_Name;
            txtPlanQty.Text = selWorkReq.Req_Qty.ToString();
            txtPlanQUnit.Text = selWorkReq.Item_Unit;

            cboWC.Items.Clear();
            foreach (WorkCenterVO no in list)
            {
                cboWC.Items.Add(no.Wc_Name);
            }
            cboWC.Items.Insert(0, "선택");   //빈값으로 된것도 주려고 (선택없음 역할)

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WorkCenterVO vo = list.Find(x => x.Wc_Name.Equals(cboWC.SelectedItem));
            WorkOrderService service = new WorkOrderService();
            bool result = service.InsertWorkOrder(txtReqNo.Text, lblWoNo.Text, txtICode.Text, vo.Wc_Code, Convert.ToInt32(txtPlanQty.Text), txtPlanQUnit.Text, dtpOrderDate.Value, Convert.ToInt32(txtOrder.Text), txtRemark.Text, "abcd123");
            if (result)
            {
                this.DialogResult = DialogResult.OK;               
                this.Close();
            }
            else
            {
                MessageBox.Show("등록 실패");
                this.Close();
            }
        }
    }
}
