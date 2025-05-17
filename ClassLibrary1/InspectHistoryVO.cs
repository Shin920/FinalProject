using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class InspectHistoryVO
    {
        public long Inspect_measure_seq { get; set; } // 검사순번
        public string Item_code { get; set; }               // 품목코드
        public string Process_code { get; set; }           // 공정코드
        public string Inspect_code { get; set; }           // 항목코드
        public DateTime Inspect_date { get; set; }            // 측정일자
        public DateTime Inspect_datetime { get; set; }      // 측정일시
        public decimal Inspect_val { get; set; }              // 측정값
        public string Workorderno { get; set; }           // 작업지시번호
        public string Ins_Date { get; set; }                // 최초입력일자
        public string Ins_Emp { get; set; }                // 최초입력자
        public string Up_Date { get; set; }                // 최초수정일자
        public string Up_Emp { get; set; }                // 최초수정자
    }

    public class InspectMeasureHistoryVO //건조
    {
        public string Workorderno { get; set; } //작업지시번호
        public string GV_Code { get; set; } 
        public DateTime Ins_Date { get; set; } 
        public DateTime Unloading_datetime { get; set; } 
        public DateTime f { get; set; } 
        public DateTime Unloading_date { get; set; } 
        public string Unloading_wc { get; set; } 
   
    }
}
