using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class WorkReqVO
    {
        
        public string Wo_Req_No { get; set; } // 생산의뢰번호

        public int Req_Seq { get; set; } // 의뢰순번

        public string Item_Code { get; set; } // 품목코드

        public string Item_Name { get; set; } // 품목이름

        public int Req_Qty { get; set; } // 의뢰수량

        public DateTime Prd_Plan_Date { get; set; } // 생산완료예정일

        public string Cust_Name { get; set; } // 거래처명

        public string Project_Name { get; set; } // 프로젝트명

        public string Sale_Emp { get; set; } // 영업담당

        public string Req_Status { get; set; } // 의뢰상태

        public DateTime Ins_Date { get; set; } // 최초입력일자

        public string Ins_Emp { get; set; } // 최초입력자

        public DateTime Up_Date { get; set; } // 최종수정일자

        public string MyProperty { get; set; } // 최종수정자

        public string Item_Unit { get; set; } // 품목단위

    }
}
