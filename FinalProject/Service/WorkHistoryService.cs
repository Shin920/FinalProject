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
    public class WorkHistoryService
    {
        /// <summary>
        /// 근무자들의 근무 이력 조회
        /// </summary>
        /// <param name="begDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<WorkHistoryVO_Simple> GetWorkHistory(string begDate, string endDate)       //근무자들의 근무이력 조회
        {
            WorkHistoryDAC dac = new WorkHistoryDAC();
            List<WorkHistoryVO_Simple> list = dac.GetWorkHistory(begDate, endDate);
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 근무자ID와 근무자명 목록만 조회
        /// </summary>
        /// <returns></returns>
        public List<UserVO> GetUserSmallList()       //근무자ID와 근무자명 목록만 조회
        {
            WorkHistoryDAC dac = new WorkHistoryDAC();
            List<UserVO> list = dac.GetUserSmallList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 근무자의 일별 근무정보 조회(Pivot)
        /// </summary>
        /// <param name="begDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        //public List<WorkHistoryVO> GetWorkerHistoryPivot(string begDate, string endDate)       //근무자의 일별 근무정보 조회(Pivot)
        //{
        //    WorkHistoryDAC dac = new WorkHistoryDAC();
        //    List<WorkHistoryVO> list = dac.GetWorkerHistoryPivot(begDate, endDate);
        //    dac.Dispose();

        //    return list;
        //}
        public DataTable GetWorkerHistoryPivot(string begDate, string endDate)       //근무자의 일별 근무정보 조회(Pivot)
        {
            WorkHistoryDAC dac = new WorkHistoryDAC();
            DataTable list = dac.GetWorkerHistoryPivot(begDate, endDate);
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 특정 근무자의 일자별 상세근무내역
        /// </summary>
        /// <param name="prdDate"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<WorkHistoryVO> GetWorkerDetailHistory(string prdDate, string userID)       //특정 근무자의 일자별 상세근무내역
        {
            WorkHistoryDAC dac = new WorkHistoryDAC();
            List<WorkHistoryVO> list = dac.GetWorkerDetailHistory(prdDate, userID);
            dac.Dispose();

            return list;
        }
    }
}
