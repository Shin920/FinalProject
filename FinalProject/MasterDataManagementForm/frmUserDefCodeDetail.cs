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
    public partial class frmUserDefCodeDetail : FinalProject.List_List_b
    {
        frmMain frm;
        List<UserDefCodeVO> coList;
        List<UserDefCodeVO> coDetailList;
        public frmUserDefCodeDetail()
        {
            InitializeComponent();

            cboSearchType.Items.Add("선택");
            cboSearchType.Items.Add("대분류");
            cboSearchType.Items.Add("상세분류");
            cboSearchType.SelectedIndex = 0;
        }

        private void frmUserDefCodeDetail_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvBig);
            CommonUtil.AddGridTextColumn(dgvBig, "대분류코드", "Userdefine_Ma_Code", colWidth: 120);
            CommonUtil.AddGridTextColumn(dgvBig, "대분류명", "Userdefine_Ma_Name", colWidth: 120);
            CommonUtil.AddGridTextColumn(dgvBig, "사용여부", "Use_YN", colWidth: 120);

            CommonUtil.SetInitGridView(dgvDetail);
            CommonUtil.AddGridTextColumn(dgvDetail, "상세분류코드", "Userdefine_Mi_Code", colWidth: 120);
            CommonUtil.AddGridTextColumn(dgvDetail, "상세분류명", "Userdefine_Mi_Name", colWidth: 120);
            CommonUtil.AddGridTextColumn(dgvDetail, "비고", "Remark", colWidth: 120);
            CommonUtil.AddGridTextColumn(dgvDetail, "사용여부", "Use_YN", colWidth: 120);
            CommonUtil.AddGridTextColumn(dgvDetail, "대분류코드", "Userdefine_Ma_Code", colWidth: 120, visibility: false);

            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            /*btnCell.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);*/     //이 간격은 없어도 될듯
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;

            dgvDetail.Columns.Insert(5, btnCell);

            LoadData();



            frm = (frmMain)this.MdiParent;
            frm.Insert += Frm_Insert;
            frm.Select += Frm_Select;
            frm.Delete += Frm_Delete;
            frm.Refresh += Frm_Refresh;
            frm.UpDate += Frm_UpDate;
        }

        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCodeDetail) && frm.ActiveMdiChild == this)
                {
                    txtUdtDetailCode.ReadOnly = false;
                    btnSave.Enabled = true;
                }
            }
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCodeDetail) && frm.ActiveMdiChild == this)
                {
                    if (string.IsNullOrWhiteSpace(txtUdtName.Text))
                    {
                        MessageBox.Show("상세분류명을 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "상세분류 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        UserDefCodeService service = new UserDefCodeService();
                        UserDefCodeVO no = new UserDefCodeVO()
                        {
                            Userdefine_Mi_Code = txtUdtDetailCode.Text,
                            Userdefine_Mi_Name = txtUdtName.Text,
                            Remark = txtUdtRemark.Text,
                            Up_Emp = "로그인관리자"
                        };
                        bool result = service.UpdateUserDefCodeDetail(no);
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

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCodeDetail) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }
        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCodeDetail) && frm.ActiveMdiChild == this)
                {
                    DialogResult dr = MessageBox.Show($"{dgvDetail.CurrentRow.Cells[1].Value.ToString()}를 삭제하시겠습니까?", "상세분류 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        UserDefCodeService service = new UserDefCodeService();
                        bool result = service.DeleteUserDefCodeDetail(dgvDetail.CurrentRow.Cells[0].Value.ToString());
                        if (result)
                            MessageBox.Show("삭제되었습니다.");
                        else
                            MessageBox.Show("삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }
                }
            }
            LoadData();
            CommonUtil.ClearTextBox(pnlCondition);
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmUserDefCodeDetail) && frm.ActiveMdiChild == this)
                {
                    if (cboSearchType.SelectedIndex <= 0 || string.IsNullOrWhiteSpace(txtCode.Text) && string.IsNullOrWhiteSpace(txtName.Text))
                    {
                        MessageBox.Show("검색하실 조건을 입력해주십시오.");
                        return;
                    }
                    if (cboSearchType.SelectedIndex > 0 && cboSearchType.SelectedItem.ToString() == "대분류")
                    {
                        if (!string.IsNullOrWhiteSpace(txtCode.Text) && !string.IsNullOrWhiteSpace(txtName.Text))
                        {
                            dgvBig.DataSource = coList.FindAll(x => x.Userdefine_Ma_Code.Contains(txtCode.Text) && x.Userdefine_Ma_Name.Contains(txtName.Text));
                            dgvDetail.DataSource = coDetailList.FindAll(x => x.Userdefine_Ma_Code.Contains(dgvBig.CurrentRow.Cells[0].Value.ToString()) && x.Userdefine_Ma_Name.Contains(dgvBig.CurrentRow.Cells[1].Value.ToString()));
                        }
                        else if (!string.IsNullOrWhiteSpace(txtCode.Text))
                        {
                            dgvBig.DataSource = coList.FindAll(x => x.Userdefine_Ma_Code.Contains(txtCode.Text));
                            dgvDetail.DataSource = coDetailList.FindAll(x => x.Userdefine_Ma_Code.Contains(dgvBig.CurrentRow.Cells[0].Value.ToString()));
                        }
                        else if (!string.IsNullOrWhiteSpace(txtName.Text))
                        {
                            dgvBig.DataSource = coList.FindAll(x => x.Userdefine_Ma_Code.Contains(txtName.Text));
                            dgvDetail.DataSource = coDetailList.FindAll(x => x.Userdefine_Ma_Code.Contains(dgvBig.CurrentRow.Cells[0].Value.ToString()));
                        }
                    }
                    else if (cboSearchType.SelectedIndex > 0 && cboSearchType.SelectedItem.ToString() == "상세분류")
                    {
                        if (!string.IsNullOrWhiteSpace(txtCode.Text) && !string.IsNullOrWhiteSpace(txtName.Text))
                        {
                            dgvDetail.DataSource = coDetailList.FindAll(x => x.Userdefine_Mi_Code.Contains(txtCode.Text) && x.Userdefine_Mi_Name.Contains(txtName.Text));
                            string val = dgvDetail.CurrentRow.Cells[4].Value.ToString();
                            //지금 6번셀이 코드값인데 visible을 false로 해서 그냥 contains안에 넣으니까 오류가 발생함. 그래서 메세지박스로 visible = flase인것도
                            //값을 읽어올수는 있는걸 확인했기때문에 그걸 변수에 담아서 넣어주는것
                            dgvBig.DataSource = coList.FindAll(x => x.Userdefine_Ma_Code.Contains(val));
                        }
                        else if (!string.IsNullOrWhiteSpace(txtCode.Text))
                        {
                            dgvDetail.DataSource = coDetailList.FindAll(x => x.Userdefine_Mi_Code.Contains(txtCode.Text));
                            string val = dgvDetail.CurrentRow.Cells[4].Value.ToString();
                            dgvBig.DataSource = coList.FindAll(x => x.Userdefine_Ma_Code.Contains(val));
                        }
                        else if (!string.IsNullOrWhiteSpace(txtName.Text))
                        {
                            dgvDetail.DataSource = coDetailList.FindAll(x => x.Userdefine_Mi_Name.Contains(txtName.Text));
                            string val = dgvDetail.CurrentRow.Cells[4].Value.ToString();
                            dgvBig.DataSource = coList.FindAll(x => x.Userdefine_Ma_Code.Contains(val));
                        }
                    }
                }

            }
        }

        private void LoadData()
        {
            UserDefCodeService service = new UserDefCodeService();

            coList = service.GetUserDefCodeList();
            coDetailList = service.GetUserDefCodeDetailList();

            dgvBig.DataSource = null;
            dgvBig.DataSource = coList;

            dgvDetail.DataSource = null;
            dgvDetail.DataSource = coDetailList.FindAll(x => x.Userdefine_Ma_Code.Equals(dgvBig.CurrentRow.Cells[0].Value.ToString()));

            //상세분류에도 처음부터 전체 목록을 보여줄지 아니면 대분류의 특정 로우를 클릭했을때 그거에 맞는것만 보여줄지
        }

        private void dgvBig_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail.DataSource = null;
            dgvDetail.DataSource = coDetailList.FindAll((x) => x.Userdefine_Ma_Code.Equals(dgvBig[0, e.RowIndex].Value.ToString()));

            txtUdtCode.Text = dgvBig.CurrentRow.Cells[0].Value.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUdtCode.Text) || string.IsNullOrWhiteSpace(txtUdtDetailCode.Text) || string.IsNullOrWhiteSpace(txtUdtName.Text))
            {
                MessageBox.Show("필수입력 사항을 입력해주십시오.");
                return;
            }

            UserDefCodeService service = new UserDefCodeService();
            UserDefCodeVO no = new UserDefCodeVO()
            {
                Userdefine_Ma_Code = txtUdtCode.Text,
                Userdefine_Mi_Code = txtUdtDetailCode.Text,
                Userdefine_Mi_Name = txtUdtName.Text,
                Remark = txtUdtRemark.Text,
                Ins_Emp = "로그인관리자"
            };

            bool result = service.InsertUserDefCodeDetail(no);
            if (result)
            {
                MessageBox.Show("등록되었습니다.");
                LoadData();
                CommonUtil.ClearTextBox(pnlCondition);

            }
            else
                MessageBox.Show("등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            CommonUtil.ClearTextBox(pnlCondition);
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)  //사용여부 변경버튼
            {
                //해당로우의 데이터부분을 DB에 사용여부N으로 업데이트 시키기
                string use;
                if (dgvDetail[3, e.RowIndex].Value.ToString() == "Y")
                    use = "N";
                else
                    use = "Y";

                UserDefCodeService service = new UserDefCodeService();
                bool result = service.UseYNSwap(use, dgvDetail[0, e.RowIndex].Value.ToString(), true);

                if (result)
                {
                    MessageBox.Show("변경되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("변경 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");

            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //검색을 해서 조회되었을때 로우를 더블클릭하면 그 로우를 갖는 대분류가 대분류그리드뷰에 나오게 하기          
            string val = dgvDetail[4, e.RowIndex].Value.ToString();
            dgvBig.DataSource = coList.FindAll(x => x.Userdefine_Ma_Code.Contains(val));

            //수정을 위해 텍스트박스에 값 채워지게
            txtUdtDetailCode.Text = dgvDetail[0, e.RowIndex].Value.ToString();
            txtUdtName.Text = dgvDetail[1, e.RowIndex].Value.ToString();
            if (dgvDetail[2, e.RowIndex].Value != null)
            {
                txtUdtRemark.Text = dgvDetail[2, e.RowIndex].Value.ToString();
            }
            txtUdtCode.Text = dgvDetail[4, e.RowIndex].Value.ToString();

            btnSave.Enabled = false;


        }
    }
}
