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
    public class WorkOrderService
    {
        /// <summary>
        /// 기간 내 실적조회
        /// </summary>
        /// <param name="begDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<WorkOrderVO> GetWorkOrderHistory(string begDate, string endDate)        //기간 내 실적조회
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            List<WorkOrderVO> list = dac.GetWorkOrderHistory(begDate, endDate);
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 실적보정
        /// </summary>
        /// <param name="prdQty"></param>
        /// <param name="workOrderCode"></param>
        /// <returns></returns>
        public bool UpdatePrdQty(string prdQty, string workOrderCode)        //실적보정
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.UpdatePrdQty(prdQty, workOrderCode);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 팔레트 마감폼에서의 기간 내 실적조회
        /// </summary>
        /// <param name="begDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<WorkOrderVO> GetWorkOrderHistoryInPallete(string begDate, string endDate)        //팔레트 마감폼에서의 기간 내 실적조회
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            List<WorkOrderVO> list = dac.GetWorkOrderHistoryInPallete(begDate, endDate);
            dac.Dispose();

            return list;
        }

        public List<WorkOrderVO> GetDailyWorkOrder()        //메인화면 용 당일 작업진행중인 목록
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            List<WorkOrderVO> list = dac.GetDailyWorkOrder();
            dac.Dispose();

            return list;
        }

        public DataTable GetUserDailyWorkOrder(string userId)        //사용자의 당일 할당작업 목록
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            DataTable dt = dac.GetUserDailyWorkOrder(userId);
            dac.Dispose();

            return dt;
        }

        public List<WorkOrderVO> GetWorkOrderList()        // 작업지시 목록조회
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            List<WorkOrderVO> list = dac.GetWorkOrderList();
            dac.Dispose();

            return list;
        }

        public List<WorkOrderVO> SearchWorkOrderList(string begDate, string endDate)        // 작업지시 목록조회
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            List<WorkOrderVO> list = dac.SearchWorkOrderList(begDate, endDate);
            dac.Dispose();

            return list;
        }

        public bool InsertWorkOrder(string workReqNo, string woNo, string code, string wcode, int pqty, string punit, DateTime date, int rseq, string remark, string emp)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.InsertWorkOrder(workReqNo, woNo, code, wcode, pqty, punit, date, rseq, remark, emp);
            dac.Dispose();

            return result;
        }
        public bool UpdateWorkOrder(WorkOrderVO no)       //작업지시 수정
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.UpdateWorkOrder(no);
            dac.Dispose();

            return result;
        }

        public bool FinishWorkOrder(string code)       //작업지시 마감
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.FinishWorkOrder(code);
            dac.Dispose();

            return result;
        }
        public bool CancelFinish(string code)       //작업지시 마감
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.CancelFinish(code);
            dac.Dispose();

            return result;
        }

        public bool SetClose(string workorderno, string managerid, string wc_code) // 마감시 실행
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.SetClose(workorderno, managerid, wc_code);
            dac.Dispose();

            return result;
        }


        public bool SetWoOrder7(string workOrderNum)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.SetWoOrder7(workOrderNum);
            dac.Dispose();

            return result;
        }

        public DataTable GetbyTime()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            DataTable dt = dac.GetbyTime();
            dac.Dispose();

            return dt;
        }

        public string GetUserID(string wcode)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            string id = dac.GetUserID(wcode);
            dac.Dispose();

            return id;
        }
    }
}