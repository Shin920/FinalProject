using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class DefectiveVO
    {
        public string Workorderno { get; set; }     //작업지시번호
        public int Def_Seq { get; set; }//불량순번
        public string Def_Mi_Code { get; set; }//불량현상상세분류코드
        public DateTime Def_Date { get; set; }//발생일시
        public int Def_Qty { get; set; }//불량수량
        public string Def_Image_Name { get; set; }//불량사진명
        public string Def_Image_Path { get; set; }//불량사진경로
        public byte[] Def_Image_Binary { get; set; }//불량사진 바이너리
        public DateTime Ins_Date { get; set; }//최초입력일자
        public string Ins_Emp { get; set; }//최초입력자
        public DateTime Up_Date { get; set; }//최종수정일자
        public string Up_Emp { get; set; }//최종수정자
        public string Def_Ma_Code { get; set; }//불량현상대분류코드
        public string Def_Ma_Name { get; set; }//불량현상대분류명
        public string Use_YN { get; set; }//사용여부      
        public string Def_Mi_Name { get; set; }//불량현상상세분류명      
        public string Remark { get; set; } //비고      
        public string Item_Code { get; set; } //품목코드
        public string Item_Name { get; set; } //품목명
        public string Wc_Name { get; set; } //작업장명
        public string Wc_Code { get; set; }//작업장코드
        public DateTime Prd_Date { get; set; }//생산일자
        public string Wo_Status { get; set; } //작업지시상태
        public int Prd_Qty { get; set; } //생산수량
        public int Bad_Prd_Qty { get; set; } //불량수량



    }
}
