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
    public partial class frmLoginInfo : Form
    {
        frmMain frm = null;
        List<UserInfoVO> userlist;
        UserInfoService userservice = new UserInfoService();
        List<ScreenItem_MasterVO> screenitemlist; //모든 스크린 
        ScreenItem_MasterService screenservice = new ScreenItem_MasterService();
        public frmLoginInfo()
        {
            InitializeComponent();
        }

        private void frmLoginInfo_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += OnSelect; //조회

            dtpEnd.MaxDate = DateTime.Now;

            userlist = new List<UserInfoVO>();
            userlist = userservice.GetAllUser();
            screenitemlist = new List<ScreenItem_MasterVO>();
            screenitemlist = screenservice.GetALLScreenItem(); //모든스크린

            UserInfoVO uservo = new UserInfoVO();

            userlist.Insert(0, uservo);
            cboUser.DisplayMember = "User_Name";
            cboUser.ValueMember = "User_ID";
            cboUser.DataSource = userlist;

            ScreenItem_MasterVO screenvo = new ScreenItem_MasterVO();
            screenitemlist.Insert(0, screenvo);
            cboScreen.DisplayMember = "Type";
            cboScreen.ValueMember = "Screen_Code";
            cboScreen.DataSource = screenitemlist;

            CommonUtil.SetInitGridView(dgvList);  
            CommonUtil.AddGridTextColumn(dgvList, "이름", "User_Name", colWidth: 210);
            CommonUtil.AddGridTextColumn(dgvList, "세션아이디", "Session_ID", colWidth: 210);
            CommonUtil.AddGridTextColumn(dgvList, "화면명", "Type", colWidth: 210);
            CommonUtil.AddGridTextColumn(dgvList, "로그인", "Login_Date", colWidth: 210);
            CommonUtil.AddGridTextColumn(dgvList, "화면오픈", "Open_Date", colWidth: 210);


        }
        private void OnSelect(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmLoginInfo) && frm.ActiveMdiChild == this)
                {
                    int dayresult = DateTime.Compare(dtpstart.Value, dtpEnd.Value);
                    if (dayresult > 0)
                    {
                        MessageBox.Show("날짜가 올바르지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (cboUser.SelectedValue == null && cboScreen.SelectedValue == null) //날짜만골랏을때
                    {
                        dgvList.DataSource = userservice.GetUser_Screen_Login(dtpstart.Value, dtpEnd.Value.AddDays(1), "0", "0");
                    }
                    else if (cboScreen.SelectedValue == null) //유저만골랏을떄
                    {
                        dgvList.DataSource = userservice.GetUser_Screen_Login(dtpstart.Value, dtpEnd.Value.AddDays(1), "0", cboUser.SelectedValue.ToString());
                    }
                    else if (cboUser.SelectedValue == null) //스크린만골랏을떄
                    {
                        dgvList.DataSource = userservice.GetUser_Screen_Login(dtpstart.Value, dtpEnd.Value.AddDays(1), cboScreen.SelectedValue.ToString(), "0");
                    }
                    else
                    {
                        dgvList.DataSource = userservice.GetUser_Screen_Login(dtpstart.Value, dtpEnd.Value.AddDays(1), cboScreen.SelectedValue.ToString(), cboUser.SelectedValue.ToString());
                    }
                }
            }
        }
    }
}
