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
    public partial class UcCarriageMoniter : UserControl
    {
        public UcCarriageMoniter()
        {
            InitializeComponent();
        }
        public string CarriageName 
        {
            get { return lblName.Text; }
            set { lblName.Text = value; } 
        }
        public string CarraigeStatus 
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = value; }
        }

        public string WorkOrderNum 
        {
            get { return lblWorkOrderNum.Text; }
            set { lblWorkOrderNum.Text = value; }
        }
        public string ItemCode 
        {
            get { return lblItemCode.Text; }
            set { lblItemCode.Text = value; }
        }
        public string ItemName 
        {
            get { return lblItemName.Text; }
            set { lblItemName.Text = value; }
        }
        public string LoadingTime 
        {
            get { return lblLoadingTime.Text; }
            set { lblLoadingTime.Text = value; }
        }     
    }
}
