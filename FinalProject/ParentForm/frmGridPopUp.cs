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
    
    public partial class frmGridPopUp : Form
    {
        public delegate void CodeHandler(object sender, CodeNameArgs e);
        public event CodeHandler CodeName;

        string menuName;
        public frmGridPopUp(string menu)
        {
            InitializeComponent();
            menuName = menu;
        }

        private void frmGridPopUp_Load(object sender, EventArgs e)
        {
            lblTitle.Text = menuName;

            if(menuName == "작업장")
            {
                CommonUtil.SetInitGridView(dataGridView1);
                CommonUtil.AddGridTextColumn(dataGridView1, "작업장코드", "Wc_Code");
                CommonUtil.AddGridTextColumn(dataGridView1, "작업장명", "Wc_Name");
                WorkCenterService service = new WorkCenterService();
                List<WorkCenterVO> list = service.GetWorkCenterSmallList();
                dataGridView1.DataSource = list;
            }
            else if (menuName == "공정")
            {
                CommonUtil.SetInitGridView(dataGridView1);
                CommonUtil.AddGridTextColumn(dataGridView1, "공정코드", "Process_Code");
                CommonUtil.AddGridTextColumn(dataGridView1, "공정명", "Process_Name");
                ProcessService service = new ProcessService();
                List<ProcessVO> list = service.GetProcessSmallList();
                dataGridView1.DataSource = list;
            }
            else if (menuName == "대차")
            {
                CommonUtil.SetInitGridView(dataGridView1);
                CommonUtil.AddGridTextColumn(dataGridView1, "대차코드", "GV_Code");
                CommonUtil.AddGridTextColumn(dataGridView1, "대차명", "GV_Name");
                CarriageService service = new CarriageService();
                List<CarriageVO> list = service.GetCarriageSmallList();
                dataGridView1.DataSource = list;
            }
            else if (menuName == "품목")
            {
                CommonUtil.SetInitGridView(dataGridView1);
                CommonUtil.AddGridTextColumn(dataGridView1, "품목코드", "Item_Code");
                CommonUtil.AddGridTextColumn(dataGridView1, "품목명", "Item_Name");
                CarriageService service = new CarriageService();
                List<ItemVO> list = service.GetItemSmallList();
                dataGridView1.DataSource = list;
            }
            else if (menuName == "대차그룹")
            {
                CommonUtil.SetInitGridView(dataGridView1);
                CommonUtil.AddGridTextColumn(dataGridView1, "그룹명", "GV_Group");
                CommonUtil.AddGridTextColumn(dataGridView1, "대차명", "GV_Name");
                CarriageService service = new CarriageService();
                List<CarriageVO> list = service.GetCarriageGroupSmallList();
                dataGridView1.DataSource = list;
            }
            else if (menuName == "근무자")
            {
                CommonUtil.SetInitGridView(dataGridView1);
                CommonUtil.AddGridTextColumn(dataGridView1, "근무자ID", "User_ID");
                CommonUtil.AddGridTextColumn(dataGridView1, "근무자명", "User_Name");
                WorkHistoryService service = new WorkHistoryService();
                List<UserVO> list = service.GetUserSmallList();
                dataGridView1.DataSource = list;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string code = dataGridView1[0, e.RowIndex].Value.ToString();
            string name = dataGridView1[1, e.RowIndex].Value.ToString();

            if (CodeName != null)
            {
                CodeNameArgs args = new CodeNameArgs();
                args.Code = code;
                args.Name = name;
                CodeName(this, args);
            }
            this.Close();
        }
    }

    public class CodeNameArgs : EventArgs
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
