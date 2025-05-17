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
    public partial class frmVacateCar : Form
    {
        string workorderno;
        string managerid;
        string wc_code;
        string reason;
        string item_code;
        public string prdQty;
        DataTable allFireDT;
        public string Reason { set { reason = value; } }
        public frmVacateCar(string workorderno, string wc_code, string item_code)
        {
            InitializeComponent();
            this.workorderno = workorderno;
            this.wc_code = wc_code;
            this.item_code = item_code;
        }

        private void frmVacateCar_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();
            CommonUtil.SetInitGridView(dataGridView1);
            //select gc.gv_code, gv_name, loading_time, gv_qty, workorderno 
            CommonUtil.AddGridTextColumn(dataGridView1, "대차코드", "gv_code");
            CommonUtil.AddGridTextColumn(dataGridView1, "대차명", "gv_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "적재시각", "loading_time");
            CommonUtil.AddGridTextColumn(dataGridView1, "수량", "GV_Rest_Qty");
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "workorderno", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "요입시간", "in_time");
            CommonUtil.AddGridTextColumn(dataGridView1, "요출시간", "out_time");
            CommonUtil.AddGridTextColumn(dataGridView1, "현황순번", "Status_Seq", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "대차이력순번", "Hist_Seq", visibility: false);


            CommonUtil.SetGridViewFontSize(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            CommonUtil.SetGridWidth(dataGridView1, "In_Time", 200);
            CommonUtil.SetGridWidth(dataGridView1, "Out_Time", 200);
            CommonUtil.SetGridWidth(dataGridView1, "loading_time", 200);
            CommonUtil.SetGridWidth(dataGridView1, "gv_code", 120);
            CommonUtil.SetGridWidth(dataGridView1, "gv_name", 110);
            CommonUtil.SetGridWidth(dataGridView1, "GV_Rest_Qty", 60);
        }
        private void LoadData()
        {
            CartService service = new CartService();
            var list = service.GetOriginCarList(workorderno, "소성");
            dataGridView1.DataSource = list;
            allFireDT = CommonUtil.ToDataTable(list);
        }
        private void frmVacateCar_Shown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            if(txtQty.Text == "" || Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["GV_Rest_Qty"].Value) < Convert.ToInt32(txtQty.Text))
            {
                MessageBox.Show("제대로 된 수량을 입력해주세요.");
                return;
            }

            if (dataGridView1.SelectedRows.Count < 1) return;

                frmVacReasonPopup frm = new frmVacReasonPopup();
            frm.Owner = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            if(frm.ShowDialog() == DialogResult.OK)
            {
                //이유 받아왔을 경우
                //gv_current_status에 gv_rest_qty, up_date, up_emp (where gv_code)
                //gv_history에 clear_Date, clear_datetime, clear_qty, clear_cause, clear_wc, clear_item, up_date, up_emp (where hist_Seq)
                string gv_code = dataGridView1.SelectedRows[0].Cells["gv_code"].Value.ToString();
                string hist_seq = dataGridView1.SelectedRows[0].Cells["hist_seq"].Value.ToString();

                CartService service = new CartService();
                bool result = service.VacateCar(gv_code, Convert.ToInt32(txtQty.Text), wc_code, item_code, hist_seq, managerid, workorderno, reason);
                if (result)
                {
                    MessageBox.Show($"대차코드 [{gv_code}] 의 수량 [{txtQty.Text}]이 다음의 이유로 언로딩 되었습니다. \n[사유]\n {reason}");
                    LoadData();
                    txtQty.Text = "";
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
