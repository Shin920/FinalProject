using FinalProject.Service;
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
    public partial class frmFormM : Form
    {
        frmMain frm = null;
        List<ScreenItem_MasterVO> screanlist;
        ScreenItem_MasterService screenservice = new ScreenItem_MasterService();
        public frmFormM()
        {
            InitializeComponent();
        }

        private void frmFormM_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent; //함수에 전달해주기위해 
            frm.Select += OnSelect; //조회
            frm.Refresh += OnRefresh; //새로고침

            //데이터그리드뷰
            CommonUtil.SetInitGridView(dgvFormM);
            CommonUtil.AddGridTextColumn(dgvFormM, "화면코드", "Screen_Code", colWidth: 300);
            CommonUtil.AddGridTextColumn(dgvFormM, "화면명", "Type", colWidth: 300);
            CommonUtil.AddGridTextColumn(dgvFormM, "화면경로", "Screen_Path", colWidth: 350);
            CommonUtil.AddGridTextColumn(dgvFormM, "입력일자", "Ins_Date", colWidth: 210);
            CommonUtil.AddGridTextColumn(dgvFormM, "사용여부", "Use_YN", colWidth: 210);

            //사용여부 변경버튼 생성
            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;
            dgvFormM.Columns.Add(btnCell);

            //데이터그리드뷰 보여주기
            GetAll();
            //콤보박스
            ControlSetting();
        }
        private void GetAll()  //데이터그리드뷰 보여주기
        {
            screanlist = new List<ScreenItem_MasterVO>();
            screanlist = screenservice.GetALLScreenItem();
            dgvFormM.DataSource = screanlist;
        }
        private void ControlSetting() //콤보박스
        {   
            Dictionary<string, string> cbolist = screanlist.ToDictionary(item => item.Screen_Code, item => item.Type);
            cboGroup.DisplayMember = "Value";
            cboGroup.ValueMember = "Key";
            cboGroup.DataSource = new BindingSource(cbolist, null);
            txtGroup.Text = cboGroup.SelectedValue.ToString();
           
        }
        private void OnRefresh(object sender, EventArgs e)//새로고침
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmFormM) && frm.ActiveMdiChild == this)
                {

                }
            }
        }

        private void OnSelect(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmFormM) && frm.ActiveMdiChild == this)
                {

                }
            }
        }

        private void dgvFormM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvFormM.Columns["btn"].Index)//눌러서 사용과 사용안함 변경
                {
                    if ((dgvFormM.SelectedRows[0].Cells[4].Value).ToString() == "Y") //사용안함
                    {
                        screenservice.UsedScreenItem_MasterVO((dgvFormM.SelectedRows[0].Cells[0].Value).ToString(), "N");
                    }
                    else //사용함
                    {
                        screenservice.UsedScreenItem_MasterVO((dgvFormM.SelectedRows[0].Cells[0].Value).ToString(), "Y");
                    }
                    GetAll();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dgvFormM_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
