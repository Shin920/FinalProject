using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class Goods_In_HistoryVO
    {
        public long Num { get; set; }              // 순번
        public string Workorderno { get; set; }   // 작업지시번호
        public string GV_Code { get; set; }     // 대차코드
        public DateTime Prd_Date { get; set; }     // 생산
        public string Item_Name { get; set; }     // 품목명
        public string Remark { get; set; }        // 비고
        public string Prd_Endtime { get; set; } // 작업마감시간
    }
    public class Goods_In_HistoryPackageVO // 포장작업일지리포트
    {
        public long Num { get; set; }              // 순번
        public string Workorderno { get; set; }   // 작업지시번호
        public string Pallet_No { get; set; }     // 팔레트번호
        public DateTime In_Date { get; set; }     // 입고일자
        public string Item_Name { get; set; }     // 품목명
        public string Remark { get; set; }        // 비고
        public string Prd_Endtime { get; set; } // 작업마감시간
    }
}
