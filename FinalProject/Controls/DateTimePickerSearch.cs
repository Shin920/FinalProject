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
    public partial class DateTimePickerSearch : UserControl
    {
        public DateTime dateTimePickerValue1 { get { return dateTimePicker1.Value; } set { dateTimePicker1.Value = value; } }
        public DateTime dateTimePickerValue2 { get { return dateTimePicker2.Value; } set { dateTimePicker2.Value = value; } }
        public string ButtonText { get { return btnSearch.Text; } set { btnSearch.Text = value; } }

        public event SearchButtonClick btnDateTimeSearch_Click;
        public DateTimePickerSearch()
        {
            InitializeComponent();
        }
        public delegate void SearchButtonClick(object sender, EventArgs args);

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnDateTimeSearch_Click?.Invoke(sender, e);
        }

        private void DateTimePickerSearch_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.AddDays(-7).ToShortDateString());
                dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                dateTimePicker2.MaxDate = DateTime.Now;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                if (MessageBox.Show("날짜를 다시 선택해주세요.", "날짜선택", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.AddDays(-7).ToShortDateString());
                    dateTimePicker1.MaxDate = DateTime.Now;
                    dateTimePicker2.MaxDate = DateTime.Now;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                if (MessageBox.Show("날짜를 다시 선택해주세요.", "날짜선택", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.AddDays(-7).ToShortDateString());
                    dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                    dateTimePicker1.MaxDate = DateTime.Now;
                    dateTimePicker2.MaxDate = DateTime.Now;
                }
            }
        }
    }
}
