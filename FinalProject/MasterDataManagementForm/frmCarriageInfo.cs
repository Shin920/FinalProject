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
    public partial class frmCarriageInfo : FinalProject.List_b
    {
        frmMain frm = null;
        List<CarriageVO> list;
        public frmCarriageInfo()
        {
            InitializeComponent();
        }

        private void frmCarriageInfo_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
            frm.Delete += Frm_Delete;
            frm.Insert += Frm_Insert;
            frm.UpDate += Frm_UpDate;


            CommonUtil.SetInitGridView(dgvCarriage);
            CommonUtil.AddGridTextColumn(dgvCarriage, "대차코드", "GV_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvCarriage, "대차명", "GV_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvCarriage, "대차그룹명", "GV_Group", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvCarriage, "대차상태", "GV_Status", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvCarriage, "언로딩작업장", "Unloading_Wc", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvCarriage, "입력일자", "Ins_Date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvCarriage, "사용여부", "Use_YN", colWidth: 100);

            //사용여부 변경버튼 생성
            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            /*btnCell.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);*/     //이 간격은 없어도 될듯
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;

            dgvCarriage.Columns.Add(btnCell);

            LoadData();

            cboName.SelectedIndex = 0;
        }

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCarriageInfo) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }
        }

        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCarriageInfo) && frm.ActiveMdiChild == this)
                {
                    txtUdtCode.ReadOnly = false;
                    btnSave.Enabled = true;
                    CommonUtil.ClearTextBox(pnlCondition);
                }
            }
        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCarriageInfo) && frm.ActiveMdiChild == this)
                {
                    DialogResult dr = MessageBox.Show($"{dgvCarriage.CurrentRow.Cells[1].Value.ToString()}을 삭제하시겠습니까?", "대차 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        CarriageService service = new CarriageService();
                        bool result = service.DeleteCarriage(dgvCarriage.CurrentRow.Cells[0].Value.ToString());
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
                if (fr.GetType() == typeof(frmCarriageInfo) && frm.ActiveMdiChild == this)
                {
                    if (string.IsNullOrWhiteSpace(txtUdtName.Text))
                    {
                        MessageBox.Show("대차명을 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "대차정보 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        CarriageService service = new CarriageService();
                        CarriageVO no = new CarriageVO()
                        {
                            GV_Code = txtUdtCode.Text,
                            GV_Name = txtUdtName.Text,
                            GV_Group = cboUdtGroup.SelectedItem.ToString(),
                            Up_Emp = "로그인관리자"
                        };
                        bool result = service.UpdateCarriage(no);
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
                if (fr.GetType() == typeof(frmCarriageInfo) && frm.ActiveMdiChild == this)
                {

                    //콤보박스로 이름을 선택했을경우 , 코드번호를 입력해서 검색할 경우, 두개 다 입력했을경우, 아무것도 입력 안했을 경우
                    //코드는 입력한 수를 포함하고있는지로 하고 이름은 콤보박스이기때문에 같은지로 
                    if (cboName.SelectedIndex <= 0 && string.IsNullOrWhiteSpace(txtCode.Text))
                    {
                        MessageBox.Show("검색하실 조건을 입력해주십시오.");
                    }
                    else if (cboName.SelectedIndex > 0 && !string.IsNullOrWhiteSpace(txtCode.Text))
                    {
                        List<CarriageVO> findList = list.FindAll(x => x.GV_Code.Contains(txtCode.Text) && x.GV_Name.Equals(cboName.SelectedValue.ToString()));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvCarriage.DataSource = null;
                            dgvCarriage.DataSource = findList;

                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(txtCode.Text))
                    {
                        List<CarriageVO> findList = list.FindAll(x => x.GV_Code.Contains(txtCode.Text));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvCarriage.DataSource = null;
                            dgvCarriage.DataSource = findList;
                        }

                    }
                    else if (cboName.SelectedIndex > 0)
                    {
                        List<CarriageVO> findList = list.FindAll(x => x.GV_Name.Equals(cboName.SelectedItem));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvCarriage.DataSource = null;
                            dgvCarriage.DataSource = findList;
                        }

                    }
                }
            }
        }



        private void LoadData()
        {
            CarriageService service = new CarriageService();
            list = service.GetCarriageList();

            dgvCarriage.DataSource = null;
            dgvCarriage.DataSource = list;


            //콤보박스 바인딩
            cboName.Items.Clear();
            foreach (CarriageVO no in list)
            {
                cboName.Items.Add(no.GV_Name);
            }
            cboName.Items.Insert(0, "선택");   //빈값으로 된것도 주려고 (선택없음 역할)
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //저장하고 
            if (string.IsNullOrWhiteSpace(txtUdtCode.Text))
            {
                MessageBox.Show("대차코드를 입력해주십시오.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUdtName.Text))
            {
                MessageBox.Show("대차명을 입력해주십시오.");
                return;
            }

            CarriageService service = new CarriageService();
            bool result = service.InsertCarriage(txtUdtCode.Text, txtUdtName.Text, cboUdtGroup.Text, "로그인관리자이름");
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


        private void dgvCarriage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            txtUdtCode.ReadOnly = true;
            txtUdtCode.Text = dgvCarriage[0, e.RowIndex].Value.ToString();
            txtUdtName.Text = dgvCarriage[1, e.RowIndex].Value.ToString();
        }

        private void dgvCarriage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)  //사용여부 변경버튼
            {
                //MessageBox.Show(dgvGroup[3, e.RowIndex].Value.ToString());

                //해당로우의 데이터부분을 DB에 사용여부N으로 업데이트 시키기
                string use;
                if (dgvCarriage[6, e.RowIndex].Value.ToString() == "Y")
                    use = "N";
                else
                    use = "Y";

                CarriageService service = new CarriageService();
                bool result = service.UseYNSwap(use, dgvCarriage[0, e.RowIndex].Value.ToString());

                if (result)
                {
                    MessageBox.Show("변경되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("변경 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }
    }
}
