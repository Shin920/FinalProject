using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP
{
    public partial class frmVacReasonPopup : Form
    {
        public frmVacReasonPopup()
        {
            InitializeComponent();
        }

        private void frmVacReasonPopup_Load(object sender, EventArgs e)
        {
            
        }

        private void cboReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboReason.Text == "직접입력")
            {
                txtReason.ReadOnly = false;
            }
            else
            {
                txtReason.ReadOnly = true;
                txtReason.Text = "";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmVacateCar frm = (frmVacateCar)this.Owner;
            if (cboReason.Text == "직접입력")
                frm.Reason = txtReason.Text;
            else
                frm.Reason = cboReason.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
