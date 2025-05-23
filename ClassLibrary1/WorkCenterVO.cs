﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class WorkCenterVO
    {
        public string Wc_Code { get; set; }
        public string Wc_Name { get; set; }
        public string Wc_Group { get; set; }
        public string Process_Code { get; set; }

        public string Process_Name { get; set; }
        public string Auto_Wo_YN { get; set; }
        public string Auto_Start_YN { get; set; }
        public string ERP_IF_YN { get; set; }
        public string Wo_Status { get; set; }
        public string Nop_Auto_YN { get; set; }
        public int Nop_Check_Time { get; set; }
        public DateTime Last_Cnt_Time { get; set; }
        public string Prd_Req_Type { get; set; }
        public string Pallet_YN { get; set; }
        public string Item_Code { get; set; }
        public string Prd_Unit { get; set; }
        public string Mold_Setup_YN { get; set; }
        public string In_Qty_Auto_YN { get; set; }
        public string Wo_Ini_Char { get; set; }
        public string Use_YN { get; set; }
        public string Remark { get; set; }
        public DateTime Ins_Date { get; set; }
        public string Ins_Emp { get; set; }
        public DateTime Up_Date { get; set; }
        public string Up_Emp { get; set; }

    }
}
