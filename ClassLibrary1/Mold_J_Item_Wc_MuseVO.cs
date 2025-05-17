using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class Mold_J_Item_Wc_MuseVO
    {
        public DateTime Prd_Date { get; set; } //생산일자
        public string Mold_Code { get; set; } //금형코드
        public string Mold_Name { get; set; } //금형명
        public string Workorderno { get; set; } //작업지시번호
        public string Item_Code { get; set; } //품목코드
        public string Item_Name { get; set; } //품목명
        public string Wc_Code { get; set; } //작업장코드
        public string Wc_Name { get; set; } //작업장이름
        public int Mold_Shot_Cnt { get; set; } //금형타수
        public int Mold_Prd_Qty { get; set; } //금형생산량
        public DateTime Use_Starttime { get; set; } //금형사용시작시간
        public DateTime Use_Endtime { get; set; } //금형사용종료시간
        public int Use_Seq{ get; set; } //사용순번
        public DateTime Ins_Date { get; set; }//최초입력일자
        public string Ins_Emp { get; set; }//최초입력자
        public DateTime Up_Date { get; set; }//최초수정일자
        public string p_Emp { get; set; }//최종수정자
        public DateTime Last_Setup_Time { get; set; }

     
    }
}
