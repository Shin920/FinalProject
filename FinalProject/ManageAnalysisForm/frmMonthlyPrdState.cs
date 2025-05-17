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
    public partial class frmMonthlyPrdState : FinalProject.List
    {
        frmMain frm = null;
        List<AnalysePrdVO> list;
        public frmMonthlyPrdState()
        {
            InitializeComponent();
        }

        private void frmMonthlyPrdState_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;


            nmcMonth.Value = Convert.ToDecimal(DateTime.Now.ToString("MM"));

            CommonUtil.SetInitGridView(dgvList);
            CommonUtil.AddGridTextColumn(dgvList, "공정명", "Process_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "작업장명", "Wc_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "품목명", "Item_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "전월목표량", "Past_Plan_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "전월생산량", "Past_Prd_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "전월생산시간", "Past_Prd_Time", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "전월달성률(%)", "Past_Goal_Rate", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "당월목표량", "This_Goal_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "당월생산량", "This_Prd_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "당월생산시간", "This_Prd_Hour", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "당월달성률(%)", "This_Goal_Rate", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvList, "전월대비증감량", "Plus_Minus", colWidth: 100);

            LoadData();
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMonthlyPrdState) && frm.ActiveMdiChild == this)
                {
                    LoadData();

                }
            }
        }

        private void LoadData()
        {
            AnalyseService service = new AnalyseService();
            list = service.GetPrdMonthly(nmcMonth.Value.ToString());

            dgvList.DataSource = null;
            dgvList.DataSource = list;


        }
    }
}
