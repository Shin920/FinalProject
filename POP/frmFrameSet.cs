using ClassLibrary1;
using FinalProjectVO;
using POP.Service;
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
    public partial class frmFrameSet : Form
    {
        string WorkOrderNO;
        string itemCode;
        string managerid;
        public frmFrameSet()
        {
            InitializeComponent();
        }
        public frmFrameSet(string WorkNO)
        {
            InitializeComponent();
            txtWorkNO.Text = WorkOrderNO = WorkNO;
        }

        private void frmFrameSet_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();
            //작업지시 데이터 가져오기
            //작업지시번호, 품목명, 작업지시일, 작업장, 실적수량, 단위
            WorkOrderService service = new WorkOrderService();
            POPWorkVO wo = service.GetWorkOrderDetail(WorkOrderNO);
            txtWorkNO.Text = wo.Workorderno;
            //이름으로 바꿔야함
            txtWorkPlace.Text = wo.wc_Name;
            txtWorkPlace.Tag = wo.wc_Code;
            txtWorkDate.Text = wo.Plan_Date.ToString("yyyy-MM-dd");
            txtUnit.Text = wo.Item_Unit;
            txtQty.Text = wo.Plan_Qty.ToString();
            txtProd.Text = wo.Item_Name;
            txtProd.Tag = wo.Item_Code;
            itemCode = wo.Item_Code;

            //장착대상금형목록

            //select  select Mold_Code, Mold_Name, Mold_Group
            CommonUtil.SetInitGridView(dgvCanSetList);
            CommonUtil.AddGridTextColumn(dgvCanSetList, "금형코드", "Mold_Code");
            CommonUtil.AddGridTextColumn(dgvCanSetList, "금형명", "Mold_Name");
            CommonUtil.AddGridTextColumn(dgvCanSetList, "그룹", "Mold_Group");
            CommonUtil.SetGridViewFontSize(dgvCanSetList);
            dgvCanSetList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanSetList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //장착금형목록


            CommonUtil.SetInitGridView(dgvSettedList);
            CommonUtil.AddGridTextColumn(dgvSettedList, "금형코드", "Mold_Code");
            CommonUtil.AddGridTextColumn(dgvSettedList, "금형명", "Mold_Name");
            CommonUtil.AddGridTextColumn(dgvSettedList, "그룹", "Mold_Group");
            CommonUtil.SetGridViewFontSize(dgvSettedList);
            dgvSettedList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSettedList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void frmFrameSet_Shown(object sender, EventArgs e)
        {
            LoadCanSetList();

            //select m.mold_code, mold_name, mold_group 
            LoadSettedList();
        }

        private void LoadSettedList()
        {
            MoldService service2 = new MoldService();
            List<MoldVO> list2 = service2.GetSettedMoldList(txtWorkNO.Text);
            dgvSettedList.DataSource = list2;
        }

        private void LoadCanSetList()
        {
            MoldService service1 = new MoldService();
            List<MoldVO> list = service1.GetCanSetMoldList();
            dgvCanSetList.DataSource = list;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //유효성체크
            //할당 대상 금형 목록에서 체크하지 않은 경우
            if (dgvCanSetList.SelectedRows.Count < 1)
            {
                MessageBox.Show("할당할 금형을 선택해주세요.");
                return;
            }
            string mold = dgvCanSetList.SelectedRows[0].Cells["Mold_Code"].Value.ToString();
            string manager = managerid;

            MoldService service = new MoldService();
            bool result = service.SetMold(mold, manager, WorkOrderNO, txtWorkPlace.Tag.ToString());
            if (result)
            {
                MessageBox.Show("금형이 장착되었습니다");
                LoadSettedList();
                LoadCanSetList();
            }
            else
            {
                MessageBox.Show("금형 장착에 실패했습니다.");
            }

        }

        private void btnUnSet_Click(object sender, EventArgs e)
        {
            //유효성체크
            //할당 대상 금형 목록에서 체크하지 않은 경우
            if (dgvSettedList.SelectedRows.Count < 1)
            {
                MessageBox.Show("해제할 금형을 선택해주세요.");
                return;
            }
            string mold = dgvSettedList.SelectedRows[0].Cells["Mold_Code"].Value.ToString();
            string manager = managerid;

            MoldService service = new MoldService();
            bool result = service.UnSetMold(mold, manager, WorkOrderNO);
            if (result)
            {
                MessageBox.Show("금형이 해제되었습니다");
                LoadSettedList();
                LoadCanSetList();
            }
            else
            {
                MessageBox.Show("금형 해제에 실패했습니다.");
            }
        }
    }
}
