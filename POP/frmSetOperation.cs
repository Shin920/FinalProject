using FinalProject;
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
    public partial class frmSetOperation : Form
    {
        string managerid;
        public frmSetOperation()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;
            string seq = dataGridView1.SelectedRows[0].Cells["nop_seq"].Value.ToString();
            string wcname = dataGridView1.SelectedRows[0].Cells["wc_Name"].Value.ToString();
            SetOperatePopup frm = new SetOperatePopup(seq, wcname, managerid);
            frm.StartPosition = FormStartPosition.CenterScreen;
            if(frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void frmSetOperation_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();
            //select wc_Name, nop_ma_Name, Nop_Mi_Name, Nop_Happentime, Nop_Canceltime, nh.wc_code, nop_seq, nop_time

            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업장", "wc_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "주원인", "nop_ma_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "상세원인", "Nop_Mi_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "발생시각", "Nop_Happentime");
            CommonUtil.AddGridTextColumn(dataGridView1, "해제시각", "Nop_Canceltime");
            CommonUtil.AddGridTextColumn(dataGridView1, "비가동시간(분)", "nop_time");
            CommonUtil.AddGridTextColumn(dataGridView1, "작업장코드", "wc_code",visibility:false);
            CommonUtil.AddGridTextColumn(dataGridView1, "발생순번", "nop_seq", visibility: false);

            CommonUtil.SetGridViewFontSize(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            CommonUtil.SetGridWidth(dataGridView1, "Nop_Happentime", 150);
            CommonUtil.SetGridWidth(dataGridView1, "Nop_Canceltime", 150);
            CommonUtil.SetGridWidth(dataGridView1, "nop_time", 120);
        }

        private void frmSetOperation_Shown(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.ClearSelection();
        }

        private void LoadData()
        {
            NonOperationService service = new NonOperationService();
            DataTable dt = service.GetNonOperationList();
            dataGridView1.DataSource = dt;
        }
    }
}
