using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class BoxingVO
    {
        public string Workorderno { get; set; }//작업지시번호
        public string Pallet_No { get; set; } //팔레트번호
        public int Barcode_No { get; set; } //바코드번호
        public DateTime In_Date { get; set; }//입고일자
        public string Grade_Code { get; set; }//등급
        public string Grade_Detail_Code { get; set; }//포장등급상세코드
        public string Size_Code { get; set; }//사이즈
        public string Size_Name { get; set; }
        public string Grade_Detail_Name { get; set; } //등급상세명
        public string Boxing_Grade_Code { get; set; } //포장등급
        public int In_Qty { get; set; } //생산수량
        public string Upload_Flag { get; set; }//ERP인터페이스여부
        public string Update_YN { get; set; } //수정여부
        public int F_In_Qty { get; set; }//최초생산수량
        public DateTime Closed_Time { get; set; } //마감시간
        public DateTime Cancel_Time { get; set; }//취소시간
        public DateTime Print_Date { get; set; } //바코드발행일시

        public string Use_YN { get; set; } //사용여부
        public string In_YN { get; set; }//입고여부
        public string Remark { get; set; }//비고
        public DateTime Ins_Date { get; set; }//최초입력일자
        public string Ins_Emp { get; set; } //최초입력자
        public DateTime Up_Date { get; set; } //최종수정일자
        public string Up_Emp { get; set; } //최종수정자
        public DateTime Prd_Date { get; set; }//생산일자
        public string Wo_Status { get; set; }//작업지시상태
        public string Item_Code { get; set; }//품목코드
        public string Item_Name { get; set; }//품목명
        public int Prd_Qty { get; set; }//적재가능수량
        public int Load_Qty { get; set; }   //적재되어있는 수량
        public int Tot_Qty { get; set; }   //적재되어있는 수량
        public int Rest_Qty { get; set; }   //적재되어있는 수량
        public int Seq { get; set; }    //팔레트 일련번호


    }

    
         public class BoxingVO_Finish
    {
        public string Workorderno { get; set; }//작업지시번호
        public string Pallet_No { get; set; } //팔레트번호
        public int Barcode_No { get; set; } //바코드번호
        //public DateTime In_Date { get; set; }//입고일자
       
        //public string Grade_Detail_Name { get; set; } //등급상세명
        //public string Boxing_Grade_Code { get; set; } //포장등급
        public int In_Qty { get; set; } //생산수량
        public string Upload_Flag { get; set; }//ERP인터페이스여부
       
     
        public DateTime Closed_Time { get; set; } //마감시간
        public DateTime Cancel_Time { get; set; }//취소시간   
      
        public DateTime Prd_Date { get; set; }//생산일자
        public string Wo_Status { get; set; }//작업지시상태
        public string Item_Code { get; set; }//품목코드
        public string Item_Name { get; set; }//품목명
        //public int Prd_Qty { get; set; }//적재가능수량
        //public int Load_Qty { get; set; }   //적재되어있는 수량
        //public int Tot_Qty { get; set; }   //적재되어있는 수량
        //public int Rest_Qty { get; set; }   //적재되어있는 수량
        //public int Seq { get; set; }    //팔레트 일련번호


    }
    public class BoxingVO_Info
    {
        
        public string Pallet_No { get; set; } //팔레트번호
        
        public string Grade_Code { get; set; }//등급
        public string Grade_Detail_Code { get; set; }//포장등급상세코드      
        public string Grade_Detail_Name { get; set; } //등급상세명
       
        public int In_Qty { get; set; } //생산수량
        public string Upload_Flag { get; set; }//ERP인터페이스여부
         
        public string In_YN { get; set; }//입고여부
      
       


    }
}
