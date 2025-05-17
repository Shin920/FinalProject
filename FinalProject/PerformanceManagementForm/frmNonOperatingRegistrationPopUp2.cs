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
    public partial class frmNonOperatingRegistrationPopUp2 : FinalProject.Detail_Popup
    {
        public event EventHandler SaveEvent;

        List<WorkCenterVO> wcList;
        List<NonOperationVO> nopList;

        public frmNonOperatingRegistrationPopUp2()
        {
            InitializeComponent();
        }

        private void frmNonOperatingRegistrationPopUp2_Load(object sender, EventArgs e)
        {
            //작업장 정보 가져와서 바인딩
            WorkCenterService wcService = new WorkCenterService();
            wcList = wcService.GetWorkCenterSmallList();
            foreach(WorkCenterVO wv in wcList)
            {
                cboWorkPlace.Items.Add(wv.Wc_Name);
            }
            cboWorkPlace.Items.Insert(0, "");

            NonOperationService nopService = new NonOperationService();
            nopList = nopService.GetNopDetailSmallList();
            foreach (NonOperationVO no in nopList)
            {
                cboNopDetailName.Items.Add(no.Nop_Mi_Name);
            }
            cboNopDetailName.Items.Insert(0, "");
        }

        private void cboWorkPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWorkPlace.SelectedIndex == 0)
            {
                txtWorkPlaceCode.ReadOnly = false;
                txtWorkPlaceCode.Text = "";
            }
            if (cboWorkPlace.SelectedIndex > 0)
            {
                txtWorkPlaceCode.ReadOnly = true;
                txtWorkPlaceCode.Text = wcList.Find(x => x.Wc_Name.Equals(cboWorkPlace.SelectedItem.ToString())).Wc_Code;
            }

        }

        private void cboNopDetailName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNopDetailName.SelectedIndex == 0)
            {
                txtNopDetailCode.ReadOnly = false;
                txtNopDetailCode.Text = "";
            }
            if (cboNopDetailName.SelectedIndex > 0)
            {
                txtNopDetailCode.ReadOnly = true;
                txtNopDetailCode.Text = nopList.Find(x => x.Nop_Mi_Name.Equals(cboNopDetailName.SelectedItem.ToString())).Nop_Mi_Code;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            foreach(Control ctrl in grbConditions.Controls)
            {
                if(ctrl.GetType() == typeof(TextBox) && ctrl.Name != "txtNote")
                {
                    if(string.IsNullOrWhiteSpace(ctrl.Text))
                    {
                        cnt++;
                    }
                }
            }
            if(cnt > 0)
            {
                MessageBox.Show("필수입력 항목을 입력해주십시오.");
                return;
            }

            NonOperationVO nv = new NonOperationVO()
            {
                Nop_Happentime = DateTime.Now,
                Nop_Time = numericUpDown1.Value,
                Nop_Canceltime = DateTime.Now.AddMinutes((double)numericUpDown1.Value),
                Wc_Code = txtWorkPlaceCode.Text,
                Nop_Mi_Code = txtNopDetailCode.Text,
                Nop_Type = txtNopType.Text,             
                Remark = txtNote.Text,
                Ins_Emp = "로그인관리자"               
            };
            //@Nop_Happentime, @Nop_Canceltime, @Wc_Code, @Nop_Mi_Code, @Nop_Type, @Nop_Time, @Remark, 이름
            NonOperationService service = new NonOperationService();
            bool result = service.RegisterNop(nv);
            if (result)
            {
                MessageBox.Show("등록되었습니다.");
                if (SaveEvent != null)
                {
                    SaveEvent(this, null);
                }              
                this.Close();
            }
            else
                MessageBox.Show("등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
