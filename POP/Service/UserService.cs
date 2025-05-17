using ClassLibrary1;
using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP
{
    public class UserService
    {
        /// <summary>
        /// 로그인 체크
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        /// <returns>UserVO</returns>
        public UserVO GetUserIDName(string id, string pw)
        {
            UserDAC dac = new UserDAC();
            UserVO user = dac.GetUserIDName(id, pw);
            dac.Dispose();
            return user;
        }
        
        /// <summary>
        /// 할당 가능한 모든 인원 조회
        /// </summary>
        /// <param name="workOrderNo"></param>
        /// <returns></returns>
        public List<POPWorkerSetVO> GetCanAllocateWorkers(string wcCode, string workOrderNo)
        {
            UserDAC dac = new UserDAC();
            List<POPWorkerSetVO> list = dac.GetCanAllocateWorkers(wcCode, workOrderNo);
            dac.Dispose();
            return list;
        }
        public List<POPWorkerSetVO> GetAllocatedWorkers(string wcCode, string workOrderNo)
        {
            UserDAC dac = new UserDAC();
            List<POPWorkerSetVO> list = dac.GetAllocatedWorkers(wcCode, workOrderNo);
            dac.Dispose();
            return list;
        }

        internal bool SetWorker(string worker, string manager, string workOrderNo)
        {
            UserDAC dac = new UserDAC();
            bool result = dac.SetWorker(worker, manager, workOrderNo);
            dac.Dispose();
            return result;
        }

        internal bool UnAllocateWorkers(string worker, string managerid,  string allocationdate, string hist_Seq, string detail_Seq, string wc_code)
        {
            UserDAC dac = new UserDAC();
            bool result = dac.UnAllocateWorkers(worker, managerid, allocationdate,hist_Seq,detail_Seq, wc_code);
            dac.Dispose();
            return result;
        }

        internal bool UnAllocateWorkers(List<UnAllocateVO> list, string managerid, string wc_code)
        {
            UserDAC dac = new UserDAC();
            bool result = dac.UnAllocateWorkers(list, managerid, wc_code);
            dac.Dispose();
            return result;
        }

        internal bool UpdateUserPrd(string workorderno, int goodqty, string managerid)
        {
            UserDAC dac = new UserDAC();
            bool result = dac.UpdateUserPrd(workorderno, goodqty, managerid);
            dac.Dispose();
            return result;
        }
    }
}
