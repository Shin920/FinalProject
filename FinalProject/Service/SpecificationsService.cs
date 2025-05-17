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
    public class SpecificationsService
    {
        /// <summary>
        /// 품목리스트에서 품목명과 품목코드 리스트만 가져온다
        /// </summary>
        /// <returns></returns>
        public List<SpecificationVO> GetProductList()   //품목리스트에서 품목명과 품목코드 리스트만 가져온다
        {
            SpecificationDAC dac = new SpecificationDAC();
            List<SpecificationVO> list = dac.GetProductList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 모든 품질규격을 가져오기
        /// </summary>
        /// <returns></returns>
        public List<SpecificationVO> GetSpecList()   //모든 품질규격 가져오기
        {
            SpecificationDAC dac = new SpecificationDAC();
            List<SpecificationVO> list = dac.GetSpecList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 복사한 규격들을 품목에 추가
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int CopySpec(List<SpecificationVO> list)   //복사한 규격들을 품목에 추가
        {
            SpecificationDAC dac = new SpecificationDAC();
            int cnt = dac.CopySpec(list);
            dac.Dispose();

            return cnt;
        }
        /// <summary>
        /// 새 품질규격을 추가
        /// </summary>
        /// <param name="sv"></param>
        /// <returns></returns>
        public bool InsertNewSpec(SpecificationVO sv)     //새 품질규격을 추가
        {
            SpecificationDAC dac = new SpecificationDAC();
            bool result = dac.InsertNewSpec(sv);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 품질규격 삭제
        /// </summary>
        /// <param name="sv"></param>
        /// <returns></returns>
        public bool DeleteSpec(SpecificationVO sv)   //품질규격 삭제
        {
            SpecificationDAC dac = new SpecificationDAC();
            bool result = dac.DeleteSpec(sv);
            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 등록된 품질규격 목록을 가져온다
        /// </summary>
        /// <returns></returns>
        public List<SpecificationVO> GetInspectionList()   //등록된 품질규격 목록을 가져온다
        {
            SpecificationDAC dac = new SpecificationDAC();
            List<SpecificationVO> list = dac.GetInspectionList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 측정한 품질규격값에 대한 목록
        /// </summary>
        /// <param name="begDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<SpecificationVO> GetFinishedInspectionList(string begDate, string endDate)   //측정한 품질규격값에 대한 목록
        {
            SpecificationDAC dac = new SpecificationDAC();
            List<SpecificationVO> list = dac.GetFinishedInspectionList(begDate, endDate);
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 품질측정값 추가한 목록을 가져온다
        /// </summary>
        /// <param name="workOrderNum"></param>
        /// <param name="inspectCode"></param>
        /// <returns></returns>
        public DataTable GetConditionValue(string workOrderNum, string inspectCode)      //품질측정값 추가한 목록을 가져온다
        {
            SpecificationDAC dac = new SpecificationDAC();
            DataTable dt = dac.GetConditionValue(workOrderNum, inspectCode);
            dac.Dispose();

            return dt;
        }

        /// <summary>
        /// 작업지시 품목의 품질측정 기본값 목록을 가져온다
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public List<SpecificationVO> GetInsSpectValueList(string itemCode, string processCode)      //작업지시 품목의 품질측정 기본값 목록을 가져온다
        {
            SpecificationDAC dac = new SpecificationDAC();
            List<SpecificationVO> list = dac.GetInsSpectValueList(itemCode, processCode);
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 품질측정 값 추가
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
        public bool InsertNewInsValue(SpecificationVO pc)    //품질측정 값 추가
        {
            SpecificationDAC dac = new SpecificationDAC();
            bool result = dac.InsertNewInsValue(pc);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 품질측정 값 삭제
        /// </summary>
        /// <param name="rownNum"></param>
        /// <param name="workOrderNum"></param>
        /// <returns></returns>
        public bool DeleteInsValue(int rownNum, string workOrderNum)    //품질측정 값 삭제
        {
            SpecificationDAC dac = new SpecificationDAC();
            bool result = dac.DeleteInsValue(rownNum, workOrderNum);
            dac.Dispose();

            return result;
        }

        public string GetLastCode()   //가장 최근 등록된 코드명을 가져온다
        {
            SpecificationDAC dac = new SpecificationDAC();
            string result = dac.GetLastCode();
            dac.Dispose();

            return result;
        }
    }
}
