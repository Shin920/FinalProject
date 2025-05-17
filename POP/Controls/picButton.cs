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
    public partial class picButton : UserControl
    {
        public picButton()
        {
            InitializeComponent();
        }
        public string btnText { get { return button1.Text.ToString(); } set {button1.Text = value; } }
        public Image btnImage { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
    }
}
