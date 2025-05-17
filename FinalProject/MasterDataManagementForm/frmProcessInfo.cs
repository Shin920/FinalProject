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
    public partial class frmProcessInfo : FinalProject.List_b
    {
        frmMain frm = null;
        List<ProcessVO> list;
        public frmProcessInfo()
        {
            InitializeComponent();
        }

        private void frmProcessInfo_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
            frm.Delete += Frm_Delete;
            frm.Insert += Frm_Insert;
            frm.UpDate += Frm_UpDate;


            CommonUtil.SetInitGridView(dgvPrcList);
            CommonUtil.AddGridTextColumn(dgvPrcList, "공정코드", "Process_code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvPrcList, "공정이름", "Process_name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvPrcList, "비고", "Remark", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvPrcList, "입력일자", "Ins_Date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvPrcList, "사용여부", "Use_YN", colWidth: 100);

            //사용여부 변경버튼 생성
            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            /*btnCell.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);*/     //이 간격은 없어도 될듯
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;

            dgvPrcList.Columns.Add(btnCell);

            LoadData();

            cboPrcName.SelectedIndex = 0;
        }

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmProcessInfo) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }
        }

        private void Frm_Insert(object sender, EventArgs e)
        {
            CommonUtil.ClearTextBox(pnlCondition);

            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmProcessInfo) && frm.ActiveMdiChild == this)
                {
                    if (list.Count < 1)
                    {
                        txtUdtPrcCode.Text = "PC10001";
                        btnSave.Enabled = true;
                        return;
                    }

                    int code = int.Parse(list[list.Count - 1].Process_code.Replace("PC", ""));
                    txtUdtPrcCode.Text = "PC" + (code + 1);

                    btnSave.Enabled = true;
                }
            }
        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmProcessInfo) && frm.ActiveMdiChild == this)
                {
                    DialogResult dr = MessageBox.Show($"{dgvPrcList.CurrentRow.Cells[1].Value.ToString()}을 삭제하시겠습니까?", "공정 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ProcessService service = new ProcessService();
                        bool result = service.DeleteProcess(dgvPrcList.CurrentRow.Cells[0].Value.ToString());
                        if (result)
                            MessageBox.Show("삭제되었습니다.");
                        else
                            MessageBox.Show("삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }

                }
            }

            LoadData();
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmProcessInfo) && frm.ActiveMdiChild == this)
                {
                    if (string.IsNullOrWhiteSpace(txtUdtPrcName.Text))
                    {
                        MessageBox.Show("공정명을 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "공정명 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        ProcessService service = new ProcessService();
                        ProcessVO no = new ProcessVO()
                        {
                            Process_code = txtUdtPrcCode.Text,
                            Process_name = txtUdtPrcName.Text,
                            Remark = txtUdtPrcRemark.Text,
                            Up_Emp = "로그인관리자"
                        };
                        bool result = service.UpdateProcess(no);
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
                if (fr.GetType() == typeof(frmProcessInfo) && frm.ActiveMdiChild == this)
                {
                  
                    //콤보박스로 이름을 선택했을경우 , 코드번호를 입력해서 검색할 경우, 두개 다 입력했을경우, 아무것도 입력 안했을 경우
                    //코드는 입력한 수를 포함하고있는지로 하고 이름은 콤보박스이기때문에 같은지로 
                    if (cboPrcName.SelectedIndex <= 0 && string.IsNullOrWhiteSpace(txtPrcCode.Text))
                    {
                        MessageBox.Show("검색하실 조건을 입력해주십시오.");
                    }
                    else if (cboPrcName.SelectedIndex > 0 && !string.IsNullOrWhiteSpace(txtPrcCode.Text))
                    {
                        List<ProcessVO> findList = list.FindAll(x => x.Process_code.Contains(txtPrcCode.Text) && x.Process_name.Equals(cboPrcName.SelectedValue.ToString()));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvPrcList.DataSource = null;
                            dgvPrcList.DataSource = findList;
                            
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(txtPrcCode.Text))
                    {
                        List<ProcessVO> findList = list.FindAll(x => x.Process_code.Contains(txtPrcCode.Text));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvPrcList.DataSource = null;
                            dgvPrcList.DataSource = findList;
                        }

                    }
                    else if (cboPrcName.SelectedIndex > 0)
                    {
                        List<ProcessVO> findList = list.FindAll(x => x.Process_name.Equals(cboPrcName.SelectedItem));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvPrcList.DataSource = null;
                            dgvPrcList.DataSource = findList;
                        }

                    }
                }
            }
        }

        

        private void LoadData()
        {
            ProcessService service = new ProcessService();
            list = service.GetProcessList();

            dgvPrcList.DataSource = null;
            dgvPrcList.DataSource = list;


            //콤보박스 바인딩
            cboPrcName.Items.Clear();
            foreach (ProcessVO no in list)
            {                
                cboPrcName.Items.Add(no.Process_name);
            }
            cboPrcName.Items.Insert(0, "선택");   //빈값으로 된것도 주려고 (선택없음 역할)
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //저장하고 
            if (string.IsNullOrWhiteSpace(txtUdtPrcCode.Text))
            {
                MessageBox.Show("공정코드를 입력해주십시오.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUdtPrcName.Text))
            {
                MessageBox.Show("공정명을 입력해주십시오.");
                return;
            }

            ProcessService service = new ProcessService();
            bool result = service.InsertProcess(txtUdtPrcCode.Text, txtUdtPrcName.Text, txtUdtPrcRemark.Text, "로그인관리자이름");
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
             

        private void dgvPrcList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            txtUdtPrcCode.Text = dgvPrcList[0, e.RowIndex].Value.ToString();
            txtUdtPrcName.Text = dgvPrcList[1, e.RowIndex].Value.ToString();
            txtUdtPrcRemark.Text = dgvPrcList[2, e.RowIndex].Value.ToString();
        }

        private void dgvPrcList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)  //사용여부 변경버튼
            {
                //MessageBox.Show(dgvGroup[3, e.RowIndex].Value.ToString());

                //해당로우의 데이터부분을 DB에 사용여부N으로 업데이트 시키기
                string use;
                if (dgvPrcList[4, e.RowIndex].Value.ToString() == "Y")
                    use = "N";
                else
                    use = "Y";

                ProcessService service = new ProcessService();
                bool result = service.UseYNSwap(use, dgvPrcList[0, e.RowIndex].Value.ToString());

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
