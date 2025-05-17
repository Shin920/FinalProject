using DevExpress.XtraReports.UI;
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
    public partial class frmMakeWorkLog : Form
    {
        public delegate void threadDelegate();
        threadDelegate threadmethod;
        List<Goods_In_HistoryPackageVO> boxlist;
        DataTable dt = new DataTable();
        XtraReportFrmMakeWorkLog rpt = new XtraReportFrmMakeWorkLog();
        public frmMakeWorkLog()
        {
            InitializeComponent();
        }
        private void ReportBinding()
        {
            ReportService service = new ReportService();
            DataTable dt = service.GetPackingList(dtpDate.Value.ToShortDateString());

            XtraReportFrmMakeWorkLog rpt = new XtraReportFrmMakeWorkLog();
            rpt.DataSource = dt;

            documentViewer1.DocumentSource = rpt;
            rpt.CreateDocument();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ReportService service = new ReportService();
            DataTable dt = service.GetPackingList(dtpDate.Value.ToShortDateString());

            XtraReportFrmMakeWorkLog rpt = new XtraReportFrmMakeWorkLog();

            rpt.DataSource = dt;
            ReportPreviewForm frm = new ReportPreviewForm(rpt);

            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void frmMakeWorkLog_Load(object sender, EventArgs e)
        {

            documentViewer1.DocumentSource = null;
            threadmethod += ReportBinding;
            using (WaitForm waitfrm = new WaitForm(() => { Thread.Sleep(2000); dtpDate.Invoke(threadmethod); })) //기다리기
            {
                waitfrm.ShowDialog(this);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            documentViewer1.DocumentSource = null;
            threadmethod += ReportBinding;
            using (WaitForm waitfrm = new WaitForm(() => { Thread.Sleep(2000); dtpDate.Invoke(threadmethod); })) //기다리기
            {
                waitfrm.ShowDialog(this);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ReportService service = new ReportService();
            DataTable dt = service.GetPackingList(dtpDate.Value.ToShortDateString());

            XtraReportFrmMakeWorkLog rpt = new XtraReportFrmMakeWorkLog();

            rpt.DataSource = dt;
            ReportPreviewForm frm = new ReportPreviewForm(rpt);

            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }
    }
}
