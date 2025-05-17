using DevExpress.XtraReports.UI;
using FinalProject.Util;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmPankingWorkLog : Form
    {
        public delegate void threadDelegate();
        threadDelegate threadmethod;
        List<Goods_In_HistoryPackageVO> boxlist;
        DataTable dt = new DataTable();
        PackingLog rpt = new PackingLog();
        public frmPankingWorkLog()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            documentViewer1.DocumentSource = null;
            threadmethod += ReportBinding;
            using (WaitForm waitfrm = new WaitForm(() => { Thread.Sleep(2000); dtpDate.Invoke(threadmethod); })) //기다리기
            {
                waitfrm.ShowDialog(this);
            }
        }
        private void ReportBinding()
        {
            //string date = dtpDate.Value.ToString("yyyyMMdd");


            //var searchlist = (from data in boxlist
            //                  where data.In_Date.ToString("yyyyMMdd") == date
            //                  select data).ToList();
            //dt = ListDataTable.ToDataTable(searchlist);
            //rpt.DataSource = dt;
            //rpt.Parameters["Ins_Date"].Value = dtpDate.Value.ToString("yyyy-MM-dd");
            //rpt.Parameters["Ins_Date"].Visible = false; 
            //documentViewer1.DocumentSource = rpt;
            //rpt.CreateDocument();

            ReportService service = new ReportService();
            DataTable dt = service.GetPackingList(dtpDate.Value.ToShortDateString());

            PackingLog rpt = new PackingLog();
            rpt.DataSource = dt;
           
            documentViewer1.DocumentSource = rpt;
            rpt.CreateDocument();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ReportService service = new ReportService();
            DataTable dt = service.GetPackingList(dtpDate.Value.ToShortDateString());
            
            PackingLog rpt = new PackingLog();

            rpt.DataSource = dt;
            ReportPreviewForm frm = new ReportPreviewForm(rpt);

            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void frmPankingWorkLog_Load(object sender, EventArgs e)
        {
            documentViewer1.DocumentSource = null;
            threadmethod += ReportBinding;
            using (WaitForm waitfrm = new WaitForm(() => { Thread.Sleep(2000); dtpDate.Invoke(threadmethod); })) //기다리기
            {
                waitfrm.ShowDialog(this);
            }
        }
    }
}
