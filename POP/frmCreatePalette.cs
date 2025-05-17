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
    public partial class frmCreatePalette : Form
    {
        string WorkOrderNO;
        string itemCode;
        string managerid;
        int remainQty;
        int totQty;

        DataTable Gardedt = new DataTable();
        DataTable Sizedt = new DataTable();
        List<BoxingVO> palList = new List<BoxingVO>();
        public frmCreatePalette(string WorkNO)
        {
            InitializeComponent();
            txtWorkNO.Text = WorkOrderNO = WorkNO;
        }

        private void frmCreatePalette_Load(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.MdiParent;
            managerid = frm.GetUserID();
            //작업지시 데이터 가져오기
            //작업지시번호, 품목명, 작업지시일, 작업장, 실적수량, 단위
            WorkOrderService service = new WorkOrderService();
            POPWorkVO wo = service.GetWorkOrderDetail(WorkOrderNO);
            txtWorkNO.Text = wo.Workorderno;
            txtWorkPlace.Text = wo.wc_Name;
            txtWorkPlace.Tag = wo.wc_Code;
            txtWorkDate.Text = wo.Plan_Date.ToString("yyyy-MM-dd");
            txtUnit.Text = wo.Item_Unit;
            txtProd.Text = wo.Item_Name;
            txtProd.Tag = wo.Item_Code;
            itemCode = wo.Item_Code;

            int madeQty = service.GetRemainQty(WorkOrderNO);

            if ((wo.in_qty_main - madeQty) < 0)
                remainQty = totQty = 0;
            else
                remainQty = totQty = wo.in_qty_main - madeQty;

            txtQty.Text = $"{wo.in_qty_main}개 (잔여 수량: {remainQty}개)";

            //select Pallet_No , item_name, Grade_Detail_Name, In_Qty, Grade_Code, Grade_Code, Size_Code
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "팔레트번호", "Pallet_No");
            CommonUtil.AddGridTextColumn(dataGridView1, "제품", "item_name");
            CommonUtil.AddGridTextColumn(dataGridView1, "등급", "Grade_Detail_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "수량", "In_Qty");
            CommonUtil.AddGridTextColumn(dataGridView1, "등급코드", "Grade_Code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "등급상세코드", "Grade_Detail_Code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "사이즈", "Size_Code", visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "사이즈", "Size_Name");
            CommonUtil.AddGridTextColumn(dataGridView1, "바코드", "Barcode_No", visibility: false);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            CommonUtil.SetGridViewFontSize(dataGridView1,25);

        }

        private void frmCreatePalette_Shown(object sender, EventArgs e)
        {
            PackService service = new PackService();
            Gardedt = service.GetPackGradeList();
            cboGradeDetail.DataSource = Gardedt;
            cboGradeDetail.DisplayMember = "Grade_Detail_Name";
            cboGradeDetail.ValueMember = "Grade_Detail_Code";

            Sizedt = service.GetPalSize(txtUnit.Text);
            cboSize.DataSource = Sizedt;
            cboSize.DisplayMember = "size_name";
            cboSize.ValueMember = "size_code";

            GetPalList(txtWorkNO.Text);
            //GetPalNoList(txtWorkNO.Text);
        }
        private void GetPalNoList(string workorderno)
        {
            PackService service = new PackService();
            palList = service.GetPalNoList(workorderno);
            cboPalNo.DataSource = palList;
            cboPalNo.DisplayMember = "Pallet_No";
            cboPalNo.ValueMember = "Size_Code";
        }
        private void GetPalList(string workorderno)
        {
            PackService service = new PackService();
            palList = service.GetPalList(workorderno);
            dataGridView1.DataSource = palList;
        }
        private void cboGradeDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = Gardedt.Rows[cboGradeDetail.SelectedIndex].ItemArray;
            txtGrade.Text = item[2].ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (remainQty == 0)
            {
                MessageBox.Show("팔레트 생성이 필요하지 않습니다.");
                return;
            }
            if((numQty.Value * Convert.ToInt32(cboSize.Tag)) > remainQty * 2)
            {
                if(numQty.Value < 8)
                {
                    if(cboSize.SelectedIndex != 0)
                    {
                        MessageBox.Show($"너무 많은 수량의 팔레트가 생성 요청 되었습니다. 적절한 수량의 팔레트를 생성해주세요.\n남은 수량: {remainQty}\n요청된 팔레트 제품 적재 가능 수량{numQty.Value * Convert.ToInt32(cboSize.Tag)}");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"너무 많은 수량의 팔레트가 생성 요청 되었습니다. 적절한 수량의 팔레트를 생성해주세요.\n남은 수량: {remainQty}\n요청된 팔레트 제품 적재 가능 수량{numQty.Value * Convert.ToInt32(cboSize.Tag)}");
                    return;
                }
             
            }


            if (cboPalNo.Text == "새로생성")
            {
                //팔레트번호 새로 생성해야함
                PackService service = new PackService();
                string newpalno = service.CreateNewPalNo(txtWorkNO.Text);
                //Workorderno, Pallet_No, Barcode_No, Grade_Code, Grade_Detail_Code, Size_Code, Grade_Detail_Name, In_Qty, F_In_Qty, Print_Date, In_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp
                BoxingVO bv = new BoxingVO();

                bv.Workorderno = txtWorkNO.Text;
                bv.Pallet_No = "P" + newpalno;
                bv.Grade_Code = txtGrade.Text;
                bv.Grade_Detail_Code = cboGradeDetail.SelectedValue.ToString();
                bv.Grade_Detail_Name = cboGradeDetail.Text;
                bv.Size_Code = cboSize.SelectedValue.ToString();
                bv.In_Qty = Convert.ToInt32(numQty.Value);
                bv.F_In_Qty = Convert.ToInt32(numQty.Value);
                bv.Print_Date = DateTime.Now;
                bv.In_YN = "N";
                bv.Ins_Date = DateTime.Now;
                bv.Ins_Emp = managerid;
                bv.Up_Date = DateTime.Now;
                bv.Up_Emp = managerid;
                bv.Prd_Qty = Convert.ToInt32(cboSize.Tag);

                bool result = service.InsertPackHistory(bv);
                if (result)
                {
                    SettxtQty();

                    GetPalList(txtWorkNO.Text);
                    int index = dataGridView1.Rows.Count - 1;
                    dataGridView1.FirstDisplayedScrollingRowIndex = index;
                    dataGridView1.Refresh();

                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
                    dataGridView1.Rows[index].Selected = true;

                    cboPalNo.SelectedIndex = 0;
                    numQty.Value = 1;

                    //바코드 다운로드도 해야함
                    CommonUtil.BarCodePrint(dataGridView1.SelectedRows[0].Cells["Barcode_No"].Value.ToString());
                }
            }
            else
            {
                //기존에 등록된 팔레트 수량 증가하는경우
                PackService service = new PackService();
                bool result = service.UpdatePal(lblPalNo.Tag.ToString(), Convert.ToInt32(numQty.Value), Convert.ToInt32(cboSize.Tag), managerid);

                if (result)
                {
                    SettxtQty();

                    GetPalList(txtWorkNO.Text);
                    int index = dataGridView1.Rows.Count - 1;
                    dataGridView1.FirstDisplayedScrollingRowIndex = index;
                    dataGridView1.Refresh();

                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
                    dataGridView1.Rows[index].Selected = true;
                    cboPalNo.SelectedIndex = 0;
                    numQty.Value = 1;

                    CommonUtil.BarCodePrint(dataGridView1.SelectedRows[0].Cells["Barcode_No"].Value.ToString());
                }
            }
        }

        private void SettxtQty()
        {
            int qty = 0;
            qty = remainQty - (int)(Convert.ToInt32(cboSize.Tag) * numQty.Value);
            if (qty < 0)
            {
                remainQty = 0;
            }
            else remainQty = qty;
            txtQty.Text = $"{totQty}개 (잔여 수량: {remainQty}개)";
        }

        private void cboPalNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPalNo.Text != "새로생성")
            {
                cboSize.Text = cboPalNo.SelectedValue.ToString();
                cboSize.Enabled = false;
            }
            else
            {
                cboSize.SelectedIndex = cboGradeDetail.SelectedIndex = 0;
                cboSize.Enabled = true;
                cboGradeDetail.Enabled = true;
                numQty.Value = 1;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Workorderno, Pallet_No, Barcode_No, Grade_Code, Grade_Detail_Code, Size_Code, Grade_Detail_Name, In_Qty, F_In_Qty, Print_Date, In_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp, p.Prd_Qty
            cboPalNo.Text = dataGridView1.SelectedRows[0].Cells["Pallet_No"].Value.ToString();
            cboGradeDetail.Text = dataGridView1.SelectedRows[0].Cells["Grade_Detail_Name"].Value.ToString();
            cboGradeDetail.SelectedValue = dataGridView1.SelectedRows[0].Cells["Grade_Detail_Code"].Value.ToString();
            txtGrade.Text = dataGridView1.SelectedRows[0].Cells["Grade_Code"].Value.ToString();
            cboSize.SelectedValue = dataGridView1.SelectedRows[0].Cells["Size_Code"].Value.ToString();
            cboSize.Tag = dataGridView1.SelectedRows[0].Cells["In_Qty"].Value.ToString();
            lblPalNo.Tag = dataGridView1.SelectedRows[0].Cells["Barcode_No"].Value.ToString();

            cboGradeDetail.Enabled = false;
            cboSize.Enabled = false;
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = Sizedt.Rows[cboSize.SelectedIndex].ItemArray;
            cboSize.Tag = item[1].ToString();
        }
    }
}
