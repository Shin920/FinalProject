using DevExpress.XtraReports.UI;
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
    public partial class XtraRepotPreview_Kim : Form
    {
        public XtraRepotPreview_Kim(XtraReport1_Kim rpt)
        {
            InitializeComponent();

            using (ReportPrintTool tool = new ReportPrintTool(rpt))
            {
                tool.ShowRibbonPreviewDialog();
            }
        }
    }
}
