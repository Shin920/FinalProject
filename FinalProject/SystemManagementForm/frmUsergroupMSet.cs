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
    public partial class frmUsergroupMSet : Form
    {
        frmMain frm = null;
        List<UsergroupVO> selectlist;
        List<UsergroupVO> grouplist;
        List<ScreenItem_AuthorityVO> Screenlist;
        UsergroupService userservice = new UsergroupService();
        ScreenItem_MasterService screenservice = new ScreenItem_MasterService();
        public frmUsergroupMSet()
        {
            InitializeComponent();
        }

        private void frmUsergroupMSet_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent; //함수에 전달해주기위해 
            frm.Select += OnSelect; //조회
            frm.Refresh += OnRefresh; //새로고침
            frm.UpDate += OnUpDate; //수정
            frm.Delete += OnDelete; //삭제
            frm.Insert += OnInsert;//등록

            //콤보박스 바인딩 사용자 그룹코드, 그룹명
            //CommonService service = new CommonService();
            //List<ComboItemVO> list = service.GetUserGroup_CategoryCode(); //그룹코드가져오기
            //콤보박스 불러오기
            //CommonUtil.ComboBinding(cboUserGN, list, "com_Name", true, "전체"); //이름

            //데이터그리드뷰 사용자그룹목록
            CommonUtil.SetInitGridView(dgvUsergroup);
            CommonUtil.AddGridTextColumn(dgvUsergroup, "사용자 그룹코드", "UserGroup_Code", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvUsergroup, "사용자 그룹명", "UserGroup_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvUsergroup, "입력일자", "Ins_Date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvUsergroup, "사용여부", "Use_YN", colWidth: 60);
      
            //데이터그리드뷰 화면권한 허용
            CommonUtil.SetInitGridView(dgvfrmY);
            CommonUtil.AddGridTextColumn(dgvfrmY, "화면코드", "Program_Name", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvfrmY, "화면명", "Menu_Name", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvfrmY, "설정자", "Ins_Emp", colWidth: 200);
            //사용안하는 컬럼
            CommonUtil.AddGridTextColumn(dgvfrmY, "사용자 그룹코드", "UserGroup_Code", visibility: false);
            
            GetAllUserGroup(); //유저그룹전체
            ControlSetting();//콤보박스
        }
        private void GetAllUserGroup() //유저그룹전체
        {

            grouplist = new List<UsergroupVO>();
            grouplist = userservice.GetUsergroupList().Where<UsergroupVO>(e => e.Use_YN == "Y").ToList();
            dgvUsergroup.DataSource = grouplist;
            GetGroupScreenItem(dgvUsergroup.SelectedRows[0].Cells[0].Value.ToString()); //선택한화면그룹
        }
        private void ControlSetting()// 그리드뷰 버튼, 콤보박스세팅, 클릭하면 자동으로 텍스트생성
        {
            Dictionary<string, string> cbolist = grouplist.FindAll(item => item.Use_YN == "Y").ToDictionary(item => item.UserGroup_Code, item => item.UserGroup_Name); //사용을 하는 그룹만
            cboUserGN.DisplayMember = "Value";
            cboUserGN.ValueMember = "Key";
            cboUserGN.DataSource = new BindingSource(cbolist, null);
            textBox1.Text = cboUserGN.SelectedValue.ToString();
            
        }
        private void GetGroupScreenItem(string groupCode)// 선택한 그룹의 화면가져오기
        {
            Screenlist = new List<ScreenItem_AuthorityVO>();
            Screenlist = screenservice.GetUseGroupScreenItem(groupCode);
            dgvfrmY.DataSource = null;
            dgvfrmY.DataSource = Screenlist;
        }
        private void OnInsert(object sender, EventArgs e)//등록
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUsergroupMSet) && frm.ActiveMdiChild == this)
                {
                    frmUsergroupMSet_CRUD frm = new frmUsergroupMSet_CRUD();
                    frm.ShowDialog();
                }
            }
        }

        private void OnDelete(object sender, EventArgs e)//삭제
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUsergroupMSet) && frm.ActiveMdiChild == this)
                {
                    frmUsergroupMSet_CRUD frm = new frmUsergroupMSet_CRUD();
                    frm.ShowDialog();
                }
            }
        }

        private void OnUpDate(object sender, EventArgs e)//수정
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUsergroupMSet) && frm.ActiveMdiChild == this)
                {
                    frmUsergroupMSet_CRUD frm = new frmUsergroupMSet_CRUD();
                    frm.ShowDialog();
                }
            }
        }

        private void OnRefresh(object sender, EventArgs e) //새로고침
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUsergroupMSet) && frm.ActiveMdiChild == this)
                {
                    GetAllUserGroup();
                    ControlSetting();//콤보박스
                }
            }
        }

        private void OnSelect(object sender, EventArgs e)//조회
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUsergroupMSet) && frm.ActiveMdiChild == this)
                {

                    //유효성검사
                    int UserG_Code = 0;
                    if (cboUserGN.Text == "전체" && textBox1.Text == "")
                    {
                        dgvUsergroup.DataSource = grouplist;
                        return;
                    }
                    if (cboUserGN.Text != "전체")
                        UserG_Code = Convert.ToInt32(cboUserGN.SelectedValue);
                    if (textBox1.Text != "")
                        UserG_Code = Convert.ToInt32(textBox1.Text);

                    //selectList중에서 검색조건에 맞는 것만 필터링해서
                    if (UserG_Code > 0)
                    {
                        selectlist = (from userG in grouplist
                                  where userG.UserGroup_Code.Equals(UserG_Code)
                                      select userG).ToList();
                        dgvUsergroup.DataSource = null;
                        dgvUsergroup.DataSource = selectlist;
                    }
                }
            }
        }

        private void dgvUsergroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetGroupScreenItem(dgvUsergroup.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void cboUserGN_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = cboUserGN.SelectedValue.ToString();
        }
    }
}
