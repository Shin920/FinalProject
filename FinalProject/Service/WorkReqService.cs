using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service
{
    public class WorkReqService
    {
        public List<WorkReqVO> GetWorkReqList()    //생산의뢰 목록을 가져온다
        {
            WorkReqDAC dac = new WorkReqDAC();
            List<WorkReqVO> list = dac.GetWorkReqList();
            dac.Dispose();

            return list;
        }

        public List<WorkReqVO> SearchWorkReqList(string begDate, string endDate)    //생산의뢰 목록을 가져온다
        {
            WorkReqDAC dac = new WorkReqDAC();
            List<WorkReqVO> list = dac.SearchWorkReqList(begDate, endDate);
            dac.Dispose();

            return list;
        }

        public bool FinishWorkReq(string code)
        {
            WorkReqDAC dac = new WorkReqDAC();
            bool result = dac.FinishWorkReq(code);
            dac.Dispose();

            return result;
        }
    }
}
