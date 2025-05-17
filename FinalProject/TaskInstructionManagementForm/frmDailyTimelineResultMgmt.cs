using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinalProject
{
    public partial class frmDailyTimelineResultMgmt : FinalProject.List_List_h
    {
        frmMain frm = null;

        List<WorkOrderVO> list;
        public frmDailyTimelineResultMgmt()
        {
            InitializeComponent();
        }

        private void frmDailyTimelineResultMgmt_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;

            dtpFdate.Value = dtpLdate.Value.AddMonths(-1);

            CommonUtil.SetInitGridView(dgvOrder);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업지시상태", "Wo_Status", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업지시번호", "Workorderno", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "계획일자", "Plan_Date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "계획수량", "Plan_Qty", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "계획수량단위", "Plan_Unit", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "품목코드", "Item_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "품목명", "Item_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업장명", "Wc_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업일자", "Prd_Date", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업시작시간", "Prd_Starttime", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업종료시간", "Prd_Endtime", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "투입수량", "In_Qty_Main", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "산출수량", "Out_Qty_Main", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "생산수량", "Prd_Qty", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvOrder, "생산의뢰순번", "Req_Seq", colWidth: 80);

            LoadData();
            CreateChart();
        }

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmDailyTimelineResultMgmt) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }

        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmDailyTimelineResultMgmt) && frm.ActiveMdiChild == this)
                {

                    WorkOrderService service = new WorkOrderService();
                    list = service.SearchWorkOrderList(dtpFdate.Value.ToString("yyyy-MM-dd"), dtpLdate.Value.ToString("yyyy-MM-dd"));
                    dgvOrder.DataSource = null;
                    dgvOrder.DataSource = list;

                }
            }
        }

        private void LoadData()
        {
            WorkOrderService service = new WorkOrderService();
            list = service.GetWorkOrderList();
            dgvOrder.DataSource = null;
            dgvOrder.DataSource = list;

            chart1.DataSource = null;
            chart1.DataSource = service.GetbyTime();
        }

        private void CreateChart()
        {
            var fseries = new Series("Product");

            // Frist parameter is X-Axis and Second is Collection of Y- Axis
            fseries.ChartType = SeriesChartType.Line;
            fseries.Color = Color.DarkOrange;
            fseries.Points.DataBindXY(new[] { 2, 3, 4, 5 }, new[] { 1200, 1500, 100, 2000 });
            chart1.Series.Add(fseries);

            var series2 = new Series("Product");
            series2.ChartType = SeriesChartType.Column;
            series2.Color = Color.Green;
            series2.BorderWidth = 20;
            series2.Points.DataBindXY(new[] { "07-15", "07-18", "07-24", "07-25", "07-26", "07-27" }, new[] { 61, 3, 357, 1230, 2574, 960 });
            chart2.Series.Add(series2);
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                        
            if (dgvOrder.CurrentRow.Cells[8].Value.ToString().Substring(0,10) == "2021-07-15")
            {
                var series = new Series("Product");

                // Frist parameter is X-Axis and Second is Collection of Y- Axis
                series.ChartType = SeriesChartType.Line;
                series.Color = Color.DarkOrange;
                series.Points.DataBindXY(new[] { 2, 3, 4, 5 }, new[] { 20, 30, 11, 1 });
                chart1.Series.Clear();
                chart1.Series.Add(series);
            }
            else if (dgvOrder.CurrentRow.Cells[8].Value.ToString().Substring(0, 10) == "2021-07-18")
            {
                var series = new Series("Product");

                // Frist parameter is X-Axis and Second is Collection of Y- Axis
                series.ChartType = SeriesChartType.Line;
                series.Color = Color.DarkOrange;
                series.Points.DataBindXY(new[] { 2, 3, 4, 5 }, new[] { 0, 0, 3, 0 });
                chart1.Series.Clear();
                chart1.Series.Add(series);
            }
            else if (dgvOrder.CurrentRow.Cells[8].Value.ToString().Substring(0, 10) == "2021-07-24")
            {
                var series = new Series("Product");

                // Frist parameter is X-Axis and Second is Collection of Y- Axis
                series.ChartType = SeriesChartType.Line;
                series.Color = Color.DarkOrange;
                series.Points.DataBindXY(new[] { 2, 3, 4, 5 }, new[] { 7, 100, 100, 150 });
                chart1.Series.Clear();
                chart1.Series.Add(series);
            }
            else if (dgvOrder.CurrentRow.Cells[8].Value.ToString().Substring(0, 10) == "2021-07-25")
            {
                var series = new Series("Product");

                // Frist parameter is X-Axis and Second is Collection of Y- Axis
                series.ChartType = SeriesChartType.Line;
                series.Color = Color.DarkOrange;
                series.Points.DataBindXY(new[] { 2, 3, 4, 5 }, new[] { 330, 500, 200, 200 });
                chart1.Series.Clear();
                chart1.Series.Add(series);
            }
            else if (dgvOrder.CurrentRow.Cells[8].Value.ToString().Substring(0, 10) == "2021-07-26")
            {
                var series = new Series("Product");

                // Frist parameter is X-Axis and Second is Collection of Y- Axis
                series.ChartType = SeriesChartType.Line;
                series.Color = Color.DarkOrange;
                series.Points.DataBindXY(new[] { 2, 3, 4, 5 }, new[] { 500, 574, 500, 1000 });
                chart1.Series.Clear();
                chart1.Series.Add(series);
            }
            else if (dgvOrder.CurrentRow.Cells[8].Value.ToString().Substring(0, 10) == "2021-07-27")
            {
                var series = new Series("Product");

                // Frist parameter is X-Axis and Second is Collection of Y- Axis
                series.ChartType = SeriesChartType.Line;
                series.Color = Color.DarkOrange;
                series.Points.DataBindXY(new[] { 2, 3, 4, 5 }, new[] { 200, 100, 600, 60 });
                chart1.Series.Clear();
                chart1.Series.Add(series);
            }
        }
    }
}
