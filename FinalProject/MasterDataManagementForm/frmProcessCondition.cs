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
    public partial class frmProcessCondition : FinalProject.List_List_b
    {
        frmMain frm = null;
        List<SpecificationVO> prdList;
        List<ProcessVO> procList;
        List<WorkCenterVO> wcList;
        List<ProcessVO> conList;

        bool isBookMark = false;
        public frmProcessCondition()
        {
            InitializeComponent();
        }

        private void frmProcessCondition_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvProductList);
            CommonUtil.AddGridTextColumn(dgvProductList, "품목", "Item_Name", colWidth: 240);
            CommonUtil.AddGridTextColumn(dgvProductList, "품목코드", "Item_Code", colWidth: 240, align: DataGridViewContentAlignment.MiddleCenter);
    

            CommonUtil.SetInitGridView(dgvProcessList);
            CommonUtil.AddGridTextColumn(dgvProcessList, "품목코드", "Item_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcessList, "작업장코드", "Wc_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcessList, "조건항목코드", "Condition_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcessList, "조건항목명", "Condition_Name", colWidth: 225);
            CommonUtil.AddGridTextColumn(dgvProcessList, "규격상한값", "USL", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcessList, "규격기준값", "SL", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcessList, "규격하한값", "LSL", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcessList, "단위", "Condition_Unit");
            CommonUtil.AddGridTextColumn(dgvProcessList, "비고", "Remark");

            SpecificationsService service = new SpecificationsService();
            prdList = service.GetProductList();

            dgvProductList.DataSource = prdList;

            //dgvProductList.Paint += DgvProductList_Paint;

            foreach (SpecificationVO sv in prdList)
            {
                cboProductName.Items.Add(sv.Item_Name);
            }
            cboProductName.Items.Insert(0, "");

            foreach (SpecificationVO sv in prdList)
            {
                cboNewProductName.Items.Add(sv.Item_Name);
            }
            cboNewProductName.Items.Insert(0, "");

            WorkCenterService service2 = new WorkCenterService();
            wcList = service2.GetWorkCenterSmallList();
            foreach (WorkCenterVO pc in wcList)
            {
                cboSystemName.Items.Add(pc.Wc_Name);
            }
            cboSystemName.Items.Insert(0, "");

            foreach (WorkCenterVO pc in wcList)
            {
                cboNewWcName.Items.Add(pc.Wc_Name);
            }
            cboNewWcName.Items.Insert(0, "");

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
                if (fr.GetType() == typeof(frmProcessCondition) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmProcessCondition");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmProcessCondition");
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

        //private void DgvProductList_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvProductList.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvProductList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvProductList.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void LoadData()
        {
            //품목정보는 품목쪽에서만 가져오고 그거의 품목코드를 클릭했을때 공정정보 테이블쪽에서 데이터 찾아와서 2번그리드에 바인딩

            //근데 품목정보 그리드뷰가 업데이트 될 일은 이 폼에서 없으니까 처음 로드될때만 해놓으면 될듯. 여기에 넣으면 오히려 낭비
            //품목/설비(작업장인듯) 콤보박스 바인딩
            btnSave.Enabled = false;
           
            ProcessService service3 = new ProcessService();
            procList = service3.GetProcessConditionList();

            dgvProcessList.DataSource = null;
            dgvProcessList.DataSource = procList.FindAll(x => x.Item_Code.Equals(dgvProductList.CurrentRow.Cells[1].Value.ToString()));

            //dgvProcessList.Paint += DgvProcessList_Paint;

            cboCondition.Items.Clear();

            ProcessService service = new ProcessService();
            conList = service.GetConditionList();
            foreach (ProcessVO pc in conList)
            {
                cboCondition.Items.Add(pc.Condition_Name);
            }
            cboCondition.Items.Insert(0, "");


            nmrLSL.Value = nmrSL.Value = nmrUSL.Value = 0;

            if (cboNewProductName.SelectedIndex >= 0)
                cboNewProductName.SelectedIndex = 0;
            if (cboNewWcName.SelectedIndex >= 0)
                cboNewWcName.SelectedIndex = 0;


        }

        //private void DgvProcessList_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvProcessList.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvProcessList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvProcessList.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmProcessCondition) && frm.ActiveMdiChild == this)
                {
                    int nCnt = 0;
                    foreach (Control tx in pnlCondition.Controls)
                    {
                        if (tx.GetType() == typeof(TextBox) && tx.Name != "txtNote")
                        {
                            if (string.IsNullOrWhiteSpace(tx.Text))
                                nCnt++;     //비고를 적는 텍스트박스를 제외하고는 필수사항이라 빈 텍스트박스가 있으면 카운트 세서 체크
                        }
                    }
                    if (nCnt > 0)
                    {
                        MessageBox.Show("필수항목을 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "공정조건 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        ProcessService service = new ProcessService();
                        ProcessVO pc = new ProcessVO()
                        {
                            Condition_Name = txtNewConditionName.Text,
                            SL = nmrSL.Value,
                            USL = nmrUSL.Value,
                            LSL = nmrLSL.Value,
                            Condition_Unit = txtUnit.Text,
                            Remark = txtNote.Text,
                            Item_Code = txtNewProductCode.Text,
                            Wc_Code = txtNewWcCode.Text,
                            Condition_Code = txtNewConditionCode.Text,
                            Up_Emp = frm.UserName
                         
                        };
                        bool result = service.UpdateProcCondition(pc);
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
                if (fr.GetType() == typeof(frmProcessCondition) && frm.ActiveMdiChild == this)
                {
                    //foreach (SpecificationVO sv in prdList)
                    //{
                    //    cboNewProductName.Items.Add(sv.Item_Name);
                    //}
                    //cboNewProductName.Items.Insert(0, "");

                    //foreach (WorkCenterVO wc in wcList)
                    //{
                    //    cboNewWcName.Items.Add(wc.Wc_Name);
                    //}
                    //cboNewWcName.Items.Insert(0, "");

                    if (procList.Count < 1)      //처음으로 등록할대는 코드번호에 +1할게 없어서 오류나니까 리스트에 아무것도 없으면 이 번호 주는것
                    {
                        txtNewConditionCode.Text = "CC10001";
                        btnSave.Enabled = true;
                        return;
                    }
                    int code = int.Parse(procList[procList.Count - 1].Condition_Code.Replace("CC", ""));

                    txtNewConditionCode.Text = "CC" + (code + 1);

                    btnSave.Enabled = true;


                }

            }
        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmProcessCondition) && frm.ActiveMdiChild == this)
                {
                    DialogResult dr = MessageBox.Show($"{dgvProcessList.CurrentRow.Cells[3].Value.ToString()}를 삭제하시겠습니까?", "공정조건 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ProcessVO pc = new ProcessVO()
                        {
                            Item_Code = dgvProcessList.CurrentRow.Cells[0].Value.ToString(),
                            Wc_Code = dgvProcessList.CurrentRow.Cells[1].Value.ToString(),
                            Condition_Code = dgvProcessList.CurrentRow.Cells[2].Value.ToString()
                        };

                        ProcessService service = new ProcessService();
                        bool result = service.DeleteProcCondition(pc);
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
                if (fr.GetType() == typeof(frmProcessCondition) && frm.ActiveMdiChild == this)
                {
                    btnSave.Enabled = false;
                    LoadData();
                    cboProductName.SelectedIndex = 0;
                    cboSystemName.SelectedIndex = 0;
                    txtProductCode.Text = "";
                    txtSystemCode.Text = "";
                    btnClearText.PerformClick();
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmProcessCondition) && frm.ActiveMdiChild == this)
                {
                    if (string.IsNullOrWhiteSpace(txtProductCode.Text) && string.IsNullOrWhiteSpace(txtSystemCode.Text))
                    {
                        MessageBox.Show("검색하실 조건을 입력해주십시오.");
                        return;
                    }
                    dgvProductList.ClearSelection();
                  
                    if (!string.IsNullOrWhiteSpace(txtProductCode.Text) && !string.IsNullOrWhiteSpace(txtSystemCode.Text))
                    {
                        int rowIndex = -1;
                        foreach (DataGridViewRow row in dgvProductList.Rows)
                        {
                            if (row.Cells[1].Value.ToString().Contains(txtProductCode.Text))
                            {
                                rowIndex = row.Index;
                                //dgvProduct.CurrentCell = dgvProduct.Rows[rowIndex].Cells[0];  //이렇게 하면 한개까지만 선택이 되서 아래처럼 Selected True하니까 여러개까지 가능
                                dgvProductList.Rows[rowIndex].Selected = true;
                                //break;    //한개만 찾는거면 찾으면 break로 바로 나가주는게 좋은데 contains로 포함하는 모든 애들을 찾을거라 중간에 나가는거 없이 하는것
                            }
                        }
                       

                        dgvProcessList.DataSource = procList.FindAll(x => x.Item_Code.Contains(txtProductCode.Text) && x.Wc_Code.Contains(txtSystemCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductCode.Text))
                    {
                        int rowIndex = -1;
                        foreach (DataGridViewRow row in dgvProductList.Rows)
                        {
                            if (row.Cells[1].Value.ToString().Contains(txtProductCode.Text))
                            {
                                rowIndex = row.Index;
                                dgvProductList.Rows[rowIndex].Selected = true;
                                //break;
                            }
                        }


                        dgvProcessList.DataSource = procList.FindAll(x => x.Item_Code.Contains(txtProductCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtSystemCode.Text))
                    {
                        dgvProductList.ClearSelection();     //품질규격에서만 조회를 한거니까 예를 들면 성형으로 검색했으면 모든 품목의 성형에 대해 나올것이다. 그러니
                                                         //왼쪽 품목그리드뷰의 행은 아무것도 선택되어있지않는게 맞다.

                        dgvProcessList.DataSource = procList.FindAll(x => x.Wc_Code.Contains(txtSystemCode.Text));
                    }
                }
            }
        }

        

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dgvProductList.CurrentRow == null)
            {
                MessageBox.Show("공정조건을 추가할 품목을 선택해주십시오.");
                return;
            }

            frmCopyProcessConditions frm = new frmCopyProcessConditions(dgvProductList.CurrentRow.Cells[1].Value.ToString(), dgvProductList.CurrentRow.Cells[0].Value.ToString(), procList.FindAll(x => x.Item_Code.Equals(dgvProductList.CurrentRow.Cells[1].Value.ToString())), this.frm.UserName);
            frm.Show();

            frm.SaveEvent += Frm_SaveEvent;
        }

        private void Frm_SaveEvent(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nCnt = 0;
            foreach (Control tx in pnlCondition.Controls)
            {
                if (tx.GetType() == typeof(TextBox) && tx.Name != "txtNote")
                {
                    if (string.IsNullOrWhiteSpace(tx.Text))
                        nCnt++;     //비고를 적는 텍스트박스를 제외하고는 필수사항이라 빈 텍스트박스가 있으면 카운트 세서 체크
                }
            }
            if (nCnt > 0)
            {
                MessageBox.Show("필수항목을 입력해주십시오.");
                return;
            }

            //이제 저장          
            ProcessVO pc = new ProcessVO()
            {
                Condition_Name = txtNewConditionName.Text,
                SL = nmrSL.Value,
                USL = nmrUSL.Value,
                LSL = nmrLSL.Value,
                Condition_Unit = txtUnit.Text,
                Remark = txtNote.Text,
                Item_Code = txtNewProductCode.Text,
                Wc_Code = txtNewWcCode.Text,
                Condition_Code = txtNewConditionCode.Text,
                Ins_Emp = frm.UserName,
                Condition_Group = null      //일단 공정그룹은 null로 했다. 만약 줄거면 입력패널에 콤보박스로 그룹바인딩해서 선택해야함

            };

            ProcessService service = new ProcessService();
            bool result = service.InsertProcCondition(pc);
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
            nmrLSL.Value = nmrSL.Value = nmrUSL.Value = 0;
            cboNewProductName.SelectedIndex = cboNewWcName.SelectedIndex = 0;
        }

        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductName.SelectedIndex > 0)
            {
                txtProductCode.ReadOnly = true;
                txtProductCode.Text = prdList.Find(x => x.Item_Name.Equals(cboProductName.SelectedItem.ToString())).Item_Code;
            }
            else if (cboProductName.SelectedIndex == 0)
                txtProductCode.Text = "";
        }

        private void cboSystemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSystemName.SelectedIndex > 0)
            {
                txtSystemCode.ReadOnly = true;
                txtSystemCode.Text = wcList.Find(x => x.Wc_Name.Equals(cboSystemName.SelectedItem.ToString())).Wc_Code;
            }
            else if (cboSystemName.SelectedIndex == 0)
                txtSystemCode.Text = "";
        }

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
     
        }

        private void cboNewProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNewProductName.SelectedIndex > 0)
            {
                txtNewProductCode.ReadOnly = true;
                txtNewProductCode.Text = prdList.Find(x => x.Item_Name.Equals(cboNewProductName.SelectedItem.ToString())).Item_Code;
            }
            else if (cboNewProductName.SelectedIndex == 0)
                txtNewProductCode.Text = "";
        }

        private void cboNewWcName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNewWcName.SelectedIndex > 0)
            {
                txtNewWcCode.ReadOnly = true;
                txtNewWcCode.Text = wcList.Find(x => x.Wc_Name.Equals(cboNewWcName.SelectedItem.ToString())).Wc_Code;
            }
            else if (cboNewWcName.SelectedIndex == 0)
                txtNewWcCode.Text = "";
        }

        private void dgvProcessList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNewConditionCode.Text = dgvProcessList.CurrentRow.Cells[2].Value.ToString();
            txtNewConditionName.Text = dgvProcessList.CurrentRow.Cells[3].Value.ToString();
            cboNewWcName.SelectedItem = wcList.Find(x => x.Wc_Code.Equals(dgvProcessList.CurrentRow.Cells[1].Value.ToString())).Wc_Name;
            cboNewProductName.SelectedItem = prdList.Find(x => x.Item_Code.Equals(dgvProcessList.CurrentRow.Cells[0].Value.ToString())).Item_Name;
            txtUnit.Text = dgvProcessList.CurrentRow.Cells[7].Value.ToString();
            if (dgvProcessList.CurrentRow.Cells[8].Value != null)
            {
                txtNote.Text = dgvProcessList.CurrentRow.Cells[8].Value.ToString();
            }
            nmrUSL.Value = Convert.ToDecimal(dgvProcessList.CurrentRow.Cells[4].Value);
            nmrSL.Value = Convert.ToDecimal(dgvProcessList.CurrentRow.Cells[5].Value);
            nmrLSL.Value = Convert.ToDecimal(dgvProcessList.CurrentRow.Cells[6].Value);


            cboNewWcName.Enabled = false;
            cboNewProductName.Enabled = false;
            btnSave.Enabled = false;

        }

        private void cboCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCondition.SelectedIndex > 0)
            {
               
                txtNewConditionName.ReadOnly = true;
                txtNewConditionCode.Text = conList.Find(x => x.Condition_Name.Equals(cboCondition.SelectedItem.ToString())).Condition_Code;
                txtNewConditionName.Text = cboCondition.SelectedItem.ToString();
            }
            else if (cboCondition.SelectedIndex == 0)
            {
                txtNewConditionCode.Text = "";
                txtNewConditionName.Text = "";
                txtNewConditionName.ReadOnly = false;
            }
        }
    }
}
