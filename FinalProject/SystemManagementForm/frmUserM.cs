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
    public partial class frmUserM : Form
    {
        frmMain frm = null;
        List<UserInfoVO> userlist;
        List<UserInfoVO> groupuserlist; //권한부여받은 유저들
        UserInfoService userService = new UserInfoService();

        List<UsergroupVO> grouplist;
        List<UserGroup_MappingVO> groupMappinglist;
        List<UserGroup_MappingVO> subMappinglist;
        UsergroupService groupservice = new UsergroupService();

        public frmUserM()
        {
            InitializeComponent();
        }

        private void frmUserM_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent; //함수에 전달해주기위해 
            frm.Select += OnSelect; //조회
            frm.Refresh += OnRefresh; //새로고침
            frm.UpDate += OnUpDate; //수정
            frm.Insert += OnInsert;//등록
            frm.Delete += OnDelete;//삭제

            //데이터바인딩
            CommonUtil.SetInitGridView(dgvUserList);
            CommonUtil.AddGridTextColumn(dgvUserList, "아이디", "User_ID", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvUserList, "이름", "User_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvUserList, "사용유무", "Use_YN", colWidth: 100);

            CommonUtil.SetInitGridView(dgvGroup);
            CommonUtil.AddGridTextColumn(dgvGroup, "사용자그룹코드", "UserGroup_Code", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvGroup, "사용자그룹명", "UserGroup_Name", colWidth: 200);

            CommonUtil.SetInitGridView(dgvUserGroupUes);
            CommonUtil.AddGridTextColumn(dgvUserGroupUes, "아이디", "User_ID", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvUserGroupUes, "이름", "User_Name", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvUserGroupUes, "사용유무", "Use_YN", colWidth: 100);

            DataGridViewCheckBoxColumn gridcheckbox = new DataGridViewCheckBoxColumn();
            gridcheckbox.HeaderText = "선택";
            gridcheckbox.Name = "checkbtn";
            gridcheckbox.FalseValue = "false";
            gridcheckbox.TrueValue = "true";
            gridcheckbox.Width = 50;
            dgvUserGroupUes.Columns.Insert(0, gridcheckbox);

            GetAllUser(); //유저목록전체
            GetAllUserGroup();

            ControlSetting();
        }

        private void OnDelete(object sender, EventArgs e) //삭제
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserM) && frm.ActiveMdiChild == this)
                {
                    if (MessageBox.Show(dgvUserList.SelectedRows[0].Cells[1].Value.ToString() + "를 삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //   MessageBox.Show(dgvParent.SelectedRows[0].Cells[0].Value.ToString());
                        if (userService.DeleteUserInfoVO(dgvUserList.SelectedRows[0].Cells[0].Value.ToString()))
                        {
                            GetAllUser();
                            GetAllUserGroup();
                            ControlSetting();//콤보박스
                        }
                        else
                        {
                            MessageBox.Show("삭제실패");
                        }
                    }
                }
            }
        }

        private void OnInsert(object sender, EventArgs e) //등록
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserM) && frm.ActiveMdiChild == this)
                {
                    frmUserM_Addpop frm = new frmUserM_Addpop();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("등록", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetAllUser();
                        GetAllUserGroup();
                        ControlSetting();//콤보박스
                    }
                }
            }
        }

        private void GetAllUser() //유저목록전체
        {
            userlist = new List<UserInfoVO>();
            userlist = userService.GetAllUser();
            dgvUserList.DataSource = userlist;

            groupuserlist = userlist;//권한부여받은 유저들
            dgvUserGroupUes.DataSource = groupuserlist;

        }
        private void GetAllUserGroup()// 사용자그룹목록
        {
            grouplist = new List<UsergroupVO>();
            grouplist = groupservice.GetUsergroupList();
            dgvGroup.DataSource = grouplist.FindAll(item => item.Use_YN == "Y");
            groupMappinglist = new List<UserGroup_MappingVO>();
            groupMappinglist = groupservice.GetAllUserGroup_Mapping();

            subMappinglist = new List<UserGroup_MappingVO>(); //맵핑된전체유저들중 선택그룹에해당하는 유저들
            subMappinglist = groupMappinglist.FindAll(item => item.UserGroup_Code == dgvGroup.SelectedRows[0].Cells[0].Value.ToString());//맵핑된전체유저들중 하나의그룹에해당하는 애들만

        }
        private void ControlSetting() // 콤보박스 세팅
        {
            Dictionary<string, string> cbolist = userlist.FindAll(item => item.Use_YN == "Y").ToDictionary(item => item.User_ID, item => item.User_Name);
            cboUser.DisplayMember = "Value";
            cboUser.ValueMember = "Key";
            cboUser.DataSource = new BindingSource(cbolist, null);
            txtUser.Text = cboUser.SelectedValue.ToString();
        }

   
        private void OnUpDate(object sender, EventArgs e)//수정
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserM) && frm.ActiveMdiChild == this)
                {
                    GetAllUser();
                    GetAllUserGroup();
                    ControlSetting();//콤보박스
                }
            }
        }

        private void OnRefresh(object sender, EventArgs e)//새로고침
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserM) && frm.ActiveMdiChild == this)
                {

                }
            }
        }

        private void OnSelect(object sender, EventArgs e)//조회
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserM) && frm.ActiveMdiChild == this)
                {
                    foreach (DataGridViewRow row in dgvUserList.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Contains(txtUser.Text))
                        {
                            row.Cells[0].Selected = true;
                        }
                    }

                }
            }
        }

        private void dgvGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            subMappinglist = new List<UserGroup_MappingVO>(); //맵핑된전체유저들중 선택그룹에해당하는 유저들
            subMappinglist = groupMappinglist.FindAll(item => item.UserGroup_Code == dgvGroup.SelectedRows[0].Cells[0].Value.ToString());//맵핑된전체유저들중 하나의그룹에해당하는 애들만

            foreach (DataGridViewRow row in dgvUserGroupUes.Rows)
            {
                row.Cells[0].Value = false;
            }


            for (int i = 0; i < groupuserlist.Count; i++)
            {
                for (int j = 0; j < subMappinglist.Count; j++)
                {
                    if (groupuserlist[i].User_ID == subMappinglist[j].User_ID)
                    {
                        dgvUserGroupUes.Rows[i].Cells[0].Value = true;
                    }
                }
            }
        }

        private void dgvUserGroupUes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvUserGroupUes.SelectedRows[0].Cells[0].Value = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUser.Text = cboUser.SelectedValue.ToString();
        }
    }
}
