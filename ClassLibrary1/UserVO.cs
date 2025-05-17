using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class UserVO
    {
        public string User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_PW { get; set; }
        public string Ins_Emp { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddrZip { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string UserGroup_Code { get; set; }
    }

    public class UnAllocateVO
    {
        public string User_ID { get; set; }
        public DateTime Allocation_date { get; set; }
        public int hist_seq { get; set; }
        public int Detail_Seq { get; set; }
    }
}
