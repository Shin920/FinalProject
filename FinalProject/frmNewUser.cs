using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmNewUser : FinalProject.Detail_Popup
    {
        bool isCheck = false;
        public frmNewUser()
        {
            InitializeComponent();
        }

        private void frmNewUser_Load(object sender, EventArgs e)
        {
            //부서정보 바인딩
            LoginService service = new LoginService();
            DataTable dt = service.GetGroupList();

            cboGroup.DisplayMember = "UserGroup_Name";
            cboGroup.ValueMember = "UserGroup_Code";
            cboGroup.DataSource = dt;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("아이디를 입력해주십시오.");
                return;
            }
            LoginService service = new LoginService();
            bool result = service.isOverlap(txtID.Text);

            if (result)
            {
                lblGoodID.Visible = true;
                lblBadID.Visible = false;
                isCheck = true;
            }               
            else
            {
                lblBadID.Visible = true;
                lblGoodID.Visible = false;

            }
                
        }
        private void btnPost_Click(object sender, EventArgs e)
        {
            frmPost frm = new frmPost();           
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtZipCode.Text = frm.Zipcode;
                txtAddr1.Text = frm.Address1;
                txtAddr2.Text = frm.Address2;
            }
        }

      

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in grbConditions.Controls)
            {
                if(ctrl.GetType() == typeof(TextBox))
                {
                    if (string.IsNullOrWhiteSpace(ctrl.Text))
                    {
                        MessageBox.Show("미입력된 항목이 있습니다.");
                        return;
                    }
                        
                }
            }
            if(lblPwdWarning.Visible == true)
            {
                MessageBox.Show("비밀번호는 8~16자리의 영문자, 숫자, 특수기호의 조합이어야 합니다.");
                return;
            }
            else if(txtPwd.Text != txtPwdR.Text)
            {
                MessageBox.Show("비밀번호가 일치하지않습니다.\n다시 입력하여 주십시오.");
                lblPwdWrong.Visible = true;
                return;
            }
            UserVO user = new UserVO()
            {
                User_Name = txtName.Text,
                User_ID = txtID.Text,
                User_PW = txtPwdR.Text,
                UserGroup_Code = cboGroup.SelectedValue.ToString(),
                Phone = txtPhone.Text,
                Email = txtEmail.Text + "@" + txtEmail2.Text,
                AddrZip = txtZipCode.Text,
                Addr1 = txtAddr1.Text,
                Addr2 = txtAddr2.Text,
                Ins_Emp = txtName.Text
            };
            //사용자정보 테이블에 저장시키기
            LoginService service = new LoginService();
            bool result = service.InsertNewUser(user);
            if (result)
            {
                MessageBox.Show("등록되었습니다.");
                this.Close();
            }
            else
                MessageBox.Show("등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 127)
                e.Handled = true;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtPwd_Leave(object sender, EventArgs e)
        {
            //8~16이어야한다 이런 체크
            if(isPassCheck(txtPwd.Text) == false)
            {
                lblPwdWarning.Visible = true;
            }
            else
            {
                lblPwdWarning.Visible = false;
            }
           
        }
        public bool isPassCheck(string pwd)
        {
            if (txtPwd.Text.Length < 8) return false;

            //숫자1이상, 영문1이상, 특수문자1이상
            Regex regexPass = new Regex(@"^(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{9,}$", RegexOptions.IgnorePatternWhitespace);
            return regexPass.IsMatch(pwd);
         
        }

        private void txtPwdR_Leave(object sender, EventArgs e)
        {
            //위에 입력한거랑 동일한지 체크
            if (txtPwd.Text != txtPwdR.Text)
                lblPwdWrong.Visible = true;
            else
                lblPwdWrong.Visible = false;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void cboEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboEmail.SelectedIndex > 0)
            {
                txtEmail2.Text = cboEmail.SelectedItem.ToString();
                
            }
            else
            {
                txtEmail2.Text = "";
            }
        }

        
    }
}
