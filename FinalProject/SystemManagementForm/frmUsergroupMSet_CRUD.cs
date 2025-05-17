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
    public partial class frmUsergroupMSet_CRUD : Form
    {
        UsergroupService userservice = new UsergroupService();
        List<UsergroupVO> grouplist;

        ScreenItem_MasterService screenservice = new ScreenItem_MasterService();
        List<ScreenItem_AuthorityVO> NotScreenlist;//초기 안쓰는거
        List<ScreenItem_AuthorityVO> UseScreenlist; //초기 쓰는거
        List<ScreenItem_AuthorityVO> InsertUpdateScreenlist; //db에 들어갈애들
        List<ScreenItem_AuthorityVO> DeleteScreenlist; //db에서 삭제되는 목록들

        public frmUsergroupMSet_CRUD()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsergroupMSet_CRUD_Load(object sender, EventArgs e)
        {
            //c첫번째
            CommonUtil.SetInitGridView(dgvNUseScreen);
            CommonUtil.AddGridTextColumn(dgvNUseScreen, "화면코드", "Screen_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvNUseScreen, "화면명", "Type", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvNUseScreen, "화면경로", "Screen_Path", colWidth: 200);
            //두번째
            CommonUtil.SetInitGridView(dgvUseScreen);
            CommonUtil.AddGridTextColumn(dgvUseScreen, "화면코드", "Screen_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvUseScreen, "화면명", "Type", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvUseScreen, "화면경로", "Screen_Path", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvUseScreen, "설정자", "Ins_Emp", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvUseScreen, "입력일", "Ins_Date", colWidth: 100);

            ControlSetting();// 그리드뷰 버튼, 콤보박스세팅
        }
        private void ControlSetting()// 그리드뷰 버튼, 콤보박스세팅
        {
            //그리드뷰 체크박스

            DataGridViewCheckBoxColumn gridcheckbox = new DataGridViewCheckBoxColumn();
            gridcheckbox.HeaderText = "선택";
            gridcheckbox.Name = "checkbtn";
            gridcheckbox.Width = 60;
            dgvNUseScreen.Columns.Insert(0, gridcheckbox);

            DataGridViewCheckBoxColumn gridcheckbox2 = new DataGridViewCheckBoxColumn();
            gridcheckbox2.HeaderText = "선택";
            gridcheckbox2.Name = "checkbtn2";
            gridcheckbox2.Width = 60;
            dgvUseScreen.Columns.Insert(0, gridcheckbox2);

            DataGridViewCheckBoxColumn gridC = new DataGridViewCheckBoxColumn();
            gridC.HeaderText = "추가";
            gridC.Name = "gridC";
            gridC.Width = 60;
            dgvUseScreen.Columns.Insert(4, gridC);

            DataGridViewCheckBoxColumn gridR = new DataGridViewCheckBoxColumn();
            gridR.HeaderText = "조회";
            gridR.Name = "gridR";
            gridR.Width = 60;
            dgvUseScreen.Columns.Insert(5, gridR);

            DataGridViewCheckBoxColumn gridU = new DataGridViewCheckBoxColumn();
            gridU.HeaderText = "수정";
            gridU.Name = "gridU";
            gridU.Width = 60;
            dgvUseScreen.Columns.Insert(6, gridU);

            DataGridViewCheckBoxColumn gridD = new DataGridViewCheckBoxColumn();
            gridD.HeaderText = "삭제";
            gridD.Name = "gridD";
            gridD.Width = 60;
            dgvUseScreen.Columns.Insert(7, gridD);
            ///combobox
            grouplist = new List<UsergroupVO>();
            grouplist = userservice.GetAllUserGroup();
            Dictionary<string, string> cbolist = grouplist.FindAll(item => item.Use_YN == "Y").ToDictionary(item => item.UserGroup_Code, item => item.UserGroup_Name); //사용을 하는 그룹만
            cboGroup.DisplayMember = "Value";
            cboGroup.ValueMember = "Key";
            cboGroup.DataSource = new BindingSource(cbolist, null);
            txtGroup.Text = cboGroup.SelectedValue.ToString();
           
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboGroup.SelectedValue.ToString()))
            {
                txtGroup.Text = cboGroup.SelectedValue.ToString();
            }
        }

        private void Btngroup_Click(object sender, EventArgs e)// 그룹버튼 조회시 dgvScreenItem에 적용되지않은화면과 적용된화면 
        {
            //그룹에서 사용하지않는 화면
            InsertUpdateScreenlist = new List<ScreenItem_AuthorityVO>();
            DeleteScreenlist = new List<ScreenItem_AuthorityVO>();

            NotScreenlist = new List<ScreenItem_AuthorityVO>();
            NotScreenlist = screenservice.GetNotUseGroupScreenItem(txtGroup.Text);
            dgvNUseScreen.DataSource = NotScreenlist;
            //그룹에서 사용하는화면
            UseScreenlist = new List<ScreenItem_AuthorityVO>();
            UseScreenlist = screenservice.GetUseGroupScreenItem(txtGroup.Text);
            if (UseScreenlist.Count > 0)
            {
                dgvUseScreen.DataSource = UseScreenlist;
                for (int i = 0; i < UseScreenlist.Count; i++) //crud 체크박스
                {
                    string crudcheck = UseScreenlist[i].Pre_Type;
                    for (int j = 0; j < 4; j++)
                    {
                        if (crudcheck[j] == 'Y')//y면은 체크
                        {
                            dgvUseScreen.Rows[i].Cells[j + 4].Value = true;
                        }
                    }
                }
            }
            else
            {
                dgvUseScreen.DataSource = null;
            }
        }
        private void BtnIn_Click(object sender, EventArgs e)
        {
            List<ScreenItem_AuthorityVO> removeitem = new List<ScreenItem_AuthorityVO>();
            foreach (DataGridViewRow row in dgvNUseScreen.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true) //체크박스가 선택된 row들만
                {
                    ScreenItem_AuthorityVO item = NotScreenlist.Find(i => i.Screen_Code == row.Cells[1].Value.ToString());
                    if (UseScreenlist.Count(a => a.Screen_Code == item.Screen_Code) < 1) //사용하는 리스트에 중복으로 들어가는 지 체크 없다면 add  
                    {
                        UseScreenlist.Add(item); //사용그리드뷰에 담을 리스트
                        removeitem.Add(item);
                        if (DeleteScreenlist.Count(deletitem => deletitem.Screen_Code == item.Screen_Code) > 0)//db에 삭제할 리스트중 다시 사용한다면 삭제할 목록에서 제거
                        {
                            DeleteScreenlist.Remove(DeleteScreenlist.Find(de => de.Screen_Code == item.Screen_Code));
                        }
                    }
                }
            }
            for (int i = 0; i < removeitem.Count; i++)
            {
                for (int j = 0; j < NotScreenlist.Count; j++)
                {
                    if (NotScreenlist[j].Screen_Code == removeitem[i].Screen_Code)
                    {
                        NotScreenlist.RemoveAt(j);
                        break;
                    }
                }
            }
            dgvNUseScreen.DataSource = null;
            dgvNUseScreen.DataSource = NotScreenlist;
            if (dgvUseScreen.RowCount > 0)
            {
                dgvUseScreen.DataSource = null;
            }
            dgvUseScreen.DataSource = UseScreenlist;
            for (int i = 0; i < UseScreenlist.Count; i++) //crud 체크박스
            {
                if (!string.IsNullOrEmpty(UseScreenlist[i].Pre_Type))
                {
                    string crudcheck = UseScreenlist[i].Pre_Type;

                    for (int j = 0; j < 4; j++)
                    {
                        if (crudcheck[j] == 'Y')//y면은 체크
                        {
                            dgvUseScreen.Rows[i].Cells[j + 4].Value = true;
                        }

                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder crud = new StringBuilder();
                foreach (DataGridViewRow row in dgvUseScreen.Rows)
                {
                    crud.Clear();
                    for (int i = 4; i < 8; i++) //crud 체크
                    {
                        if (Convert.ToBoolean(row.Cells[i].Value) == true)
                        {
                            crud.Append("Y");
                        }
                        else
                        {
                            crud.Append("N");
                        }
                    }
                    ScreenItem_AuthorityVO item = new ScreenItem_AuthorityVO
                    {
                        UserGroup_Code = txtGroup.Text,
                        Screen_Code = row.Cells[1].Value.ToString(),
                        Pre_Type = crud.ToString(),
                        Ins_Date = DateTime.Now,
                        Ins_Emp = UserInfo.User_Name

                    };
                    InsertUpdateScreenlist.Add(item);
                }
                if (InsertUpdateScreenlist.Count > 0)
                    screenservice.InsertUpdateScreenItem_Authority(InsertUpdateScreenlist);
                if (DeleteScreenlist.Count > 0)
                    screenservice.DeleteGroupUseScreenItem_Authority(txtGroup.Text, DeleteScreenlist);
            }
            catch (Exception err)
            {
                MessageBox.Show("선택한 내용이없습니다."+ err.ToString());
            }
        }

        private void BtnOut_Click(object sender, EventArgs e)
        {
            List<ScreenItem_AuthorityVO> removeitem = new List<ScreenItem_AuthorityVO>();
            foreach (DataGridViewRow row in dgvUseScreen.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true) //체크박스가 선택된 row들만
                {
                    ScreenItem_AuthorityVO item = UseScreenlist.Find(i => i.Screen_Code == row.Cells[1].Value.ToString());
                    DeleteScreenlist.Add(UseScreenlist.Find(x => x.Screen_Code == item.Screen_Code.ToString()));//디비에 삭제될 리스트에 먼저 추가.

                    if (NotScreenlist.Count(a => a.Screen_Code == item.Screen_Code) < 1) //사용하는 리스트에 중복으로 들어가는 지 체크 없다면 add  
                    {
                        NotScreenlist.Add(item); //사용그리드뷰에 담을 리스트       
                        removeitem.Add(item);
                    }
                }
            }
            for (int i = 0; i < removeitem.Count; i++)
            {
                for (int j = 0; j < UseScreenlist.Count; j++)
                {
                    if (UseScreenlist[j].Screen_Code == removeitem[i].Screen_Code)
                    {
                        UseScreenlist.RemoveAt(j);
                        break;
                    }
                }
            }
            dgvNUseScreen.DataSource = null;
            dgvNUseScreen.DataSource = NotScreenlist;
            if (dgvUseScreen.RowCount > 0)
            {
                dgvUseScreen.DataSource = null;
            }
            dgvUseScreen.DataSource = UseScreenlist;

            for (int i = 0; i < UseScreenlist.Count; i++) //crud 체크박스
            {
                if (!string.IsNullOrEmpty(UseScreenlist[i].Pre_Type))
                {
                    string crudcheck = UseScreenlist[i].Pre_Type;

                    for (int j = 0; j < 4; j++)
                    {
                        if (crudcheck[j] == 'Y')//y면은 체크
                        {
                            dgvUseScreen.Rows[i].Cells[j + 4].Value = true;
                        }
                    }
                }
            }
        }

        private void BtnScreen_Click(object sender, EventArgs e)

        {
            if (rdoScreenName.Checked)
            {
                foreach (DataGridViewRow row in dgvNUseScreen.Rows)
                {
                    if (row.Cells[2].Value.ToString().Contains(txtSearch.Text))
                    {
                        row.Cells[2].Selected = true;
                    }
                }
            }
            else if (rdoScreenCode.Checked)
            {
                foreach (DataGridViewRow row in dgvNUseScreen.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains(txtSearch.Text))
                    {
                        row.Cells[1].Selected = true;
                    }
                }
            }
        }

        private void dgvNUseScreen_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvNUseScreen.SelectedRows[0].Cells[0].Value = true;
        }

        private void dgvUseScreen_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvUseScreen.SelectedRows[0].Cells[0].Value = true;
        }
    }
}
