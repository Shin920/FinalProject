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
    public partial class frmAddItem : FinalProject.Detail_Popup
    {
        List<ItemVO> list;
        
        public frmAddItem()
        {
            InitializeComponent();
        }

        private void frmAddItem_Load(object sender, EventArgs e)
        {
            
            ProcessService pservice = new ProcessService();
            ItemService iservice = new ItemService();
            List<ProcessVO> plist = pservice.GetProcessList();
            List<ComboItemVO> ilist = iservice.GetItemType();
            list = iservice.GetItemList();

            if (list.Count < 1)
            {
                txtCode.Text = "IC10001";
                btnSave.Enabled = true;
                return;
            }

            int code = int.Parse(list[list.Count - 1].Item_Code.Replace("IC", ""));
            txtCode.Text = "IC" + (code + 1);

            btnSave.Enabled = true;

            foreach (ComboItemVO no in ilist)
            {
                cboType.Items.Add(no.com_Code);

            }

            cboType.SelectedIndex = 0;

            foreach (ProcessVO no in plist)
            {
                cboLvl1.Items.Add(no.Process_name);
                cboLvl2.Items.Add(no.Process_name);
                cboLvl3.Items.Add(no.Process_name);
                cboLvl4.Items.Add(no.Process_name);
                cboLvl5.Items.Add(no.Process_name);

            }
            cboLvl1.Items.Insert(0, "");
            cboLvl2.Items.Insert(0, "");
            cboLvl3.Items.Insert(0, "");
            cboLvl4.Items.Insert(0, "");
            cboLvl5.Items.Insert(0, "");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //추가
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    MessageBox.Show("품목코드를 입력해주십시오.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("품목명을 입력해주십시오.");
                    return;
                }
                if (!(cboType.SelectedIndex > 0))
                {
                    MessageBox.Show("유형이 선택되지 않았습니다.");
                    return;
                }

                ItemService service = new ItemService();
                bool result = service.InsertItem(txtCode.Text, txtName.Text, txtEng.Text, txtAlias.Text, cboType.SelectedItem.ToString(), txtSpec.Text, txtUnit.Text, nmcStock.Value, nmcPph.Value, nmcPpB.Value, Convert.ToInt32(nmcCav.Value), Convert.ToInt32(nmcLpq.Value), Convert.ToInt32(nmcSpq.Value), Convert.ToInt32(nmcDgq.Value) , Convert.ToInt32(nmcHgq.Value), cboLvl1.SelectedItem.ToString(), cboLvl2.SelectedItem.ToString(), cboLvl3.SelectedItem.ToString(), cboLvl4.SelectedItem.ToString(), cboLvl5.SelectedItem.ToString(),  "로그인관리자이름");
                if (result)
                {
                    MessageBox.Show("등록되었습니다.");

                }

                else
                    MessageBox.Show("등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nmcCav_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
