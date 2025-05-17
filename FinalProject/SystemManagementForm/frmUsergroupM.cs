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
    public partial class frmUsergroupM : Form
    {
        frmMain frm = null;
        List<UsergroupVO> selectList;
        List<UsergroupVO> allList;
        public frmUsergroupM()
        {
            InitializeComponent();
        }

        private void frmUsergroupM_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent; //함수에 전달해주기위해 
            frm.Select += OnSelect; //조회
            frm.Refresh += OnRefresh; //새로고침
            frm.Insert += OnInsert; //추가
            frm.UpDate += OnUpDate; //수정

            //콤보박스 바인딩 사용자 그룹코드, 그룹명
            CommonService service = new CommonService();
            List<ComboItemVO> list = service.GetUserGroup_CategoryCode(); //그룹코드가져오기
            //콤보박스 불러오기
            CommonUtil.ComboBinding(cboUserGN, list, "GetUserGroup_CategoryCode", true, "전체"); //이름
            //CommonUtil.ComboBinding(cboUserGC, list, "GetUserGroup_CategoryCode", true, "전체"); //코드

            //데이터그리드뷰
            CommonUtil.SetInitGridView(dgvUsergroup);
            CommonUtil.AddGridTextColumn(dgvUsergroup, "사용자 그룹코드", "UserGroup_Code", colWidth: 370);
            CommonUtil.AddGridTextColumn(dgvUsergroup, "사용자 그룹명", "UserGroup_Name", colWidth: 370);
            CommonUtil.AddGridTextColumn(dgvUsergroup, "입력일자", "Ins_Date", colWidth: 370);
            CommonUtil.AddGridTextColumn(dgvUsergroup, "사용여부", "Use_YN", colWidth: 370);

            //사용여부 변경버튼 생성
            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;

            dgvUsergroup.Columns.Add(btnCell);
           
            //데이터그리드뷰 보여주기
            UsergroupService ser = new UsergroupService();
            selectList = ser.GetUsergroupList();
            dgvUsergroup.DataSource = selectList;

        }

        private void OnUpDate(object sender, EventArgs e)//수정
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUsergroupM) && frm.ActiveMdiChild == this)
                {
                    //유효성검사                 
                    if (txtUserGroupCode.Text.Trim().Length < 1) return;                    
                    if (txtUserGroupName.Text.Trim().Length < 1) return;
                    //처리로직         
                    //VO객체를 생성해서 DB에 전달해서 수정
                    UsergroupVO UserG = new UsergroupVO
                    {                
                        UserGroup_Code = txtUserGroupCode.Text, //사용자 그룹코드
                        UserGroup_Name = txtUserGroupName.Text//사용자 그룹명
                    };

                    UsergroupService service = new UsergroupService();
                    bool result = service.UPdateUsergroup(UserG);

                    //결과처리
                    if (result)
                    {
                        MessageBox.Show("수정되었습니다.");
                        //다시 전체조회
                        UsergroupService ser = new UsergroupService();
                        selectList = ser.GetUsergroupList();
                        dgvUsergroup.DataSource = selectList;
                        //정보가져오기
                        UsergroupService vice = new UsergroupService();
                       vice.GetUsergroupInfo(txtUserGroupCode.Text);
                    }
                    else
                    {
                        MessageBox.Show("수정 중 오류가 발생하였습니다. 다시 시도해주세요. ");
                    }
                }
            }
        }
        private void OnInsert(object sender, EventArgs e)//추가, 등록
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUsergroupM) && frm.ActiveMdiChild == this)
                {
                    //유효성검사
                    StringBuilder sb = new StringBuilder();  //유효성 체크(입력했는지)
                    if (txtUserGroupCode.Text.Trim().Length < 1)
                        sb.AppendLine("- 사용자 그룹코드를 입력하세요");
                    if (txtUserGroupName.Text.Trim().Length < 1)
                        sb.AppendLine("- 사용자 그룹명을 입력하세요");
                    if (sb.Length > 0)
                    {
                        MessageBox.Show(sb.ToString());
                        return;
                    }
                    //처리로직 VO객체를 생성해서 DB에 전달해서 신규등록
                    UsergroupVO UserG = new UsergroupVO
                    {
                        UserGroup_Code = txtUserGroupCode.Text, //사용자 그룹코드
                        UserGroup_Name = txtUserGroupName.Text//사용자 그룹명
                    };
                    UsergroupService service = new UsergroupService();
                    bool result = service.InsertUsergroup(UserG);
                    if (result)
                    {
                        MessageBox.Show("등록되었습니다.");
                    
                        //검색창 초기화시키기
                        cboUserGN.SelectedIndex = 0;
                       // cboUserGC.SelectedIndex = 0;
                        //상세 초기화 시키기 
                        txtUserGroupCode.Text = txtUserGroupName.Text = "";
                        //다시 전체조회
                        UsergroupService ser = new UsergroupService();
                        selectList = ser.GetUsergroupList();
                        dgvUsergroup.DataSource = selectList;
                    }
                    else
                        MessageBox.Show("등록 중 오류가 발생하였습니다.");
                }
            }
        }
        private void OnRefresh(object sender, EventArgs e)//새로고침
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUsergroupM) && frm.ActiveMdiChild == this)
                {
                    //검색창 초기화시키기
                    cboUserGN.SelectedIndex = 0;
                    //cboUserGC.SelectedIndex = 0;
                    //상세 초기화 시키기 
                    txtUserGroupCode.Text = txtUserGroupName.Text = "";
                    //다시 전체조회
                    UsergroupService ser = new UsergroupService();
                    selectList = ser.GetUsergroupList();
                    dgvUsergroup.DataSource = selectList;
                }
            }
        }
        private void OnSelect(object sender, EventArgs e)//조회
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUsergroupM) && frm.ActiveMdiChild == this)
                {
                    //유효성검사
                    int UserG_Code = 0;
                    if (cboUserGN.Text == "전체" )
                    {
                        dgvUsergroup.DataSource = allList;
                        return;
                    }
                    if (cboUserGN.Text != "전체")
                        UserG_Code = Convert.ToInt32(cboUserGN.SelectedValue);
                    //if (cboUserGC.Text != "전체")
                    //    UserG_Code = Convert.ToInt32(cboUserGC.SelectedValue);

                    //selectList중에서 검색조건에 맞는 것만 필터링해서
                    if (UserG_Code > 0)
                    {
                        selectList = (from userG in allList
                                      where userG.UserGroup_Code.Equals(UserG_Code)
                                      select userG).ToList();
                        dgvUsergroup.DataSource = null;
                        dgvUsergroup.DataSource = selectList;
                    }
                }
            }
        }

        private void dgvUsergroup_CellClick(object sender, DataGridViewCellEventArgs e) //셀이 클릭되었을 경우
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 4)
            {
                if (MessageBox.Show("사용여부를 변경하시겠습니까?", "사용여부변경", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string UserG = (dgvUsergroup[0, e.RowIndex].Value).ToString();
                    string useYN = (dgvUsergroup[3, e.RowIndex].Value).ToString();

                    useYN = (useYN == "Y") ? "N" : "Y";

                    UsergroupService service = new UsergroupService();
                   bool result = service.UPdateUsergroupUseYN(UserG, useYN);
                    if (result)
                    {
                        selectList = service.GetUsergroupList();
                        dgvUsergroup.DataSource = selectList;
                    }
                }
            }
            else
            {
                txtUserGroupCode.Text = (dgvUsergroup[0, e.RowIndex].Value).ToString(); ;    //사용자 그룹코드
                txtUserGroupName.Text = (dgvUsergroup[1, e.RowIndex].Value).ToString(); ;   //사용자 그룹명
            }
           //string UserG = (dgvUsergroup[0, e.RowIndex].Value).ToString();

           // UsergroupService service = new UsergroupService();
           // UsergroupVO userG = service.GetUsergroupInfo(UserG);
           // if (userG != null)
           // {
           //     txtUserGroupCode.Text = userG.UserGroup_Code;    //사용자 그룹코드
           //     txtUserGroupName.Text = userG.UserGroup_Name;   //사용자 그룹명
           // }
           // else
           // {
           //     MessageBox.Show("조회 중 오류가 발생했습니다.");
           // }

        }
    }
}
