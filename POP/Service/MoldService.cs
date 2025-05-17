using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Service
{
    public class MoldService
    {
        internal List<MoldVO> GetCanSetMoldList()
        {
            MoldDAC dac = new MoldDAC();
            List<MoldVO>  list = dac.GetCanSetMoldList();
            dac.Dispose();
            return list;
        }

        internal List<MoldVO> GetSettedMoldList(string workOrderNo)
        {
            MoldDAC dac = new MoldDAC();
            List<MoldVO> list = dac.GetSettedMoldList(workOrderNo);
            dac.Dispose();
            return list;
        }

        internal bool SetMold(string mold, string manager, string workOrderNO, string wc_Code)
        {
            MoldDAC dac = new MoldDAC();
            bool result = dac.SetMold(mold, manager, workOrderNO, wc_Code);
            dac.Dispose();
            return result;
        }

        internal bool UnSetMold(string mold, string manager, string workOrderNO)
        {
            MoldDAC dac = new MoldDAC();
            bool result = dac.UnSetMold(mold, manager, workOrderNO);
            dac.Dispose();
            return result;
        }

        internal int IsMoldSetted(string workOrderNo)
        {
            MoldDAC dac = new MoldDAC();
            int count = dac.IsMoldSetted(workOrderNo);
            dac.Dispose();
            return count;
        }

        internal bool UpdateMoldPrd(string workorderno, int good, int bad, string managerid, List<MoldVO> moldList)
        {
            MoldDAC dac = new MoldDAC();
            bool result = dac.UpdateMoldPrd(workorderno, good, bad, managerid, moldList);
            dac.Dispose();
            return result;
        }
    }
}
