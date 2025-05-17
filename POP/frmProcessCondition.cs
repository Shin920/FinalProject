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
    public partial class frmProcessCondition : Form
    {
        string WorkOrderNO;
        string itemCode;
        string managerid;
        public frmProcessCondition()
        {
            InitializeComponent();
        }
        public frmProcessCondition(string text, string WorkNO)
        {
            InitializeComponent();
            this.Text = text;
            txtWorkNO.Text = WorkOrderNO = WorkNO;
        }


        private void frmProcessCondition_Load(object sender, EventArgs e)
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

            if (this.Text == "공정조건 등록")
            {
                //공정조건 등록 버튼 눌러서 들어온 경우
                //측정항목(조건항목명?), 기준값, 상한값, 하한값

                //select  Condition_Code, Condition_Name, SL, USL, LSL, Process_code  where Item_Code = @item_code and Wc_Code = @wc_code

     
                CommonUtil.SetInitGridView(dgv1);
                CommonUtil.AddGridTextColumn(dgv1, "측정항목코드", "Condition_Code", visibility: false);
                CommonUtil.AddGridTextColumn(dgv1, "측정항목", "Condition_Name");
                CommonUtil.AddGridTextColumn(dgv1, "공정코드", "Process_code", visibility: false);
                CommonUtil.AddGridTextColumn(dgv1, "USL", "USL");
                CommonUtil.AddGridTextColumn(dgv1, "SL", "SL");
                CommonUtil.AddGridTextColumn(dgv1, "LSL", "LSL");
                CommonUtil.SetGridViewFontSize(dgv1);
                ProcessConditionList(wo);
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                CommonUtil.SetGridViewFontSize(dgv1,25);
                CommonUtil.SetGridWidth(dgv1, "Condition_Name", 150);

                //select Condition_measure_seq, c.Condition_Code, Condition_Name, Condition_Val, Condition_Datetime	

                CommonUtil.SetInitGridView(dgv2);
                CommonUtil.AddGridTextColumn(dgv2, "측정항목코드", "Condition_Code", visibility: false);
                CommonUtil.AddGridTextColumn(dgv2, "조건순번", "Condition_measure_seq", visibility: false);
                CommonUtil.AddGridTextColumn(dgv2, "측정항목", "Condition_Name", visibility: false);
                CommonUtil.AddGridTextColumn(dgv2, "측정값", "Condition_Val");
                CommonUtil.AddGridTextColumn(dgv2, "측정일시", "Condition_Datetime");
                dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                CommonUtil.SetGridViewFontSize(dgv2, 25);
                CommonUtil.SetGridWidth(dgv2, "Condition_Datetime", 160);
            }
            else if (this.Text == "품질 측정값 등록")
            {

                //select inspect_code, inspect_name, USL, SL, LSL FROM Inspect_Spec_Master
         
                CommonUtil.SetInitGridView(dgv1);
                CommonUtil.AddGridTextColumn(dgv1, "항목코드", "inspect_code", visibility: false);
                CommonUtil.AddGridTextColumn(dgv1, "측정항목", "inspect_name");
                CommonUtil.AddGridTextColumn(dgv1, "공정코드", "Process_code", visibility: false);
                CommonUtil.AddGridTextColumn(dgv1, "USL", "USL");
                CommonUtil.AddGridTextColumn(dgv1, "SL", "SL");
                CommonUtil.AddGridTextColumn(dgv1, "LSL", "LSL");
                CommonUtil.SetGridViewFontSize(dgv1);
                CheckQualityList(wo);
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                CommonUtil.SetGridViewFontSize(dgv1,25);

                CommonUtil.SetGridWidth(dgv1, "inspect_name", 150);

                //
                CommonUtil.SetInitGridView(dgv2);
                CommonUtil.AddGridTextColumn(dgv2, "검사순번", "Inspect_measure_seq", visibility: false);
                CommonUtil.AddGridTextColumn(dgv2, "항목명", "Inspect_name", visibility: false);
                CommonUtil.AddGridTextColumn(dgv2, "항목코드", "Inspect_code", visibility: false);
                CommonUtil.AddGridTextColumn(dgv2, "측정값", "Inspect_val");
                CommonUtil.AddGridTextColumn(dgv2, "측정일시", "Inspect_datetime");
                dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                CommonUtil.SetGridWidth(dgv2, "Inspect_datetime", 160);

                CommonUtil.SetGridViewFontSize(dgv2,25);
            }
        }
        /// <summary>
        /// 공정조건 목록 조회
        /// </summary>
        /// <param name="wo"></param>
        private void ProcessConditionList(POPWorkVO wo)
        {
            SetProcessConditionService service1 = new SetProcessConditionService();
            var list = service1.GetProcessConditionList(itemCode, wo.wc_Code);
            dgv1.DataSource = list;
        }
        /// <summary>
        /// 품질측정항목 등록 조회
        /// </summary>
        /// <param name="wo"></param>
        private void CheckQualityList(POPWorkVO wo)
        {
            WorkOrderService service1 = new WorkOrderService();
            var list = service1.GetQualityCheckList(itemCode, wo.wc_Code);
            dgv1.DataSource = list;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (this.Text == "공정조건 등록")
            {
                //해당하는 조건항목코드로 등록된 항목들 조회, 품목코드, 작업지시번호, 작업장코드로
                //dgv1의 0번컬럼 = 조건항목코드
                string Condition_Code = dgv1.SelectedRows[0].Cells[0].Value.ToString();
                GetMeasuredData(Condition_Code);
            }
            else if (this.Text == "품질 측정값 등록")
            {
                string processCode = dgv1.SelectedRows[0].Cells["Process_code"].Value.ToString();
                //where Item_code =@Item_code  and Process_code=@Process_code and Workorderno = @Workorderno

                GetInspectData(processCode);
            }
        }

        private void GetInspectData(string processCdoe)
        {
            WorkOrderService service1 = new WorkOrderService();
            List<POPQuailtyItemVO> list = service1.GetQualityInfo(itemCode, processCdoe, WorkOrderNO);
            dgv2.DataSource = list;
        }
        /// <summary>
        /// 공정조건 별 측정값 조회
        /// </summary>
        /// <param name="Condition_Code"></param>
        private void GetMeasuredData(string Condition_Code)
        {
            SetProcessConditionService service = new SetProcessConditionService();
            List<POPMesuredConditionVO> list = service.GetMeasuredCondition(Condition_Code, itemCode, txtWorkPlace.Tag.ToString(), WorkOrderNO);
            dgv2.DataSource = list;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
            //등록시 품목코드, 작업장코드, 조건항목코드, 측정일자, 측정일시, 측정값, 작업지시번호, 최초입력일자, 최초입력자, 최종수정일자, 최종수정자
            if (dgv1.SelectedRows.Count < 1)
            {
                MessageBox.Show("등록할 측정 목록을 선택해주세요");
                return;
            }
            else if (txtValue.Text.Trim().Length < 1)
            {
                MessageBox.Show("측정값을 입력해주세요.");
                return;
            }

            if (this.Text == "공정조건 등록")
            {
                POPMesuredConditionVO mc = new POPMesuredConditionVO()
                {
                    Condition_Code = dgv1.SelectedRows[0].Cells[0].Value.ToString(),
                    Condition_Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                    Condition_Datetime = DateTime.Now,
                    Condition_Val = Convert.ToDecimal(txtValue.Text),
                    Ins_Date = DateTime.Now,
                    Ins_Emp = managerid,
                    Up_Date = DateTime.Now,
                    Up_Emp = managerid,
                    Item_code = itemCode,
                    Wc_Code = txtWorkPlace.Tag.ToString(),
                    Workorderno = WorkOrderNO
                };
                SetProcessConditionService service = new SetProcessConditionService();
                bool result = service.InsertConditionValue(mc);
                if (result)
                {
                    txtValue.Text = "";
                    GetMeasuredData(dgv1.SelectedRows[0].Cells[0].Value.ToString());
                }
                else
                {
                    txtValue.Text = "";
                    MessageBox.Show("등록에 실패하였습니다.");
                }
            }
            else if (this.Text == "품질 측정값 등록")
            {
                POPQuailtyItemVO qi = new POPQuailtyItemVO()
                {
                    Inspect_code = dgv1.SelectedRows[0].Cells["inspect_code"].Value.ToString(),
                    Process_code = dgv1.SelectedRows[0].Cells["Process_code"].Value.ToString(),
                    Inspect_val = Convert.ToDecimal(txtValue.Text),
                    Ins_Emp = managerid,
                    Up_Emp = managerid,
                    Item_code = itemCode,
                    Workorderno = WorkOrderNO
                };

                WorkOrderService service = new WorkOrderService();
                bool result = service.InsertInspectValue(qi, managerid);
                if (result)
                {
                    txtValue.Text = "";
                    GetInspectData(dgv1.SelectedRows[0].Cells["Process_code"].Value.ToString());
                }
                else
                {
                    txtValue.Text = "";
                    MessageBox.Show("등록에 실패하였습니다.");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv1.SelectedRows.Count < 1)
            {
                MessageBox.Show("등록할 측정 목록을 선택해주세요");
                return;
            }
            else if (txtValue.Text.Trim().Length < 1)
            {
                MessageBox.Show("측정값을 입력해주세요.");
                return;
            }

            if (this.Text == "공정조건 등록")
            {
                if (dgv2.SelectedRows.Count < 1) return;
                string Condition_measure_seq = dgv2.SelectedRows[0].Cells[1].Value.ToString();

                SetProcessConditionService service = new SetProcessConditionService();
                bool result = service.UpdateConditionValue(Condition_measure_seq, txtValue.Text, managerid);
                if (result)
                {
                    txtValue.Text = "";
                    GetMeasuredData(dgv1.SelectedRows[0].Cells[0].Value.ToString());
                }
                else
                {
                    txtValue.Text = "";
                    MessageBox.Show("등록에 실패하였습니다.");
                }
            }
            else if (this.Text == "품질 측정값 등록")
            {
                //Inspect_measure_seq
                string Inspect_measure_seq = dgv2.SelectedRows[0].Cells["Inspect_measure_seq"].Value.ToString();

                WorkOrderService service = new WorkOrderService();
                bool result = service.UpdateInspectValue(Inspect_measure_seq, txtValue.Text, managerid);
                if (result)
                {
                    txtValue.Text = "";
                    GetInspectData(dgv1.SelectedRows[0].Cells["Process_code"].Value.ToString());
                }
                else
                {
                    txtValue.Text = "";
                    MessageBox.Show("등록에 실패하였습니다.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.Text == "공정조건 등록")
            {
                string Condition_measure_seq = dgv2.SelectedRows[0].Cells[1].Value.ToString();

                SetProcessConditionService service = new SetProcessConditionService();
                bool result = service.DeleteConditionValue(Condition_measure_seq);
                if (result)
                {
                    txtValue.Text = "";
                    GetMeasuredData(dgv1.SelectedRows[0].Cells[0].Value.ToString());
                }
                else
                {
                    txtValue.Text = "";
                    MessageBox.Show("삭제에 실패하였습니다.");
                }
            }
            else if (this.Text == "품질 측정값 등록")
            {
                string Inspect_measure_seq = dgv2.SelectedRows[0].Cells["Inspect_measure_seq"].Value.ToString();

                WorkOrderService service = new WorkOrderService();
                bool result = service.DeleteInspectValue(Inspect_measure_seq);
                if (result)
                {
                    txtValue.Text = "";
                    GetInspectData(dgv1.SelectedRows[0].Cells["Process_code"].Value.ToString());
                }
                else
                {
                    txtValue.Text = "";
                    MessageBox.Show("삭제에 실패하였습니다.");
                }
            }
        }

        private void frmProcessCondition_Shown(object sender, EventArgs e)
        {
            dgv1.ClearSelection();
            dgv2.ClearSelection();
        }
    }
}
