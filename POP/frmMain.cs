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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }

        public frmMain(string tag)
        {
            InitializeComponent();
            this.Tag = tag;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if(this.Tag == null)
                LoginCheck();

            //시간/날짜 표시
            //2021-06-25(금요일) 오전 02:48:33
            timer1.Start();
            lblDate.Text = $"{DateTime.Now.ToString("yyyy-MM-dd(dddd)")} " + $"{DateTime.Now.ToString("T")}";

            //Tag = $"{user.User_ID}/{user.User_Name}";
            if (this.Tag != null)
                lblUser.Text = $"👤 {this.Tag.ToString().Substring(this.Tag.ToString().IndexOf('/') + 1)} 님";
            pnlLog.Visible = true;
            tblButtons.Visible = true;
            //string text = this.Text;
        }
        private void picLogOut_Click(object sender, EventArgs e)
        {
            pnlLog.Visible = false;
            tblButtons.Visible = false;
            LoginCheck();
        }

        /// <summary>
        /// 로그인하는지, x버튼 눌러서 나가는지 체크
        /// </summary>
        private void LoginCheck()
        {
            frmLogin frm = new frmLogin();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Owner = this;
            if (frm.ShowDialog() == DialogResult.Cancel)
            {
                this.MdiParent.Close();
            }
            else
            {
                this.Tag = this.MdiParent.Tag = frm.Tag;
                pnlLog.Visible = true;
                tblButtons.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = $"{DateTime.Now.ToString("yyyy-MM-dd(dddd)")} " + $"{DateTime.Now.ToString("T")}";
        }

        /// <summary>
        /// 어떤버튼 눌렀는지 mdi 부모폼의 text로 전달
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForming_Click(object sender, EventArgs e)
        {
            this.MdiParent.Text = "성형";
            this.Close();
        }
        private void btnFiring_Click(object sender, EventArgs e)
        {
            this.MdiParent.Text = "소성";
            this.Close();
        }
        private void btnPacking_Click(object sender, EventArgs e)
        {
            this.MdiParent.Text = "포장";
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
