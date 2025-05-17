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
    
    public partial class frmMonthlyPkgState : FinalProject.List
    {
        frmMain frm = null;
        List<AnalyseVO> list;
        public frmMonthlyPkgState()
        {
            InitializeComponent();
        }

        private void frmMonthlyPkgState_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
                      
                        
            nmcMonth.Value = Convert.ToDecimal(DateTime.Now.ToString("MM"));

            CommonUtil.SetInitGridView(dgvMonthly);
            CommonUtil.AddGridTextColumn(dgvMonthly, "품목코드", "Item_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMonthly, "품목명", "Item_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMonthly, "포장일자", "In_Date", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMonthly, "일일포장량", "In_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMonthly, "누계포장량", "totQty", colWidth: 100);

            LoadData();
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMonthlyPkgState) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                    
                }
            }
        }

        private void LoadData()
        {
            AnalyseService service = new AnalyseService();
            list = service.GetPkgMonthly(nmcMonth.Value.ToString());

            dgvMonthly.DataSource = null;
            dgvMonthly.DataSource = list;

          
        }
    }
}
