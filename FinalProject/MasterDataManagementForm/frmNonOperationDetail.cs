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
    public partial class frmNonOperationDetail : FinalProject.List_List_b
    {
        frmMain frm;
        List<NonOperationVO> nopList;
        List<NonOperationVO> nopDetailList;
        bool IsSelect = false;       //조회 후에 상세그리드뷰를 더블클릭했을때와 일반적인 상황에서 더블클릭했을때 보여지는게 다르게 하려고(조회시 true, 새로고침시 false)
        bool isBookMark = false;

        public frmNonOperationDetail()
        {
            InitializeComponent();

            cboSearchType.Items.Add("");
            cboSearchType.Items.Add("비가동 대분류");
            cboSearchType.Items.Add("비가동 상세분류");    //로드에 만들면 계속 생성되서
        }

        private void frmNonOperationDetail_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvGroup);
            CommonUtil.AddGridTextColumn(dgvGroup, "비가동 대분류코드", "Nop_Ma_Code", colWidth: 130, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvGroup, "비가동 대분류명", "Nop_Ma_Name", colWidth: 140);
            CommonUtil.AddGridTextColumn(dgvGroup, "입력일자", "Ins_Date", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvGroup, "사용여부", "Use_YN", colWidth: 73, align: DataGridViewContentAlignment.MiddleCenter);

            CommonUtil.SetInitGridView(dgvDetailGroup);
            CommonUtil.AddGridTextColumn(dgvDetailGroup, "상세분류코드", "Nop_Mi_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailGroup, "상세분류명", "Nop_Mi_Name", colWidth: 175);
            CommonUtil.AddGridTextColumn(dgvDetailGroup, "입력일자", "Ins_Date", colWidth: 175, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailGroup, "비고", "Remark", colWidth: 357);
            CommonUtil.AddGridTextColumn(dgvDetailGroup, "사용여부", "Use_YN", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailGroup, "대분류코드", "Nop_Ma_Code", colWidth: 370, visibility:false);

            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            /*btnCell.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);*/     //이 간격은 없어도 될듯
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;

            dgvDetailGroup.Columns.Insert(5, btnCell);

            LoadData();

            

            frm = (frmMain)this.MdiParent;
            frm.Insert += Frm_Insert;
            frm.Select += Frm_Select;
            frm.Delete += Frm_Delete;
            frm.Refresh += Frm_Refresh;
            frm.UpDate += Frm_UpDate;
            frm.BookMarkReg += Frm_BookMarkReg;

            //if (frm.BookMarkList != null)
            //{
            //    foreach (string r in frm.BookMarkList)
            //    {
            //        if (this.GetType().ToString().Split('.')[1].Trim() == r.Trim())     //그냥 getType으로 하면 클래스명까지 붙어서 .으로 잘라주고 trim을 양쪽다 안하니 안나와서
            //        {
            //            frm.btnBookMarkColor = Color.Yellow;
            //            isBookMark = true;
            //        }
            //        else
            //        {
            //            frm.btnBookMarkColor = Color.Transparent;   //다른 폼으로 갔는데 거기는 즐겨찾기 아니면 다시 원래 색으로
            //        }
            //    }
            //}
        }

        private void Frm_BookMarkReg(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperationDetail) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmNonOperationDetail");
                        if (result)
                        {
                            MessageBox.Show("즐겨찾기 등록되었습니다.");
                            isBookMark = true;
                            frm.btnBookMarkColor = Color.SteelBlue;
                        }
                        else
                            MessageBox.Show("즐겨찾기 등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }
                    else
                    {
                        MenuService service = new MenuService();
                        bool result = service.DeleteBookMark(frm.UserID, "frmNonOperationDetail");
                        if (result)
                        {
                            MessageBox.Show("즐겨찾기 해제되었습니다.");
                            isBookMark = false;
                            frm.btnBookMarkColor = Color.FromArgb(57, 61, 70);
                        }

                        else
                            MessageBox.Show("즐겨찾기 해제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }

                }
            }
        }

        private void LoadData()
        {
            btnSave.Enabled = false;

            NonOperationService service = new NonOperationService();

            nopList = service.GetNonOperationGroupList();
            nopDetailList = service.GetNopOperationDetailList();

            dgvGroup.DataSource = null;
            dgvGroup.DataSource = nopList;

            //dgvGroup.Paint += DgvGroup_Paint;

            int rowIndex = -1;
            if (!string.IsNullOrWhiteSpace(lblNOCode.Text))
            {
                foreach (DataGridViewRow row in dgvGroup.Rows)
                {
                    if (row.Cells[0].Value.ToString().Contains(lblNOCode.Text))
                    {
                        dgvGroup.ClearSelection();
                        rowIndex = row.Index;
                        //dgvProduct.CurrentCell = dgvProduct.Rows[rowIndex].Cells[0];  //이렇게 하면 한개까지만 선택이 되서 아래처럼 Selected True하니까 여러개까지 가능
                        dgvGroup.Rows[rowIndex].Selected = true;
                        break;    //한개만 찾는거면 찾으면 break로 바로 나가주는게 좋은데 contains로 포함하는 모든 애들을 찾을거라 중간에 나가는거 없이 하는것
                    }

                }
                dgvDetailGroup.DataSource = null;
                dgvDetailGroup.DataSource = nopDetailList.FindAll(x => x.Nop_Ma_Code.Equals(dgvGroup[0, rowIndex].Value.ToString()));
                lblNOCode.Text = "";
                return;

            }
            dgvDetailGroup.DataSource = null;
            dgvDetailGroup.DataSource = nopDetailList.FindAll(x => x.Nop_Ma_Code.Equals(dgvGroup.CurrentRow.Cells[0].Value.ToString()));
            //상세분류에도 처음부터 전체 목록을 보여줄지 아니면 대분류의 특정 로우를 클릭했을때 그거에 맞는것만 보여줄지
            //dgvDetailGroup.Paint += DgvDetailGroup_Paint;
        }

        //private void DgvDetailGroup_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvDetailGroup.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvDetailGroup.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvDetailGroup.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        //private void DgvGroup_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvGroup.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvGroup.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvGroup.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperationDetail) && frm.ActiveMdiChild == this)
                {

                    //for(int i = 0; i < nopDetailList.Count; i++)
                    //{
                    //    nopDetailList[i].Nop_Mi_Code.CompareTo()
                    //}
                    //for문으로 돌아서 현재의 전 항목에 대해 compare하고 (compare재정의) 가장 큰 애가 나오면 그 애의 숫자에 +1 또는 sort해서 마지막 인덱스에 잇는애 +1

                    //근데 어차피 DB에서 정렬된 상태에서 리스트에 들어가니까 마지막것만 찾으면 될거같아서 이렇게 했다

                    if (nopDetailList.Count < 1)
                    {

                        txtNewDetailCode.Text = "NOPD10001";
                        txtNewCode.Text = dgvGroup.CurrentRow.Cells[0].Value.ToString();
                        btnSave.Enabled = true;
                        return;
                    }

                    int code = int.Parse(nopDetailList[nopDetailList.Count - 1].Nop_Mi_Code.Replace("NOPD", ""));
                    
                    txtNewDetailCode.Text = "NOPD" + (code + 1);

                    txtNewCode.Text = dgvGroup.CurrentRow.Cells[0].Value.ToString();

                    btnSave.Enabled = true;
                }
            }
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperationDetail) && frm.ActiveMdiChild == this)
                {
                    btnSave.Enabled = false;

                    if (string.IsNullOrWhiteSpace(txtNewDetailName.Text))
                    {
                        MessageBox.Show("상세분류명을 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "상세분류 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        NonOperationService service = new NonOperationService();
                        NonOperationVO no = new NonOperationVO()
                        {
                            Nop_Mi_Code = txtNewDetailCode.Text,
                            Nop_Mi_Name = txtNewDetailName.Text,
                            Remark = txtNote.Text,
                            Up_Emp = frm.UserName
                        };
                        bool result = service.UpdateDetailNop(no);
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
                if (fr.GetType() == typeof(frmNonOperationDetail) && frm.ActiveMdiChild == this)
                {
                    btnSave.Enabled = false;
                    IsSelect = false;
                    LoadData();
                    CommonUtil.ClearTextBox(pnlCondition);
                }
            }
        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperationDetail) && frm.ActiveMdiChild == this)
                {
                    btnSave.Enabled = false;

                    DialogResult dr = MessageBox.Show($"{dgvDetailGroup.CurrentRow.Cells[1].Value.ToString()}를 삭제하시겠습니까?", "비가동 상세분류 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        NonOperationService service = new NonOperationService();
                        bool result = service.DeleteDetailNop(dgvDetailGroup.CurrentRow.Cells[0].Value.ToString());
                        if (result)
                        {
                            MessageBox.Show("삭제되었습니다.");
                            LoadData();
                        }
                        else
                            MessageBox.Show("삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperationDetail) && frm.ActiveMdiChild == this)
                {
                    if (cboSearchType.SelectedIndex <= 0 || string.IsNullOrWhiteSpace(txtSearchCode.Text) && string.IsNullOrWhiteSpace(txtSearchName.Text))
                    {
                        MessageBox.Show("검색하실 조건을 입력해주십시오.");
                        return;
                    }

                    IsSelect = true;

                    if (cboSearchType.SelectedIndex > 0 && cboSearchType.SelectedItem.ToString() == "비가동 대분류")
                    {
                        if (!string.IsNullOrWhiteSpace(txtSearchCode.Text) && !string.IsNullOrWhiteSpace(txtSearchName.Text))
                        {
                            dgvGroup.DataSource = nopList.FindAll(x => x.Nop_Ma_Code.Contains(txtSearchCode.Text) && x.Nop_Ma_Name.Contains(txtSearchName.Text));
                            dgvDetailGroup.DataSource = nopDetailList.FindAll(x => x.Nop_Ma_Code.Contains(dgvGroup.CurrentRow.Cells[0].Value.ToString()) && x.Nop_Ma_Name.Contains(dgvGroup.CurrentRow.Cells[1].Value.ToString()));
                        }
                        else if (!string.IsNullOrWhiteSpace(txtSearchCode.Text))
                        {
                            dgvGroup.DataSource = nopList.FindAll(x => x.Nop_Ma_Code.Contains(txtSearchCode.Text));
                            dgvDetailGroup.DataSource = nopDetailList.FindAll(x => x.Nop_Ma_Code.Contains(dgvGroup.CurrentRow.Cells[0].Value.ToString()));
                        }
                        else if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                        {
                            dgvGroup.DataSource = nopList.FindAll(x => x.Nop_Ma_Name.Contains(txtSearchName.Text));
                            dgvDetailGroup.DataSource = nopDetailList.FindAll(x => x.Nop_Ma_Code.Contains(dgvGroup.CurrentRow.Cells[0].Value.ToString()));
                        }
                    }
                    else if (cboSearchType.SelectedIndex > 0 && cboSearchType.SelectedItem.ToString() == "비가동 상세분류")
                    {
                        if (!string.IsNullOrWhiteSpace(txtSearchCode.Text) && !string.IsNullOrWhiteSpace(txtSearchName.Text))
                        {
                            dgvDetailGroup.DataSource = nopDetailList.FindAll(x => x.Nop_Mi_Code.Contains(txtSearchCode.Text) && x.Nop_Mi_Name.Contains(txtSearchName.Text));
                            string val = dgvDetailGroup.CurrentRow.Cells[6].Value.ToString();
                            //지금 6번셀이 코드값인데 visible을 false로 해서 그냥 contains안에 넣으니까 오류가 발생함. 그래서 메세지박스로 visible = flase인것도
                            //값을 읽어올수는 있는걸 확인했기때문에 그걸 변수에 담아서 넣어주는것
                            dgvGroup.DataSource = nopList.FindAll(x => x.Nop_Ma_Code.Contains(val));
                        }
                        else if (!string.IsNullOrWhiteSpace(txtSearchCode.Text))
                        {
                            dgvDetailGroup.DataSource = nopDetailList.FindAll(x => x.Nop_Mi_Code.Contains(txtSearchCode.Text));
                            string val = dgvDetailGroup.CurrentRow.Cells[6].Value.ToString();
                            dgvGroup.DataSource = nopList.FindAll(x => x.Nop_Ma_Code.Contains(val));
                        }
                        else if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                        {
                            dgvDetailGroup.DataSource = nopDetailList.FindAll(x => x.Nop_Mi_Name.Contains(txtSearchName.Text));
                            string val = dgvDetailGroup.CurrentRow.Cells[6].Value.ToString();
                            dgvGroup.DataSource = nopList.FindAll(x => x.Nop_Ma_Code.Contains(val));                         
                        }
                    }
                }

            }
        }

       
        private void dgvGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            dgvDetailGroup.DataSource = null;
            dgvDetailGroup.DataSource = nopDetailList.FindAll((x) => x.Nop_Ma_Code.Equals(dgvGroup[0, e.RowIndex].Value.ToString()));

            txtNewCode.Text = dgvGroup.CurrentRow.Cells[0].Value.ToString();
            lblNOCode.Text = dgvGroup.CurrentRow.Cells[0].Value.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewCode.Text) || string.IsNullOrWhiteSpace(txtNewDetailCode.Text) || string.IsNullOrWhiteSpace(txtNewDetailName.Text))
            {
                MessageBox.Show("필수입력 사항을 입력해주십시오.");
                return;
            }

            NonOperationService service = new NonOperationService();
            NonOperationVO no = new NonOperationVO()
            {
                Nop_Ma_Code = txtNewCode.Text,
                Nop_Mi_Code = txtNewDetailCode.Text,
                Nop_Mi_Name = txtNewDetailName.Text,
                Remark = txtNote.Text,
                Ins_Emp = frm.UserName
            };

            bool result = service.InsertDetailNop(no);
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

        private void dgvDetailGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            if (e.ColumnIndex == 5)  //사용여부 변경버튼
            {
                //해당로우의 데이터부분을 DB에 사용여부N으로 업데이트 시키기
                string use;
                if (dgvDetailGroup[4, e.RowIndex].Value.ToString() == "Y")
                    use = "N";
                else
                    use = "Y";

                NonOperationService service = new NonOperationService();
                bool result = service.UseYNSwap(use, dgvDetailGroup[0, e.RowIndex].Value.ToString(), true);

                if (result)
                {
                    MessageBox.Show("변경되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("변경 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");

            }
        }

        private void dgvDetailGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //검색을 해서 조회되었을때 로우를 더블클릭하면 그 로우를 갖는 대분류가 대분류그리드뷰에 나오게 하기  
            if (IsSelect)
            {
                string val = dgvDetailGroup[6, e.RowIndex].Value.ToString();
                dgvGroup.DataSource = nopList.FindAll(x => x.Nop_Ma_Code.Contains(val));
            }

            //수정을 위해 텍스트박스에 값 채워지게
            txtNewDetailCode.Text = dgvDetailGroup[0, e.RowIndex].Value.ToString();
            txtNewDetailName.Text = dgvDetailGroup[1, e.RowIndex].Value.ToString();
            txtNote.Text = dgvDetailGroup[3, e.RowIndex].Value.ToString();
            txtNewCode.Text = dgvDetailGroup[6, e.RowIndex].Value.ToString();

            btnSave.Enabled = false;


        }
    }
}
