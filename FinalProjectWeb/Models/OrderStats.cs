using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectWeb.Models
{
    public class OrderStats
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int MM { get; set; }
        public int Qty { get; set; }
    }
}