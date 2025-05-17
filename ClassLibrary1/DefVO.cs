using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    /// <summary>
    /// 불량현상대분류
    /// </summary>
    public class Def_Ma_Master
    {
        public string Def_Ma_Code { get; set; }
        public string Def_Ma_Name { get; set; }

    }

    public class Def_Mi_Master
    {
        
        public string Def_Mi_Code { get; set; }
        public string Def_Ma_Code { get; set; }
        public string Def_Mi_Name { get; set; }

    }
}
