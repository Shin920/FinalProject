using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class NoticeVO
    {
        public int Seq { get; set; }
        public DateTime Notice_Date { get; set; }
        public DateTime Notice_End { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public char Use_YN { get; set; }
        public DateTime Ins_Date { get; set; }
        public string Ins_Emp { get; set; }
        public DateTime Up_Date { get; set; }
        public string Up_Emp { get; set; }

        public int number { get; set; }
    }
}
