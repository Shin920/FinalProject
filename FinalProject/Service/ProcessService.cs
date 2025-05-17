using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class ProcessService
    {
        /// <summary>
        /// 공정목록을 가져온다
        /// </summary>
        /// <returns></returns>
        public List<ProcessVO> GetProcessList()    //공정목록을 가져온다
        {
            ProcessDAC dac = new ProcessDAC();
            List<ProcessVO> list = dac.GetProcessList();
            dac.Dispose();

            return list;
        }

        public bool InsertProcess(string code, string name, string remark, string emp)       //공정정보 추가
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.InsertProcess(code, name, remark, emp);
            dac.Dispose();

            return result;
        }

        public bool DeleteProcess(string code)       //공정정보 삭제
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.DeleteProcess(code);
            dac.Dispose();

            return result;
        }

        public bool UpdateProcess(ProcessVO no)       //공정정보 수정 (건별 수정)
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.UpdateProcess(no);
            dac.Dispose();

            return result;
        }


        public bool UseYNSwap(string useYN, string code)    //특정 공정정보 사용여부를 변경
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.UseYNSwap(useYN, code);
            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 공정정보의 코드와 이름목록만 조회
        /// </summary>
        /// <returns></returns>
        public List<ProcessVO> GetProcessSmallList()      //공정정보의 코드와 이름목록만 조회
        {
            ProcessDAC dac = new ProcessDAC();
            List<ProcessVO> list = dac.GetProcessSmallList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 품목의 공정조건의 설정값을 가져온다
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public List<ProcessVO> GetProcessConditionList()      //품목의 공정조건의 설정값을 가져온다
        {
            ProcessDAC dac = new ProcessDAC();
            List<ProcessVO> list = dac.GetProcessConditionList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 공정조건 수정
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
        public bool UpdateProcCondition(ProcessVO pc)    //공정조건 수정
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.UpdateProcCondition(pc);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 공정조건 삭제
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="wcCode"></param>
        /// <param name="conditionCode"></param>
        /// <returns></returns>
        public bool DeleteProcCondition(ProcessVO pc)    //공정조건 삭제
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.DeleteProcCondition(pc);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 공정조건 추가
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
        public bool InsertProcCondition(ProcessVO pc)    //공정조건 추가
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.InsertProcCondition(pc);
            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 복사한 규격들을 품목에 추가
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int CopyProcCondition(List<ProcessVO> list)   //복사한 규격들을 품목에 추가
        {
            ProcessDAC dac = new ProcessDAC();
            int result = dac.CopyProcCondition(list);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 아직 공정조건을 등록하지 않은 작업지시의 목록을 가져온다
        /// </summary>
        /// <param name="begDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ProcessVO> GetNotClearWorkOrderList(string begDate, string endDate)      //관리자마감하지 않은 작업지시의 목록을 가져온다
        {
            ProcessDAC dac = new ProcessDAC();
            List<ProcessVO> list = dac.GetNotClearWorkOrderList(begDate, endDate);
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 작업지시 품목의 공정기본값 목록을 가져온다
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public List<ProcessVO> GetConditionSpecList(string itemCode, string wcCode)      //작업지시 품목의 공정기본값 목록을 가져온다
        {
            ProcessDAC dac = new ProcessDAC();
            List<ProcessVO> list = dac.GetConditionSpecList(itemCode, wcCode);
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 공정조건 값 추가
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
        public bool InsertNewConditionValue(ProcessVO pc)    //공정조건 값 추가
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.InsertNewConditionValue(pc);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 공정조건값 추가한 목록을 가져온다
        /// </summary>
        /// <param name="workOrderNum"></param>
        /// <returns></returns>
        public DataTable GetConditionValue(string workOrderNum, string conditionCode)      //공정조건값 추가한 목록을 가져온다
        {
            ProcessDAC dac = new ProcessDAC();
            DataTable dt = dac.GetConditionValue(workOrderNum, conditionCode);
            dac.Dispose();

            return dt;
        }
        /// <summary>
        /// 공정조건 값 삭제
        /// </summary>
        /// <param name="ConditionNum"></param>
        /// <returns></returns>
        public bool DeleteConditionValue(int rowNum, string workOrderNum)    //공정조건 값 삭제
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.DeleteConditionValue(rowNum, workOrderNum);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 마감된 작업지시의 공정조건 측정값에 대한 목록
        /// </summary>
        /// <param name="workOrderNum"></param>
        /// <param name="begDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ProcessVO> GetFinishedConditionValue(string begDate, string endDate)      //마감된 작업지시의 공정조건 측정값에 대한 목록
        {
            ProcessDAC dac = new ProcessDAC();
            List<ProcessVO> list = dac.GetFinishedConditionValue(begDate, endDate);
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 등록한 공정조건들의 목록
        /// </summary>
        /// <returns></returns>
        public List<ProcessVO> GetConditionList()       //등록한 공정조건들의 목록
        {
            ProcessDAC dac = new ProcessDAC();
            List<ProcessVO> list = dac.GetConditionList();
            dac.Dispose();

            return list;
        }
    }
}
