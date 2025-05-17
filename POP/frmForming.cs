using ClassLibrary1;
using FinalProjectVO;
using POP.Controls;
using POP.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP
{

    public partial class frmForming : Form
    {

        List<POPWorkVO> list;
        string managerid;
        public string prdQty;
        public string GV_Code;
        int MadePrdQty;
        public string goodQty;
        public string badQty;

        //string workOrderNum;
        string machineName;
        MachineButton btn;
        frmMachineTask frm;
        int process_ID;
        //public bool IsTaskEnable    //가동중인지
        //{
        //    get
        //    {
        //        return btnStop.Enabled;
        //    }
        //    set
        //    {
        //        {
        //            btnStart.Enabled = !value;  //***value가 넘어오는데 true/false로 넘어오기때문에 if/else를 이렇게 줄일수있다.
        //            btnStop.Enabled = value;
        //            btnShow.Enabled = value;
        //        }

        //    }
        //}

        public frmForming()
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

        // 각 버튼 누를때 필요한것 => 태그에 frmForming/frmxx 식으로 누적?
        private void frmForming_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();

            CommonUtil.SetInitGridView(dataGridView1);
            //w.Workorderno, Wo_Status, w.Item_Code, i.Item_Name, i.Item_Unit, w.Plan_Qty, w.Prd_Qty, w.Prd_Starttime, w.Prd_Endtime, ed.Up_Date
            CommonUtil.AddGridTextColumn(dataGridView1, "상태", "Userdefine_Mi_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "Workorderno");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목코드", "Item_Code");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목명", "Item_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "단위", "Item_Unit", colWidth: 500);
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
            CommonUtil.AddGridTextColumn(dataGridView1, "최신대차코드", "gv_code", visibility
           : false);
            CommonUtil.AddGridTextColumn(dataGridView1, "hist_seq", "hist_seq", visibility
           : false);
            CommonUtil.AddGridTextColumn(dataGridView1, "시간당생산량", "bad_prd_qty", visibility
           : false);
            CommonUtil.AddGridTextColumn(dataGridView1, "시간당생산량", "good_prd_qty", visibility
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
        /// <summary>
        /// 데이터 그리드뷰에 정보 바인딩
        /// </summary>
        public void LoadData()
        {
            WorkOrderService service = new WorkOrderService();
            list = service.GetAllWorkODList("성형");
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    dataGridView1.DataSource = list;
                }));
            }
            else
            {
                dataGridView1.DataSource = list;
            }
            CommonUtil.SetGridColor(dataGridView1);
        }

        /// <summary>
        /// 현장마감 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClosing_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            string workorderno = dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString();
            string wc_code = dataGridView1.SelectedRows[0].Cells["wc_code"].Value.ToString();
            //wo_order가 3인지 확인(건조대차에 적재가 모두 다 완료된것) + 품질수치 등록되어있는지
            SetProcessConditionService cservice = new SetProcessConditionService();
            int count = cservice.IsInspectRegisterd(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString());
            
            WorkOrderService wservice = new WorkOrderService();
            LoadData();
            CommonUtil.SetGridColor(dataGridView1);
            bool result1 = wservice.SetWoOrder3(workorderno, managerid);
            if (result1 && count != 0)
            {
                
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

        /// <summary>
        /// 건조대차 로딩 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDryCarLoading_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmProductCar(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["item_code"].Value.ToString()));
        }
        /// <summary>
        /// 작업자 할당
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetWorker_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            //그리드뷰 11번이 작업장코드
            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmWorkerSet(dataGridView1.CurrentRow.Cells["wc_code"].Value.ToString(), dataGridView1.CurrentRow.Cells["workorderno"].Value.ToString()));
        }
        /// <summary>
        /// 금형장착/탈착
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetMold_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmFrameSet(dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString()));
        }
        /// <summary>
        /// 공정조건등록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegCondition_Click(object sender, EventArgs e)
        {
            //유효성검사
            if (dataGridView1.CurrentRow.Index < 0)
                return;

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
            //유효성검사
            if (dataGridView1.SelectedRows.Count < 1)
                return;
            //해당 작업지시번호로 등록된 성형대차가 남아있는지 + 건조대차 수량이 계획수량과 같은지
            //wo_order가 3인지 확인(건조대차에 적재가 모두 다 완료된것)
            if(dataGridView1.SelectedRows[0].Cells["wo_Order"].Value.ToString() != "3")
            {
                MessageBox.Show("해당 작업지시번호로 적재된 성형대차가 존재재하거나, 계획 수량과 맞지 않습니다. 생산 완료 이후에 시도해주세요.");
                return;
            }

            this.MdiParent.Text += '/' + this.Name;
            Form1 frm = (Form1)this.MdiParent;
            frm.openChildForm(new frmProcessCondition("품질 측정값 등록", dataGridView1.CurrentRow.Cells[1].Value.ToString()));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedRows[0].Index < 0) return;
            if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "생산대기")
            {
                btnStart.BackColor = Color.ForestGreen;
                btnEnd.BackColor = Color.WhiteSmoke;
                btnMachine.BackColor = Color.WhiteSmoke;
                btnStart.Enabled = true;
                btnEnd.Enabled = false;
                SetButtonColor("기계 시작");
                OnProcessButtonColor("생산대기");
                btnMachine.Enabled = false;
                btnMachine.BackColor = Color.WhiteSmoke;
                progressBar1.Value = 0;
            }
            else if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "생산중")
            {
                OnProcessButtonColor("생산중");
                //Wo_Order
                if (dataGridView1.SelectedRows[0].Cells["wo_Order"].Value.ToString() == "2" || dataGridView1.SelectedRows[0].Cells["wo_Order"].Value.ToString() == "7")
                {
                    SetButtonColor("기계 종료");
                    int Temp_Prd_Qty = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Temp_Prd_Qty"].Value);
                    progressBar1.Maximum = Temp_Prd_Qty;

                    WorkOrderService service = new WorkOrderService();
                    int prd_Qty = service.GetPrdQty(dataGridView1.SelectedRows[0].Cells["workorderno"].Value.ToString());

                    progressBar1.Value = prd_Qty;
                    progressBar1.DisplayStyle = POP.Controls.ProgressBarDisplayText.CustomText;
                    progressBar1.CustomText = $"{prd_Qty} / {Temp_Prd_Qty}";

                }
                else
                {
                    SetButtonColor("기계 시작");

                    progressBar1.Value = 0;
                    progressBar1.CustomText = null;

                }
            }
            else if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "생산중지")
            {
                SetButtonColor("기계 시작");
                OnProcessButtonColor("생산대기");
                progressBar1.Value = 0;
            }
        }

        private void StopProcessButtonColor()
        {
            btnStart.BackColor = Color.ForestGreen;
            //btnEnd.BackColor = Color.Gray;
            //btnMachine.BackColor = Color.Gray;
            btnStart.Enabled = true;
            btnEnd.Enabled = false;
            btnMachine.Enabled = false;


            //wo_State = WO_03로 변경
            string workorderno = dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString();
            string wc_code = dataGridView1.SelectedRows[0].Cells["wc_Code"].Value.ToString();

            UserService uservice = new UserService();
            List<POPWorkerSetVO> list = uservice.GetAllocatedWorkers(wc_code, workorderno);

            WorkOrderService service = new WorkOrderService();

            bool result = service.SetWostate03(workorderno, managerid, "성형", list);

            if (result)
            {
                LoadData();
                CommonUtil.SetGridColor(dataGridView1);
            }
        }

        private void OnProcessButtonColor(string inputCase)
        {
            if (inputCase == "생산대기")
            {
                btnEnd.BackColor = Color.Red;
                btnStart.Enabled = true;
                btnEnd.Enabled = false;
                btnMachine.Enabled = false;

                btnMachine.BackColor = btnRegPrdQuality.BackColor = Color.WhiteSmoke;

                btnClosing.BackColor = btnSetWorker.BackColor = btnSetMold.BackColor = btnRegCondition.BackColor = Color.FromArgb(255, 207, 135);

                btnMachine.Enabled = btnRegPrdQuality.Enabled = false;

                btnClosing.Enabled = btnSetWorker.Enabled = btnSetMold.Enabled = btnRegCondition.Enabled =  true;
            }
            else if (inputCase == "생산중")
            {
                btnEnd.BackColor = Color.Red;
      
                btnStart.Enabled = false;
                btnEnd.Enabled = true;

                btnMachine.BackColor = btnRegPrdQuality.BackColor = Color.FromArgb(255, 207, 135);

                btnClosing.BackColor = btnSetWorker.BackColor = btnSetMold.BackColor = btnRegCondition.BackColor = Color.WhiteSmoke;

                btnMachine.Enabled = btnRegPrdQuality.Enabled = true;

                btnClosing.Enabled = btnSetWorker.Enabled = btnSetMold.Enabled = btnRegCondition.Enabled = false;

            }
            //btnStart.BackColor = Color.Gray;

        }

        private void frmForming_Shown(object sender, EventArgs e)
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
            UserService uservice = new UserService();
            List<POPWorkerSetVO> list = uservice.GetAllocatedWorkers(wc_code, workOrderNo);
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
            //금형등록 안된경우
            MoldService service2 = new MoldService();
            int moldCount = service2.IsMoldSetted(workOrderNo);
            if (moldCount == 0)
            {
                sb.AppendLine("해당 작업지시번호로 등록된 금형이 없습니다.");
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

            WorkOrderService service = new WorkOrderService();
            bool result = service.OrderStart(dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString(), managerid, list);
            if (result)
            {
                dataGridView1.SelectedRows[0].DefaultCellStyle.BackColor = Color.ForestGreen;
                dataGridView1.SelectedRows[0].DefaultCellStyle.ForeColor = Color.White;
                OnProcessButtonColor("생산중");
                LoadData();
                CommonUtil.SetGridColor(dataGridView1);
            }
            else
            {
                MessageBox.Show("작업 시작에 실패했습니다.");
            }
        }
        /// <summary>
        /// 기계 시작/종료버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMachine_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "생산대기" || dataGridView1.SelectedRows[0].Cells[0].Value.ToString() == "생산중지") return;

            //넘겨야하는거: 작업지시번호, 계획수량, 품목코드, 품목명
            string workOrderNo = dataGridView1.SelectedRows[0].Cells["Workorderno"].Value.ToString();
            string prd_Code = dataGridView1.SelectedRows[0].Cells["Item_Code"].Value.ToString();
            string planQty = dataGridView1.SelectedRows[0].Cells["Plan_Qty"].Value.ToString();
            string prd_Name = dataGridView1.SelectedRows[0].Cells["Item_Name"].Value.ToString();
            string prd_Qty = dataGridView1.SelectedRows[0].Cells["prd_Qty"].Value.ToString();
            string wc_code = dataGridView1.SelectedRows[0].Cells["wc_Code"].Value.ToString();
            string gv_code = "";
            if (dataGridView1.SelectedRows[0].Cells["gv_code"].Value != null)
            {
                gv_code = dataGridView1.SelectedRows[0].Cells["gv_code"].Value.ToString();
            }
            string item_code = dataGridView1.SelectedRows[0].Cells["item_code"].Value.ToString();
            long hist_seq = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["hist_seq"].Value);

            int Prd_Qty = 0;
            if (btnMachine.Text == "기계 시작")
            {
                PrdQtyPopUp frm = new PrdQtyPopUp(workOrderNo, planQty, prd_Code, prd_Name, 1, managerid, prd_Qty, gv_code, hist_seq, wc_code, item_code);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Owner = this;

                frm.cntEvent += delegate (object s, CntEventArgs a)
                {
                    Prd_Qty = a.Prd_Cnt;
                };

            if (frm.ShowDialog() == DialogResult.OK)
                {
                    //패널에 기계이름으 바인딩해서 동적생성. 지금 만들어놓은 사이즈에 깔끔하게 4개정도 들어갈 사이즈로 버튼 사이즈 지정하자


                    //등록한 기계정보 만큼 버튼생성

                    //근데 taskID랑 DB의 작업지시에 사용중에 있는 거랑 같은애는 버튼 enabled = false;
                    MachineService service = new MachineService();
                    List<WorkOrderVO> mList = service.GetUsingMachine();

                    List<taskItem> tasks = ConfigurationManager.GetSection("taskList") as List<taskItem>;
                    

                        int cnt = (int)Math.Ceiling(tasks.Count / 2.0);

                        int idx = 1;
                    for (int r = 0; r < cnt; r++)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (idx > tasks.Count)
                                break;

                            btn = new MachineButton(workOrderNo, Prd_Qty);   //(50, 2)정도 여유를 줄 생각, 그러면 그 다음은 (20, 2+35) 35는 컨트롤의 y사이즈
                                                         //btn.Name = $"taskControl{i}";
                            btn.Name = tasks[idx - 1].taskID;

                            btn.Location = new Point(40 + (165 * i), 10 + (60 * r));
                            btn.Size = new Size(150, 50);
                            //btn.Anchor = AnchorStyles.Right;
                            //그리고 기계가 많아서 컨트롤이 많아질때를 생각해서 패널의 오토스크롤을 true로 해놓자

                            btn.Task_ID = tasks[idx - 1].taskID;
                            btn.Task_IP = tasks[idx - 1].hostIP;
                            btn.Task_Port = tasks[idx - 1].hostPort;
                            btn.Task_Remark = tasks[idx - 1].remark;

                            btn.Font = new Font("맑은 고딕", 27, FontStyle.Bold);
                            btn.BackColor = Color.SandyBrown;

                            /*btn.IsTaskEnable = false;*/  //처음에는 모든 가동이 실행중이지 않다. 그래서 시작버튼만 가능하게

                            pnlMachineButtonList.Controls.Add(btn);

                            foreach (WorkOrderVO wv in mList)
                            {
                                if (wv.Using_Machine == btn.Name)
                                {
                                    btn.btnForeColor = Color.Silver;    //근데 enable을 false로 하면 버튼 색이 안먹는다. enable지우고 하면 잘된다. 그냥 색깔은 없는걸로
                                    btn.Enabled = false;

                                }
                            }

                            idx++;
                            btn.macEvent += Btn_macEvent;
                        }

                    }
                       
                    
                    pnlMachineButtonList.Visible = true;

                    //생산수량 정해줌 => 프로그레스바 시작
                    //프로그레스바 maxvalue = 넘어온 생산수량 => 이걸100%
                    //작업지시의 생산 시작시간 update해서 이거+수량에따른 시간 계산

                    progressBar1.Value = 0;
                    progressBar1.Maximum = Convert.ToInt32(prdQty);
                    //제품품목코드로 시간당 생산수량 읽어와서 계산?

                    //직업순번 2번으로 변경, 작업시작시간 업데이트, 최종수정일자, 최종수정자 업데이트, Temp_Prd_Qty에 수량 등록
                    // 투입수량(투입수량은 기계종료할때 입력)
                    WorkOrderService service3 = new WorkOrderService();
                    bool result = service3.StartMachine(workOrderNo, managerid, Convert.ToInt32(prdQty), GV_Code);
                    if (result)
                    {
                        //기계에 시작하는 이벤트 등록
                        //DoOrder order = new DoOrder();
                        //decimal PrdQty_Per_Hour = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["PrdQty_Per_Hour"].Value);

                        //order.StartMachine(workOrderNo, Convert.ToInt32(prdQty), (int)decimal.Round(PrdQty_Per_Hour));
                        //order.StartMachineEvent += Order_StartMachineEvent;

                        SetButtonColor("기계 종료");
                        LoadData();
                        CommonUtil.SetGridColor(dataGridView1);
                    }
                    else
                    {
                        MessageBox.Show("기계 시작에 실패했습니다.");
                    }
                }


            }
            else if (btnMachine.Text == "기계 종료")
            {
                pnlMachineButtonList.Visible = false;

                int good_Prd_Qty = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["good_Prd_Qty"].Value);
                int bad_prd_Qty = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["bad_prd_Qty"].Value);
                int totPrdQty = good_Prd_Qty + bad_prd_Qty;

                PrdQtyPopUp frm2 = new PrdQtyPopUp(workOrderNo, totPrdQty.ToString(), prd_Code, prd_Name, 2, managerid, totPrdQty.ToString(), gv_code, hist_seq, wc_code, item_code, good_Prd_Qty, bad_prd_Qty);
                frm2.StartPosition = FormStartPosition.CenterScreen;
                frm2.Owner = this;
                if (frm2.ShowDialog() == DialogResult.OK)
                {
                    if (frm2.BadQtyY)
                    {
                        //불량품 있는 경우 불량사유 등록하는거
                        frmRegBadReason frm1 = new frmRegBadReason(workOrderNo, managerid, Convert.ToInt32(badQty));
                        frm1.StartPosition = FormStartPosition.CenterScreen;
                        frm1.Owner = this;
                        if(frm1.ShowDialog() == DialogResult.OK)
                        {
                            progressBar1.Value = 0;
                            SetButtonColor("기계 시작");
                            LoadData();
                            CommonUtil.SetGridColor(dataGridView1);
                        }
                        
                    }
                    progressBar1.Value = 0;
                    SetButtonColor("기계 시작");
                    LoadData();
                    CommonUtil.SetGridColor(dataGridView1);

                    if(frm != null)
                    {
                        frm.TaskExit = true;
                        frm.Close();
                    }
                   

                    //IsTaskEnable = false;

                    //프로세스 중지(설비 중지)
                    //프로세스ID를 기준으로 Kill을 한다
                    
                    foreach (Process pro in Process.GetProcesses())       //GetProcesses는 지금 실행중인 프로세스를 다 가져오고 GetProcessesbyID는 id를 내가 알때
                    {
                        if (pro.Id == 0) return;
                        if (pro.Id.Equals(process_ID))
                        {
                            pro.Kill();
                            break;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("기계 종료에 실패했습니다.");
                }
            }
        }

        private void Btn_macEvent(object sender, MacEventArgs e)
        {
            //기계를 선택하면 DB에 작업지시번호에 기계명 업데이트
            //그리고 서버와 통신해서 기계 가동
            //string macName = "";
            //foreach (Control ctrl in pnlMachineButtonList.Controls)
            //{
            //    if (ctrl.GetType() == typeof(MachineButton))
            //    {
            //        if (ctrl == (MachineButton)sender)
            //            macName = ctrl.Name;
            //    }
            //}
            MachineService service = new MachineService();
            bool result = service.InsertUsingMachine(e.MacName, dataGridView1.CurrentRow.Cells[1].Value.ToString());

            frm = e.frm;

            if (result)
            {
                MessageBox.Show("기계가 가동됩니다.");
                //machineName = null;
                pnlMachineButtonList.Visible = false;

            }

            else
            {
                MessageBox.Show("기계 가동에 실패하였습니다.\n다시 시도하여 주십시오.");
                //machineName = null;
                pnlMachineButtonList.Visible = false;
            }
        }

        private void SetButtonColor(string text)
        {
            if (text == "기계 종료")
            {
                btnMachine.Text = text;
            }
            else if (text == "기계 시작")
            {
                btnMachine.Text = text;
            }
        }

        private void Order_StartMachineEvent(object sender, EventArgs e)
        {
            //콘솔에서 실행 어떻게
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (btnMachine.Text == "기계 종료")
            {
                MessageBox.Show("기계를 종료한 뒤 선택해주세요");
                return;
            }
            StopProcessButtonColor();
            SetButtonColor("작업종료");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) 
        {
            if (frm != null) 
                 frm.Show();
        }
    }

   
}
