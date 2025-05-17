using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class WorkOrderVO
    {
        public string Workorderno { get; set; } //작업지시번호
        public string Item_Code { get; set; } //품목코드
        public string Item_Name { get; set; } //품목명
        public string Wc_Code { get; set; } //작업장코드
        public string Wc_Name { get; set; } //작업장명
        public int Plan_Qty { get; set; } //계획수량
        public string Plan_Unit { get; set; }//계획수량단위
        public DateTime Plan_Date { get; set; } //계획일자
        public DateTime Prd_Date { get; set; } //생산일자
        public string Wo_Status { get; set; } //작업지시상태
        public int Wo_Order { get; set; } //작업순서
        public DateTime Plan_Starttime { get; set; } //계획시작시간
        public DateTime Plan_Endtime { get; set; } //계획종료시간
        public DateTime Prd_Starttime { get; set; } //작업시작시간
        public DateTime Prd_Endtime { get; set; } //작업종료시간
        public int In_Qty_Main { get; set; } //투입수량
        public int Out_Qty_Main { get; set; } //산출수량
        public int Prd_Qty { get; set; }//생산수량
        public string Prd_Unit { get; set; }//생산수량단위
        public DateTime Worker_CloseTime { get; set; } //현장마감시간
        public DateTime Manager_CloseTime { get; set; } //관리자마감시간
        public DateTime Close_CancelTime { get; set; } //마감취소시간
        public string Wo_Req_No { get; set; } //생산의뢰번호
        public int Req_Seq { get; set; }//의뢰순번
        public string Mat_LotNo { get; set; } //원자재Lot
        public string Remark { get; set; } //비고
        public DateTime Ins_Date { get; set; } //최초입력일자
        public string Ins_Emp { get; set; }//최초입력자
        public DateTime Up_Date { get; set; } //최종수정일자
        public string Up_Emp { get; set; }//최종수정자
        public string Process_Name { get; set; }    //공정명
        public string Process_code { get; set; }    //공정코드
        public string Using_Machine { get; set; }   //기계이름

    }
}
