using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Service
{
    public class BadProdService
    {
        internal List<Def_Ma_Master> GetDefMaList()
        {
            BadProdDAC dac = new BadProdDAC();
            List<Def_Ma_Master> list = dac.GetDefMaList();
            dac.Dispose();
            return list;
        }
        public DataTable GetDefMiList()
        {
            BadProdDAC dac = new BadProdDAC();
            DataTable dt = dac.GetDefMiList();
            dac.Dispose();
            return dt;
        }
        /// <summary>
        /// 불량수량 등록
        /// </summary>
        /// <param name="list"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        internal bool RegBadProdHistory(List<DefectiveVO> list, string managerid)
        {
            BadProdDAC dac = new BadProdDAC();
            bool result = dac.RegBadProdHistory(list, managerid);
            dac.Dispose();
            return result;
        }
    }
}
