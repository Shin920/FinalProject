using FinalProject.Service;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmUserM_Addpop : Form
    {
        public frmUserM_Addpop()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserM_Addpop_Load(object sender, EventArgs e)
        {
            lblManager.Text = UserInfo.User_Name;
            lblDay.Text = DateTime.Now.ToShortDateString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtPwd.Text))
            {

                UserInfoVO user = new UserInfoVO
                {
                    User_Name = txtName.Text,
                    User_ID = txtID.Text,
                    User_PW = txtPwd.Text,
                    Ins_Emp = lblManager.Text,
                    Ins_Date = Convert.ToDateTime(lblDay.Text)

                };
                UserInfoService service = new UserInfoService();

                if (service.InsertUser(user))
                {

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {

                    MessageBox.Show("이미 등록된 회원입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("필수항목을 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtName.Text= txtID.Text = txtPwd.Text =lblManager.Text = lblDay.Text="";
        }
    }
}
