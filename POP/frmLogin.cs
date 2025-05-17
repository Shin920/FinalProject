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

namespace POP
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 로그인, 사원증 바코드 찍거나 직접 입력하여 로그인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //1. 직접 입력하여 로그인
            //유효성 체크
            StringBuilder sb = new StringBuilder();
            //아무것도 입력 안하고 로그인 하는 경우
            if (txtID.Text.Trim().Length == 0 && txtpassword.Text.Trim().Length == 0)
                return;

            if (txtID.Text.Trim().Length == 0)
                sb.Append("아이디");
            if (txtpassword.Text.Trim().Length == 0)
                sb.Append("비밀번호");

            if(sb.Length > 0)
            {
                MessageBox.Show(sb.ToString() + "를 입력해주세요.");
                return;
            }
            //2. 바코드 찍어서 로그인


            //아이디 비밀번호 모두 입력한 경우
            UserService service = new UserService();
            UserVO user = service.GetUserIDName(txtID.Text, txtpassword.Text);
            if(user != null)
            {
                this.Tag = $"{user.User_ID}/{user.User_Name}";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if(user == null)
            {
                MessageBox.Show("해당하는 사원정보가 없습니다.");
                return;
            }
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Form1 main = (Form1)this.Owner.MdiParent;
            main.ReadCompleted += Main_ReadCompleted;
        }
        private void Main_ReadCompleted(object sender, ReadEventAgrs e)
        {
            if (((Form1)this.Owner.MdiParent).ActiveMdiChild != this.Owner) return;

            string idpwd = e.ReadMessage;
            string[] ID_PWD = idpwd.Split('/');
            //바코드를 id/pwd로 받아온다면 -> split 이용
            txtID.Text = ID_PWD[0];
            txtpassword.Text = ID_PWD[1];
        }

    }

}
