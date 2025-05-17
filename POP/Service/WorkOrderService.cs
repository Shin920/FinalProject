using ClassLibrary1;
using FinalProjectDAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Service
{
    public class WorkOrderService
    {
        /// <summary>
        /// 모든 작업지시 가져오기
        /// </summary>
        /// <returns></returns>
        public List<POPWorkVO> GetAllWorkODList(string Case)
        {
            POPWorkDAC dac = new POPWorkDAC();
            List<POPWorkVO> list = dac.GetAllWorkODList(Case);
            dac.Dispose();
            return list;
        }
        /// <summary>
        /// 작업지시생성 대상 적재대차 목록 가져오기
        /// </summary>
        /// <param name="inputCase"></param>
        /// <returns></returns>
        internal List<CarListVO> GetLoadedCarList(string inputCase)
        {
            POPWorkDAC dac = new POPWorkDAC();
            List<CarListVO> list = dac.GetLoadedCarList(inputCase);
            dac.Dispose();
            return list;
        }

        /// <summary>
        /// 작업지시 정보 가져오기
        /// </summary>
        /// <param name="workOrderNO"></param>
        /// <returns></returns>
        public POPWorkVO GetWorkOrderDetail(string workOrderNO)
        {
            POPWorkDAC dac = new POPWorkDAC();
            POPWorkVO wo = dac.GetWorkOrderDetail(workOrderNO);
            dac.Dispose();
            return wo;
        }
        /// <summary>
        /// 작업시작
        /// </summary>
        /// <param name="workOrderNo"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        public bool OrderStart(string workOrderNo, string managerid, List<POPWorkerSetVO> list)
        {
            POPWorkDAC dac = new POPWorkDAC();
            bool result = dac.OrderStart(workOrderNo, managerid, list);
            dac.Dispose();
            return result;
        }
        /// <summary>
        /// 팔레트 생성이 완료된 수량
        /// </summary>
        /// <param name="workOrderNO"></param>
        /// <returns></returns>
        internal int GetRemainQty(string workOrderNO)
        {
            POPWorkDAC dac = new POPWorkDAC();
            int count = dac.GetRemainQty(workOrderNO);
            dac.Dispose();
            return count;
        }

        /// <summary>
        /// 기계시작
        /// </summary>
        /// <param name="workOrderNO"></param>
        /// <param name="managerid"></param>
        /// <param name="prd_Qty"></param>
        /// <param name="gv_Code"></param>
        /// <returns></returns>
        internal bool StartMachine(string workOrderNO, string managerid, int prd_Qty, string gv_Code)
        {
            POPWorkDAC dac = new POPWorkDAC();
            bool result = dac.StartMachine(workOrderNO, managerid, prd_Qty, gv_Code);
            dac.Dispose();
            return result;
        }

        /// <summary>
        /// 기계종료
        /// </summary>
        /// <param name="workOrderNO"></param>
        /// <param name="managerid"></param>
        /// <param name="goodQty"></param>
        /// <param name="BadQty"></param>
        /// <returns></returns>
        internal bool StopMachine(string workOrderNO, string managerid, int goodQty, int BadQty)
        {
            //생산수량 최종수정일자, 최종수정자, 작업순서, 작업종료시간
            //where workorderno = @workorderno
            POPWorkDAC dac = new POPWorkDAC();
            bool result = dac.StopMachine(workOrderNO, managerid, goodQty, BadQty);
            dac.Dispose();
            return result;
        }
        /// <summary>
        /// 작업상태 WO_01로 변경
        /// </summary>
        /// <param name="workorderno"></param>
        /// <param name="managerid"></param>
        /// <returns></returns>
        internal bool SetWostate03(string workorderno, string managerid, string inputcase, List<POPWorkerSetVO> list)
        {
            POPWorkDAC dac = new POPWorkDAC();
            bool result = dac.SetWostate03(workorderno, managerid, inputcase, list);
            dac.Dispose();
            return result;
        }
        /// <summary>
        /// 측정항목 리스트
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="wc_Code"></param>
        /// <returns></returns>
        internal List<POPQualityCheckVO> GetQualityCheckList(string itemCode, string wc_Code)
        {
            POPWorkDAC dac = new POPWorkDAC();
            List<POPQualityCheckVO> list = dac.GetQualityCheckList(itemCode, wc_Code);
            dac.Dispose();
            return list;
        }

        internal List<POPQuailtyItemVO> GetQualityInfo(string itemCode, string processCdoe, string workOrderNO)
        {
            POPWorkDAC dac = new POPWorkDAC();
            List<POPQuailtyItemVO> list = dac.GetQualityInfo(itemCode, processCdoe, workOrderNO);
            dac.Dispose();
            return list;
        }

        internal bool SetWoOrder3(string workorderno, string managerid)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.SetWoOrder3(workorderno, managerid);
            dac.Dispose();
            return result;
        }

        internal bool InsertInspectValue(POPQuailtyItemVO qi, string managerid)
        {
            POPWorkDAC dac = new POPWorkDAC();
            bool result = dac.InsertInspectValue(qi, managerid);
            dac.Dispose();
            return result;
        }
        /// <summary>
        /// 작업지시 생성
        /// </summary>
        /// <param name="newOrderno"></param>
        /// <param name="oldOrderno"></param>
        /// <param name="item_code"></param>
        /// <param name="wc_code"></param>
        /// <param name="qty"></param>
        /// <param name="unit"></param>
        /// <param name="managerid"></param>
        /// <param name="process_code"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        internal bool CreateWorkOrder(string newOrderno, string oldOrderno, string item_code, string wc_code, int qty, string unit, string managerid, string process_code, string date, int Status_Seq, string GV_Code, string inputCase)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.CreateWorkOrder(newOrderno, oldOrderno, item_code, wc_code, qty, unit, managerid, process_code, date, Status_Seq, GV_Code, inputCase);
            dac.Dispose();
            return result;
        }

        internal bool RegLoadPerformance(string workOrderNO, string managerid, int qty)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.RegLoadPerformance(workOrderNO, managerid, qty);
            dac.Dispose();
            return result;
        }

        internal bool UpdateInspectValue(string inspect_measure_seq, string val, string managerid)
        {
            POPWorkDAC dac = new POPWorkDAC();
            bool result = dac.UpdateInspectValue(inspect_measure_seq,val, managerid);
            dac.Dispose();
            return result;
        }

        internal bool DeleteInspectValue(string inspect_measure_seq)
        {
            POPWorkDAC dac = new POPWorkDAC();
            bool result = dac.DeleteInspectValue(inspect_measure_seq);
            dac.Dispose();
            return result;
        }

        internal bool SetClose(string workorderno, string managerid, string wc_code)
        {
            POPWorkDAC dac = new POPWorkDAC();
            bool result = dac.SetClose(workorderno, managerid, wc_code);
            dac.Dispose();
            return result;
        }

        internal int GetPrdQty(string workorderno)
        {
            POPWorkDAC dac = new POPWorkDAC();
            int prd_qty = dac.GetPrdQty(workorderno);
            dac.Dispose();
            return prd_qty;
        }
    }
}
