using ClassLibrary1;
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
    public partial class frmReceive : Form
    {
        string workorderno;
        string managerid;
        DataTable allDt = new DataTable();
        public frmReceive(string workorderno)
        {
            //선택한 row가 있는 경우
            InitializeComponent();
            this.workorderno = workorderno;
        }
        public frmReceive()
        {
            InitializeComponent();
        }

        private void frmReceive_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();
            //작업지시 데이터 가져오기
            //작업지시번호, 품목명, 작업지시일, 작업장, 실적수량, 단위
            //WorkOrderService service = new WorkOrderService();
            //POPWorkVO wo = service.GetWorkOrderDetail(workorderno);

            frm.ReadCompleted += Main_ReadCompleted;

            CommonUtil.SetInitGridView(dataGridView1);
            //select g.Barcode_No, seq,  Pallet_No, g.WorkOrderno, item_name, QTY, Grade_Detail_Name
            CommonUtil.AddGridTextColumn(dataGridView1, "팔레트번호", "Pallet_No");
            CommonUtil.AddGridTextColumn(dataGridView1, "SEQ", "seq");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목", "item_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "등급", "Grade_Detail_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "수량", "QTY");

            CommonUtil.AddGridTextColumn(dataGridView1, "바코드번호", "Barcode_No", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "WorkOrderno", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업장", "wc_name", visibility: false);


            CommonUtil.SetGridViewFontSize(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void LoadPalList(string workorderno)
        {
            PackService service = new PackService();
            allDt = service.LoadPalList(workorderno);
            dataGridView1.DataSource = allDt;
        }
        private void Main_ReadCompleted(object sender, ReadEventAgrs e)
        {
            if (((Form1)this.MdiParent).ActiveMdiChild != this) return;

            string barseq = e.ReadMessage;
            string[] bar_seq = barseq.Split('/');
            //바코드를 id/pwd로 받아온다면 -> split 이용
            lblbarcodeno.Text = bar_seq[0];
            lblseq.Text = bar_seq[1];

            //데이터테이블에서 해당하는 항목을 나타냄
            DataRow[] arrRows = null;
            arrRows = allDt.Select($"Barcode_No={lblbarcodeno.Text} AND SEQ={lblseq.Text}");
            foreach (DataRow row in arrRows)
            {
                txtPalNo.Text = row["Pallet_No"].ToString();
                txtWorkOrderNo.Text = row["WorkOrderno"].ToString();
                txtItem.Text = row["item_name"].ToString();
                txtWcName.Text = row["wc_name"].ToString();
                txtGrade.Text = row["Grade_Detail_Name"].ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //팔레트, 작지, 품목, 작업장, 등급
            //select g.Barcode_No, seq,  Pallet_No, g.WorkOrderno, item_name, QTY, Grade_Detail_Name
            txtPalNo.Text = dataGridView1.SelectedRows[0].Cells["Pallet_No"].Value.ToString();
            txtWorkOrderNo.Text = dataGridView1.SelectedRows[0].Cells["WorkOrderno"].Value.ToString();
            txtItem.Text = dataGridView1.SelectedRows[0].Cells["item_name"].Value.ToString();
            txtWcName.Text = dataGridView1.SelectedRows[0].Cells["wc_name"].Value.ToString();
            txtGrade.Text = dataGridView1.SelectedRows[0].Cells["Grade_Detail_Name"].Value.ToString();
            lblbarcodeno.Text = dataGridView1.SelectedRows[0].Cells["Barcode_No"].Value.ToString();
            lblseq.Text = dataGridView1.SelectedRows[0].Cells["seq"].Value.ToString();
        }

        private void frmReceive_Shown(object sender, EventArgs e)
        {
            LoadPalList(workorderno);
            dataGridView1.ClearSelection();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            PackService service = new PackService();
            bool result = service.InPallet(lblbarcodeno.Text, lblseq.Text, managerid);
            if (result)
            {
                LoadPalList(workorderno);
                Reset();
            }
            else
            {
                MessageBox.Show("입고등록에 실패했습니다. 다시 시도해주세요.");
                return;
            }
        }
        private void Reset()
        {
            txtGrade.Text = txtItem.Text = txtPalNo.Text = txtWcName.Text = txtWorkOrderNo.Text = "";
            lblbarcodeno.Text = lblseq.Text = "";
        }
    }
}
