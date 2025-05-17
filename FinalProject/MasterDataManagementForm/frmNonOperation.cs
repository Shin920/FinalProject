using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FinalProjectVO;

namespace FinalProject
{
    public partial class frmNonOperation : FinalProject.List_b
    {
        frmMain frm = null;
        List<NonOperationVO> list;  //조회 이벤트에서도 이 데이터를 가지고 찾아내기 위해서 전역으로 선언해서 데이터 담아놓기

        bool isBookMark = false;
        public frmNonOperation()
        {
            InitializeComponent();
        }

        private void frmNonOperation_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvGroup);
            CommonUtil.AddGridTextColumn(dgvGroup, "비가동 대분류코드", "Nop_Ma_Code", colWidth:365, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvGroup, "비가동 대분류명", "Nop_Ma_Name", colWidth: 365);
            CommonUtil.AddGridTextColumn(dgvGroup, "입력일자", "Ins_Date", colWidth: 365, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvGroup, "사용여부", "Use_YN", colWidth: 365, align: DataGridViewContentAlignment.MiddleCenter);          

            //사용여부 변경버튼 생성
            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();
           
            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            /*btnCell.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);*/     //이 간격은 없어도 될듯
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;
                           
            dgvGroup.Columns.Add(btnCell);

            LoadData();   

            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
            frm.Delete += Frm_Delete;
            frm.Insert += Frm_Insert;
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
                if (fr.GetType() == typeof(frmNonOperation) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmNonOperation");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmNonOperation");
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

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperation) && frm.ActiveMdiChild == this)
                {
                    btnSave.Enabled = false;
                    if (string.IsNullOrWhiteSpace(txtNewGroupName.Text))
                    {
                        MessageBox.Show("비가동 대분류명을 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "비가동 대분류 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        NonOperationService service = new NonOperationService();
                        NonOperationVO no = new NonOperationVO()
                        {
                            Nop_Ma_Code = txtNewGroupCode.Text,
                            Nop_Ma_Name = txtNewGroupName.Text,                          
                            Up_Emp = frm.UserName
                        };
                        bool result = service.UpdateNonOperation(no);
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

        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperation) && frm.ActiveMdiChild == this)
                {
                    if (list.Count < 1)
                    {
                        txtNewGroupCode.Text = "NOP10001";
                        btnSave.Enabled = true;
                        return;
                    }

                    int code = int.Parse(list[list.Count - 1].Nop_Ma_Code.Replace("NOP", ""));
                    txtNewGroupCode.Text = "NOP" + (code + 1);

                    btnSave.Enabled = true;
                }
            }
           
        }

        private void LoadData()
        {
            btnSave.Enabled = false;

            NonOperationService service = new NonOperationService();
            list = service.GetNonOperationGroupList();

            dgvGroup.DataSource = null;
            dgvGroup.DataSource = list;

            //dgvGroup.Paint += DgvGroup_Paint;

            cboGroupName.Items.Clear();
            foreach (NonOperationVO no in list)
            {
                cboGroupName.Items.Add(no.Nop_Ma_Name);
            }
            cboGroupName.Items.Insert(0, "");   //빈값으로 된것도 주려고 (선택없음 역할)
        }

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

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperation) && frm.ActiveMdiChild == this)
                {
                    btnSave.Enabled = false;

                    DialogResult dr = MessageBox.Show($"{dgvGroup.CurrentRow.Cells[1].Value.ToString()}를 삭제하시겠습니까?", "비가동 대분류 삭제", MessageBoxButtons.YesNo);
                    if(dr == DialogResult.Yes)
                    {
                        NonOperationService service = new NonOperationService();
                        bool result = service.DeleteNonOperation(dgvGroup.CurrentRow.Cells[0].Value.ToString());
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

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperation) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                    CommonUtil.ClearTextBox(pnlCondition);

                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmNonOperation) && frm.ActiveMdiChild == this)
                {
                    btnSave.Enabled = false;
                    //MessageBox.Show("김수호3");
                    //콤보박스로 이름을 선택했을경우 , 코드번호를 입력해서 검색할 경우, 두개 다 입력했을경우, 아무것도 입력 안했을 경우
                    //코드는 입력한 수를 포함하고있는지로 하고 이름은 콤보박스이기때문에 같은지로 
                    if (cboGroupName.SelectedIndex <= 0 && string.IsNullOrWhiteSpace(txtGroupCode.Text))
                    {
                        MessageBox.Show("검색하실 조건을 입력해주십시오.");                      
                    }
                    else if (cboGroupName.SelectedIndex > 0 && !string.IsNullOrWhiteSpace(txtGroupCode.Text))
                    {
                        List<NonOperationVO> findList = list.FindAll(x => x.Nop_Ma_Code.Contains(txtGroupCode.Text) && x.Nop_Ma_Name.Equals(cboGroupName.SelectedItem.ToString()));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvGroup.DataSource = null;
                            dgvGroup.DataSource = findList;
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(txtGroupCode.Text))
                    {
                        List<NonOperationVO> findList = list.FindAll(x => x.Nop_Ma_Code.Contains(txtGroupCode.Text));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvGroup.DataSource = null;
                            dgvGroup.DataSource = findList;
                        }

                    }
                    else if (cboGroupName.SelectedIndex > 0)
                    {
                        List<NonOperationVO> findList = list.FindAll(x => x.Nop_Ma_Name.Equals(cboGroupName.SelectedItem));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvGroup.DataSource = null;
                            dgvGroup.DataSource = findList;
                        }

                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //저장하고 
            if (string.IsNullOrWhiteSpace(txtNewGroupCode.Text))
            {
                MessageBox.Show("비가동 대분류코드를 입력해주십시오.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNewGroupName.Text))
            {
                MessageBox.Show("비가동 대분류명를 입력해주십시오.");
                return;
            }

            NonOperationService service = new NonOperationService();
            bool result = service.InsertNonOperation(txtNewGroupCode.Text, txtNewGroupName.Text, frm.UserName);
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
        

        private void dgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            if (e.ColumnIndex == 4)  //사용여부 변경버튼
            {
                //MessageBox.Show(dgvGroup[3, e.RowIndex].Value.ToString());

                //해당로우의 데이터부분을 DB에 사용여부N으로 업데이트 시키기
                string use;
                if (dgvGroup[3, e.RowIndex].Value.ToString() == "Y")
                    use = "N";
                else                
                    use = "Y";

                NonOperationService service = new NonOperationService();
                bool result = service.UseYNSwap(use, dgvGroup[0, e.RowIndex].Value.ToString(), false);

                if (result)
                {
                    MessageBox.Show("변경되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("변경 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");


            }
        }

        private void dgvGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            txtNewGroupCode.Text = dgvGroup[0, e.RowIndex].Value.ToString();
            txtNewGroupName.Text = dgvGroup[1, e.RowIndex].Value.ToString();
        }
    }
}
