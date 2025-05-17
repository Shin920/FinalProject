using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service
{
    public class AnalyseService
    {
        public List<AnalyseVO> GetPkgMonthly(string mon)    //생산의뢰 목록을 가져온다
        {
            AnalyseDAC dac = new AnalyseDAC();
            List<AnalyseVO> list = dac.GetPkgMonthly(mon);
            dac.Dispose();

            return list;
        }

        public List<AnalysePrdVO> GetPrdMonthly(string mon)      //월별 생산 조회
        {
            AnalyseDAC dac = new AnalyseDAC();
            List<AnalysePrdVO> list = dac.GetPrdMonthly(mon);
            dac.Dispose();

            return list;
        }
    }
}
