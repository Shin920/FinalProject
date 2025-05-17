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
    public partial class frmSpecifications : FinalProject.List_List_b
    {
        frmMain frm = null;
        List<SpecificationVO> prdList;
        List<SpecificationVO> specList = new List<SpecificationVO>();
        List<ProcessVO> procList;
        List<SpecificationVO> insList;

        string lastCode;
        bool isBookMark = false;
        public frmSpecifications()
        {
            InitializeComponent();          
        }

        private void frmSpecifications_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvProduct);
            CommonUtil.AddGridTextColumn(dgvProduct, "품목", "Item_Name", colWidth:240);
            CommonUtil.AddGridTextColumn(dgvProduct, "품목코드", "Item_Code", colWidth: 240, align: DataGridViewContentAlignment.MiddleCenter); 

            CommonUtil.SetInitGridView(dgvQuality);
            CommonUtil.AddGridTextColumn(dgvQuality, "검사항목코드", "Inspect_code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvQuality, "검사항목명", "Inspect_name");
            CommonUtil.AddGridTextColumn(dgvQuality, "품목코드", "Item_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvQuality, "공정코드", "Process_code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvQuality, "규격상한값", "USL", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvQuality, "규격기준값", "SL", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvQuality, "규격하한값", "LSL", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvQuality, "샘플크기", "Sample_size", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvQuality, "단위", "Inspect_Unit");
            CommonUtil.AddGridTextColumn(dgvQuality, "비고", "Remark");
            CommonUtil.AddGridTextColumn(dgvQuality, "측정여부", "", align: DataGridViewContentAlignment.MiddleCenter);     //이건 애매함
            CommonUtil.AddGridTextColumn(dgvQuality, "사용여부", "Use_YN", align: DataGridViewContentAlignment.MiddleCenter);

           

            SpecificationsService service = new SpecificationsService();
            prdList = service.GetProductList();

            ProcessService prcService = new ProcessService();
            procList = prcService.GetProcessList();

            LoadData();

            foreach (SpecificationVO sv in prdList)
            {
                cboProductName.Items.Add(sv.Item_Name);
            }
            cboProductName.Items.Insert(0, "");

            foreach (ProcessVO pc in procList)        //공정정보에서 가져와야한다 (근데 그냥 모든 공정정보가 아니더라도 그냥 품질규격에 등록된 공정들만 가져와도될거같아서)
            {
                cboProcessName.Items.Add(pc.Process_name);  //근데 specList에서 가져오면 distinct로 중복된 애들은 제거해야할듯
            }
            cboProcessName.Items.Insert(0, "");

            foreach (SpecificationVO sv in prdList)
            {
                cboNewProductName.Items.Add(sv.Item_Name);
            }
            cboNewProductName.Items.Insert(0, "");

            foreach (ProcessVO pc in procList)
            {
                cboNewProcessName.Items.Add(pc.Process_name);
            }
            cboNewProcessName.Items.Insert(0, "");

            frm = (frmMain)this.MdiParent;

            frm.Select += Frm_Select;
            frm.Delete += Frm_Delete;
            frm.Insert += Frm_Insert;
            frm.UpDate += Frm_UpDate;
            frm.Refresh += Frm_Refresh;
            frm.BookMarkReg += Frm_BookMarkReg;

            btnSave.Enabled = false;

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
                if (fr.GetType() == typeof(frmSpecifications) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmSpecifications");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmSpecifications");
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

            SpecificationsService service = new SpecificationsService();
            if(specList.Count > 0)
            {
                specList.Clear();
            }
            
            specList = service.GetSpecList();

            dgvProduct.DataSource = null;
            dgvProduct.DataSource = prdList;

            //dgvProduct.Paint += DgvProduct_Paint;

            if (dgvProduct.CurrentRow != null)
            {
                dgvQuality.DataSource = null;
                dgvQuality.DataSource = specList.FindAll(x => x.Item_Code.Equals(dgvProduct.CurrentRow.Cells[1].Value.ToString()));

                //dgvQuality.Paint += DgvQuality_Paint;
            }

            cboInspectiontList.Items.Clear();

           
            insList = service.GetInspectionList();
            foreach (SpecificationVO pc in insList)
            {
                cboInspectiontList.Items.Add(pc.Inspect_name);
            }
            cboInspectiontList.Items.Insert(0, "");

            nmrLSL.Value = nmrSampleSize.Value = nmrSL.Value = nmrUSL.Value = 0;

            if(cboNewProductName.SelectedIndex >= 0)
                cboNewProductName.SelectedIndex = 0;
            if(cboNewProcessName.SelectedIndex >= 0)
                cboNewProcessName.SelectedIndex = 0;

            SpecificationsService service2 = new SpecificationsService();
            lastCode = service2.GetLastCode();
        }

        //private void DgvQuality_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvQuality.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvQuality.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvQuality.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        //private void DgvProduct_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvProduct.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvProduct.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvProduct.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmSpecifications) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmSpecifications) && frm.ActiveMdiChild == this)
                {
                    int nCnt = 0;
                    foreach(Control tx in pnlCondition.Controls)
                    {
                        if(tx.GetType() == typeof(TextBox) && tx.Name != "txtNote")
                        {
                            if(string.IsNullOrWhiteSpace(tx.Text))
                                nCnt++;     //비고를 적는 텍스트박스를 제외하고는 필수사항이라 빈 텍스트박스가 있으면 카운트 세서 체크
                        }
                    }
                    if (nCnt > 0)
                    {
                        MessageBox.Show("필수항목을 입력해주십시오.");
                        return;
                    }

                    //DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "품질규격 수정", MessageBoxButtons.YesNo);
                    //if (dresult == DialogResult.Yes)
                    //{
                    //    DefectiveService service = new DefectiveService();
                    //    DefectiveVO df = new DefectiveVO()
                    //    {
                    //        Def_Mi_Code = txtNewDetailCode.Text,
                    //        Def_Mi_Name = txtNewDetailName.Text,
                    //        Remark = txtNote.Text,
                    //        Up_Emp = "로그인관리자"
                    //    };
                    //    bool result = service.UpdateDefDetail(df);
                    //    if (result)
                    //    {
                    //        MessageBox.Show("수정되었습니다.");
                    //        LoadData();
                    //        CommonUtil.ClearTextBox(pnlCondition);
                    //    }
                    //    else
                    //        MessageBox.Show("수정 중 오류가 발생하였습니다.\n다시 시도하여 주십시오");
                    //}
                }
            }
        }

        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmSpecifications) && frm.ActiveMdiChild == this)
                {
                    cboNewProductName.Enabled = true;
                    cboNewProcessName.Enabled = true;

                    btnClearText.PerformClick();
                    if(specList.Count < 1)      //처음으로 등록할대는 코드번호에 +1할게 없어서 오류나니까 리스트에 아무것도 없으면 이 번호 주는것
                    {
                        txtInspectionCode.Text = "QS10001";
                        btnSave.Enabled = true;
                        return;
                    }
                    int code = int.Parse(lastCode.Replace("QS", ""));

                    txtInspectionCode.Text = "QS" + (code + 1);

                    btnSave.Enabled = true;

                    
                }
                
            }
        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmSpecifications) && frm.ActiveMdiChild == this)
                {
                    DialogResult dr = MessageBox.Show($"{dgvQuality.CurrentRow.Cells[1].Value.ToString()}를 삭제하시겠습니까?", "품질규격 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        SpecificationVO sv = new SpecificationVO()
                        {
                            Item_Code = dgvQuality.CurrentRow.Cells[2].Value.ToString(),
                            Process_code = dgvQuality.CurrentRow.Cells[3].Value.ToString(),
                            Inspect_code = dgvQuality.CurrentRow.Cells[0].Value.ToString()
                        };

                        SpecificationsService service = new SpecificationsService();
                        bool result = service.DeleteSpec(sv);
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
                if (fr.GetType() == typeof(frmSpecifications) && frm.ActiveMdiChild == this)
                {
                    if (string.IsNullOrWhiteSpace(txtProductCode.Text) && string.IsNullOrWhiteSpace(txtProcessCode.Text))
                    {
                        MessageBox.Show("검색하실 조건을 입력해주십시오.");
                        return;
                    }
                    dgvProduct.ClearSelection();
                    //if (cboProductName.SelectedIndex > 0 && cboProcessName.SelectedIndex > 0)   //품목과 공정 둘다 조건을 줬을때 품목그리드뷰는 해당로우가 선택되고 품질규격은 해당하는 데이터들만 보이게
                    //{
                    //     ***이 콤보박스에서의 조건들을 빼도되는게 콤보박스의 아이템을 선택하면 txt에 코드가 입력되고, 그러면 txt는 null이 아니니까
                    //     조건문을 탈거고 즉, 텍스트박스에 직접 입력이든 콤보박스 선택이든 텍스트박스의 코드값으로 검색하는 조건만 있으면 된다.***
                    //}
                    //else if (cboProductName.SelectedIndex > 0)      
                    //{
                    //}
                    //else if (cboProcessName.SelectedIndex > 0)
                    //{
                    //    
                    //}
                    if (!string.IsNullOrWhiteSpace(txtProductCode.Text) && !string.IsNullOrWhiteSpace(txtProcessCode.Text))
                    {
                        int rowIndex = -1;
                        foreach (DataGridViewRow row in dgvProduct.Rows)
                        {
                            if (row.Cells[1].Value.ToString().Contains(txtProductCode.Text))
                            {
                                rowIndex = row.Index;
                                //dgvProduct.CurrentCell = dgvProduct.Rows[rowIndex].Cells[0];  //이렇게 하면 한개까지만 선택이 되서 아래처럼 Selected True하니까 여러개까지 가능
                                dgvProduct.Rows[rowIndex].Selected = true;
                                //break;    //한개만 찾는거면 찾으면 break로 바로 나가주는게 좋은데 contains로 포함하는 모든 애들을 찾을거라 중간에 나가는거 없이 하는것
                            }
                        }
                        //dgvProduct.ClearSelection();  
                        //dgvProduct.CurrentCell = dgvProduct.Rows[rowIndex].Cells[0];

                        dgvQuality.DataSource = specList.FindAll(x => x.Item_Code.Contains(txtProductCode.Text) && x.Process_code.Contains(txtProcessCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductCode.Text))
                    {
                        int rowIndex = -1;
                        foreach (DataGridViewRow row in dgvProduct.Rows)
                        {
                            if (row.Cells[1].Value.ToString().Contains(txtProductCode.Text))
                            {
                                rowIndex = row.Index;
                                dgvProduct.Rows[rowIndex].Selected = true;
                                //break;
                            }
                        }
                        //아래는 구글링으로 찾은 링큐 사용법인데 cast가 잘못된거같은데 잘모르겠다...
                        //int rowIndex = -1;
                        //DataGridViewRow row = dgvProduct.Rows
                        //    .Cast<DataGridViewRow>()
                        //    .Where(r => r.Cells["Item_Code"].Value.ToString().Equals(txtProductCode.Text))
                        //    .First();
                        //rowIndex = row.Index;

                        //dgvProduct.ClearSelection();  //이게 전에 배울때 있었던건데 오히려 0번째 로우가 선택될때, 즉 처음 폼을 시작하면 0번째 로우가 선택되있게 했는데
                        //검색조건에 0번재로우가 선택되는 값을 넣고 조회를 누르면 0번째 로우가 선택이 지워진다. 다른애들은 처음부터 문제없고 0번째가 이미 선택이 처음에 되있는 상태여서
                        //이런 문제가 발생하는건지....                     
                        //dgvProduct.CurrentCell = dgvProduct.Rows[rowIndex].Cells[0];

                        dgvQuality.DataSource = specList.FindAll(x => x.Item_Code.Contains(txtProductCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text))
                    {                      
                        dgvProduct.ClearSelection();     //품질규격에서만 조회를 한거니까 예를 들면 성형으로 검색했으면 모든 품목의 성형에 대해 나올것이다. 그러니
                                                         //왼쪽 품목그리드뷰의 행은 아무것도 선택되어있지않는게 맞다.
                        
                        dgvQuality.DataSource = specList.FindAll(x => x.Process_code.Contains(txtProcessCode.Text));
                    }
                }
            }
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            CommonUtil.ClearTextBox(pnlCondition);
            nmrLSL.Value = nmrSampleSize.Value = nmrSL.Value = nmrUSL.Value = 0;
            cboNewProductName.SelectedIndex = cboNewProcessName.SelectedIndex = cboInspectiontList.SelectedIndex = 0;
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

        private void cboNewProcessName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNewProcessName.SelectedIndex > 0)
            {
                txtNewProcessCode.ReadOnly = true;
                txtNewProcessCode.Text = procList.Find(x => x.Process_name.Equals(cboNewProcessName.SelectedItem.ToString())).Process_code;        //공정정보에서 가져온 리스트에서 콤보박스 텍스트와 동일한 애의 코드를 가져다가 입력
            }
            else if (cboNewProcessName.SelectedIndex == 0)
                txtNewProcessCode.Text = "";

            
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
            SpecificationVO sv = new SpecificationVO()
            {
                Inspect_code = txtInspectionCode.Text,
                Inspect_name = txtInspectionItem.Text,
                Item_Code = txtNewProductCode.Text,
                Sample_size = Convert.ToInt32(nmrSampleSize.Value),
                Process_code = txtNewProcessCode.Text,
                Inspect_Unit = txtUnit.Text,
                USL = nmrUSL.Value,
                SL = nmrSL.Value,
                LSL = nmrLSL.Value,
                Remark = txtNote.Text,
                Ins_Emp = frm.UserName,
                Spec_Desc = "이건 뭔지 모르겠음"
            };

            SpecificationsService service = new SpecificationsService();
            bool result = service.InsertNewSpec(sv);
            if (result)
            {
                MessageBox.Show("등록되었습니다.");
                LoadData();
                CommonUtil.ClearTextBox(pnlCondition);
            }
            else
                MessageBox.Show("등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
        }

        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (cboProductName.SelectedIndex > 0)
            {
                txtProductCode.ReadOnly = true;
                txtProductCode.Text = prdList.Find(x => x.Item_Name.Equals(cboProductName.SelectedItem.ToString())).Item_Code;
            }
            if (cboProductName.SelectedIndex == 0)
                txtProductCode.Text = "";
        }

        private void cboProcessName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (cboProcessName.SelectedIndex > 0)
            {
                txtProcessCode.ReadOnly = true;
                txtProcessCode.Text = procList.Find(x => x.Process_name.Equals(cboProcessName.SelectedItem.ToString())).Process_code;
            }
            if (cboProcessName.SelectedIndex == 0)
                txtProcessCode.Text = "";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if(dgvProduct.CurrentRow == null)
            {
                MessageBox.Show("품질규격을 추가할 품목을 선택해주십시오.");
                return;
            }
            //if (specList.Count < 1)      //처음으로 등록할대는 코드번호에 +1할게 없어서 오류나니까 리스트에 아무것도 없으면 이 번호 주는것
            //{
            //    txtInspectionCode.Text = "QS10001";
            //    btnSave.Enabled = true;
            //    return;
            //}
            //int code = int.Parse(specList[specList.Count - 1].Inspect_code.Replace("QS", ""));

            //string newSpecCode = "QS" + (code + 1);

            frmQualitySpecificationCopyPopUp frm = new frmQualitySpecificationCopyPopUp(dgvProduct.CurrentRow.Cells[1].Value.ToString(), dgvProduct.CurrentRow.Cells[0].Value.ToString(), specList.FindAll(x => x.Item_Code.Equals(dgvProduct.CurrentRow.Cells[1].Value.ToString())), this.frm.UserName);
            frm.Show();

            frm.SaveEvent += Frm_SaveEvent;
        }

        private void Frm_SaveEvent(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            dgvQuality.DataSource = specList.FindAll(x => x.Item_Code.Equals(dgvProduct.CurrentRow.Cells[1].Value.ToString()));
        }

        private void dgvQuality_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;

            //아래 패널에 값 바인딩하기
            txtInspectionCode.Text = dgvQuality.CurrentRow.Cells[0].Value.ToString();
            txtInspectionItem.Text = dgvQuality.CurrentRow.Cells[1].Value.ToString();
            cboNewProcessName.SelectedItem = procList.Find(x => x.Process_code.Equals(dgvQuality.CurrentRow.Cells[3].Value.ToString())).Process_name;
            cboNewProductName.SelectedItem = prdList.Find(x => x.Item_Code.Equals(dgvQuality.CurrentRow.Cells[2].Value.ToString())).Item_Name;
            txtUnit.Text = dgvQuality.CurrentRow.Cells[8].Value.ToString();
            if (dgvQuality.CurrentRow.Cells[9].Value != null)
            {
                txtNote.Text = dgvQuality.CurrentRow.Cells[9].Value.ToString();
            }
            nmrUSL.Value = Convert.ToDecimal(dgvQuality.CurrentRow.Cells[4].Value);
            nmrSL.Value = Convert.ToDecimal(dgvQuality.CurrentRow.Cells[5].Value);
            nmrLSL.Value = Convert.ToDecimal(dgvQuality.CurrentRow.Cells[6].Value);
            nmrSampleSize.Value = Convert.ToDecimal(dgvQuality.CurrentRow.Cells[7].Value);

            cboNewProcessName.Enabled = false;
            cboNewProductName.Enabled = false;
            btnSave.Enabled = false;

        }

        private void cboInspectiontList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboInspectiontList.SelectedIndex > 0)
            {

                txtInspectionItem.ReadOnly = true;
                txtInspectionCode.Text = insList.Find(x => x.Inspect_name.Equals(cboInspectiontList.SelectedItem.ToString())).Inspect_code;
                txtInspectionItem.Text = cboInspectiontList.SelectedItem.ToString();
            }
            else if (cboInspectiontList.SelectedIndex == 0)
            {
                txtInspectionCode.Text = "";
                txtInspectionItem.Text = "";
                txtInspectionItem.ReadOnly = false;
            }
        }
    }
}
