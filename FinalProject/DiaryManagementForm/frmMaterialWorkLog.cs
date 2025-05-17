
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
    public partial class frmMaterialWorkLog : Form
    {
        public delegate void threadDelegate();
        threadDelegate threadmethod;

        List<Goods_In_HistoryVO> dryList;
        List<InspectMeasureHistoryVO> imhList;

        DataTable dt = new DataTable();
        XtraReportFrmMaterialWorkLog rpt = new XtraReportFrmMaterialWorkLog();
       
        public frmMaterialWorkLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportService service = new ReportService();
            DataTable dt = service.GetMaterialList(dtpDate.Value.ToShortDateString());

            XtraReportFrmMaterialWorkLog rpt = new XtraReportFrmMaterialWorkLog();

            rpt.DataSource = dt;
            ReportPreviewForm frm = new ReportPreviewForm(rpt);

            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }
        private void ReportBinding()
        {
            ReportService service = new ReportService();
            DataTable dt = service.GetMaterialList(dtpDate.Value.ToShortDateString());

            XtraReportFrmMaterialWorkLog rpt = new XtraReportFrmMaterialWorkLog();
            rpt.DataSource = dt;

            documentViewer1.DocumentSource = rpt;
            rpt.CreateDocument();

        }
        private void frmMaterialWorkLog_Load(object sender, EventArgs e)
        {
            documentViewer1.DocumentSource = null;
            threadmethod += ReportBinding;
            using (WaitForm waitfrm = new WaitForm(() => { Thread.Sleep(2000); dtpDate.Invoke(threadmethod); })) //기다리기
            {
                waitfrm.ShowDialog(this);
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
     
            ReportService service = new ReportService();
            DataTable dt = service.GetMaterialList(dtpDate.Value.ToShortDateString());

            XtraReportFrmMaterialWorkLog rpt = new XtraReportFrmMaterialWorkLog();

            rpt.DataSource = dt;
            ReportPreviewForm frm = new ReportPreviewForm(rpt);

            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }
    }
}
