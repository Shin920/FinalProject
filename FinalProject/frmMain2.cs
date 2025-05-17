using FinalProject.Service;
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

namespace FinalProject
{
    public partial class frmMain2 : Form
    {
        
        public string UserName { get; set; }
        frmMain frm = null;
        public frmMain2()
        {
            InitializeComponent();

            
        }

        private void frmMain2_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvWorkOrderHistory);
            CommonUtil.AddGridTextColumn(dgvWorkOrderHistory, "작업시작시간", "Prd_Starttime", colWidth: 117, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrderHistory, "작업지시상태", "Wo_Status", colWidth: 90);
            CommonUtil.AddGridTextColumn(dgvWorkOrderHistory, "작업지시번호", "Workorderno", colWidth: 127, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrderHistory, "품목명", "Item_Name");
            CommonUtil.AddGridTextColumn(dgvWorkOrderHistory, "작업장명", "Wc_Name", colWidth: 90);
            CommonUtil.AddGridTextColumn(dgvWorkOrderHistory, "공정명", "Process_name", colWidth: 85, align: DataGridViewContentAlignment.MiddleCenter);

            dgvWorkOrderHistory.Columns[0].DefaultCellStyle.Format = "HH시 mm분 ss초";

            CommonUtil.SetInitGridView(dgvNotice);
            CommonUtil.AddGridTextColumn(dgvNotice, "공지번호", "SEQ", visibility:false);     //랭크로 가져와서 번호 먹여야할듯
            CommonUtil.AddGridTextColumn(dgvNotice, "공지번호", "number", colWidth: 95, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvNotice, "공지일", "Notice_Date", align: DataGridViewContentAlignment.MiddleCenter);        
            CommonUtil.AddGridTextColumn(dgvNotice, "제목", "TITLE", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvNotice, "내용", "Description", colWidth:782);
            CommonUtil.AddGridTextColumn(dgvNotice, "공지종료일", "Notice_End", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvNotice, "유효 여부", "USE_YN", visibility:false);

            CommonUtil.SetInitGridView(dgvUserWork);
            CommonUtil.AddGridTextColumn(dgvUserWork, "할당일자", "Allocation_date", align: DataGridViewContentAlignment.MiddleCenter);    
            CommonUtil.AddGridTextColumn(dgvUserWork, "작업지시번호", "Workorderno", colWidth: 124, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvUserWork, "작업장명", "Wc_Name");
            CommonUtil.AddGridTextColumn(dgvUserWork, "품목명", "Item_Name");
            CommonUtil.AddGridTextColumn(dgvUserWork, "공정명", "Process_name", align: DataGridViewContentAlignment.MiddleCenter);




            frm = (frmMain)this.MdiParent;

            timer1.Start();

            LoadNoticeData();
            LoadWorkOrderHistory();
            LoadUserWorkOrder();
            LoadNote();
            LoadUserData();


            frm.Select += Frm_Select;                  
            
        }

        private void LoadUserData()
        {
            MenuService service = new MenuService();
            DataTable dt = service.GetUserInfo(frm.UserID);        //frm.UserID로 입력하면 된다

            UserName = lblUserName.Text = dt.Rows[0][0].ToString();
            lblGroupName.Text = dt.Rows[0][1].ToString();
        }

        private void LoadNote()
        {
            MenuService service = new MenuService();
            txtNoteView.Text = service.GetUserNote(frm.UserID);
        }

        private void LoadUserWorkOrder()
        {
            WorkOrderService service = new WorkOrderService();
            DataTable dt = service.GetUserDailyWorkOrder(frm.UserID);

            dgvUserWork.DataSource = null;
            dgvUserWork.DataSource = dt;
        }

        private void LoadWorkOrderHistory()
        {
            WorkOrderService service = new WorkOrderService();
            List<WorkOrderVO> list = service.GetDailyWorkOrder();

            dgvWorkOrderHistory.DataSource = null;
            dgvWorkOrderHistory.DataSource = list;
        }

        private void LoadNoticeData()
        {
            NoticeService service = new NoticeService();

            dgvNotice.DataSource = null;
            dgvNotice.DataSource = service.GetNoticeList();
          
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMain2))
                {
                    if (frm.ActiveMdiChild == this)
                    {
                        //MessageBox.Show("Hello");
                    }
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //여기서 업데이트냐 인서트냐를 구분해야하는데 프로시저로 확인후에 해야할듯하긴하다

            if (lblNote.ForeColor == Color.FromArgb(57, 61, 70))    //메모장이 활성화 된 상태에서 저장버튼을 누른다면
            {
                MenuService service = new MenuService();
                service.InsertNewNote(frm.UserID, txtNoteView.Text);

                LoadNote();
            }
            else
            {
                //공지사항으로 등록하기
                NoticeService service = new NoticeService();
                NoticeVO nv = new NoticeVO()
                {
                    Notice_Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    Notice_End = Convert.ToDateTime(DateTime.Now.AddDays(7).ToShortDateString()),
                    Title = txtTitle.Text,
                    Description = txtNotice.Text,
                    Use_YN = 'Y',
                    Ins_Emp = UserName,
                    Up_Emp = UserName
                };
                bool result = service.InsertNotice(nv);
                if (result)
                {
                    MessageBox.Show("공지가 등록되었습니다.");
                    LoadNoticeData();
                }
                else
                    MessageBox.Show("공지 등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }

        private void label3_Click(object sender, EventArgs e)       //메모장 라벨 클릭
        {
            txtTitle.Visible = false;
            txtNotice.Visible = false;
            txtNoteView.Visible = true;
            lblNote.ForeColor = Color.FromArgb(57, 61, 70);
            lblNotice.ForeColor = Color.FromArgb(224, 224, 224);
   
        }

        private void lblNotice_Click(object sender, EventArgs e)
        {
            txtNoteView.Visible = false;
            txtTitle.Visible = true;
            txtNotice.Visible = true;
            lblNotice.ForeColor = Color.FromArgb(57, 61, 70);
            lblNote.ForeColor = Color.FromArgb(224, 224, 224);
        }
    }
}
