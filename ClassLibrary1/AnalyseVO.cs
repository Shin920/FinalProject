using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class AnalyseVO
    {
        public string Item_Code { get; set; }

        public string Item_Name { get; set; }

        public DateTime In_Date { get; set; }

        public int In_Qty { get; set; }

        public int totQty { get; set; }
    }

    public class AnalysePrdVO
    {
        public string Process_Name { get; set; }    //공정명

        public string Wc_Name { get; set; }     //작업장명

        public string Item_Name { get; set; }       //품목명

        public int Past_Plan_Qty { get; set; }      //전월목표량

        public int Past_Prd_Qty { get; set; }       //전월생산량

        public int Past_Prd_Time { get; set; }      //전월생산시간

        public Decimal Past_Goal_Rate { get; set; }     //전월달성률

        public int This_Goal_Qty { get; set; }      //당월 목표량

        public int This_Prd_Qty { get; set; }        //당월 생산량

        public int This_Prd_Hour { get; set; }      //당월 생산시간

        public Decimal This_Goal_Rate { get; set; }     //당월 달성률

        public int Plus_Minus { get; set; }     //전월대비 증감량
    }
}
