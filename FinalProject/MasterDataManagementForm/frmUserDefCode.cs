using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmUserDefCode : FinalProject.List_b
    {
        frmMain frm = null;
        List<UserDefCodeVO> list;
        public frmUserDefCode()
        {
            InitializeComponent();
        }

        private void frmUserDefCode_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
            frm.Delete += Frm_Delete;
            frm.Insert += Frm_Insert;
            frm.UpDate += Frm_UpDate;


            CommonUtil.SetInitGridView(dgvUDCList);
            CommonUtil.AddGridTextColumn(dgvUDCList, "대분류코드", "Userdefine_Ma_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvUDCList, "대분류명", "Userdefine_Ma_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvUDCList, "비고", "Remark", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvUDCList, "사용여부", "Use_YN", colWidth: 100);

            //사용여부 변경버튼 생성
            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            /*btnCell.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);*/     //이 간격은 없어도 될듯
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;

            dgvUDCList.Columns.Add(btnCell);

            LoadData();
        }

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCode) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }

        }

        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCode) && frm.ActiveMdiChild == this)
                {
                    txtUdtCode.Clear();
                    txtUdtCode.ReadOnly = false;
                    btnSave.Enabled = true;
                }
            }            
        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCode) && frm.ActiveMdiChild == this)
                {
                    DialogResult dr = MessageBox.Show($"{dgvUDCList.CurrentRow.Cells[1].Value.ToString()}을 삭제하시겠습니까?", "사용자정의코드 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        UserDefCodeService service = new UserDefCodeService();
                        bool result = service.DeleteUserDefCode(dgvUDCList.CurrentRow.Cells[0].Value.ToString());
                        if (result)
                            MessageBox.Show("삭제되었습니다.");
                        else
                            MessageBox.Show("삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }

                }
            }
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCode) && frm.ActiveMdiChild == this)
                {
                    if (string.IsNullOrWhiteSpace(txtUdtName.Text))
                    {
                        MessageBox.Show("대분류명을 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "대분류명 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        UserDefCodeService service = new UserDefCodeService();
                        UserDefCodeVO no = new UserDefCodeVO()
                        {
                            Userdefine_Ma_Code = txtUdtCode.Text,
                            Userdefine_Ma_Name = txtUdtName.Text,
                            Remark = txtRemark.Text,
                            Up_Emp = "로그인관리자"
                        };
                        bool result = service.UpdateUserDefCode(no);
                        if (result)
                        {
                            MessageBox.Show("수정되었습니다.");
                            LoadData();
                            CommonUtil.ClearTextBox(pnlCondition);
                        }
                        else
                            MessageBox.Show("수정 중 오류가 발생하였습니다.\n다시 시도하여 주십시오");
                    }
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCode) && frm.ActiveMdiChild == this)
                {
                     
                    if (string.IsNullOrWhiteSpace(txtUDName.Text) && string.IsNullOrWhiteSpace(txtUDCode.Text))
                    {
                        MessageBox.Show("검색하실 조건을 입력해주십시오.");
                    }
                    else if (string.IsNullOrWhiteSpace(txtUDName.Text) && !string.IsNullOrWhiteSpace(txtUDCode.Text))
                    {
                        List<UserDefCodeVO> findList = list.FindAll(x => x.Userdefine_Ma_Code.Contains(txtUDCode.Text) && x.Userdefine_Ma_Name.Contains(txtUDName.Text));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvUDCList.DataSource = null;
                            dgvUDCList.DataSource = findList;
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(txtUDCode.Text))
                    {
                        List<UserDefCodeVO> findList = list.FindAll(x => x.Userdefine_Ma_Code.Contains(txtUDCode.Text));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvUDCList.DataSource = null;
                            dgvUDCList.DataSource = findList;
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(txtUDName.Text))
                    {
                        List<UserDefCodeVO> findList = list.FindAll(x => x.Userdefine_Ma_Name.Contains(txtUDName.Text));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvUDCList.DataSource = null;
                            dgvUDCList.DataSource = findList;
                        }

                    }
                }
            }
        }

        private void dgvUDCList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)  //사용여부 변경버튼
            {
                //MessageBox.Show(dgvGroup[3, e.RowIndex].Value.ToString());

                //해당로우의 데이터부분을 DB에 사용여부N으로 업데이트 시키기
                string use;
                if (dgvUDCList[3, e.RowIndex].Value.ToString() == "Y")
                    use = "N";
                else
                    use = "Y";

                UserDefCodeService service = new UserDefCodeService();
                bool result = service.UseYNSwap(use, dgvUDCList[0, e.RowIndex].Value.ToString(), false);

                if (result)
                {
                    MessageBox.Show("변경되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("변경 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }

        private void LoadData()
        {
            UserDefCodeService service = new UserDefCodeService();
            list = service.GetUserDefCodeList();

            dgvUDCList.DataSource = null;
            dgvUDCList.DataSource = list;


            //콤보박스 바인딩
            //foreach (UserDefCodeVO no in list)
            //{
            //    cboGroupName.Items.Add(no.Nop_Ma_Name);
            //}
            //cboGroupName.Items.Insert(0, "");   //빈값으로 된것도 주려고 (선택없음 역할)
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //저장하고 
            if (string.IsNullOrWhiteSpace(txtUdtCode.Text))
            {
                MessageBox.Show("사용자정의 대분류코드를 입력해주십시오.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUdtName.Text))
            {
                MessageBox.Show("사용자정의 대분류명를 입력해주십시오.");
                return;
            }

            UserDefCodeService service = new UserDefCodeService();
            bool result = service.InsertUserDefCode(txtUdtCode.Text, txtUdtName.Text, txtRemark.Text, "로그인관리자이름");
            if (result)
            {
                MessageBox.Show("등록되었습니다.");
                LoadData();
            }

            else
                MessageBox.Show("등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");

            //텍스트박스 초기화
            CommonUtil.ClearTextBox(pnlCondition);
        }

        private void btnTextClear_Click(object sender, EventArgs e)
        {
            CommonUtil.ClearTextBox(pnlCondition);
        }

        private void dgvUDCList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            txtUdtCode.Text = dgvUDCList[0, e.RowIndex].Value.ToString();
            txtUdtCode.ReadOnly = true;
            txtUdtName.Text = dgvUDCList[1, e.RowIndex].Value.ToString();
        }
    }
}
