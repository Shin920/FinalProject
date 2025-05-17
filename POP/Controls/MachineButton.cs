using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP.Controls
{
    public partial class MachineButton : UserControl
    {
        public delegate void MacEventHandler(object sender, MacEventArgs e);
        public event MacEventHandler macEvent;

        int process_ID;
        string workOrderNum;
        int prd_Cnt;

        frmMachineTask frm;

        public string Task_ID { get { return lblTask_ID.Text; } set { lblTask_ID.Text = value; } }
        public string Task_IP { get { return lblTask_IP.Text; } set { lblTask_IP.Text = value; } }
        public string Task_Port { get { return lblTask_Port.Text; } set { lblTask_Port.Text = value; } }
        public string Task_Remark { get { return button4.Text; } set { button4.Text = value; } }
        public Color btnForeColor { get { return button4.ForeColor; } set { button4.ForeColor = value; } }
        public MachineButton(string workOrderNum, int prdCnt)
        {
            InitializeComponent();

            this.workOrderNum = workOrderNum;
            this.prd_Cnt = prdCnt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string prgName = @"\POPMachine.exe";
            string prgName = Application.StartupPath + "\\POPMachine.exe"; //절대경로가 필요하면 이렇게 하면 되고
            /*string prgName = @"C:\Users\k8325\Desktop\FinalProject\POP\bin\Debug\POPMachine.exe";  */      //아예 이렇게 주니까 된다..왜 위에 처럼 하면 안되지?



            Process pro = Process.Start(prgName, $"{Task_ID} {Task_IP} {Task_Port}");
            process_ID = pro.Id;

            frm = new frmMachineTask(Task_ID, Task_IP, Task_Port, workOrderNum, prd_Cnt, Task_Remark, process_ID);
            frm.Owner = (frmForming)this.Parent.Parent;
            frm.Show();
            frm.Hide();

            if (macEvent != null)
            {
                MacEventArgs args = new MacEventArgs();
                args.MacName = this.Name;   //또는 thisTask_ID
                args.frm = frm;
                macEvent(this, args);
            }

        }
    }
    public class MacEventArgs : EventArgs
    {
        public string MacName { get; set; }
        public frmMachineTask frm { get; set; }
    }
}
