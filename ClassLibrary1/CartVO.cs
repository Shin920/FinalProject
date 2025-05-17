using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class CartVO
    {
        public string GV_Code { get; set; }
        public string GV_Name { get; set; }
        public string GV_Group { get; set; }
        public string GV_Status { get; set; }
        public string Unloading_Wc { get; set; }
        public char Use_YN { get; set; }
        public DateTime Ins_Date { get; set; }
        public string Ins_Emp { get; set; }
        public DateTime Up_Date { get; set; }
        public string Up_Emp { get; set; }
        public DateTime loading_time { get; set; }

        public int GV_Rest_Qty { get; set; }
        public string workorderno { get; set; }
        public int Status_Seq { get; set; }
        public long Hist_Seq { get; set; }
        public DateTime? In_Time { get; set; }
        public DateTime? Out_Time { get; set; }
        public string item_Name { get; set; }
        public string item_Code { get; set; }
    }
}
