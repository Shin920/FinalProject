using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class WaitForm : Form
    {
        public Action Worker;
        public WaitForm(Action worker)
        {
            InitializeComponent();
            this.Worker = worker;
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
        }

        private void Progressbar_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Worker).ContinueWith((t) => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
