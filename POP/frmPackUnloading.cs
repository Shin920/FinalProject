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
    public partial class frmPackUnloading : Form
    {
        string workorderno;
        string managerid;
        public frmPackUnloading(string workorderno)
        {
            InitializeComponent();
            this.workorderno = workorderno;
        }

        private void frmPackUnloading_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();
            //작업지시 데이터 가져오기
            //작업지시번호, 품목명, 작업지시일, 작업장, 실적수량, 단위
            WorkOrderService service = new WorkOrderService();
            POPWorkVO wo = service.GetWorkOrderDetail(workorderno);
            txtWorkNO.Text = wo.Workorderno;
            txtWorkPlace.Text = wo.wc_Name;
            txtWorkPlace.Tag = wo.wc_Code;
            txtWorkDate.Text = wo.Plan_Date.ToString("yyyy-MM-dd");
            txtUnit.Text = wo.Item_Unit;
            txtQty.Text = wo.Prd_Qty.ToString();
            txtProd.Text = wo.Item_Name;
            txtProd.Tag = wo.Item_Code;

            CommonUtil.SetInitGridView(dataGridView1);
            //select gc.gv_code, gv_name, loading_time, gv_qty, workorderno 
            CommonUtil.AddGridTextColumn(dataGridView1, "대차코드", "gv_code");
            CommonUtil.AddGridTextColumn(dataGridView1, "대차명", "gv_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "workorderno");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목코드", "item_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목명", "item_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "수량", "GV_Rest_Qty");

            CommonUtil.AddGridTextColumn(dataGridView1, "현황순번", "Status_Seq", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "대차이력순번", "Hist_Seq", visibility: false);


            CommonUtil.SetGridViewFontSize(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            CommonUtil.SetInitGridView(dataGridView2);
            //pallet_no, SEQ, g.barcode_no, TOT_QTY, REsT_QTY , g.size_code, size_name
            CommonUtil.AddGridTextColumn(dataGridView2, "팔레트번호", "pallet_no");
            CommonUtil.AddGridTextColumn(dataGridView2, "SEQ", "SEQ");
            CommonUtil.AddGridTextColumn(dataGridView2, "바코드번호", "barcode_no", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView2, "적재 가능 수량", "TOT_QTY", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView2, "적재 가능 수량", "REsT_QTY");
            CommonUtil.AddGridTextColumn(dataGridView2, "사이즈코드", "size_code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView2, "사이즈", "size_name");



            CommonUtil.SetGridViewFontSize(dataGridView2);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void frmPackUnloading_Shown(object sender, EventArgs e)
        {
            LoadData();
            GetPalletList(workorderno);
        }
        private void LoadData()
        {
            CartService service = new CartService();
            var list = service.GetOriginCarList(workorderno, "소성");
            dataGridView1.DataSource = list;
        }
        private void GetPalletList(string workorderno)
        {
            PackService service = new PackService();
            DataTable dt = service.GetPalletList(workorderno);
            dataGridView2.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count < 1) return;
            if (dataGridView1.SelectedRows.Count < 1) return;
            //REsT_QTY

            for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
            {
                int qty = 0;
                if (Convert.ToInt32(dataGridView2.SelectedRows[i].Cells["REsT_QTY"].Value) <= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["GV_Rest_Qty"].Value))
                {
                    //적재가능한 수량이 소성대차의 품목 수량보다 적거나 같을때
                    //rest_qty 수량만큼 팔레트 적재, 소성대차에서 언로딩
                    //qty = rest_qty
                    qty = Convert.ToInt32(dataGridView2.SelectedRows[i].Cells["REsT_QTY"].Value);
                }
                else if (Convert.ToInt32(dataGridView2.SelectedRows[i].Cells["REsT_QTY"].Value) > Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["GV_Rest_Qty"].Value))
                {
                    //적재가능한 수량이 소성대차에 남은 수량보다 많은 경우
                    //소성대차의 수량이 qty
                    //qty 수량만큼 팔레트 적재, 소성대차에서 언로딩
                    qty = Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["GV_Rest_Qty"].Value);
                }
                //	@managerid  NVARCHAR(20),
                //   @workorderno NVARCHAR(20),
                //@TARGET_Barcodeno int,
                //   @QTY int,
                //   @STATUS_SEQ int,
                //   @ORIGIN_GV_CODE NVARCHAR(20),
                //@Hist_Seq bigint,
                //   @seq int
                int SEQ = Convert.ToInt32(dataGridView2.SelectedRows[i].Cells["SEQ"].Value);
                int TARGET_Barcodeno = Convert.ToInt32(dataGridView2.SelectedRows[i].Cells["barcode_no"].Value);
                int Status_Seq = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Status_Seq"].Value);
                long Hist_Seq = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Hist_Seq"].Value);
                string ORIGIN_GV_CODE = dataGridView1.SelectedRows[0].Cells["gv_code"].Value.ToString();

                PackService service = new PackService();
                bool result = service.UnloadingToPallet(managerid, workorderno, TARGET_Barcodeno, qty, Status_Seq, ORIGIN_GV_CODE, Hist_Seq, SEQ);

                if (result)
                {
                    //LoadData();
                }
            }

            LoadData();
            GetPalletList(workorderno);
        }

      
    }
}
