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
    public partial class frmItemInfo : FinalProject.List_b
    {
        frmMain frm = null;
        List<ItemVO> list;
        List<ComboItemVO> comlist;
        public frmItemInfo()
        {
            InitializeComponent();
        }

        private void rdoItemName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoItemName.Checked)
            {
                rdoItemKind.Checked = false;
            }
            else
            {
                rdoItemKind.Checked = true;
            }
        }

        private void rdoItemKind_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoItemKind.Checked)
            {
                rdoItemName.Checked = false;
            }
            else
            {
                rdoItemName.Checked = true;
            }
        }

        private void frmItemInfo_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
            frm.Delete += Frm_Delete;
            frm.Insert += Frm_Insert;
            frm.UpDate += Frm_UpDate;

            rdoItemName.Checked = true;

            CommonUtil.SetInitGridView(dgvItemList);
            CommonUtil.AddGridTextColumn(dgvItemList, "품목코드", "Item_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "품목명", "Item_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "영문명", "Item_Name_Eng", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "약어", "Item_Name_Eng_Alias", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "품목유형", "Item_Type", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "규격", "Item_Spec", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "단위", "Item_Unit", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "안전재고", "Item_Stock", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "시간당생산수", "PrdQty_Per_Hour", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "배치당생산수", "PrdQTy_Per_Batch", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "캐비티수", "Cavity", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "성형줄당갯수", "Line_Per_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "포장샷당갯수", "Shot_Per_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "건조대차기본수량", "Dry_GV_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "소성대차기본수량", "Heat_GV_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "비고", "Remark", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvItemList, "사용여부", "Use_YN", colWidth: 100);

            //사용여부 변경버튼 생성
            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            /*btnCell.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);*/     //이 간격은 없어도 될듯
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;

            dgvItemList.Columns.Add(btnCell);


            LoadData();
           
            

            
            //콤보박스 바인딩
            cboItemKind.Items.Clear();
            foreach (ComboItemVO no in comlist)
            {
                cboItemKind.Items.Add(no.com_Code);

            }
            cboItemKind.Items.Insert(0, "선택");   //빈값으로 된것도 주려고 (선택없음 역할)

            
            cboItemKind.SelectedIndex = cboItemName.SelectedIndex = 0;




        }

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmItemInfo) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }

        }

        private void Frm_Insert(object sender, EventArgs e)
        {

            
                if (frm.ActiveMdiChild == this)
                {
                    frmAddItem newForm = new frmAddItem();

                    if (newForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("등록 완료");
                    }
                    LoadData();
                }
            
            
        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmItemInfo) && frm.ActiveMdiChild == this)
                {
                    DialogResult dr = MessageBox.Show($"{dgvItemList.CurrentRow.Cells[1].Value.ToString()}을 삭제하시겠습니까?", "품목 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ItemService service = new ItemService();
                        bool result = service.DeleteItem(dgvItemList.CurrentRow.Cells[0].Value.ToString());
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
                if (fr.GetType() == typeof(frmItemInfo) && frm.ActiveMdiChild == this)
                {
                    //조건의 필요성?
                    //if (string.IsNullOrWhiteSpace(txtUdtPrcName.Text))
                    //{
                    //    MessageBox.Show("품목명을 입력해주십시오.");
                    //    return;
                    //}

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "품목 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        ItemService service = new ItemService();
                        ItemVO no = new ItemVO()
                        {
                            Cavity = Convert.ToInt32(nmcUdtCavity.Text),
                            Line_Per_Qty = Convert.ToInt32(nmcUdtLineCavity.Text),
                            Shot_Per_Qty = Convert.ToInt32(nmcUdtPCS.Text),
                            Up_Emp = "로그인관리자"
                        };
                        bool result = service.UpdateItem(no);
                        if (result)
                        {
                            MessageBox.Show("수정되었습니다.");
                            LoadData();
                            CommonUtil.ClearTextBox(pnlCondition);
                            nmcUdtCavity.Value = nmcUdtLineCavity.Value = nmcUdtPCS.Value = 0;
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
                if (fr.GetType() == typeof(frmItemInfo) && frm.ActiveMdiChild == this)
                {
                    if (rdoItemName.Checked) // 품명에 체크
                    {
                        if (cboItemName.SelectedIndex <= 0 && string.IsNullOrWhiteSpace(txtSearchCode.Text))
                        {
                            MessageBox.Show("검색하실 조건을 입력해주십시오.");
                        }
                        else if (cboItemName.SelectedIndex > 0 && !string.IsNullOrWhiteSpace(txtSearchCode.Text))
                        {
                            List<ItemVO> findList = list.FindAll(x => x.Item_Code.Contains(txtSearchCode.Text) && x.Item_Name.Equals(cboItemName.SelectedValue.ToString()));
                            if (findList.Count < 1)
                                MessageBox.Show("검색된 데이터가 없습니다.");
                            else
                            {
                                dgvItemList.DataSource = null;
                                dgvItemList.DataSource = findList;

                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(txtSearchCode.Text))
                        {
                            List<ItemVO> findList = list.FindAll(x => x.Item_Code.Contains(txtSearchCode.Text));
                            if (findList.Count < 1)
                                MessageBox.Show("검색된 데이터가 없습니다.");
                            else
                            {
                                dgvItemList.DataSource = null;
                                dgvItemList.DataSource = findList;
                            }

                        }
                        else if (cboItemName.SelectedIndex > 0)
                        {
                            List<ItemVO> findList = list.FindAll(x => x.Item_Name.Equals(cboItemName.SelectedItem));
                            if (findList.Count < 1)
                                MessageBox.Show("검색된 데이터가 없습니다.");
                            else
                            {
                                dgvItemList.DataSource = null;
                                dgvItemList.DataSource = findList;
                            }

                        }
                    }
                    else // 공정쪽 체크
                    {
                        if (!string.IsNullOrWhiteSpace(cboItemKind.Text))
                        {
                            List<ItemVO> findList = list.FindAll(x => x.Item_Type.Equals(cboItemKind.SelectedItem));
                            if (findList.Count < 1)
                                MessageBox.Show("검색된 데이터가 없습니다.");
                            else
                            {
                                dgvItemList.DataSource = null;
                                dgvItemList.DataSource = findList;
                            }

                        }
                    }

                }
            }
        }

        private void LoadData()
        {
            ItemService service = new ItemService();
            list = service.GetItemList();
            comlist = service.GetItemType();

            dgvItemList.DataSource = null;
            dgvItemList.DataSource = list;


            //콤보박스 바인딩
            cboItemName.Items.Clear();

            foreach (ItemVO no in list)
            {
                cboItemName.Items.Add(no.Item_Name);

            }
            cboItemName.Items.Insert(0, "선택");   //빈값으로 된것도 주려고 (선택없음 역할)

        }

        private void dgvItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCode.Text = dgvItemList[0, dgvItemList.CurrentRow.Index].Value.ToString();

            if (e.ColumnIndex == 18)  //사용여부 변경버튼
            {
                //MessageBox.Show(dgvGroup[3, e.RowIndex].Value.ToString());

                //해당로우의 데이터부분을 DB에 사용여부N으로 업데이트 시키기
                string use;
                if (dgvItemList[17, e.RowIndex].Value.ToString() == "Y")
                    use = "N";
                else
                    use = "Y";

                ItemService service = new ItemService();
                bool result = service.UseYNSwapItem(use, dgvItemList[0, e.RowIndex].Value.ToString());

                if (result)
                {
                    MessageBox.Show("변경되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("변경 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }

        private void dgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtUdtItemCode.Text = dgvItemList[0, e.RowIndex].Value.ToString();
            txtUdtItemName.Text = dgvItemList[1, e.RowIndex].Value.ToString();
            nmcUdtCavity.Value = Convert.ToInt32(dgvItemList[10, e.RowIndex].Value);
            nmcUdtLineCavity.Value = Convert.ToInt32(dgvItemList[11, e.RowIndex].Value);
            nmcUdtPCS.Value = Convert.ToInt32(dgvItemList[12, e.RowIndex].Value);
        }
    }
}