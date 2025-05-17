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
    public partial class frmProductCar : Form
    {
        string WorkOrderNO;
        string itemCode;
        string managerid;
        DataTable allDryDT;
        DataTable allFromDT;
        public frmProductCar(string workorderno, string itemcode)
        {
            InitializeComponent();
            this.WorkOrderNO = workorderno;
            this.itemCode = itemcode;
        }
        private void frmProductCar_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();
            //작업지시 데이터 가져오기
            //작업지시번호, 품목명, 작업지시일, 작업장, 실적수량, 단위
            WorkOrderService service = new WorkOrderService();
            POPWorkVO wo = service.GetWorkOrderDetail(WorkOrderNO);
            txtWorkNO.Text = wo.Workorderno;
            txtWorkPlace.Text = wo.wc_Name;
            txtWorkPlace.Tag = wo.wc_Code;
            txtWorkDate.Text = wo.Plan_Date.ToString("yyyy-MM-dd");
            txtUnit.Text = wo.Item_Unit;
            txtQty.Text = wo.Prd_Qty.ToString();
            txtProd.Text = wo.Item_Name;
            txtProd.Tag = wo.Item_Code;
            itemCode = wo.Item_Code;

            CommonUtil.SetInitGridView(dgvDryCar);
            //select gv_code, gv_name 
            CommonUtil.AddGridTextColumn(dgvDryCar, "건조대차코드", "gv_code");
            CommonUtil.AddGridTextColumn(dgvDryCar, "건조대차명", "gv_name");

            CommonUtil.SetGridViewFontSize(dgvDryCar);
            dgvDryCar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDryCar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            CommonUtil.SetInitGridView(dgvFormingCar);
            //select gc.gv_code, gv_name, loading_time, gv_qty, workorderno 
            CommonUtil.AddGridTextColumn(dgvFormingCar, "성형대차코드", "gv_code");
            CommonUtil.AddGridTextColumn(dgvFormingCar, "성형대차명", "gv_name");
            CommonUtil.AddGridTextColumn(dgvFormingCar, "적재시각", "loading_time");
            CommonUtil.AddGridTextColumn(dgvFormingCar, "수량", "GV_Rest_Qty");
            CommonUtil.AddGridTextColumn(dgvFormingCar, "작업지시번호", "workorderno", visibility: false);
            CommonUtil.AddGridTextColumn(dgvFormingCar, "현황순번", "Status_Seq", visibility: false);
            CommonUtil.AddGridTextColumn(dgvFormingCar, "대차이력순번", "Hist_Seq", visibility: false);


            CommonUtil.SetGridViewFontSize(dgvFormingCar);
            dgvFormingCar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFormingCar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 작업해야하는 열을 검색합니다.
            CommonUtil.SetGridWidth(dgvFormingCar, "loading_time", 200);
        }
        public void LoadDryCarList()
        {
            CartService service = new CartService();
            List<CartVO> list = service.GetTargetCarList("건조");
            dgvDryCar.DataSource = list;
            allDryDT = CommonUtil.ToDataTable(list);
        }
        public void LoadFormingCarList()
        {
            CartService service = new CartService();
            List<CartVO> list = service.GetOriginCarList(WorkOrderNO, "성형");
            dgvFormingCar.DataSource = list;
            allFromDT = CommonUtil.ToDataTable(list);
        }

        private void frmProductCar_Shown(object sender, EventArgs e)
        {
            LoadDryCarList();
            LoadFormingCarList();
        }

        private void btnLoading_Click(object sender, EventArgs e)
        {
            if (dgvDryCar.SelectedRows.Count == 0 || dgvFormingCar.SelectedRows.Count == 0 || txtLoadQty.Text.Trim().Length == 0 || Convert.ToInt32(txtLoadQty.Text) > Convert.ToInt32(dgvFormingCar.SelectedRows[0].Cells["GV_Rest_Qty"].Value))
            {
                MessageBox.Show("성형대차, 건조대차, 수량을 제대로 입력해주세요.");
                return;
            }

            string originCar = dgvFormingCar.SelectedRows[0].Cells["gv_code"].Value.ToString();
            string targetCar = dgvDryCar.SelectedRows[0].Cells["gv_code"].Value.ToString();

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
            string workOrderNo = dgvFormingCar.SelectedRows[0].Cells["workorderno"].Value.ToString();
            string dry_Gv_Code = dgvDryCar.SelectedRows[0].Cells["gv_code"].Value.ToString();
            string origin_Gv_Code = dgvFormingCar.SelectedRows[0].Cells["gv_code"].Value.ToString();
            int qty = Convert.ToInt32(txtLoadQty.Text);
            int status_seq = Convert.ToInt32(dgvFormingCar.SelectedRows[0].Cells["Status_seq"].Value);
            int hist_seq = Convert.ToInt32(dgvFormingCar.SelectedRows[0].Cells["Hist_Seq"].Value);

            CartService service = new CartService();
            bool result = service.CarLoadingUnloading(managerid, workOrderNo, dry_Gv_Code, origin_Gv_Code, qty, status_seq, hist_seq, "성형");
            if (result)
            {
                LoadDryCarList();
                LoadFormingCarList();
                txtLoadQty.Text = "";
            }
            else
            {
                MessageBox.Show("건조대차 로딩에 실패하였습니다.");
            }
        }

        private void dgvFormingCar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLoadQty.Text = dgvFormingCar.SelectedRows[0].Cells["GV_Rest_Qty"].Value.ToString();
        }

        private void brnForm_Click(object sender, EventArgs e)
        {
            if (txtFormingCarS.Text == "")
            {
                dgvFormingCar.DataSource = allFromDT;
            }
            else
            {
                DataView dv = new DataView(allFromDT);
                dv.RowFilter = "gv_code LIKE '%" + txtFormingCarS.Text + "%'";
                dgvFormingCar.DataSource = dv;
            }
        }


        private void txtFormingCarS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnForm.PerformClick();
            }
        }

        private void txtDryCarS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDry.PerformClick();
            }
        }

        private void btnDry_Click(object sender, EventArgs e)
        {
            if (txtDryCarS.Text == "")
            {
                dgvDryCar.DataSource = allDryDT;
            }
            else
            {
                DataView dv = new DataView(allDryDT);
                dv.RowFilter = "gv_code LIKE '%" + txtDryCarS.Text + "%'";
                dgvDryCar.DataSource = dv;
            }
        }
    }
}
