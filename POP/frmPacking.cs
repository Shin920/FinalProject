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
    public partial class frmPacking : Form
    {
        string managerid;
        List<POPWorkVO> list;
        public frmPacking()
        {
            InitializeComponent();

            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is Button)
                {
                    ((Button)ctrl).MouseEnter += CommonUtil.buttonColorChangeWhenMouseEnter;
                    ((Button)ctrl).MouseLeave += CommonUtil.buttonColorChangeWhenMouseLeave;
                }
            }
        }
        /// <summary>
        /// 작업지시생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateWorkOrder_Click(object sender, EventArgs e)
        {
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmCreateWorkOrder("포장"));
        }
        /// <summary>
        /// 작업자 할당
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetWorker_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmWorkerSet(dataGridView1.SelectedRows[0].Cells["wc_Code"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString()));
        }
        /// <summary>
        /// 팔레트 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePalette_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmCreatePalette(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString()));
        }
        /// <summary>
        /// 팔레트 바코드 재발행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReCreatePalette_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmReCreatePalette(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString()));
        }
        /// <summary>
        /// 입고등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            //품질측정값 등록됐는지 확인
            SetProcessConditionService cservice = new SetProcessConditionService();
            int count = cservice.IsInspectRegisterd(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString());
            if(count == 0)
            {
                MessageBox.Show("품질측정값을 입력한 뒤 시도해주세요.");
                return;
            }

            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmReceive(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString()));
        }
        /// <summary>
        /// 언로딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnloading_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmPackUnloading(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString()));
        }
        /// <summary>
        /// 품질 측정값 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegPrdQuality_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
           //유효성체크
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmProcessCondition("품질 측정값 등록", dataGridView1.CurrentRow.Cells[1].Value.ToString()));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //유효성검사 + 공정조건 등록했는지 확인
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("시작할 작업을 선택해주세요.");
                return;
            }
            string workOrderNo = dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString();
            string prd_Code = dataGridView1.SelectedRows[0].Cells["Item_Code"].Value.ToString();
            string planQty = dataGridView1.SelectedRows[0].Cells["Plan_Qty"].Value.ToString();
            string prd_Name = dataGridView1.SelectedRows[0].Cells["Item_Name"].Value.ToString();
            string prd_Qty = dataGridView1.SelectedRows[0].Cells["prd_Qty"].Value.ToString();
            string wc_code = dataGridView1.SelectedRows[0].Cells["wc_Code"].Value.ToString();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<WARNING>");
            //할당된 작업자가 없는 경우
            UserService service = new UserService();
            List<POPWorkerSetVO> list = service.GetAllocatedWorkers(wc_code, workOrderNo);
            if (list.Count == 0)
            {
                sb.AppendLine("해당 작업지시번호로 할당된 작업자가 없습니다.");
            }
           
            if (sb.Length > 11)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            //작업을 고른 경우
            //생산대기 01 -> 생산중 02 로 바꿔야함
            //작업시작시간 getdate() 로 + 최종수정일자, 최종수정자 도 수정
            //WorkOrderService service = new WorkOrderService();
            //service.UpdateWorkState();

            WorkOrderService wservice = new WorkOrderService();
            bool result = wservice.OrderStart(dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString(), managerid, list);
            if (result)
            {
                dataGridView1.SelectedRows[0].DefaultCellStyle.BackColor = Color.ForestGreen;
                dataGridView1.SelectedRows[0].DefaultCellStyle.ForeColor = Color.White;
                OnProcessButtonColor();
                LoadData();
                SetButtonColor("작업시작");
                CommonUtil.SetGridColor(dataGridView1);
            }
            else
            {
                MessageBox.Show("작업 시작에 실패했습니다.");
            }
        }
        private void SetButtonColor(string text)
        {
            if (text == "작업종료")
            {
                //작업시작 버튼 누르면(생산중): 적재실적등록, 요입요출, 품질측정값등록
                btnClosing.BackColor = btnSetWorker.BackColor = Color.FromArgb(255, 207, 135);

                btnClosing.Enabled = btnSetWorker.Enabled = true;

                btnCreatePalette.BackColor = btnReCreatePalette.BackColor = btnUnloading.BackColor = btnRegPrdQuality.BackColor = Color.WhiteSmoke;

                btnCreatePalette.Enabled = btnReCreatePalette.Enabled = btnUnloading.Enabled = btnRegPrdQuality.Enabled = true;
            }
            else if (text == "작업시작")
            {
                //작업시작 버튼 누르면
                btnClosing.BackColor  = btnSetWorker.BackColor = Color.WhiteSmoke;

                btnClosing.Enabled  = btnSetWorker.Enabled = false;

                btnCreatePalette.BackColor = btnReCreatePalette.BackColor = btnUnloading.BackColor = btnRegPrdQuality.BackColor = Color.FromArgb(255, 207, 135);

                btnCreatePalette.Enabled = btnReCreatePalette.Enabled = btnUnloading.Enabled = btnRegPrdQuality.Enabled = true;
            }
        }
        private void OnProcessButtonColor()
        {
            btnEnd.BackColor = Color.Red;
            btnStart.Enabled = false;
            btnEnd.Enabled = true;
        }

        private void btnClosing_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            //[연] [오전 1:03] 현장마감처리할때 고려할점 > 작업지시번호로 등록된 소성대차에 잔여수량이 있는지
            PackService service = new PackService();
            int fCount = service.IsFireCarExist(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString());
            if (fCount != 0)
            {
                MessageBox.Show("해당 작업지시번호로 완전히 언로딩 되지 않은 소성대차가 존재합니다. 소성대차 언로딩 후 다시 시도해주세요.");
                return;
            }
            //[연] [오전 1:03] 작업지시번호로 할당된 팔레트가 모두 입고처리됐는지

            int pCount = service.IsPalletDone(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString());
            if(pCount != 0)
            {
                MessageBox.Show("해당 작업지시번호로 완전히 입고처리 되지 않은 팔레트가 존재합니다. 팔레트 입고처리 후 다시 시도해주세요.");
                return;
            }

            string workorderno = dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString();
            string wc_code = dataGridView1.SelectedRows[0].Cells["wc_code"].Value.ToString();
            if (MessageBox.Show($"작업지시번호 [{workorderno}]의 작업을 현장마감 하시겠습니까?", "현장마감확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //해당 작업지시번호 wo_status = wo_03
                WorkOrderService wservice = new WorkOrderService();
                bool result = wservice.SetClose(workorderno, managerid, wc_code);
                if (result)
                {
                    LoadData();
                    CommonUtil.SetGridColor(dataGridView1);
                }
                else
                {
                    MessageBox.Show("현장마감 처리에 실패하였습니다.");
                }
            }
        }

        private void frmPacking_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();

            CommonUtil.SetInitGridView(dataGridView1);
            //w.Workorderno, Wo_Status, w.Item_Code, i.Item_Name, i.Item_Unit, w.Plan_Qty, w.Prd_Qty, w.Prd_Starttime, w.Prd_Endtime, ed.Up_Date
            CommonUtil.AddGridTextColumn(dataGridView1, "상태", "Userdefine_Mi_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "Workorderno");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목코드", "Item_Code");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목명", "Item_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "단위", "Item_Unit");
            CommonUtil.AddGridTextColumn(dataGridView1, "계획수량", "Plan_Qty");
            CommonUtil.AddGridTextColumn(dataGridView1, "실적수량", "Prd_Qty");
            CommonUtil.AddGridTextColumn(dataGridView1, "생산시작시간", "Prd_Starttime");
            CommonUtil.AddGridTextColumn(dataGridView1, "생산종료시간", "Prd_Endtime");
            CommonUtil.AddGridTextColumn(dataGridView1, "작업장코드", "wc_Code", visibility
              : false);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업순서", "wo_Order", visibility
                : false);
            CommonUtil.AddGridTextColumn(dataGridView1, "시간당생산량", "PrdQty_Per_Hour", visibility
              : false);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시수량", "Temp_Prd_Qty", visibility
              : false);

            CommonUtil.SetGridViewFontSize(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            CommonUtil.SetGridWidth(dataGridView1, "Item_Unit", 50);
            CommonUtil.SetGridWidth(dataGridView1, "Plan_Qty", 65);
            CommonUtil.SetGridWidth(dataGridView1, "Prd_Qty", 65);
            CommonUtil.SetGridWidth(dataGridView1, "Userdefine_Mi_Name", 65);
            CommonUtil.SetGridWidth(dataGridView1, "Item_Code", 65);
            CommonUtil.SetGridWidth(dataGridView1, "Item_Name", 80);
            CommonUtil.SetGridWidth(dataGridView1, "Workorderno", 110);
            CommonUtil.SetGridWidth(dataGridView1, "Prd_Starttime", 120);
            CommonUtil.SetGridWidth(dataGridView1, "Prd_Endtime", 120);
        }

        private void frmPacking_Shown(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.ClearSelection();

            CommonUtil.SetGridColor(dataGridView1);
        }

        private void LoadData()
        {
            WorkOrderService service = new WorkOrderService();
            list = service.GetAllWorkODList("포장");
            dataGridView1.DataSource = list;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            btnStart.BackColor = Color.ForestGreen;
            btnStart.Enabled = true;
            btnEnd.Enabled = false;

            //wo_State = WO_03로 변경
            string workorderno = dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString();
            string wc_code = dataGridView1.SelectedRows[0].Cells["wc_Code"].Value.ToString();

            UserService uservice = new UserService();
            List<POPWorkerSetVO> list = uservice.GetAllocatedWorkers(wc_code, workorderno);
            WorkOrderService service = new WorkOrderService();
            bool result = service.SetWostate03(workorderno, managerid, "포장", list);

            if (result)
            {
                LoadData();
                CommonUtil.SetGridColor(dataGridView1);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "생산대기")
            {
                btnStart.BackColor = Color.ForestGreen;
                btnEnd.BackColor = Color.Red;
                btnStart.Enabled = true;
                btnEnd.Enabled = false;
                SetButtonColor("작업종료");
            }
            else if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "생산중")
            {
                SetButtonColor("작업시작");
                OnProcessButtonColor();

            }
            else if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "생산중지")
            {
                btnStart.BackColor = Color.ForestGreen;
                btnEnd.BackColor = Color.Red;
                btnStart.Enabled = true;
                btnEnd.Enabled = false;
                SetButtonColor("작업종료");
            }
        }
    }
}
