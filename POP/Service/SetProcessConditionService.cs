using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectDAC;

namespace POP.Service
{
    public class SetProcessConditionService
    {
        /// <summary>
        /// 공정조건목록 조회
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="wc_Code"></param>
        /// <returns></returns>
        public List<POPProcessConditionVO> GetProcessConditionList(string itemCode, string wc_Code)
        {
            POPProcessConditionDAC dac = new POPProcessConditionDAC();
            List<POPProcessConditionVO> list = dac.GetProcessConditionList(itemCode, wc_Code);
            dac.Dispose();
            return list;
        }
        /// <summary>
        /// 측정코드 별 측정된 공정조건 항목조회
        /// </summary>
        /// <param name="condition_Code"></param>
        /// <param name="itemCode"></param>
        /// <param name="wc_Code"></param>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        internal List<POPMesuredConditionVO> GetMeasuredCondition(string condition_Code,  string itemCode, string wc_Code, string workorderno)
        {
            POPProcessConditionDAC dac = new POPProcessConditionDAC();
            List<POPMesuredConditionVO> list = dac.GetMeasuredCondition(condition_Code, itemCode, wc_Code, workorderno);
            dac.Dispose();
            return list;
        }
        /// <summary>
        /// 공정조건 등록
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
        internal bool InsertConditionValue(POPMesuredConditionVO mc)
        {
            POPProcessConditionDAC dac = new POPProcessConditionDAC();
            bool result = dac.InsertConditionValue(mc);
            dac.Dispose();
            return result;
        }
        /// <summary>
        /// 공정조건 업데이트
        /// </summary>
        /// <param name="condition_measure_seq"></param>
        /// <param name="Condition_Val"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        internal bool UpdateConditionValue(string condition_measure_seq, string Condition_Val, string managerid)
        {
            POPProcessConditionDAC dac = new POPProcessConditionDAC();
            bool result = dac.UpdateConditionValue(condition_measure_seq, Condition_Val, managerid);
            dac.Dispose();
            return result;
        }
        /// <summary>
        /// 공정조건 삭제
        /// </summary>
        /// <param name="condition_measure_seq"></param>
        /// <returns></returns>
        internal bool DeleteConditionValue(string condition_measure_seq)
        {
            POPProcessConditionDAC dac = new POPProcessConditionDAC();
            bool result = dac.DeleteConditionValue(condition_measure_seq);
            dac.Dispose();
            return result;
        }
        internal int IsConditionRegister(string wc_code, string item_code, string workorderno)
        {
            POPProcessConditionDAC dac = new POPProcessConditionDAC();
            int count = dac.IsConditionRegister(wc_code, item_code, workorderno);
            dac.Dispose();
            return count;
        }

        internal int IsInspectRegisterd(string workorderno)
        {
            POPProcessConditionDAC dac = new POPProcessConditionDAC();
            int count = dac.IsInspectRegisterd(workorderno);
            dac.Dispose();
            return count;
        }
    }
}
