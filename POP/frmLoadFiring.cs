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
    public partial class frmLoadFiring : Form
    {
        List<POPWorkVO> list;
        string managerid;
        public frmLoadFiring()
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
        /// 적재 작업지시 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateWorkOrder_Click(object sender, EventArgs e)
        {
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmCreateWorkOrder("소성"));
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
        /// 적재실적등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegLoadPer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmLoadPerformance(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString()));
        }
        /// <summary>
        /// 요입/요출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFiring_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmBakePottery(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString()));
        }
        /// <summary>
        /// 대차비우기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVacateCar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmVacateCar(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["wc_code"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["item_code"].Value.ToString()));
        }
        /// <summary>
        /// 공정조건등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegCondition_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmProcessCondition("공정조건 등록", dataGridView1.CurrentRow.Cells[1].Value.ToString()));
        }
        /// <summary>
        /// 품질측정값 등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegPrdQuality_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            string workorderno = dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString();
            //해당 작업지시번호로 등록된 건조대차가 없어야함
            //소성대차가 모두 요출시간이 등록되어있어야함
            CartService service = new CartService();
            int count = service.GetRestDryCarListCount(workorderno);
            if(count > 0)
            {
                MessageBox.Show("해당 작업지시 번호로 등록된 건조대차 중 소성대차로 로딩되지 않은 대차가 존재합니다. 작업을 끝낸 후 등록해주세요.");
                return;
            }

            CartService service1 = new CartService();
            count = service1.GetUnOutCarCount(workorderno);
            if (count > 0)
            {
                MessageBox.Show("해당 작업지시 번호로 등록된 소성대차 중 요출되지 않은 대차가 존재합니다. 작업을 끝낸 후 등록해주세요.");
                return;
            }

            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmProcessCondition("품질 측정값 등록", dataGridView1.CurrentRow.Cells[1].Value.ToString()));
        }
        private void LoadData()
        {
            WorkOrderService service = new WorkOrderService();
            list = service.GetAllWorkODList("소성");
            dataGridView1.DataSource = list;
        }

        private void frmLoadFiring_Load(object sender, EventArgs e)
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

        private void frmLoadFiring_Shown(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.ClearSelection();

            CommonUtil.SetGridColor(dataGridView1);
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
            //공정조건 설정이 안된경우
            SetProcessConditionService service1 = new SetProcessConditionService();
            int count = service1.IsConditionRegister(wc_code, prd_Code, workOrderNo);
            if (count == 0)
            {
                sb.AppendLine("해당 작업지시번호로 등록된 공정조건이 없습니다.");
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

        private void OnProcessButtonColor()
        {
            btnEnd.BackColor = Color.Red;
            btnStart.Enabled = false;
            btnEnd.Enabled = true;
        }
        private void StopProcessButtonColor()
        {
            btnStart.BackColor = Color.ForestGreen;
            btnStart.Enabled = true;
            btnEnd.Enabled = false;

            //wo_State = WO_03로 변경
            string workorderno = dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString();
            string wc_code = dataGridView1.SelectedRows[0].Cells["wc_Code"].Value.ToString();

            UserService uservice = new UserService();
            List<POPWorkerSetVO> list = uservice.GetAllocatedWorkers(wc_code, workorderno);
            WorkOrderService service = new WorkOrderService();
            bool result = service.SetWostate03(workorderno, managerid, "소성", list);

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
        private void SetButtonColor(string text)
        {
            if (text == "작업종료")
            {
                //작업시작 버튼 누르면(생산중): 적재실적등록, 요입요출, 품질측정값등록
                btnRegPrdQuality.BackColor = btnRegLoadPer.BackColor = btnFiring.BackColor =  Color.WhiteSmoke;

                btnRegPrdQuality.Enabled = btnRegLoadPer.Enabled = btnFiring.Enabled = false;

                btnRegCondition.BackColor = btnSetWorker.BackColor = btnClosing.BackColor = Color.FromArgb(255, 207, 135);

                btnRegCondition.Enabled = btnSetWorker.Enabled = btnClosing.Enabled = true;
            }
            else if (text == "작업시작")
            {
                //작업종료버튼누르면(생산중단): 작업자할당, 공정조건등록, 작업지시생성, 현장마감
                btnRegCondition.BackColor = btnSetWorker.BackColor = btnClosing.BackColor = Color.WhiteSmoke;

               btnRegCondition.Enabled = btnSetWorker.Enabled = btnClosing.Enabled = false;

                btnRegPrdQuality.BackColor = btnRegLoadPer.BackColor = btnFiring.BackColor = Color.FromArgb(255, 207, 135);

                btnRegPrdQuality.Enabled = btnRegLoadPer.Enabled = btnFiring.Enabled = true;
            }
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            CartService service = new CartService();
            int count = service.GetRestDryCarListCount(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString());
            if (count > 0)
            {
                MessageBox.Show("해당 작업지시 번호로 등록된 건조대차 중 소성대차로 로딩되지 않은 대차가 존재합니다. 작업을 끝낸 후 종료해주세요.");
                return;
            }

            CartService service1 = new CartService();
            count = service1.GetUnOutCarCount(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString());
            if (count > 0)
            {
                MessageBox.Show("해당 작업지시 번호로 등록된 소성대차 중 요출되지 않은 대차가 존재합니다. 작업을 끝낸 후 등록해주세요.");
                return;
            }

            StopProcessButtonColor();
            CommonUtil.SetGridColor(dataGridView1);
            SetButtonColor("작업종료");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClosing_Click(object sender, EventArgs e)
        {
            //품질측정값 등록되었나 확인
            SetProcessConditionService cservice = new SetProcessConditionService();
            int count = cservice.IsInspectRegisterd(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString());

            if (count != 0)
            {
                string workorderno = dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString();
                string wc_code = dataGridView1.SelectedRows[0].Cells["wc_code"].Value.ToString();
                if (MessageBox.Show($"작업지시번호 [{workorderno}]의 작업을 현장마감 하시겠습니까?", "현장마감확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //해당 작업지시번호 wo_status = wo_03
                    WorkOrderService service = new WorkOrderService();
                    bool result = service.SetClose(workorderno, managerid, wc_code);
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
        }
    }
}
