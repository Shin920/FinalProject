using FinalProject.Service;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP
{
    public partial class Form1 : Form
    {
        public delegate void BarcodeReadComplete(object sender, ReadEventAgrs e);
        public event BarcodeReadComplete ReadCompleted;
        List<NoticeVO> noticeList;
        int idx = 0;

        SerialPort _port;
        public SerialPort Port
        {
            get
            {
                if (_port == null)
                {
                    _port = new SerialPort();
                    _port.DataReceived += Port_DataReceived;
                }

                return _port;
            }
        }

        public bool IsOpen { get; set; }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);

            string msg = _port.ReadExisting();
            this.Invoke(new EventHandler(delegate {
                if (ReadCompleted != null)
                {
                    ReadEventAgrs args = new ReadEventAgrs();
                    args.ReadMessage = msg;
                    ReadCompleted(this, args);
                }
            }));
        }

        UserVO user;
        private Form activeForm = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IsOpen = false;
            SerialPortConnection();
            LogIn();
            lblDate.Text = $"{DateTime.Now.ToString("yyyy-MM-dd(dddd)")} " + $"{DateTime.Now.ToString("T")}";
            timer1.Start();
            timer2.Start();

            //frmReCreatePalette frm = new frmReCreatePalette();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();

            NoticeService service = new NoticeService();
            noticeList = service.GetUsedNoticeList();
            if(noticeList.Count > 0)
            {
                label3.Text = noticeList[0].Description;
            }
            else
            {
                label3.Text = "등록된 공지사항이 없습니다.";
            }
        }

        private void SerialPortConnection()
        {
            if (!IsOpen) // btnConnect.Text == "연결"
            {
                Port.PortName = Properties.Settings.Default.PortName;
                Port.BaudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate);
                Port.DataBits = Convert.ToInt32(Properties.Settings.Default.DataSize);

                Parity par = Parity.None;
                if (Properties.Settings.Default.Parity == "odd")
                    par = Parity.Odd;
                else if (Properties.Settings.Default.Parity == "even")
                    par = Parity.Even;
                Port.Parity = par;

                Port.Handshake = Handshake.None;

                try
                {
                    Port.Open();
                    IsOpen = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    IsOpen = false;
                }
            }
            else //연결끊기
            {
                Port.Close();
                IsOpen = false;
            }
        }


        /// <summary>
        /// 메인폼에서 부모폼의 text에 전달한 폼 열리게함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_TextChanged(object sender, EventArgs e)
        {
            if (this.Text != null && this.Text != "")
            {
                pnlHeader.Visible = true;
                pnlNotice.Visible = true;
                lblUser.Text = $"👤 {this.Tag.ToString().Substring(this.Tag.ToString().IndexOf('/') + 1)} 님";
                //user tag에 아이디 담아두기
                lblUser.Tag = this.Tag.ToString().Substring(0, this.Tag.ToString().IndexOf('/') - 1);
                if (this.Text == "성형")
                {
                    openChildForm(new frmForming());
                }
                else if (this.Text == "소성")
                {
                    openChildForm(new frmLoadFiring());
                }
                else if (this.Text == "포장")
                {
                    openChildForm(new frmPacking());
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Text = null;
            LogIn();
        }

        /// <summary>
        /// 로그인화면으로 이동
        /// </summary>
        private void LogIn()
        {
            pnlHeader.Visible = false;
            pnlNotice.Visible = false;
            timer1.Stop();
            openChildForm(new frmMain());
        }

        /// <summary>
        /// 자식폼 열기
        /// </summary>
        /// <param name="childForm"></param>
        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.MdiParent = this;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        /// <summary>
        /// 시간
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = $"{DateTime.Now.ToString("yyyy-MM-dd(dddd)")} " + $"{DateTime.Now.ToString("T")}";

        }
        /// <summary>
        /// 뒤로가기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            if(this.Text.LastIndexOf('/') != -1 )
            {
                this.Text = this.Text.Substring(0, this.Text.LastIndexOf('/'));
            }
            else
            {
                pnlHeader.Visible = false;
                pnlNotice.Visible = false;
                timer1.Stop();
                this.Text = null;
                openChildForm(new frmMain(this.Tag.ToString()));
            }
        }
        public string GetUserID()
        {
            return this.Tag.ToString().Substring(0, this.Tag.ToString().IndexOf('/'));
        }

        private void label6_Click(object sender, EventArgs e)
        {
           openChildForm(new frmSetOperation());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(noticeList.Count > 0)
            {
                if (label3.Right == 95)
                {
                    idx++;
                    if (idx == noticeList.Count)
                    {
                        idx = 0;
                    }
                    label3.Text = noticeList[idx].Description;
                    label3.Location = new Point(1916, 4);
                }
                else
                {
                    label3.Left = label3.Left - 1;
                }
            }
            else
            {
                if (label3.Right == 95)
                {
                    label3.Text = noticeList[idx].Description;
                    label3.Location = new Point(1916, 4);
                }
                else
                {
                    label3.Left = label3.Left - 1;
                }
            }
           
        }
    }
    public class ReadEventAgrs : EventArgs
    {
        public string ReadMessage { get; set; }
    }

}
