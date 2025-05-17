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
    public partial class frmProcessConditionRegistrationPopUp2 : FinalProject.Detail_Popup
    {
        public delegate void ValueHandler(object sender, ConditionValueArgs e);
        public event ValueHandler ValueEvent;

        string wcCode;
        public frmProcessConditionRegistrationPopUp2(ProcessVO pv)
        {
            InitializeComponent();

            txtIChecktemCode.Text = pv.Condition_Code;
            txtInstructionNum.Text = pv.Workorderno;
            txtProcessCode.Text = pv.Process_code;
            txtProductCode.Text = pv.Item_Code;
            wcCode = pv.Wc_Code;
        }

        private void frmProcessConditionRegistrationPopUp2_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (nmrResult.Value == 0)
            {
                MessageBox.Show("측정값을 입력해주십시오.");
                return;
            }
            ProcessVO pv = new ProcessVO()
            {
                Item_Code = txtProductCode.Text,
                Process_code = txtProcessCode.Text,
                Wc_Code = wcCode,
                Workorderno = txtInstructionNum.Text,
                Condition_Code = txtIChecktemCode.Text,
                Condition_Val = nmrResult.Value,
                Ins_Emp = "로그인관리자"
            };
            ProcessService service = new ProcessService();
            bool result = service.InsertNewConditionValue(pv);
            if (result)
            {
                MessageBox.Show("등록되었습니다.");
                if(ValueEvent != null)
                {
                    ConditionValueArgs args = new ConditionValueArgs();
                    args.ConditionValue = nmrResult.Value;
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
    }

    public class ConditionValueArgs : EventArgs
    {
        public decimal ConditionValue { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
    }
}
