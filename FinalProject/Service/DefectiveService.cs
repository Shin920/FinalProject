using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class DefectiveService
    {
        /// <summary>
        /// 불량현상 대분류 리스트 조회
        /// </summary>
        /// <returns></returns>
        public List<DefectiveVO> GetDefectiveList()      //불량현상 대분류 리스트 조회
        {
            DefectiveDAC dac = new DefectiveDAC();
            List<DefectiveVO> list = dac.GetDefectiveList();
            dac.Dispose();

            return list;          

        }

        /// <summary>
        /// 불량현상 대분류 추가
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="empName"></param>
        /// <returns></returns>
        public bool InsertDefective(string code, string name, string empName)       //불량현상 대분류 추가
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.InsertDefective(code, name, empName);
            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 불량현상 대분류 수정
        /// </summary>
        /// <param name="name"></param>
        /// <param name="empName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool UpdateDefective(string name, string empName, string code)       //불량현상 대분류 수정
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.UpdateDefective(name, empName, code);
            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 불량현상 대분류 삭제
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool DeleteDefective(string code)       //불량현상 대분류 삭제
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.DeleteDefective(code);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 특정 불량현상 대분류 사용여부를 변경. 대분류/상세분류 둘다 쓰여서 상세분류인지를 bool 타입으로 입력하게
        /// </summary>
        /// <param name="useYN"></param>
        /// <param name="code"></param>
        /// <param name="isDetail"></param>
        /// <returns></returns>
        public bool UseYNSwap(string useYN, string code, bool isDetail)    //특정 불량현상 대분류 사용여부를 변경. 대분류/상세분류 둘다 쓰여서 상세분류인지를 bool 타입으로 입력하게
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.UseYNSwap(useYN, code, isDetail);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 불량현상 상세분류 목록 조회
        /// </summary>
        /// <returns></returns>
        public List<DefectiveVO> GetDefDetailList()     //불량현상 상세분류 목록 조회
        {
            DefectiveDAC dac = new DefectiveDAC();
            List<DefectiveVO> list = dac.GetDefDetailList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 불량현상 상세분류 수정
        /// </summary>
        /// <param name="df"></param>
        /// <returns></returns>
        public bool UpdateDefDetail(DefectiveVO df)       //불량현상 상세분류 수정
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.UpdateDefDetail(df);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 불량현상 상세분류 삭제
        /// </summary>
        /// <param name="df"></param>
        /// <returns></returns>
        public bool DeleteDefDetail(string code)       //불량현상 상세분류 삭제
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.DeleteDefDetail(code);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 불량현상 상세분류 추가
        /// </summary>
        /// <param name="df"></param>
        /// <returns></returns>
        public bool InsertDefDetail(DefectiveVO df)       //불량현상 상세분류 추가
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.InsertDefDetail(df);
            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 작업지시목록에 불량수량의 개수 포함된 목록
        /// </summary>
        /// <returns></returns>
        public List<DefectiveVO> GetWorkOrderListwithBadCount(string begDate, string endDate)     //작업지시목록에 불량수량의 개수 포함된 목록
        {
            DefectiveDAC dac = new DefectiveDAC();
            List<DefectiveVO> list = dac.GetWorkOrderListwithBadCount(begDate, endDate);
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 작업지시에 등록된 불량상세
        /// </summary>
        /// <param name="workOrderNum"></param>
        /// <returns></returns>
        public List<DefectiveVO> GetDetailDefInWorkOrderNum(string workOrderNum)     //작업지시에 등록된 불량상세
        {
            DefectiveDAC dac = new DefectiveDAC();
            List<DefectiveVO> list = dac.GetDetailDefInWorkOrderNum(workOrderNum);
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 불량이미지 추가
        /// </summary>
        /// <param name="df"></param>
        /// <returns></returns>
        public bool InsertDefImage(DefectiveVO df)       //불량이미지 추가
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.InsertDefImage(df);
            dac.Dispose();

            return result;
        }

        public bool UpdateDefImage(DefectiveVO df)       //이미 등록된 불량이력에 불량이미지 추가
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.UpdateDefImage(df);
            dac.Dispose();

            return result;
        }

        public List<ProcessVO> GetNotClearWorkOrderList(string begDate, string endDate)      //아직 공정조건을 등록하지 않은 작업지시의 목록을 가져온다
        {
            ProcessDAC dac = new ProcessDAC();
            List<ProcessVO> list = dac.GetNotClearWorkOrderList(begDate, endDate);
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 불량이력에 이미지와 이미지명만 삭제
        /// </summary>
        /// <param name="df"></param>
        /// <returns></returns>
        public bool DeleteDefImage(DefectiveVO df)       //불량이력에 이미지와 이미지명만 삭제
        {
            DefectiveDAC dac = new DefectiveDAC();
            bool result = dac.DeleteDefImage(df);
            dac.Dispose();

            return result;
        }
    }
}
