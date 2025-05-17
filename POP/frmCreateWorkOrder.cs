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
    public partial class frmCreateWorkOrder : Form
    {
        string managerid;
        string unit = "EA";
        string inputCase;
        DataTable loadedCarDT;
        public frmCreateWorkOrder(string inputcase)
        {
            InitializeComponent();
            inputCase = inputcase;

        }

        private void frmCreateWorkOrder_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();

            CommonUtil.SetInitGridView(dataGridView1);
            //select Status_Seq, gv_name, gc.gv_code, gv_qty , gc.workorderno , w.item_code, item_name, item_unit, Wo_Req_No, Req_Seq
            CommonUtil.AddGridTextColumn(dataGridView1, "순번", "Status_Seq");
            CommonUtil.AddGridTextColumn(dataGridView1, "건조대차", "gv_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "대차코드", "gv_code");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목코드", "item_code");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목명", "item_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "수량", "gv_rest_qty");
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "workorderno", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "단위", "item_unit", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "생산의뢰번호", "Wo_Req_No", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "의뢰순번", "Req_Seq", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "의뢰순번", "Line_Per_Qty", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "의뢰순번", "Shot_Per_Qty", visibility: false);
            CommonUtil.SetGridViewFontSize(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //공정이랑 작업장 목록 불러와야함
        }
        public void LoadData()
        {
            WorkOrderService service = new WorkOrderService();
            var list = service.GetLoadedCarList(inputCase);
            dataGridView1.DataSource = list;
            loadedCarDT = CommonUtil.ToDataTable(list);
        }

        private void frmCreateWorkOrder_Shown(object sender, EventArgs e)
        {
            CartService service = new CartService();
            List<WorkCenterVO> list = service.GetCenterList(inputCase);

            cboWorkCenter.DisplayMember = "wc_name";
            cboWorkCenter.ValueMember = "wc_code";
            cboWorkCenter.DataSource = list;

            List<ProcessVO> list1 = service.GetProcessList(inputCase);

            cboProcess.DisplayMember = "process_name";
            cboProcess.ValueMember = "process_code";
            cboProcess.DataSource = list1;

            LoadData();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            //품목 계획수량을 그리드뷰에서 가져오기
            //"품목코드", "item_code"/"품목명", "item_name"/"수량", "gv_qty"
            txtPrdName.Text = dataGridView1.SelectedRows[0].Cells["item_name"].Value.ToString();
            txtPrdName.Tag = dataGridView1.SelectedRows[0].Cells["item_code"].Value.ToString();
            txtQty.Text = dataGridView1.SelectedRows[0].Cells["gv_rest_qty"].Value.ToString();
            txtDate.Text = DateTime.Now.ToString();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(txtPrdName.Text.Length == 0)
            {
                MessageBox.Show("작업지시를 생성할 대차를 선택해주세요.");
                return;
            }
            else if(Convert.ToInt32(txtQty.Text) > Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["gv_rest_qty"].Value))
            {
                MessageBox.Show("제대로된 수량을 입력해주세요.");
                return;
            }

            string newOrderno = "WK" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string oldOrderno = dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString();
            string item_code = txtPrdName.Tag.ToString();
            string wc_code = cboWorkCenter.SelectedValue.ToString();
            int qty = Convert.ToInt32(txtQty.Text);
            //string unit = dataGridView1.SelectedRows[0].Cells["item_unit"].Value.ToString();
            string managerid = this.managerid;
            string process_code = cboProcess.SelectedValue.ToString();
            string date = txtDate.Text;
            int Status_Seq = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Status_Seq"].Value);
            string gv_code = dataGridView1.SelectedRows[0].Cells["gv_code"].Value.ToString();

            WorkOrderService service = new WorkOrderService();
            bool result = service.CreateWorkOrder(newOrderno, oldOrderno, item_code, wc_code, qty, unit, managerid, process_code, date, Status_Seq, gv_code, inputCase);
            if (result)
            {
                MessageBox.Show("작업지시가 생성되었습니다.");
                LoadData();

            }
            else
            {
                MessageBox.Show("작업지시 생성에 실패하였습니다.");
            }
        }
        public void ResetTextBox()
        {
            txtDate.Text = txtPrdName.Text = txtQty.Text = "";
            cboProcess.SelectedIndex = cboWorkCenter.SelectedIndex = 0;
            dataGridView1.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCarS.Text == "")
            {
                dataGridView1.DataSource = loadedCarDT;
            }
            else
            {
                DataView dv = new DataView(loadedCarDT);
                dv.RowFilter = "gv_code LIKE '%" + txtCarS.Text + "%'";
                dataGridView1.DataSource = dv;
            }
        }
    }
}
