using FinalProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP
{
    public partial class SetOperatePopup : Form
    {
        string seq;
        string managerid;
        string wcname;
        DataTable maDt = new DataTable();
        DataTable miDt = new DataTable();
        public SetOperatePopup(string seq, string wcname, string managerid)
        {
            InitializeComponent();
            this.seq = seq;
            this.managerid = managerid;
            this.wcname = wcname;
            lblWcName.Text = wcname;
        }

        private void SetOperatePopup_Load(object sender, EventArgs e)
        {

        }

        private void SetOperatePopup_Shown(object sender, EventArgs e)
        {
            LoadMiData();
            LoadMaData();
        }

        private void LoadMiData()
        {
            NonOperationService service = new NonOperationService();
            miDt = service.GetUseNopDetailMiList();
        }

        private void LoadMaData()
        {
            NonOperationService service = new NonOperationService();
            maDt = service.GetUseNonOperationMaList();
            cboNopMa.DataSource = maDt;
            cboNopMa.DisplayMember = "Nop_Ma_Name";
            cboNopMa.ValueMember = "Nop_Ma_Code";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NonOperationService service = new NonOperationService();
            bool result = service.UpdateNonOperationReason(cboNopMi.SelectedValue.ToString(), managerid, seq);
            if (result)
            {
                MessageBox.Show("비가동 사유가 변경되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("비가동 사유 변경에 실패했습니다.");
                return;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboNopMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(miDt);
            dv.RowFilter = $"Nop_Ma_Code = '{cboNopMa.SelectedValue}'";
            cboNopMi.DisplayMember = "Nop_Mi_Name";
            cboNopMi.ValueMember = "Nop_Mi_Code";
            cboNopMi.DataSource = dv;
        }
    }
}
