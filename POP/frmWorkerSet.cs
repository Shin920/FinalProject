using ClassLibrary1;
using FinalProjectVO;
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
    public partial class frmWorkerSet : Form
    {
        string wc_Code;
        string workOrderNo;
        List<POPWorkerSetVO> allocatedList;
        List<POPWorkerSetVO> CanAllocatList;
        public frmWorkerSet()
        {
            InitializeComponent();
        }
        public frmWorkerSet(string wcCode, string orderNo)
        {
            InitializeComponent();
            this.wc_Code = wcCode;
            this.workOrderNo = orderNo;
        }

        private void frmWorkerSet_Load(object sender, EventArgs e)
        {
            //작업장이름, 작업장코드 읽어와야함 (없으니까 작업장 코드만 읽어오게)

            txtWorkPlace.Text = wc_Code;

            //할당된 작업자 목록 조회
            //select hist_seq, Detail_Seq, t.user_id, t.[Allocation_date],  [Release_datetime], [Workorderno]

            CommonUtil.SetInitGridView(dgvSettedWorkers);
            CommonUtil.AddGridTextColumn(dgvSettedWorkers, "작업자", "user_id", visibility: false);
            CommonUtil.AddGridTextColumn(dgvSettedWorkers, "작업자", "user_name");
            CommonUtil.AddGridTextColumn(dgvSettedWorkers, "할당 시각", "Allocation_date");
            CommonUtil.AddGridTextColumn(dgvSettedWorkers, "작업지시코드", "Workorderno", visibility: false);
            CommonUtil.AddGridTextColumn(dgvSettedWorkers, "이력순번", "hist_seq", visibility: false);
            CommonUtil.AddGridTextColumn(dgvSettedWorkers, "상세이력순번", "Detail_Seq", visibility: false);
            CommonUtil.AddGridTextColumn(dgvSettedWorkers, "할당 시각", "Allocation_datetime", visibility:false);
            CommonUtil.SetGridViewFontSize(dgvSettedWorkers);

            LoadAllocatedData();
            dgvSettedWorkers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSettedWorkers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //할당 대상 작업자 목록 조회
            //u.User_ID,  Allocation_date, Release_datetime,  [Workorderno],  [Plan_Endtime], Wc_Code

            CommonUtil.SetInitGridView(dgvAllWorkers);
            CommonUtil.AddGridTextColumn(dgvAllWorkers, "작업자", "user_id", visibility: false);
            CommonUtil.AddGridTextColumn(dgvAllWorkers, "작업자", "user_name");
            CommonUtil.AddGridTextColumn(dgvAllWorkers, "작업장 코드", "Wc_Code");
            CommonUtil.SetGridViewFontSize(dgvAllWorkers);

            LoadCanAllocateData();
            dgvAllWorkers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllWorkers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            txtWorkerNum.Text = dgvSettedWorkers.RowCount.ToString();
        }

        private void LoadCanAllocateData()
        {
            UserService service = new UserService();
            CanAllocatList = service.GetCanAllocateWorkers(txtWorkPlace.Text, workOrderNo);
            dgvAllWorkers.DataSource = CanAllocatList;
        }

        private void LoadAllocatedData()
        {
            UserService service = new UserService();
            allocatedList = service.GetAllocatedWorkers(txtWorkPlace.Text, workOrderNo);
            dgvSettedWorkers.DataSource = allocatedList;
            txtWorkerNum.Text = allocatedList.Count.ToString();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //유효성체크
            //할당 대상 작업자 목록에서 체크하지 않은 경우
            if (dgvAllWorkers.SelectedRows.Count < 1)
            {
                MessageBox.Show("할당할 작업자를 선택해주세요.");
                return;
            }
            string worker = dgvAllWorkers.SelectedRows[0].Cells[0].Value.ToString();
            string manager = GetManagerID();

            UserService service = new UserService();
            bool result = service.SetWorker(worker, manager, workOrderNo);
            if (result)
            {
                MessageBox.Show("작업자가 할당되었습니다");
                LoadAllocatedData();
                LoadCanAllocateData();
            }
            else
            {
                MessageBox.Show("작업자 할당에 실패했습니다.");
            }

        }

        private string GetManagerID()
        {
            Form1 frm = (Form1)this.MdiParent;
            return frm.GetUserID();
        }

        private void btnUnSet_Click(object sender, EventArgs e)
        {
            //유효성체크
            //할당 작업자 목록에서 체크하지 않은 경우
            if (dgvSettedWorkers.SelectedRows.Count != 1)
            {
                MessageBox.Show("해제할 작업자를 선택해주세요.");
                return;
            }
            string worker = dgvSettedWorkers.SelectedRows[0].Cells["user_id"].Value.ToString();
            string allocationdate = dgvSettedWorkers.SelectedRows[0].Cells["Allocation_date"].Value.ToString();
            string workOrderNo = dgvSettedWorkers.SelectedRows[0].Cells["Workorderno"].Value.ToString();
            string Hist_Seq = dgvSettedWorkers.SelectedRows[0].Cells["hist_seq"].Value.ToString();
            string Detail_Seq = dgvSettedWorkers.SelectedRows[0].Cells["Detail_Seq"].Value.ToString();
            //form1 GetUserID 에 아이디 담겨있음, 3이력순번, 4상세이력순번

            string managerid = GetManagerID();
           
            UserService service = new UserService();
            bool result = service.UnAllocateWorkers(worker, managerid,allocationdate, Hist_Seq, Detail_Seq, wc_Code);
            if (result)
            {
                MessageBox.Show("작업자가 해제되었습니다");
                LoadAllocatedData();
                LoadCanAllocateData();
            }
            else
            {
                MessageBox.Show("작업자 해제에 실패했습니다.");
            }


        }

        private void frmWorkerSet_Shown(object sender, EventArgs e)
        {
            UserService service = new UserService();
            allocatedList = service.GetAllocatedWorkers(txtWorkPlace.Text, workOrderNo);
            dgvSettedWorkers.DataSource = allocatedList;

            UserService service1 = new UserService();
            CanAllocatList = service1.GetCanAllocateWorkers(txtWorkPlace.Text, workOrderNo);
            dgvAllWorkers.DataSource = CanAllocatList;
        }

        private void btnAllUnSet_Click(object sender, EventArgs e)
        {
            if (dgvSettedWorkers.SelectedRows.Count < 1)
            {
                MessageBox.Show("해제할 작업자를 선택해주세요.");
                return;
            }
            List<UnAllocateVO> list = new List<UnAllocateVO>();
            for (int i = 0; i < dgvSettedWorkers.SelectedRows.Count; i++)
            {
                UnAllocateVO uv = new UnAllocateVO();
                uv.User_ID = dgvSettedWorkers.SelectedRows[i].Cells["user_id"].Value.ToString();
                uv.Allocation_date = Convert.ToDateTime(dgvSettedWorkers.SelectedRows[i].Cells["Allocation_date"].Value);
                uv.hist_seq = Convert.ToInt32(dgvSettedWorkers.SelectedRows[i].Cells["hist_seq"].Value);
                uv.Detail_Seq = Convert.ToInt32(dgvSettedWorkers.SelectedRows[i].Cells["Detail_Seq"].Value);

                list.Add(uv);
            }
          
          
            string managerid = GetManagerID();

            UserService service = new UserService();
            bool result = service.UnAllocateWorkers(list, managerid, wc_Code);
            if (result)
            {
                MessageBox.Show("작업자가 해제되었습니다");
                LoadAllocatedData();
                LoadCanAllocateData();
            }
            else
            {
                MessageBox.Show("작업자 해제에 실패했습니다.");
            }
        }
    }
}
