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
    public partial class AButton : Button
    {
        public AButton()
        {
            InitializeComponent();

            //Design
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = SystemColors.Info;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
