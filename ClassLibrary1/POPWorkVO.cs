using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class POPWorkVO
    {
        public string Userdefine_Mi_Name { get; set; }
        public string Workorderno { get; set; }
        public string user_id { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Item_Unit { get; set; }
        public string wc_Name { get; set; }
        public string wc_Code { get; set; }
        public int Plan_Qty { get; set; }
        public int Prd_Qty { get; set; }
        public int in_qty_main { get; set; }
        public DateTime Plan_Date { get; set; }
        public DateTime Prd_Starttime { get; set; }
        public DateTime Prd_Endtime { get; set; }
        public DateTime Up_Date { get; set; }
        public int wo_Order { get; set; }
        public decimal PrdQty_Per_Hour { get; set; }
        public int Temp_Prd_Qty { get; set; }
        public string gv_code { get; set; }
        public long hist_seq { get; set; }
        public int bad_prd_qty { get; set; }
        public int good_prd_qty { get; set; }

    }

    public class POPWorkerSetVO
    {
        public string User_ID { get; set; }
        public string user_name { get; set; }
        public DateTime Allocation_date { get; set; }
        public DateTime Allocation_datetime { get; set; }
        public DateTime Release_datetime { get; set; }
        public string Workorderno { get; set; }
        public DateTime Plan_Endtime { get; set; }
        public string Wc_Code { get; set; }
        public int hist_seq { get; set; }
        public int Detail_Seq { get; set; }
    }
    public class POPQualityCheckVO
    {
        public string inspect_Code { get; set; }
        public string inspect_Name { get; set; }
        public string Process_code { get; set; }
        public decimal USL { get; set; }
        public decimal SL { get; set; }
        public decimal LSL { get; set; }
    }
    public class POPQuailtyItemVO
    {
        public long Inspect_measure_seq { get; set; }
        public string Item_code { get; set; }
        public string Process_code { get; set; }
        public string Inspect_code { get; set; }
        public DateTime Inspect_date { get; set; }
        public DateTime Inspect_datetime { get; set; }
        public decimal Inspect_val { get; set; }
        public string Workorderno { get; set; }
        public DateTime Ins_Date { get; set; }
        public string Ins_Emp { get; set; }
        public DateTime Up_Date { get; set; }
        public string Up_Emp { get; set; }
    }
    public class CarListVO
    {
        public int Status_Seq { get; set; }
        public string gv_name { get; set; }
        public string gv_code { get; set; }
        public int gv_qty { get; set; }
        public int gv_rest_qty { get; set; }
        public string workorderno { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string item_unit { get; set; }
        public string Wo_Req_No { get; set; }
        public int Req_Seq { get; set; }
        public int Shot_Per_Qty { get; set; }
        public int Line_Per_Qty { get; set; }
    }
}
