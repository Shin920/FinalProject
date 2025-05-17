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
    public partial class frmQualitySpecificationCopyPopUp : FinalProject.List_Popup
    {
        public event EventHandler SaveEvent;

        CheckBox chbox = new CheckBox();
        string itemCode;    //품질규격설정 폼에서 열때 어떤 품목에 대해 추가하려고 열었는지 보내준다. (사용자의 편의를 위해 품목명도 가져온다)
        string itemName;
        string userName;

        List<SpecificationVO> specList;
        List<SpecificationVO> prdList;
        List<ProcessVO> procList;
        List<SpecificationVO> insList;
        public frmQualitySpecificationCopyPopUp(string code, string name, List<SpecificationVO> list, string userName)
        {
            InitializeComponent();

            itemCode = code;
            itemName = name;
            insList = list;
            this.userName = userName;
        }

        private void frmQualitySpecificationCopyPopUp_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvQuality);

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvQuality.Columns.Add(chk);

            Point headerPoint = dgvQuality.GetCellDisplayRectangle(0, -1, true).Location;
            chbox.Location = new Point(headerPoint.X + 7, headerPoint.Y + 4);
            chbox.Size = new Size(18, 18);
            chbox.BackColor = Color.White;
            chbox.Click += Chbox_Click;
            dgvQuality.Controls.Add(chbox);

            
            //CommonUtil.AddGridTextColumn(dgvQuality, "체크박스", ""); //0번째
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

            LoadData();

            lblItemName.Text = itemName;
        }

        private void Chbox_Click(object sender, EventArgs e)
        {
            dgvQuality.EndEdit();
            //endEdit이란 그리드뷰에 포커스가 가있어서 편집상태가 되어있을때 오류나 값이 이상하게 되버리는데
            //이건 다른 셀을 클릭해서 편집상태를 끝냈다는 효과를 주는 메서드이다.
            foreach (DataGridViewRow row in dgvQuality.Rows)
            {
                DataGridViewCheckBoxCell box = (DataGridViewCheckBoxCell)row.Cells["chk"];
                box.Value = chbox.Checked;
            }
        }

        private void LoadData()
        {
            SpecificationsService service = new SpecificationsService();
            specList = service.GetSpecList();
            prdList = service.GetProductList();

            ProcessService prcService = new ProcessService();
            procList = prcService.GetProcessList();

            foreach (SpecificationVO sv in prdList)
            {
                if(!sv.Item_Code.Equals(itemCode))      //Copy로 팝업에 들어갔을때 현재 선택해서 들어간 품목에 대한 조회는 없애야 이미 본인한테 있는 품질규격의 복사를 막을수 있다.
                    cboProductName.Items.Add(sv.Item_Name);
            }
            cboProductName.Items.Insert(0, "");

            foreach (ProcessVO pc in procList)        //공정정보에서 가져와야한다 (근데 그냥 모든 공정정보가 아니더라도 그냥 품질규격에 등록된 공정들만 가져와도될거같아서)
            {               
                cboProcessName.Items.Add(pc.Process_name);  //근데 specList에서 가져오면 distinct로 중복된 애들은 제거해야할듯 (?)
            }
            cboProcessName.Items.Insert(0, "");
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if ((cboProductName.SelectedIndex <= 0 && cboProcessName.SelectedIndex <= 0) || (string.IsNullOrWhiteSpace(txtProductCode.Text) && string.IsNullOrWhiteSpace(txtProcessCode.Text)))
            {
                MessageBox.Show("검색하실 조건을 입력해주십시오.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtProductCode.Text) && !string.IsNullOrWhiteSpace(txtProcessCode.Text))
            {
                //dgvQuality.DataSource = specList.FindAll(x => x.Item_Code.Equals(txtProductCode.Text) && x.Process_code.Equals(txtProcessCode.Text));
                List<SpecificationVO> list = specList.FindAll(x => x.Item_Code.Equals(txtProductCode.Text) && x.Process_code.Equals(txtProcessCode.Text));
                list.RemoveAll(x => x.Item_Code.Equals(itemCode));
                dgvQuality.DataSource = list;       //이렇게 한 이유는 품목콤보박스에서는 본인품목을 제외했지만 공정정보를 가져올때는 콤보박스에 바인딩할때 품목정보와 연결되있지않고
                                                    //그냥 공정정보 리스트이기때문에 이렇게 그리드뷰에 보여줄 품질규격 리스트에서 itemCode로 본인의 품질규격을 제외하고 보여주는것
                dgvQuality.Paint += DgvQuality_Paint;

            }
            else if (!string.IsNullOrWhiteSpace(txtProductCode.Text))
            {
                List<SpecificationVO> list = specList.FindAll(x => x.Item_Code.Equals(txtProductCode.Text));
                list.RemoveAll(x => x.Item_Code.Equals(itemCode));
                dgvQuality.DataSource = list;
            }
            else if (!string.IsNullOrWhiteSpace(txtProcessCode.Text))
            {
                List<SpecificationVO> list = specList.FindAll(x => x.Process_code.Equals(txtProcessCode.Text));
                list.RemoveAll(x => x.Item_Code.Equals(itemCode));
                dgvQuality.DataSource = list;
            }

           
        }

        private void DgvQuality_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < dgvQuality.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    this.dgvQuality.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                }
                else
                {
                    this.dgvQuality.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //추가될때는 품목정보는 제외하고 처음 품질규격설정 폼에서 열때 그 품목에 품질규격들을 추가하는것
            List<SpecificationVO> list = new List<SpecificationVO>();
            int i;
            int cnt = 0;
            for (i = 0; i < dgvQuality.Rows.Count; i++)
            {
                bool isChecked = (bool)dgvQuality[0, i].EditedFormattedValue;

                if (isChecked)
                {
                    //list.Add($"{dgvQuality[1, i].Value.ToString()},{dgvQuality[3, i].Value.ToString()},{dgvQuality[4, i].Value.ToString()}");     
                    SpecificationVO sv = new SpecificationVO()
                    {
                        New_Item_Code = itemCode,
                        Ins_Emp = userName,
                        Item_Code = dgvQuality[3, i].Value.ToString(),
                        Process_code = dgvQuality[4, i].Value.ToString(),
                        Inspect_code = dgvQuality[1, i].Value.ToString(),
                        Inspect_name = dgvQuality[2, i].Value.ToString()
                    };
                    list.Add(sv);
                    cnt++;  //체크를 하고 저장버튼을 눌렀는지 아무것도 체크안하고 저장버튼을 눌렀는지 체크하려고
                    //그리고 아마 for문 돌면서 넣을때 newSpecCode가 하나라서 거기에 for 돌때마다 +1 한 코드로 줘야할듯
                }
            }

            if (cnt == 0)
            {
                MessageBox.Show("추가할 품질규격을 선택해주십시오.");
                return;
            }

            foreach (SpecificationVO pv in list)
            {
                foreach (SpecificationVO pc in insList)
                {
                    if (pv.Process_code == pc.Process_code && pv.Inspect_code == pc.Inspect_code)
                    {
                        MessageBox.Show($"[{pv.Inspect_name}]은(는) 이미 등록되어있어 추가할수 없습니다.");
                        return;
                    }
                }

            }

            //검사항목코드, 품목코드, 공정코드 까지만 복사해서 SP로 이런 애를 select해서 조회된 애를 insert into A품목에 추가시키는
            SpecificationsService service = new SpecificationsService();
            int result = service.CopySpec(list);
            if (result > 0)
            {
                MessageBox.Show($"{result}개의 품질규격이 {itemName}에 추가되었습니다.");
                if (SaveEvent != null)
                {
                    SaveEvent(this, null);
                }
                this.Close();
            }

            //등록했으면 창 닫히게 하거나 체크박스컬럼 초기화 시키거나(닫는게 좋을듯)
            else
                MessageBox.Show("추가 중 오류가 발생하였습니다.\n다시 시도하여 주십시오");


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductName.SelectedIndex > 0)
            {
                txtProductCode.ReadOnly = true;
                txtProductCode.Text = prdList.Find(x => x.Item_Name.Equals(cboProductName.SelectedItem.ToString())).Item_Code;
            }
            else if(cboProductName.SelectedIndex == 0)
            {
                txtProductCode.Text = "";
                txtProductCode.ReadOnly = false;
            }
        }

        private void cboProcessName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProcessName.SelectedIndex > 0)
            {
                txtProcessCode.ReadOnly = true;
                txtProcessCode.Text = procList.Find(x => x.Process_name.Equals(cboProcessName.SelectedItem.ToString())).Process_code;
            }
            else if (cboProcessName.SelectedIndex == 0)
            {
                txtProcessCode.Text = "";
                txtProcessCode.ReadOnly = false;
            }
        }
    }
}
