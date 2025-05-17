using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP.Controls
{

    public partial class RegBadQty : UserControl
    {
        public event EventHandler Del;
        public string Ma_Code { get { return lblBig.Tag.ToString(); }  set { lblBig.Tag = value; } }
        public string Ma_Name { get { return lblBig.Text; } set { lblBig.Text = value; } }
        public string Mi_Code { get { return lblDetail.Tag.ToString(); } set { lblDetail.Tag = value; } }
        public string Mi_Name { get { return lblDetail.Text; } set { lblDetail.Text = value; } }
        public Image prd_Img { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
        public string Qty { get { return lblQty.Text; } set { lblQty.Text = value; } }
        public bool IsDel { get; set; }
        public RegBadQty()
        {
            InitializeComponent();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            IsDel = true;
            if (Del != null)
            {
                Del(this, null);
            }
        }
    }
}
