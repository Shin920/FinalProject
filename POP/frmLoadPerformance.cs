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
    public partial class frmLoadPerformance : Form
    {
        string managerid;
        string itemCode;
        string WorkOrderNO;
        DataTable allDryDT;
        DataTable allFireDT;
        public frmLoadPerformance(string workorderno)
        {
            InitializeComponent();
            txtWorkNO.Text = WorkOrderNO = workorderno;
        }

        private void frmLoadPerformance_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();
            //작업지시 데이터 가져오기
            //작업지시번호, 품목명, 작업지시일, 작업장, 실적수량, 단위
            WorkOrderService service = new WorkOrderService();
            POPWorkVO wo = service.GetWorkOrderDetail(WorkOrderNO);
            txtWorkNO.Text = wo.Workorderno;
            //이름으로 바꿔야함
            txtWorkPlace.Text = wo.wc_Name;
            txtWorkPlace.Tag = wo.wc_Code;
            txtWorkDate.Text = wo.Plan_Date.ToString("yyyy-MM-dd");
            txtUnit.Text = wo.Item_Unit;
            txtQty.Text = wo.Plan_Qty.ToString();
            txtProd.Text = wo.Item_Name;
            txtProd.Tag = wo.Item_Code;
            itemCode = wo.Item_Code;

            CommonUtil.SetInitGridView(dgvFireCar);
            //select gv_code, gv_name 
            //소성대차
            CommonUtil.AddGridTextColumn(dgvFireCar, "소성대차코드", "gv_code");
            CommonUtil.AddGridTextColumn(dgvFireCar, "소성대차명", "gv_name");

            CommonUtil.SetGridViewFontSize(dgvFireCar);
            dgvFireCar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFireCar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //건조대차
            CommonUtil.SetInitGridView(dgvDryCar);
            //select gc.gv_code, gv_name, loading_time, gv_qty, workorderno 
            CommonUtil.AddGridTextColumn(dgvDryCar, "건조대차코드", "gv_code");
            CommonUtil.AddGridTextColumn(dgvDryCar, "건조대차명", "gv_name");
            CommonUtil.AddGridTextColumn(dgvDryCar, "적재시각", "loading_time");
            CommonUtil.AddGridTextColumn(dgvDryCar, "수량", "GV_Rest_Qty");
            CommonUtil.AddGridTextColumn(dgvDryCar, "작업지시번호", "workorderno", visibility: false);
            CommonUtil.AddGridTextColumn(dgvDryCar, "현황순번", "Status_Seq", visibility: false);
            CommonUtil.AddGridTextColumn(dgvDryCar, "대차이력순번", "Hist_Seq", visibility: false);


            CommonUtil.SetGridViewFontSize(dgvDryCar);
            dgvDryCar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDryCar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            CommonUtil.SetGridWidth(dgvDryCar, "loading_time", 200);
            CommonUtil.SetGridWidth(dgvDryCar, "GV_Rest_Qty", 60);
            CommonUtil.SetGridWidth(dgvDryCar, "gv_code", 120);
        }
        public void LoadDryCarList()
        {
            CartService service = new CartService();
            List<CartVO> list = service.GetOriginCarList(WorkOrderNO, "건조");
            dgvDryCar.DataSource = list;
            allDryDT = CommonUtil.ToDataTable(list);
        }


        public void LoadFireCarList()
        {
            CartService service = new CartService();
            List<CartVO> list = service.GetTargetCarList("소성");
            dgvFireCar.DataSource = list;
            allFireDT = CommonUtil.ToDataTable(list);
        }

        private void btnLoading_Click(object sender, EventArgs e)
        {
            if (dgvFireCar.SelectedRows.Count == 0 || dgvDryCar.SelectedRows.Count == 0 || txtLoadQty.Text.Trim().Length == 0 || Convert.ToInt32(txtLoadQty.Text) > Convert.ToInt32(dgvDryCar.SelectedRows[0].Cells["GV_Rest_Qty"].Value))
            {
                MessageBox.Show("소성대차, 건조대차, 수량을 제대로 입력해주세요.");
                return;
            }

            //target 에 수량만큼 로딩
            //origincar의 수량과 같거나 적어야함
            //cmd.Parameters.AddWithValue("@managerid", )
            //       cmd.Parameters.AddWithValue("@workorderno", )
            //       cmd.Parameters.AddWithValue("@TARGET_GV_CODE", )
            //       cmd.Parameters.AddWithValue("@QTY", )
            //       cmd.Parameters.AddWithValue("@STATUS_SEQ", )
            //       cmd.Parameters.AddWithValue("@ORIGIN_GV_CODE", )
            Form1 frm = (Form1)this.MdiParent;
            string managerid = frm.GetUserID();
            string workOrderNo = dgvDryCar.SelectedRows[0].Cells["workorderno"].Value.ToString();
            string target_Gv_Code = dgvFireCar.SelectedRows[0].Cells["gv_code"].Value.ToString();
            string origin_Gv_Code = dgvDryCar.SelectedRows[0].Cells["gv_code"].Value.ToString();
            int qty = Convert.ToInt32(txtLoadQty.Text);
            int status_seq = Convert.ToInt32(dgvDryCar.SelectedRows[0].Cells["Status_seq"].Value);
            int hist_seq = Convert.ToInt32(dgvDryCar.SelectedRows[0].Cells["Hist_Seq"].Value);

            CartService service = new CartService();
            bool result = service.CarLoadingUnloading(managerid, workOrderNo, target_Gv_Code, origin_Gv_Code, qty, status_seq, hist_seq, "적재");

            if (result)
            {
                WorkOrderService service1 = new WorkOrderService();
                service1.RegLoadPerformance(workOrderNo, managerid, Convert.ToInt32(txtQty.Text));

                LoadDryCarList();
                LoadFireCarList();
                txtLoadQty.Text = "";
            }
            else
            {
                MessageBox.Show("소성대차 로딩에 실패하였습니다.");
            }
        }

        private void frmLoadPerformance_Shown(object sender, EventArgs e)
        {
            LoadDryCarList();
            LoadFireCarList();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void btnFire_Click(object sender, EventArgs e)
        {
            if (txtFire.Text == "")
            {
                dgvFireCar.DataSource = allFireDT;
            }
            else
            {
                DataView dv = new DataView(allFireDT);
                dv.RowFilter = "gv_code LIKE '%" + txtFire.Text + "%'";
                dgvFireCar.DataSource = dv;
            }
        }

        private void dgvDryCar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLoadQty.Text = dgvDryCar.SelectedRows[0].Cells["GV_Rest_Qty"].Value.ToString();
        }

        private void btnDry_Click(object sender, EventArgs e)
        {
            if (txtDry.Text == "")
            {
                dgvDryCar.DataSource = allDryDT;
            }
            else
            {
                DataView dv = new DataView(allDryDT);
                dv.RowFilter = "gv_code LIKE '%" + txtDry.Text + "%'";
                dgvDryCar.DataSource = dv;
            }
        }

        private void txtDry_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnDry.PerformClick();
            }
        }

        private void txtFire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFire.PerformClick();
            }
        }
    }
}
