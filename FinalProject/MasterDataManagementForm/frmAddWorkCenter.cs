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
    public partial class frmAddWorkplace : FinalProject.Detail_Popup
    {
        List<ProcessVO> list;
        List<WorkCenterVO> wlist;
        public WorkCenterVO no { get; set; }
        public frmAddWorkplace()
        {
            InitializeComponent();
        }

        private void frmAddWorkplace_Load(object sender, EventArgs e)
        {
            WorkCenterService wservice = new WorkCenterService();
            wlist = wservice.GetWorkCenterList();

            if (wlist.Count < 1)
            {
                txtCode.Text = "WC10001";
                btnSave.Enabled = true;
                return;
            }

            int code = int.Parse(wlist[wlist.Count - 1].Wc_Code.Replace("WC", ""));
            txtCode.Text = "WC" + (code + 1);

            if (no != null)
            {
                txtCode.Text = no.Wc_Code;
                txtCode.ReadOnly = true;
            }
            //공정 콤보박스 바인딩
            ProcessService service = new ProcessService();
            list = service.GetProcessList();

           
            foreach (ProcessVO no in list)
            {
                cboPrcName.Items.Add(no.Process_name);
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.ReadOnly != true)
                {
                    //추가
                    if (string.IsNullOrWhiteSpace(txtCode.Text))
                    {
                        MessageBox.Show("작업장코드를 입력해주십시오.");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtName.Text))
                    {
                        MessageBox.Show("작업장명을 입력해주십시오.");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtPrcCode.Text))
                    {
                        MessageBox.Show("공정이 선택되지 않았습니다.");
                        return;
                    }

                    WorkCenterService service = new WorkCenterService();
                    bool result = service.InsertWorkCenter(txtCode.Text, txtName.Text, txtPrcCode.Text, txtRemark.Text, "로그인관리자이름");
                    if (result)
                    {
                        MessageBox.Show("등록되었습니다.");
                       
                    }

                    else
                        MessageBox.Show("등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                }
                else
                {
                    //수정
                    if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrcCode.Text))
                    {
                        MessageBox.Show("필수항목을 모두 입력해주십시오.");
                        return;
                    }

                    DialogResult dresult = MessageBox.Show("수정하시겠습니까?", "작업장정보 수정", MessageBoxButtons.YesNo);
                    if (dresult == DialogResult.Yes)
                    {
                        WorkCenterService service = new WorkCenterService();
                        WorkCenterVO no = new WorkCenterVO()
                        {
                            Wc_Name = txtName.Text,
                            Process_Code = txtPrcCode.Text,
                            Remark = txtRemark.Text,
                           
                        };
                        bool result = service.UpdateWorkCenter(no);
                        if (result)
                        {
                            MessageBox.Show("수정되었습니다.");                           
                        }
                        else
                            MessageBox.Show("수정 중 오류가 발생하였습니다.\n다시 시도하여 주십시오");
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cboPrcName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //공정명을 선택하면, txtPrcCode에 공정코드 입력되게
            ProcessVO selPrc;
            selPrc = list.Find(x => x.Process_name.Contains(cboPrcName.SelectedItem.ToString()));
            txtPrcCode.Text = selPrc.Process_code;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
