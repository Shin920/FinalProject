using POP.Service;
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
    public partial class frmBakePottery : Form
    {
        string workorderno;
        string managerid;
        DataTable allFireDT;
        public frmBakePottery(string workorderno)
        {
            InitializeComponent();
            this.workorderno = workorderno;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                dataGridView1.DataSource = allFireDT;
            }
            else
            {
                DataView dv = new DataView(allFireDT);
                dv.RowFilter = "gv_code LIKE '%" + txtSearch.Text + "%'";
                dataGridView1.DataSource = dv;
            }
        }

        private void frmBakePottery_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();

            CommonUtil.SetInitGridView(dataGridView1);
            //select gc.gv_code, gv_name, loading_time, gv_qty, workorderno 
            CommonUtil.AddGridTextColumn(dataGridView1, "소성대차코드", "gv_code");
            CommonUtil.AddGridTextColumn(dataGridView1, "소성대차명", "gv_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "적재시각", "loading_time");
            CommonUtil.AddGridTextColumn(dataGridView1, "수량", "GV_Rest_Qty");
            CommonUtil.AddGridTextColumn(dataGridView1, "요입시간", "In_Time");
            CommonUtil.AddGridTextColumn(dataGridView1, "요출시간", "Out_Time");
            CommonUtil.AddGridTextColumn(dataGridView1, "대차이력순번", "Hist_Seq", visibility: false);


            CommonUtil.SetGridViewFontSize(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            CommonUtil.SetGridWidth(dataGridView1, "In_Time", 200);
            CommonUtil.SetGridWidth(dataGridView1, "Out_Time", 200);
            CommonUtil.SetGridWidth(dataGridView1, "loading_time", 200);
            CommonUtil.SetGridWidth(dataGridView1, "gv_code", 120);
            CommonUtil.SetGridWidth(dataGridView1, "gv_name", 110);
        }

        private void frmBakePottery_Shown(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            CartService service = new CartService();
            var list = service.GetOriginCarList(workorderno, "소성");
            dataGridView1.DataSource = list;
            allFireDT = CommonUtil.ToDataTable(list);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //이미 요입됐는지 어떻게 판단?
            if (dataGridView1.SelectedRows.Count < 1) return;
            string gv_code = dataGridView1.SelectedRows[0].Cells["gv_code"].Value.ToString();
            string hist_seq = dataGridView1.SelectedRows[0].Cells["hist_seq"].Value.ToString();
            CartService service = new CartService();
            bool result = service.SetCartInOut(gv_code, hist_seq, managerid, "요입");

            LoadData();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            //요입 상태인지 어떻게 판단?
            if (dataGridView1.SelectedRows.Count < 1) return;
            if(dataGridView1.SelectedRows[0].Cells["in_time"].Value == null|| dataGridView1.SelectedRows[0].Cells["out_time"].Value != null)
            {
                MessageBox.Show("요입이 되지 않았거나, 이미 요출이 된 소성대차 입니다.");
                return;
            }
            string gv_code = dataGridView1.SelectedRows[0].Cells["gv_code"].Value.ToString();
            string hist_seq = dataGridView1.SelectedRows[0].Cells["hist_seq"].Value.ToString();
            CartService service = new CartService();
            bool result = service.SetCartInOut(gv_code, hist_seq,managerid ,"요출");

            LoadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
