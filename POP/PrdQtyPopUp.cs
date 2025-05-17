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
using FinalProjectVO;

namespace POP
{
    public partial class PrdQtyPopUp : Form
    {

        public delegate void CntEventHandler(object sender, CntEventArgs e);
        public event CntEventHandler cntEvent;
        int opencase;
        string goodBad;
        string managerid;
        string gv_code;
        long hist_seq;
        string wc_code;
        string item_code = "";
        public bool BadQtyY { get; set; }

        public PrdQtyPopUp()
        {
            InitializeComponent();
        }
        public PrdQtyPopUp(string workOrderNo, string planQty, string prd_Code, string prd_Name, int opencase, string managerID, string prd_Qty, string gv_code, long hist_seq, string wc_code, string item_code, int good_prd_qty=0, int bad_prd_qty=0)
        {
            InitializeComponent();
            BadQtyY = false;
            this.opencase = opencase;
            managerid = managerID;

            if (opencase == 1)
            {
                txtPlan_Qty1.Text = planQty;
                txtPrd_Name1.Text = prd_Name;
                txtPrd_Name1.Tag = prd_Code;
                txtWorkOrderNo1.Text = workOrderNo;
                txtPrd_Qty.Text = prd_Qty;

                CartService service = new CartService();
                List<CartVO> list = service.GetFormingCarList();

                cboFormingCar.DisplayMember = "GV_Name";
                cboFormingCar.ValueMember = "GV_Code";
                cboFormingCar.DataSource = list;
            }
            else
            {
                txtPlanQty.Text = planQty;
                txtPrdName.Text = prd_Name;
                txtPrdName.Tag = prd_Code;
                txtWorkOrderNo.Text = workOrderNo;
                //생산완료한 수량 값을 넘어오게함
                txtPrd_Qty2.Text = prd_Qty;
                this.gv_code = gv_code;
                this.hist_seq = hist_seq;
                this.wc_code = wc_code;
                this.item_code = item_code;

                numGood.Value = good_prd_qty;
                numBad.Value = bad_prd_qty;
            }
        }
        private void MinusCalc(int num)
        {
            if ((numPrdQty.Value - num) < 0)
                numPrdQty.Value = 0;
            else
            {
                numPrdQty.Value -= num;
            }
        }
        private void PlusCalc(int num)
        {
            if ((numPrdQty.Value + num) > numPrdQty.Maximum)
                numPrdQty.Value = numPrdQty.Maximum;
            else
            {
                numPrdQty.Value += num;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numPrdQty.Value == 0) return;
            this.DialogResult = DialogResult.OK;
            //생산수량 전달
            frmForming frm = (frmForming)Owner;
            if (cntEvent != null)
            {
                CntEventArgs args = new CntEventArgs();
                args.Prd_Cnt = Convert.ToInt32(numPrdQty.Value);
                cntEvent(this, args);

            }

            //만약 cbo선택을 안했을시 오류발생함(null) , 유효성 체크 필요
            frm.prdQty = numPrdQty.Text;
            frm.GV_Code = cboFormingCar.SelectedValue.ToString();
            /* frm.GV_Code = "2";  */                                    //=-----------------------------------
            this.Close();
        }

        private void btnmin1_Click(object sender, EventArgs e)
        {
            MinusCalc(1);
        }

        private void btnmin5_Click(object sender, EventArgs e)
        {
            MinusCalc(5);
        }

        private void btnmin10_Click(object sender, EventArgs e)
        {
            MinusCalc(10);
        }
        private void btnmin100_Click(object sender, EventArgs e)
        {
            MinusCalc(100);
        }

        private void btnplu1_Click(object sender, EventArgs e)
        {
            PlusCalc(1);
        }

        private void btnplu5_Click(object sender, EventArgs e)
        {
            PlusCalc(5);
        }

        private void btnplu10_Click(object sender, EventArgs e)
        {
            PlusCalc(10);
        }

        private void btnplu100_Click(object sender, EventArgs e)
        {
            PlusCalc(100);
        }

        private void PrdQtyPopUp_Load(object sender, EventArgs e)
        {
            if (opencase == 1)
            {
                //numPrdQty.Maximum = Convert.ToInt32(txtPlan_Qty1.Text) - Convert.ToInt32(txtPrd_Qty.Text);
                numPrdQty.Minimum = 0;
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else if (opencase == 2)
            {
                //numGood.Maximum = numBad.Maximum = Convert.ToInt32(txtPlanQty.Text);
                numGood.Minimum = numBad.Minimum = 0;
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }
        private void MinusValue(int num)
        {
            if (goodBad == "Good")
            {
                MinusCalc(numGood, num);
            }
            else if (goodBad == "Bad")
            {
                MinusCalc(numBad, num);
            }
            else
            {
                return;
            }
        }
        private void PlusValue(int num)
        {
            if (goodBad == "Good")
            {
                PlusCalc(numGood, num);
            }
            else if (goodBad == "Bad")
            {
                PlusCalc(numBad, num);
            }
            else
            {
                return;
            }
        }

        private void MinusCalc(NumericUpDown type, int num)
        {
            if ((type.Value - num) < 0)
                type.Value = 0;
            else
            {
                type.Value -= num;
            }
        }
        private void PlusCalc(NumericUpDown type, int num)
        {
            if ((type.Value + num) > Convert.ToInt32(txtPlanQty.Text))
                type.Value = Convert.ToInt32(txtPlanQty.Text);
            else
            {
                type.Value += num;
            }
        }
        private void numGood_Click(object sender, EventArgs e)
        {
            goodBad = "Good";
        }

        private void numBad_Click(object sender, EventArgs e)
        {
            goodBad = "Bad";
        }

        private void btnMinusMade1_Click(object sender, EventArgs e)
        {
            MinusValue(1);
        }

        private void btnMinusMade5_Click(object sender, EventArgs e)
        {
            MinusValue(5);
        }

        private void btnMinusMade10_Click(object sender, EventArgs e)
        {
            MinusValue(10);
        }

        private void btnMinusMade100_Click(object sender, EventArgs e)
        {
            MinusValue(-100);
        }

        private void btnPlusMade1_Click(object sender, EventArgs e)
        {
            PlusValue(1);
        }

        private void btnPlusMade5_Click(object sender, EventArgs e)
        {
            PlusValue(5);
        }

        private void btnPlusMade10_Click(object sender, EventArgs e)
        {
            PlusValue(10);
        }

        private void btnPlusMade100_Click(object sender, EventArgs e)
        {
            PlusValue(100);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //생산수량 업데이트
            //생산수량 최종수정일자, 최종수정자, 작업순서, 작업종료시간
            //where workorderno = @workorderno

            if ((numGood.Value + numBad.Value) != Convert.ToInt32(txtPrd_Qty2.Text))
            {
                MessageBox.Show("수량이 일치하지 않습니다.");
                return;
            }

            WorkOrderService service = new WorkOrderService();
            bool result = service.StopMachine(txtWorkOrderNo.Text, managerid, Convert.ToInt32(numGood.Value), Convert.ToInt32(numBad.Value));
            if (result)
            {
                //기계, 작업자에 수량 등록
                //UserService uservice = new UserService();
                //bool uresult = uservice.UpdateUserPrd(txtWorkOrderNo.Text, (int)numGood.Value, managerid);



                MoldService mservice = new MoldService();
                List<MoldVO> moldList = new List<MoldVO>();
                moldList = mservice.GetSettedMoldList(txtWorkOrderNo.Text);
                bool mresult = mservice.UpdateMoldPrd(txtWorkOrderNo.Text, (int)numGood.Value, (int)numBad.Value, managerid, moldList);

                //불량품 언로딩, 
                if (numBad.Value > 0)
                {
                    CartService service1 = new CartService();
                    bool result1 = service1.VacateCar(gv_code, Convert.ToInt32(numBad.Value), wc_code, item_code, hist_seq.ToString(), managerid, txtWorkOrderNo.Text);
                    BadQtyY = true;
                }

                frmForming frm = (frmForming)this.Owner;
                frm.badQty = numBad.Value.ToString();
              
                this.DialogResult = DialogResult.OK;

               
                
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void PrdQtyPopUp_Shown(object sender, EventArgs e)
        {


        }
    }

    public class CntEventArgs : EventArgs
    {
        public int Prd_Cnt { get; set; }
    }
}
