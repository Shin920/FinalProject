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
    public partial class UcPeriodControl : UserControl
    {
        public enum PeriodType { OneDay, ThreeDay, OneWeek, OneMonth, ThreeMonth, SixMonth };
        public string dtFrom
        {
            get { return dateTimePicker1.Value.ToShortDateString(); }
            set { dateTimePicker1.Value = Convert.ToDateTime(value); }
        }

        public string dtTo
        {
            get { return dateTimePicker2.Value.ToShortDateString(); }
            set { dateTimePicker2.Value = Convert.ToDateTime(value); }
        }
        public UcPeriodControl()
        {
            InitializeComponent();
        }

        private void UcPeriodControl_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "선택없음":
                    dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Now;
                    break;
                case "1일":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-1);
                    break;
                case "3일":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-3);
                    break;
                case "1주일":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-7);
                    break;
                case "1개월":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-1);
                    break;
                case "3개월":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-3);
                    break;
                case "6개월":
                    dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(-6);
                    break;
            }
        }
    }
}
