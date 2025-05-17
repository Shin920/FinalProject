using FinalProject.Service;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmNotice1 : FinalProject.List_b
    {
        frmMain frm = null;
        DataTable Alldt = new DataTable();
        string username;
        public frmNotice1()
        {
            InitializeComponent();
        }

        private void frmNotice1_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = Convert.ToDateTime("3000-01-01");
            frm = (frmMain)this.MdiParent;
            username = frm.UserName;

            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
            frm.Insert += Frm_Insert;
            frm.Delete += Frm_Delete;
            frm.UpDate += Frm_UpDate;

            CommonUtil.SetInitGridView(dataGridView1);
            //SELECT SEQ, Notice_Date, Notice_End, TITLE, Description, USE_YN
            CommonUtil.AddGridTextColumn(dataGridView1, "공지번호", "SEQ");
            CommonUtil.AddGridTextColumn(dataGridView1, "공지시작일자", "Notice_Date");
            CommonUtil.AddGridTextColumn(dataGridView1, "공지종료일자", "Notice_End");
            CommonUtil.AddGridTextColumn(dataGridView1, "제목", "TITLE");
            CommonUtil.AddGridTextColumn(dataGridView1, "내용", "Description");
            CommonUtil.AddGridTextColumn(dataGridView1, "사용여부", "USE_YN");


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMain2) && frm.ActiveMdiChild == this)
                {
                    StringBuilder sb = new StringBuilder();
                    if (txtDes.Text == "")
                        sb.AppendLine("공지 내용을 입력해주세요.");
                    if (txtTitle.Text == "")
                        sb.AppendLine("제목을 입력해주세요.");
                    if (DateTime.Compare(dtpNoticeDate.Value, dtpEndDate.Value) > 0)
                        sb.AppendLine("제대로된 날짜를 입력해주세요.");
                    if (cboUseYN.Text == "")
                        sb.AppendLine("사용여부를 선택해주세요.");

                    if (sb.Length > 0)
                    {
                        MessageBox.Show(sb.ToString());
                        return;
                    }

                    NoticeVO nv = new NoticeVO();
                    nv.Description = txtDes.Text;
                    nv.Up_Emp = username;//나중에 수정
                    nv.Title = txtTitle.Text;
                    nv.Notice_Date = Convert.ToDateTime(dtpNoticeDate.Value.ToShortDateString());
                    nv.Notice_End = Convert.ToDateTime(dtpEndDate.Value.ToShortDateString());
                    nv.Use_YN = Convert.ToChar(cboUseYN.Text);

                    NoticeService service = new NoticeService();
                    bool result = service.UpdateNotice(nv, Convert.ToInt32(lblseq.Text));
                    if (result)
                    {
                        MessageBox.Show("공지사항이 수정되었습니다.");
                        txtDes.Text = txtTitle.Text = "";
                        cboUseYN.SelectedIndex = 0;
                        dtpEndDate.Value = dtpNoticeDate.Value = DateTime.Now;
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("공지사항 수정에 실패하였습니다.");
                    }
                }
            }
        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMain2) && frm.ActiveMdiChild == this)
                {
                    if (dataGridView1.SelectedRows.Count < 1) return;

                    NoticeService service = new NoticeService();
                    bool result = service.DeleteNotice(Convert.ToInt32(lblseq.Text));
                    if (result)
                    {
                        MessageBox.Show("공지사항이 삭제되었습니다.");
                        txtDes.Text = txtTitle.Text = "";
                        cboUseYN.SelectedIndex = 0;
                        dtpEndDate.Value = dtpNoticeDate.Value = DateTime.Now;
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("공지사항 삭제에 실패하였습니다.");
                    }
                }
            }
        }

        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMain2) && frm.ActiveMdiChild == this)
                {
                    StringBuilder sb = new StringBuilder();
                    if (txtDes.Text == "")
                        sb.AppendLine("공지 내용을 입력해주세요.");
                    if (txtTitle.Text == "")
                        sb.AppendLine("제목을 입력해주세요.");
                    if (DateTime.Compare(dtpNoticeDate.Value, dtpEndDate.Value) > 0)
                        sb.AppendLine("제대로된 날짜를 입력해주세요.");
                    if (cboUseYN.Text == "")
                        sb.AppendLine("사용여부를 선택해주세요.");

                    if (sb.Length > 0)
                    {
                        MessageBox.Show(sb.ToString());
                        return;
                    }

                    NoticeVO nv = new NoticeVO();
                    nv.Description = txtDes.Text;
                    nv.Ins_Emp = username; //나중에 수정
                    nv.Up_Emp = username;
                    nv.Title = txtTitle.Text;
                    nv.Notice_Date = Convert.ToDateTime(dtpNoticeDate.Value.ToShortDateString());
                    nv.Notice_End = Convert.ToDateTime(dtpEndDate.Value.ToShortDateString());
                    nv.Use_YN = Convert.ToChar(cboUseYN.Text);

                    NoticeService service = new NoticeService();
                    bool result =  service.InsertNotice(nv);
                    if (result)
                    {
                        MessageBox.Show("공지사항이 등록되었습니다.");
                        txtDes.Text = txtTitle.Text = "";
                        cboUseYN.SelectedIndex = 0;
                        dtpEndDate.Value = dtpNoticeDate.Value = DateTime.Now;
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("공지사항 등록에 실패하였습니다.");
                    }
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {         
            foreach (Form fr in Application.OpenForms)
            {          
                if (fr.GetType() == typeof(frmMain2) && frm.ActiveMdiChild == this)
                {
                    NoticeService service = new NoticeService();
                    DataTable dt = service.GetSearchedNoticeList(dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"), txtSearch.Text, Convert.ToChar(cboUseYNS.Text));
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMain2) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                    txtDes.Text = txtTitle.Text = "";
                    cboUseYN.SelectedIndex = 0;
                    dtpEndDate.Value = dtpNoticeDate.Value = DateTime.Now;
                    txtSearch.Text = "";
                    
                }
            }
        }
        private void LoadData()
        {
            NoticeService service = new NoticeService();
            Alldt = service.GetNoticeList();
            dataGridView1.DataSource = Alldt;
        }

        private void frmNotice1_Shown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //SELECT SEQ, Notice_Date, Notice_End, TITLE, Description, USE_YN
            lblseq.Text = dataGridView1.SelectedRows[0].Cells["seq"].Value.ToString();
            dtpEndDate.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["Notice_End"].Value);
            dtpNoticeDate.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["Notice_Date"].Value);
            txtTitle.Text = dataGridView1.SelectedRows[0].Cells["TITLE"].Value.ToString();
            txtDes.Text = dataGridView1.SelectedRows[0].Cells["Description"].Value.ToString();
            cboUseYN.Text = dataGridView1.SelectedRows[0].Cells["USE_YN"].Value.ToString();
        }

        private void Check()
        {

               
        }
    }
}
