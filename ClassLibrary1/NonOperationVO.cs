using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class NonOperationVO
    {
        //public DataTable NopList { get; set; }  //비가동 대분류 목록 데이터테이블
        //public DataTable NopDeatilList { get; set; }    //비가동 상세분류 목록 데이터테이블
        public long Nop_Seq { get; set; } //발생순번
        public DateTime Nop_Date { get; set; }    //발생일자
        public DateTime Nop_Happentime { get; set; }  //발생일시
        public DateTime Nop_Canceltime { get; set; }  //해제일시
        public string Wc_Code { get; set; } //작업장코드
        public string Wc_Name { get; set; } //작업장이름
        public string Nop_Mi_Code { get; set; }     //비가동상세분류코드
        public string Nop_Type { get; set; }    //발생유형
        public decimal Nop_Time { get; set; }    //비가동시간
        public string Remark { get; set; }      //비고
        public DateTime Ins_Date { get; set; }    //최초입력일자
        public string Ins_Emp { get; set; }   //최초입력자
        public DateTime Up_Date { get; set; } //최종수정일자
        public string Up_Emp { get; set; }  //최종수정자
        public string Nop_Ma_Code { get; set; } //비가동대분류코드
        public string Nop_Ma_Name { get; set; } //비가동대분류명
        public string Use_YN { get; set; }       //사용여부
        public string Nop_Mi_Name { get; set; }    //비가동상세분류명


    }
}
