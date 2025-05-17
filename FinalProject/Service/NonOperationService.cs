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
    public class NonOperationService
    {
        /// <summary>
        /// 비가동 대분류 목록조회
        /// </summary>
        /// <returns>List<NonOperationVO></returns>
        public List<NonOperationVO> GetNonOperationGroupList()      //비가동 대분류 목록조회.
        {
            NonOperationDAC dac = new NonOperationDAC();
            List<NonOperationVO> list = dac.GetNonOperationGroupList();
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 비가동 대분류 추가
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="empName"></param>
        /// <returns></returns>
        public bool InsertNonOperation(string code, string name, string empName)       //비가동 대분류 추가
        {
            NonOperationDAC dac = new NonOperationDAC();
            bool result = dac.InsertNonOperation(code, name, empName);
            dac.Dispose();

            return result;
        }



        /// <summary>
        /// 비가동 대분류 삭제
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool DeleteNonOperation(string code)       //비가동 대분류 삭제
        {
            NonOperationDAC dac = new NonOperationDAC();
            bool result = dac.DeleteNonOperation(code);
            dac.Dispose();

            return result;
        }



        /// <summary>
        /// 특정 비가동 대분류/상세분류 사용여부를 변경
        /// isDetail 에 true를 입력하면 상세분류의 사용여부를 변경, false를 입력하면 대분류의 사용여부를 변경
        /// </summary>
        /// <param name="useYN"></param>
        /// <param name="code"></param>
        /// <param name="isDetail"></param>
        /// <returns></returns>
        public bool UseYNSwap(string useYN, string code, bool isDetail)    //특정 비가동 대분류 사용여부를 변경. 대분류/상세분류 둘다 쓰여서 상세분류인지를 bool 타입으로 입력하게
        {
            NonOperationDAC dac = new NonOperationDAC();
            bool result = dac.UseYNSwap(useYN, code, isDetail);
            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 비가동 상세분류 목록 조회
        /// </summary>
        /// <returns></returns>
        public List<NonOperationVO> GetNopOperationDetailList()     //비가동 상세분류 목록 조회
        {
            NonOperationDAC dac = new NonOperationDAC();
            List<NonOperationVO> list = dac.GetNopOperationDetailList();
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 비가동 상세분류 추가
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public bool InsertDetailNop(NonOperationVO no)       //비가동 상세분류 추가
        {
            NonOperationDAC dac = new NonOperationDAC();
            bool result = dac.InsertDetailNop(no);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 비가동 상세분류 수정
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public bool UpdateDetailNop(NonOperationVO no)       //비가동 상세분류 수정
        {
            NonOperationDAC dac = new NonOperationDAC();
            bool result = dac.UpdateDetailNop(no);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 비가동 대분류 수정
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public bool UpdateNonOperation(NonOperationVO no)       //비가동 대분류 수정
        {
            NonOperationDAC dac = new NonOperationDAC();
            bool result = dac.UpdateNonOperation(no);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 특정기간동안의 비가동 이력조회
        /// </summary>
        /// <param name="begDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<NonOperationVO> GetNopHistory(string begDate, string endDate)      //비가동 이력 조회
        {
            NonOperationDAC dac = new NonOperationDAC();
            List<NonOperationVO> list = dac.GetNopHistory(begDate, endDate);
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 비가동 등록
        /// </summary>
        /// <param name="nv"></param>
        /// <returns></returns>
        public bool RegisterNop(NonOperationVO nv)       //비가동 등록
        {
            NonOperationDAC dac = new NonOperationDAC();
            bool result = dac.RegisterNop(nv);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 비가동 상세분류명,코드 목록만 조회
        /// </summary>
        /// <returns></returns>
        public List<NonOperationVO> GetNopDetailSmallList()     //비가동 상세분류명, 코드 목록만 조회
        {
            NonOperationDAC dac = new NonOperationDAC();
            List<NonOperationVO> list = dac.GetNopDetailSmallList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 비가동 상세분류 삭제
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool DeleteDetailNop(string code)       //비가동 상세분류 삭제
        {
            NonOperationDAC dac = new NonOperationDAC();
            bool result = dac.DeleteDetailNop(code);
            dac.Dispose();

            return result;
        }
        public DataTable GetNonOperationList()
        {
            NonOperationDAC dac = new NonOperationDAC();
            DataTable dt = dac.GetNonOperationList();
            dac.Dispose();

            return dt;
        }
        /// <summary>
        /// 사용중인 상세 목록 조회
        /// </summary>
        /// <returns></returns>
        public DataTable GetUseNopDetailMiList()
        {
            NonOperationDAC dac = new NonOperationDAC();
            DataTable dt = dac.GetUseNopDetailMiList();
            dac.Dispose();

            return dt;
        }
        /// <summary>
        /// 사용중인 대분류 목록 조회
        /// </summary>
        /// <returns></returns>
        public DataTable GetUseNonOperationMaList()
        {
            NonOperationDAC dac = new NonOperationDAC();
            DataTable dt = dac.GetUseNonOperationMaList();
            dac.Dispose();

            return dt;
        }
        /// <summary>
        /// 비가동 사유변경
        /// </summary>
        /// <returns></returns>
        public bool UpdateNonOperationReason(string nop_mi_code, string managerid, string nop_seq)
        {
            NonOperationDAC dac = new NonOperationDAC();
            bool result = dac.UpdateNonOperationReason(nop_mi_code, managerid, nop_seq);
            dac.Dispose();

            return result;
        }
    }
}
