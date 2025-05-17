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
    public partial class frmRegisterQualityMeasurementsPopUp2 : FinalProject.Detail_Popup
    {
        public delegate void ValueHandler(object sender, ConditionValueArgs e);
        public event ValueHandler ValueEvent;

        string wcCode;
        public frmRegisterQualityMeasurementsPopUp2(SpecificationVO sp)
        {
            InitializeComponent();


            txtCheckItemCode.Text = sp.Inspect_code;
            txtInstructionNum.Text = sp.Workorderno;
            txtProcessCode.Text = sp.Process_code;
            txtProductCode.Text = sp.Item_Code;
            wcCode = sp.Wc_Code;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (nmrCheckResult.Value == 0)
            {
                MessageBox.Show("측정값을 입력해주십시오.");
                return;
            }
            SpecificationVO pv = new SpecificationVO()
            {
                Item_Code = txtProductCode.Text,
                Process_code = txtProcessCode.Text,
                Wc_Code = wcCode,
                Workorderno = txtInstructionNum.Text,
                Inspect_code = txtCheckItemCode.Text,
                Inspect_val = nmrCheckResult.Value,
                Ins_Emp = "로그인관리자"
            };
            SpecificationsService service = new SpecificationsService();
            bool result = service.InsertNewInsValue(pv);
            if (result)
            {
                MessageBox.Show("등록되었습니다.");
                if (ValueEvent != null)
                {
                    ConditionValueArgs args = new ConditionValueArgs();
                    args.ConditionValue = nmrCheckResult.Value;
                    args.ItemCode = txtProductCode.Text;
                    ValueEvent(this, args);
                }
                this.Close();
            }
            else
                MessageBox.Show("등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public class ConditionValueArgs : EventArgs
        {
            public decimal ConditionValue { get; set; }
            public string ItemCode { get; set; }
            public string ItemName { get; set; }
        }
    }
}
