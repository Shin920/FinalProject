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
    public partial class frmMenuM_AddDeletepop : Form
    {
        List<MenuTreeMasterVO> menulist; //메뉴
        MainFormService service = new MainFormService();

        List<ScreenItem_MasterVO> screanlist;
        ScreenItem_MasterService screenservice = new ScreenItem_MasterService();

        public frmMenuM_AddDeletepop()
        {
            InitializeComponent();
            tabControl1.DrawItem += new DrawItemEventHandler(tab_JOlist_DrawItem2);
        }
        private void tab_JOlist_DrawItem2(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.NavajoWhite, e.Bounds);

            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("맑은 고딕", 12.0f, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = StringAlignment.Center;
            stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(stringFlags));
        }

        private void button5_Click(object sender, EventArgs e)//팝업닫기
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//팝업닫기
        {
            this.Close();
        }

        private void frmMenuM_AddDeletepop_Load(object sender, EventArgs e)
        {
            ControlSetting(); // 콤보박스 세팅
            txtday1.Text = DateTime.Now.ToShortDateString();
            txtemp1.Text = UserInfo.User_Name;
            txtday2.Text = DateTime.Now.ToShortDateString();
            txtemp2.Text = UserInfo.User_Name;
        }
        private void ControlSetting() // 콤보박스 세팅
        {
            menulist = service.GetAll_MenuTree_Master();
            Dictionary<string, string> pcbblist = menulist.FindAll(item => item.Parent_Screen_Code == null).ToDictionary(item => item.Screen_Code, item => item.Screen_Name);
            cboParent.DisplayMember = "Value";
            cboParent.ValueMember = "Key";
            cboParent.DataSource = new BindingSource(pcbblist, null);
            txtParent.Text = cboParent.SelectedValue.ToString();

            screanlist = new List<ScreenItem_MasterVO>();
            screanlist = screenservice.GetALLScreenItem();
            Dictionary<string, string> cbblist = screanlist.ToDictionary(item => item.Screen_Code, item => item.Type);
            cboScreenname.DisplayMember = "Value";
            cboScreenname.ValueMember = "Key";
            cboScreenname.DataSource = new BindingSource(cbblist, null);
            txtscreencode.Text = cboScreenname.SelectedValue.ToString();
        }

        private void cboParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtParent.Text = cboParent.SelectedValue.ToString();
        }

        private void BtnS_Click(object sender, EventArgs e)//자식등록클릭경우
        {
            try
            {
                if (!string.IsNullOrEmpty(txtscreencode.Text) && !string.IsNullOrEmpty(cboScreenname.Text))
                {
                    MenuTreeMasterVO additem = new MenuTreeMasterVO()
                    {
                        Parent_Screen_Code = txtParent.Text,
                        Screen_Code = txtscreencode.Text,
                        Screen_Name = cboScreenname.Text,
                        Ins_Date = Convert.ToDateTime(txtday1.Text),
                        Ins_Emp = txtemp1.Text
                    };
                    if (service.InsertMenuTree_Master_VO(additem))
                    {
                        MessageBox.Show("저장 완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("이미 등록된 검사항목입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("필수 항목을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.Log.WriteError(err.Message);
            }
        }

        private void BtnP_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtparentcode.Text) && !string.IsNullOrEmpty(txtparentname.Text))
                {
                    MenuTreeMasterVO additem = new MenuTreeMasterVO()
                    {
                        Parent_Screen_Code = "0",
                        Screen_Code = txtparentcode.Text,
                        Screen_Name = txtparentname.Text,
                        Ins_Date = Convert.ToDateTime(txtday2.Text),
                        Ins_Emp = txtemp2.Text
                    };
                    if (service.InsertMenuTree_Master_VO(additem))
                    {
                        MessageBox.Show("저장 완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); //닫기
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("이미 등록된 검사항목입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("필수 항목을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.Log.WriteError(err.Message);
            }
        }
    }
}
