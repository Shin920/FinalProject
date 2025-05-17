using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class ProcessVO
    {
        public string Process_code { get; set; } //공정코드
        public string Process_name { get; set; } //공정명
        public string Process_Name { get; set; } //공정명
        public string Process_Group { get; set; } //공정그룹
        public string Use_YN { get; set; } //사용여부
        public string Remark { get; set; } //비고
        public DateTime Ins_Date { get; set; } //최초입력일자
        public string Ins_Emp { get; set; } //최초입력자
        public DateTime Up_Date { get; set; } //최종수정일자
        public string Up_Emp { get; set; }//최종수정자
        public string Item_Code { get; set; } //품목코드  
        public string Item_Name { get; set; } //품목명
        public string Wc_Code { get; set; } //작업장코드
        public string Wc_Name { get; set; } //작업장명
        public string Condition_Code { get; set; } //조건항목코드
        public string Condition_Name { get; set; } //조건항목명
        public string Spec_Desc { get; set; } //Spec Desc
        public decimal SL { get; set; }  //기준값
        public decimal USL { get; set; }     //상한값
        public decimal LSL { get; set; }     //하한값
        public string Condition_Unit { get; set; }  //조건단위
        public string Condition_Group { get; set; } //공정조건그룹      
        public int Condition_measure_seq { get; set; }   //조건순번
                                                         //public string Item_code { get; set; }  //품목코드   
        public DateTime Prd_Date { get; set; }  //생산일자
        public DateTime Condition_Date { get; set; }  //측정일자
        public DateTime Condition_Datetime { get; set; }  //측정일시
        public decimal Condition_Val { get; set; }   //측정값
        public string Workorderno { get; set; } //작업지시번호
        public string New_Item_Code { get; set; }   //복사한 공정이 입력될 품목코드
        public decimal avgConVal { get; set; }  //측정값의 평균

        public int cntConVal { get; set; }  //측정횟수



    }
}
