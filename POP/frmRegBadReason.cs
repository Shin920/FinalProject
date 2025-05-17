using FinalProjectVO;
using POP.Controls;
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
    public partial class frmRegBadReason : Form
    {
        DataTable def_mi;
        int idx = 0;
        string managerid = "dbswndus";
        string workorderno;
        int qty;
        int remQty=15;

        public frmRegBadReason()
        {
            InitializeComponent();
        }
        public frmRegBadReason(string workorderno, string managerid, int qty)
        {
            InitializeComponent();
            this.workorderno = workorderno;
            txtWorkOrderNo1.Text = workorderno;
            this.managerid = managerid;
            this.qty = remQty = qty;
            txtPlan_Qty1.Text = $"{qty}개 (잔여: {remQty}개)";
            numQty.Maximum = remQty;
            numQty.Minimum = 0;
        }

        private void frmRegBadReason_Load(object sender, EventArgs e)
        {
            BadProdService service = new BadProdService();
            //상세분류 목록 데이터테이블에 저장
            def_mi = service.GetDefMiList();

            //대분류 콤보박스 바인딩
            List<Def_Ma_Master> list = service.GetDefMaList();
            cboBig.DisplayMember = "Def_Ma_Name";
            cboBig.ValueMember = "Def_Ma_Code";
            cboBig.DataSource = list;
            Reset();
        }

        private void cboBig_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(def_mi);
            dv.RowFilter = $" def_ma_code = '{cboBig.SelectedValue}'";
            cboDetail.DisplayMember = "Def_Mi_Name";
            cboDetail.ValueMember = "Def_Mi_Code";
            cboDetail.DataSource = dv;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
            else
            {
                Program.Log.WriteInfo("파일열기에서 파일 선택 안함");
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(remQty == 0)
            {
                MessageBox.Show("모든 불량품을 등록하였습니다.");
                return;
            }

            if(cboBig.Text == "" || cboDetail.Text == "" || numQty.Value == 0)
            {
                MessageBox.Show("제대로된 불량 사유와 수량을 입력해주세요.");
                return;
            }
            RegBadQty rb = new RegBadQty();
            rb.Ma_Code = cboBig.SelectedValue.ToString();
            rb.Ma_Name = cboBig.Text;
            rb.Mi_Code = cboDetail.SelectedValue.ToString();
            rb.Mi_Name = cboDetail.Text;
            rb.Qty = numQty.Text;
            rb.prd_Img = pictureBox1.Image;

            rb.Name = $"{idx}RegBadQty";
            rb.Size = new Size(738, 264);
            rb.Location = new Point(0, 3 + 264 * idx);
            panel1.Controls.Add(rb);

            rb.Del += Rb_Del;
            idx++;
            remQty -= Convert.ToInt32(numQty.Value);
            txtPlan_Qty1.Text = $"{qty}개 (잔여: {remQty}개)";

            Reset();
        }

        private void Reset()
        {
            numQty.Value = 0;
            cboBig.Text = "";
            cboDetail.Text = "";
            pictureBox1.ImageLocation = "Image/noImage.png";
        }

        private void Rb_Del(object sender, EventArgs e)
        {
            foreach (RegBadQty item in panel1.Controls)
            {
                if (item.IsDel)
                {
                    remQty += Convert.ToInt32(item.Qty);
                    txtPlan_Qty1.Text = $"{qty}개 (잔여: {remQty}개)";
                    panel1.Controls.Remove(item);
                }
            }
            //다시그리기
            ShowItem();
        }

        private void ShowItem()
        {
            int idx = 0;

            foreach (RegBadQty item in panel1.Controls)
            {
                for (int i = 0; i < this.idx+1; i++)
                {
                    if (item.Name == $"{i}RegBadQty")
                    {
                        int verticalScroll = panel1.VerticalScroll.Value;

                        item.Location = new Point(0, -verticalScroll +(3 + 264 * idx)); 
                        item.Name = $"{idx}RegBadQty";
                        idx++;
                    }
                }
            }
            this.idx = idx;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            List<DefectiveVO> list = new List<DefectiveVO>();
            foreach (RegBadQty item in panel1.Controls)
            {
                //Workorderno, Def_Mi_Code, Def_Date, Def_Qty, Ins_Date, Ins_Emp, Up_Date, Up_Emp, Def_Image_Binary
                DefectiveVO dv = new DefectiveVO();
                dv.Def_Mi_Code = item.Mi_Code;
                dv.Workorderno = txtWorkOrderNo1.Text;
                dv.Def_Date = DateTime.Now;
                dv.Def_Qty = Convert.ToInt32(item.Qty);
                byte[] bimage = CommonUtil.ImageToByte(item.prd_Img);
                dv.Def_Image_Binary = bimage;

                list.Add(dv);
            }
            BadProdService service = new BadProdService();
            bool result = service.RegBadProdHistory(list, managerid);
            if (result)
            {
                MessageBox.Show("성공적으로 등록되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("등록에 실패하였습니다.");
            }
        }
    }
}
