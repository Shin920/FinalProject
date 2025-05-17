using ClassLibrary1;
using FinalProjectVO;
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
    public partial class frmReCreatePalette : Form
    {
        string WorkOrderNO;
        string managerid;
        DataTable palListdt;

        List<BoxingVO> palList = new List<BoxingVO>();
        public frmReCreatePalette(string workorderno)
        {
            InitializeComponent();
            WorkOrderNO = workorderno;
        }

        private void btnRePrint_Click(object sender, EventArgs e)
        {
            //createpalette에서 바코드 인쇄하는 부분만 복붙
            CommonUtil.BarCodePrint(dataGridView1.SelectedRows[0].Cells["Barcode_No"].Value.ToString());
        }

        private void frmReCreatePalette_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();
        }

        private void frmReCreatePalette_Shown(object sender, EventArgs e)
        {
            WorkOrderService service = new WorkOrderService();
            POPWorkVO wo = service.GetWorkOrderDetail(WorkOrderNO);
            WorkOrderNO = wo.Workorderno;

            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "팔레트번호", "Pallet_No");
            CommonUtil.AddGridTextColumn(dataGridView1, "제품", "item_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "등급", "Grade_Detail_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "수량", "In_Qty");
            CommonUtil.AddGridTextColumn(dataGridView1, "등급코드", "Grade_Code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "등급상세코드", "Grade_Detail_Code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "사이즈", "Size_Code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "사이즈", "Size_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "바코드", "Barcode_No", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "바코드", "ins_date", visibility: false);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            CommonUtil.SetGridViewFontSize(dataGridView1, 25);
            GetPalList(WorkOrderNO);
        }
        private void GetPalList(string workorderno)
        {
            PackService service = new PackService();
            palList = service.GetPalList(workorderno);
            dataGridView1.DataSource = palList;
            palListdt = CommonUtil.ToDataTable(palList);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPalNo.Text = dataGridView1.SelectedRows[0].Cells["Pallet_No"].Value.ToString();
            txtGradeDetail.Text = dataGridView1.SelectedRows[0].Cells["Grade_Detail_Name"].Value.ToString();
            txtGradeDetail.Tag = dataGridView1.SelectedRows[0].Cells["Grade_Detail_Code"].Value.ToString();
            txtGrade.Text = dataGridView1.SelectedRows[0].Cells["Grade_Code"].Value.ToString();
            txtSize.Text = dataGridView1.SelectedRows[0].Cells["Size_Name"].Value.ToString();
            lblPalNo.Tag = dataGridView1.SelectedRows[0].Cells["Barcode_No"].Value.ToString();
            txtQty.Text = dataGridView1.SelectedRows[0].Cells["In_Qty"].Value.ToString();

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtPalNo.Text == "") return;

            PackService service = new PackService();
            bool result = service.DelPal(lblPalNo.Tag.ToString());
            if (result)
            {
                MessageBox.Show("팔레트 삭제가 완료되었습니다.");
                GetPalList(WorkOrderNO);
                txtGrade.Text = txtGradeDetail.Text = txtPalNo.Text = txtSize.Text = txtQty.Text = "";
                lblPalNo.Tag = "";
            }
            else
            {
                MessageBox.Show("팔레트 생성에 실패했습니다.");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
                DataView dv = new DataView(palListdt);
                dv.RowFilter = "ins_date >= '" + dtpFrom.Value.AddDays(-1).ToString("yyyy-MM-dd") + "' and ins_date <=  '" + dtpTo.Value.AddDays(1).ToString("yyyy-MM-dd")+"'";
                dataGridView1.DataSource = dv;
        }
    }
}
