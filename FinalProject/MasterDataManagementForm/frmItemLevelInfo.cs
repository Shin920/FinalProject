using FinalProject.Service;
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
    public partial class frmItemLevelInfo : FinalProject.List_b
    {
        frmMain frm = null;
        List<ItemLevelVO> list;
        public frmItemLevelInfo()
        {
            InitializeComponent();
        }

        private void frmItemLevelInfo_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
            frm.Delete += Frm_Delete;
            frm.Insert += Frm_Insert;
            frm.UpDate += Frm_UpDate;


            CommonUtil.SetInitGridView(dgvLvlList);
            CommonUtil.AddGridTextColumn(dgvLvlList, "품목그룹코드", "Level_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvLvlList, "품목그룹명", "Level_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvLvlList, "팔렛당박스수", "Box_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvLvlList, "박스당pcs수", "Pcs_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvLvlList, "PCS당소재량", "Mat_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvLvlList, "사용여부", "Use_YN", colWidth: 100);

            //사용여부 변경버튼 생성
            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            /*btnCell.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);*/     //이 간격은 없어도 될듯
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;

            dgvLvlList.Columns.Add(btnCell);

            LoadData();
            cboLvlName.SelectedIndex = 0;
        }
        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmItemLevelInfo) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }

        }

        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmItemLevelInfo) && frm.ActiveMdiChild == this)
                {
                    txtUdtLvlCode.ReadOnly = false;

                    btnSave.Enabled = true;
                }
            }
            CommonUtil.ClearTextBox(pnlCondition);

        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmItemLevelInfo) && frm.ActiveMdiChild == this)
                {
                    DialogResult dr = MessageBox.Show($"{dgvLvlList.CurrentRow.Cells[1].Value.ToString()}을 삭제하시겠습니까?", "분류 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ItemService service = new ItemService();
                        bool result = service.DeleteItemLevel(dgvLvlList.CurrentRow.Cells[0].Value.ToString());
                        if (result)
                            MessageBox.Show("삭제되었습니다.");
                        
                        else
                            MessageBox.Show("삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }
                    LoadData();
                }
            }
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {            
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmItemLevelInfo) && frm.ActiveMdiChild == this)
                {
                    if (string.IsNullOrWhiteSpace(txtUdtLvlName.Text))
                    {
                        MessageBox.Show("분류명을 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "품목분류 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        ItemService service = new ItemService();
                        ItemLevelVO no = new ItemLevelVO()
                        {
                            Level_Code = txtUdtLvlCode.Text,
                            Level_Name = txtUdtLvlName.Text,
                            Box_Qty = Convert.ToInt32(nmcBoxQty.Value),
                            Pcs_Qty = Convert.ToInt32(nmcPcsQty.Value),
                            Mat_Qty = nmcMtrQty.Value,
                            Up_Emp = "로그인관리자"
                        };
                        bool result = service.UpdateItemLevel(no);
                        if (result)
                        {
                            MessageBox.Show("수정되었습니다.");
                            LoadData();
                            CommonUtil.ClearTextBox(pnlCondition);
                            nmcBoxQty.Value = nmcPcsQty.Value = nmcMtrQty.Value = 0;
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
                if (fr.GetType() == typeof(frmItemLevelInfo) && frm.ActiveMdiChild == this)
                {
                    
                    if (cboLvlName.SelectedIndex <= 0 && string.IsNullOrWhiteSpace(txtLvlCode.Text))
                    {
                        MessageBox.Show("검색하실 조건을 입력해주십시오.");
                    }
                    else if (cboLvlName.SelectedIndex > 0 && !string.IsNullOrWhiteSpace(txtLvlCode.Text))
                    {
                        List<ItemLevelVO> findList = list.FindAll(x => x.Level_Code.Contains(txtLvlCode.Text) && x.Level_Name.Equals(cboLvlName.SelectedValue.ToString()));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvLvlList.DataSource = null;
                            dgvLvlList.DataSource = findList;
                        }

                    }
                    else if (!string.IsNullOrWhiteSpace(txtLvlCode.Text))
                    {
                        List<ItemLevelVO> findList = list.FindAll(x => x.Level_Code.Contains(txtLvlCode.Text));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvLvlList.DataSource = null;
                            dgvLvlList.DataSource = findList;
                        }

                    }
                    else if (cboLvlName.SelectedIndex > 0)
                    {
                        List<ItemLevelVO> findList = list.FindAll(x => x.Level_Name.Equals(cboLvlName.SelectedItem));
                        if (findList.Count < 1)
                            MessageBox.Show("검색된 데이터가 없습니다.");
                        else
                        {
                            dgvLvlList.DataSource = null;
                            dgvLvlList.DataSource = findList;
                        }

                    }
                }
            }
        }



        private void LoadData()
        {
            ItemService service = new ItemService();
            list = service.GetItemLevelList();

            dgvLvlList.DataSource = null;
            dgvLvlList.DataSource = list;


            //콤보박스 바인딩
            cboLvlName.Items.Clear();
            foreach (ItemLevelVO no in list)
            {
                cboLvlName.Items.Add(no.Level_Name);
            }
            cboLvlName.Items.Insert(0, "선택");   //빈값으로 된것도 주려고 (선택없음 역할)

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //저장하고 
            if (string.IsNullOrWhiteSpace(txtUdtLvlCode.Text))
            {
                MessageBox.Show("분류코드를 입력해주십시오.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUdtLvlName.Text))
            {
                MessageBox.Show("분류명을 입력해주십시오.");
                return;
            }

            ItemService service = new ItemService();
            bool result = service.InsertItemLevel(txtUdtLvlCode.Text, txtUdtLvlName.Text, Convert.ToInt32(nmcBoxQty.Text), Convert.ToInt32(nmcPcsQty.Text), Convert.ToInt32(nmcMtrQty.Text), "로그인관리자이름");
            if (result)
            {
                MessageBox.Show("등록되었습니다.");
                LoadData();
                
            }

            else
                MessageBox.Show("등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");

            //텍스트박스 초기화
            CommonUtil.ClearTextBox(pnlCondition);
            nmcBoxQty.Value = nmcPcsQty.Value = nmcMtrQty.Value = 0;
        }

        private void btnTextClear_Click(object sender, EventArgs e)
        {
            CommonUtil.ClearTextBox(pnlCondition);
            nmcBoxQty.Value = nmcPcsQty.Value = nmcMtrQty.Value = 0;
        }


        private void dgvLvlList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUdtLvlCode.ReadOnly = true;
            btnSave.Enabled = false;
            txtUdtLvlCode.Text = dgvLvlList[0, e.RowIndex].Value.ToString();
            txtUdtLvlName.Text = dgvLvlList[1, e.RowIndex].Value.ToString();
            nmcBoxQty.Value = Convert.ToInt32(dgvLvlList[2, e.RowIndex].Value);
            nmcPcsQty.Value = Convert.ToInt32(dgvLvlList[3, e.RowIndex].Value);
            nmcMtrQty.Value = Convert.ToInt32(dgvLvlList[4, e.RowIndex].Value);
        }

        private void dgvLvlList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)  //사용여부 변경버튼
            {
                //MessageBox.Show(dgvGroup[3, e.RowIndex].Value.ToString());

                //해당로우의 데이터부분을 DB에 사용여부N으로 업데이트 시키기
                string use;
                if (dgvLvlList[5, e.RowIndex].Value.ToString() == "Y")
                    use = "N";
                else
                    use = "Y";

                ItemService service = new ItemService();
                bool result = service.UseYNSwap(use, dgvLvlList[0, e.RowIndex].Value.ToString());

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
