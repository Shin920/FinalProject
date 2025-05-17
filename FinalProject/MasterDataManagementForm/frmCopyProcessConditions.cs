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
    public partial class frmCopyProcessConditions : FinalProject.List_Popup
    {
        public event EventHandler SaveEvent;

        CheckBox chbox = new CheckBox();
        string itemCode;    //품질규격설정 폼에서 열때 어떤 품목에 대해 추가하려고 열었는지 보내준다. (사용자의 편의를 위해 품목명도 가져온다)
        string itemName;
        string userName;
        
        List<SpecificationVO> prdList;
        List<ProcessVO> procList;
        List<ProcessVO> commonList;
        
        public frmCopyProcessConditions(string code, string name, List<ProcessVO> list, string userName)
        {
            InitializeComponent();

            itemCode = code;
            itemName = name;
            commonList = list;
            this.userName = userName;
        }

        private void frmCopyProcessConditions_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvProcess.Columns.Add(chk);

            Point headerPoint = dgvProcess.GetCellDisplayRectangle(0, -1, true).Location;
            chbox.Location = new Point(headerPoint.X + 7, headerPoint.Y + 4);
            chbox.Size = new Size(18, 18);
            chbox.BackColor = Color.White;
            chbox.Click += Chbox_Click;
            dgvProcess.Controls.Add(chbox);

            CommonUtil.SetInitGridView(dgvProcess);
            //CommonUtil.AddGridTextColumn(dgvQuality, "체크박스", ""); //0번째
            CommonUtil.AddGridTextColumn(dgvProcess, "품목코드", "Item_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcess, "작업장코드", "Wc_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcess, "조건항목코드", "Condition_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProcess, "조건항목명", "Condition_Name", colWidth: 370);
            CommonUtil.AddGridTextColumn(dgvProcess, "규격상한값", "USL", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcess, "규격기준값", "SL", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcess, "규격하한값", "LSL", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProcess, "단위", "Condition_Unit");
            CommonUtil.AddGridTextColumn(dgvProcess, "비고", "Remark");

            LoadData();

            lblItemName.Text = itemName;
        }

        private void LoadData()
        {
            SpecificationsService service = new SpecificationsService();          
            prdList = service.GetProductList();

            ProcessService prcService = new ProcessService();
            procList = prcService.GetProcessConditionList();

            foreach (SpecificationVO sv in prdList)
            {
                if (!sv.Item_Code.Equals(itemCode))      //Copy로 팝업에 들어갔을때 현재 선택해서 들어간 품목에 대한 조회는 없애야 이미 본인한테 있는 품질규격의 복사를 막을수 있다.
                    cboProductName.Items.Add(sv.Item_Name);
            }
            cboProductName.Items.Insert(0, "");
           
        }
        private void Chbox_Click(object sender, EventArgs e)
        {
            dgvProcess.EndEdit();
            //endEdit이란 그리드뷰에 포커스가 가있어서 편집상태가 되어있을때 오류나 값이 이상하게 되버리는데
            //이건 다른 셀을 클릭해서 편집상태를 끝냈다는 효과를 주는 메서드이다.
            foreach (DataGridViewRow row in dgvProcess.Rows)
            {
                DataGridViewCheckBoxCell box = (DataGridViewCheckBoxCell)row.Cells["chk"];
                box.Value = chbox.Checked;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if ((cboProductName.SelectedIndex <= 0 && string.IsNullOrWhiteSpace(txtProductCode.Text)))
            {
                MessageBox.Show("검색하실 조건을 입력해주십시오.");
                return;
            }
          
            else if (!string.IsNullOrWhiteSpace(txtProductCode.Text))
            {
                List<ProcessVO> list = procList.FindAll(x => x.Item_Code.Equals(txtProductCode.Text));

                dgvProcess.DataSource = null;
                dgvProcess.DataSource = list;

                dgvProcess.Paint += DgvProcess_Paint;
            }
           

        }

        private void DgvProcess_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < dgvProcess.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    this.dgvProcess.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                }
                else
                {
                    this.dgvProcess.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
            //추가될때는 품목정보는 제외하고 처음 품질규격설정 폼에서 열때 그 품목에 품질규격들을 추가하는것
            List<ProcessVO> list = new List<ProcessVO>();
            int i;
            int cnt = 0;
            for (i = 0; i < dgvProcess.Rows.Count; i++)
            {
                bool isChecked = (bool)dgvProcess[0, i].EditedFormattedValue;

                if (isChecked)
                {
                    //list.Add($"{dgvQuality[1, i].Value.ToString()},{dgvQuality[3, i].Value.ToString()},{dgvQuality[4, i].Value.ToString()}");     
                    ProcessVO sv = new ProcessVO()
                    {
                        New_Item_Code = itemCode,
                        Ins_Emp = userName,
                        Item_Code = dgvProcess[1, i].Value.ToString(),
                        Wc_Code = dgvProcess[2, i].Value.ToString(),
                        Condition_Code = dgvProcess[3, i].Value.ToString(),
                        Condition_Name = dgvProcess[4, i].Value.ToString()
                    };
                    list.Add(sv);
                    cnt++;  //체크를 하고 저장버튼을 눌렀는지 아무것도 체크안하고 저장버튼을 눌렀는지 체크하려고
                }
            }

            if (cnt == 0)
            {
                MessageBox.Show("추가할 공정조건을 선택해주십시오.");
                return;
            }

           foreach(ProcessVO pv in list)
            {
                foreach(ProcessVO pc in commonList)
                {
                    if (pv.Wc_Code == pc.Wc_Code && pv.Condition_Code == pc.Condition_Code)
                    {
                        MessageBox.Show($"[{pv.Condition_Name}]은(는) 이미 등록되어있어 추가할수 없습니다.");
                        return;
                    }
                }
              
            }
                //검사항목코드, 품목코드, 공정코드 까지만 복사해서 SP로 이런 애를 select해서 조회된 애를 insert into A품목에 추가시키는
                ProcessService service = new ProcessService();
            int result = service.CopyProcCondition(list);
            if (result > 0)
            {
                MessageBox.Show($"{result}개의 공정조건이 {itemName}에 추가되었습니다.");
                if(SaveEvent != null)
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
            else if (cboProductName.SelectedIndex == 0)
            {
                txtProductCode.Text = "";
                txtProductCode.ReadOnly = false;
            }
        }
    }
}
