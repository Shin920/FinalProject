using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class POPProcessConditionVO
    {
        public string Condition_Code { get; set; }
        public string Condition_Name { get; set; }
        //public string Condition_code { get; set; }
        public decimal SL { get; set; }
        public decimal USL { get; set; }
        public decimal LSL { get; set; }
    }
    public class POPMesuredConditionVO
    {
        public string Condition_Group { get; set; }
        public long Condition_measure_seq { get; set; }
        public DateTime Condition_Datetime { get; set; }
        public decimal Condition_Val { get; set; }

        public string Item_code { get; set; }
        public string Wc_Code { get; set; }
        public string Condition_Code { get; set; }
        public string Condition_Name { get; set; }
        public DateTime Condition_Date { get; set; }
        public string Workorderno { get; set; }
        public DateTime Ins_Date { get; set; }
        public string Ins_Emp { get; set; }
        public DateTime Up_Date { get; set; }
        public string Up_Emp { get; set; }

    }

}
