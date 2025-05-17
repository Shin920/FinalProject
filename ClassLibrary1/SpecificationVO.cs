using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class SpecificationVO
    {

       public string Item_Code { get; set; }//품목코드
        public string Item_Name { get; set; }//품목명
        public string Process_code { get; set; }//공정코드
        public string Process_name { get; set; }    //공정명
        public string Process_Name { get; set; }    //공정명
        public string Wc_Code { get; set; }    //작업장 코드
        public string Wc_Name { get; set; }    //작업장명
        public string Inspect_code { get; set; } //항목코드
        public string Inspect_name { get; set; } //검사항목명
        public string Spec_Desc { get; set; } //Spec Desc
        public decimal USL { get; set; }   //규격상한값
        public decimal SL { get; set; } //규격기준값
        public decimal LSL { get; set; }     //규격하한값
        public int Sample_size { get; set; }//샘플크기
        public string Inspect_Unit { get; set; }    //단위
        public string Use_YN { get; set; }  //사용여부
        public string Remark { get; set; } //비고
        public DateTime Ins_Date { get; set; }   //최초입력일자
        public string Ins_Emp { get; set; } //최초입력자
        public DateTime Up_Date { get; set; }//최종수정일자
        public string Up_Emp { get; set; }  //최종수정자

        public string New_Item_Code { get; set; }   //내가 필요해서 만든것. copy할때 복사한걸 추가할 품목코드
        public string New_Inspect_code { get; set; }
        public int cntVal { get; set; } //측정횟수
        public decimal avgVal { get; set; } //평균값

        public string Workorderno { get; set; }
        public DateTime Prd_Date { get; set; }
        public DateTime Inspect_date { get; set; }

        public decimal Inspect_val { get; set; }
    }
}
