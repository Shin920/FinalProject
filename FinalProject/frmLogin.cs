using FinalProject.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"../../Image/ico.ico"; 
            pnlSearch.Visible = true;
            panel1.Visible = false;
            lblFindPwd.Visible = true;
            lblSignUp.Visible = true;
            lblBack.Visible = false;
            //btnPwdSearch.Visible = false;
            btnLogin.Visible = true;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //유효성 검사
            if(string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("아이디를 입력해주십시오.");
                return;
            }
            if(string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("비밀번호를 입력해주십시오.");
                return;
            }
            LoginService service = new LoginService();
            string name = service.IsUserLogin(txtID.Text, txtpassword.Text);

            if (name == null)
            {
                MessageBox.Show("일치하는 사용자가 없습니다.");
                txtID.Text = txtpassword.Text = "";
                return;
            }
            this.Hide();
            frmMain main = new frmMain(txtID.Text.Trim(), this);     //로그인폼 객체도 넘겨준다
            main.Show();
        }

        public void ClearText()
        {
            txtID.Text = txtpassword.Text = "";
        }

        private void btnPwdSearch_Click(object sender, EventArgs e)
        {
            string pwd =  CreatePassword();

            LoginService service = new LoginService();
            bool upd = service.UpdatePassWord(txtIDS.Text, pwd);

            if(!upd)
            {
                MessageBox.Show("다시 시도하여 주십시오.");
                return;
            }
            
            bool result = SendMail(txtIDS.Text, txtEmailS.Text, pwd);
            if (result)
                MessageBox.Show("새 비밀번호가 메일로 발송되었습니다.");          
            else           
                MessageBox.Show("메일 발송 중 오류가 발생했습니다.");

           
        }
        private string CreatePassword()     //비밀번호 재생성
        {
            //신규비밀번호(난수 8자리 - 영어대문자+숫자)
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int temp = rnd.Next(1, 36);
                if (temp < 10)
                    sb.Append(temp);
                else
                    sb.Append((char)(temp + 55));
            }
            return sb.ToString();
        }
        private bool SendMail(string name, string email, string newPwd)     //메일 발송
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("k8325172@gmail.com", "abcd");

                MailAddress mailTo = new MailAddress(email);
                MailAddress mailFrom = new MailAddress("k8325172@gmail.com");

                MailMessage message = new MailMessage(mailFrom, mailTo);
                message.Subject = $"{name}님의 비밀번호 초기화 안내 메일입니다.";
                message.Body = $"{name}님의 비밀번호는 {newPwd}으로 초기화 되었습니다.\n 로그인해주십시오.";

                message.SubjectEncoding = Encoding.UTF8;
                message.BodyEncoding = Encoding.UTF8;

                client.Send(message);

                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }

        }
        private void label1_Click(object sender, EventArgs e)       //뒤로가기 라벨
        {
            panel1.Visible = false;
            pnlSearch.Visible = true;
            lblFindPwd.Visible = true;
            lblSignUp.Visible = true;
            lblBack.Visible = false;
        }

        private void lblFindPwd_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            pnlSearch.Visible = false;
            lblFindPwd.Visible = false;
            lblSignUp.Visible = false;
            lblBack.Visible = true;
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            frmNewUser frm = new frmNewUser();
            frm.ShowDialog();
        }
    }
}
