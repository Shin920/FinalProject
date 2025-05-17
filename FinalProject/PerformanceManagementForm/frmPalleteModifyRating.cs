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
    public partial class frmPalleteModifyRating : Form
    {
        string woNum;
        string palletNo;
        string grdName;
        public frmPalleteModifyRating(string workOrderNum, string palletNo, string gradeName)
        {
            InitializeComponent();

            woNum = workOrderNum;
            this.palletNo = palletNo;
            grdName = gradeName;
        }

        private void frmPalleteModifyRating_Load(object sender, EventArgs e)
        {
            textBox1.Text = grdName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BoxingVO box = new BoxingVO()
            {
                Workorderno = woNum,
                Pallet_No = palletNo,
                Grade_Detail_Name = textBox1.Text
            };

            BoxingService service = new BoxingService();
            bool result = service.UpdatePalleteGrade(box);
            if(result)
            {
                MessageBox.Show("수정되었습니다.");
                this.Close();
            }
            else
            {
                MessageBox.Show("수정 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
