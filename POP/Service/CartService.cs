using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Service
{
    public class CartService
    {
        internal List<CartVO> GetFormingCarList()
        {
            CartDAC dac = new CartDAC();
            List<CartVO> list = dac.GetFormingCarList();
            dac.Dispose();
            return list;
        }

        internal List<CartVO> GetTargetCarList(string inputCase)
        {
            CartDAC dac = new CartDAC();
            List<CartVO> list = dac.GetTargetCarList(inputCase);
            dac.Dispose();
            return list;
        }
        /// <summary>
        /// 작업장조회
        /// </summary>
        /// <param name="inputCase"></param>
        /// <returns></returns>
        internal List<WorkCenterVO> GetCenterList(string inputCase)
        {
            CartDAC dac = new CartDAC();
            List<WorkCenterVO> list = dac.GetCenterList(inputCase);
            dac.Dispose();
            return list;
        }
        /// <summary>
        /// 공정리스트 조회
        /// </summary>
        /// <param name="inputCase"></param>
        /// <returns></returns>
        internal List<ProcessVO> GetProcessList(string inputCase)
        {
            CartDAC dac = new CartDAC();
            List<ProcessVO> list = dac.GetProcessList(inputCase);
            dac.Dispose();
            return list;
        }

        /// <summary>
        /// 사용 가능한 소성 대차 목록
        /// </summary>
        /// <returns></returns>
        internal List<CartVO> GetFiringCarList()
        {
            CartDAC dac = new CartDAC();
            List<CartVO> list = dac.GetFiringCarList();
            dac.Dispose();
            return list;
        }
        /// <summary>
        /// 작업지시번호로 적재되어있는 성형대차/건조대차 목록 조회
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        internal List<CartVO> GetOriginCarList(string workorderno, string inputCase)
        {
            CartDAC dac = new CartDAC();
            List<CartVO> list = dac.GetOriginCarList(workorderno, inputCase);
            dac.Dispose();
            return list;
        }

        internal bool CarLoadingUnloading(string managerid, string WorkOrderNO, string dry_Gv_Code, string origin_Gv_Code, int qty, int status_seq, long hist_seq, string inputCase)
        {
            CartDAC dac = new CartDAC();
            bool result = dac.CarLoadingUnloading(managerid, WorkOrderNO, dry_Gv_Code, origin_Gv_Code, qty, status_seq, hist_seq, inputCase);
            dac.Dispose();
            return result;
        }

        internal bool SetCartInOut(string gv_code, string hist_seq, string managerid, string inputCase)
        {
            CartDAC dac = new CartDAC();
            bool result = dac.SetCartInOut(gv_code, hist_seq, managerid, inputCase);
            dac.Dispose();
            return result;
        }

        internal bool VacateCar(string gv_code, int qty, string wc_code, string item_code, string hist_seq, string managerid, string workorderno, string reason = "기타")
        {
            CartDAC dac = new CartDAC();
            bool result = dac.VacateCar(gv_code, qty, wc_code, item_code, hist_seq, managerid,workorderno, reason);
            dac.Dispose();
            return result;
        }

        internal int GetUnOutCarCount(string workorderno)
        {
            CartDAC dac = new CartDAC();
            int result = dac.GetUnOutCarCount(workorderno);
            dac.Dispose();
            return result;
        }

        internal int GetRestDryCarListCount(string workorderno)
        {
            CartDAC dac = new CartDAC();
            int result = dac.GetRestDryCarListCount(workorderno);
            dac.Dispose();
            return result;
        }
    }
}
