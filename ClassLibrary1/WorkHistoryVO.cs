using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class WorkHistoryVO
    {
        public int Work_Seq { get; set; } //이력순번
        public DateTime Work_Date { get; set; }//근무일자
        public string Process_Code { get; set; }//공정코드
        public string User_ID { get; set; } //사용자ID
        public DateTime Work_StartTime { get; set; } //근무시작시간
        public DateTime Work_EndTime { get; set; } //근무종료시간
        public decimal Work_Time { get; set; } //근무시간
        public string Work_type { get; set; }//휴무구분
        public string Remark { get; set; } //비고
        public DateTime Ins_Date { get; set; }//최초입력일자
        public string Ins_Emp { get; set; } //최초입력자
        public DateTime Up_Date { get; set; } //최종수정일자
        public string Up_Emp { get; set; } //최종수정자
        public string User_Name { get; set; }   //사용자명
        public string Wc_Name { get; set; }   //작업장명
        public int Hist_Seq { get; set; } //이력순번    int

        public string Workorderno { get; set; } //작업지시번호
        public string Item_Code { get; set; } //품목코드
        public string Item_Name { get; set; } //품목명
        public string Wc_Code { get; set; } //작업장코드     
        public DateTime Prd_Date { get; set; } //생산일자
        public string Wo_Status { get; set; } //작업지시상태
        public DateTime Prd_Starttime { get; set; }//작업시작시간
        public DateTime Prd_Endtime { get; set; } //작업종료시간
        public int Prd_Qty { get; set; }//생산수량




    }

  

    public class WorkHistoryVO_Simple
    {
        public DateTime Work_Date { get; set; }//근무일자
        public string User_ID { get; set; } //사용자ID
        public DateTime Work_StartTime { get; set; } //근무시작시간
        public DateTime Work_EndTime { get; set; } //근무종료시간
        public decimal Work_Time { get; set; } //근무시간

        public string Wc_Name { get; set; } //사용자ID
        public string User_Name { get; set; } //사용자ID


    }
}
