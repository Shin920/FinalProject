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
    public class BoxingService
    {
        /// <summary>
        /// 완제품 입고리스트 조회
        /// </summary>
        /// <returns></returns>
        public List<BoxingVO_Finish> GetFinishedProductList(string begDate, string endDate)  //완제품 입고리스트 조회
        {
            BoxingDAC dac = new BoxingDAC();
            List<BoxingVO_Finish> list = dac.GetFinishedProductList(begDate, endDate);
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 포장작업에 사용된 팔레트 정보
        /// </summary>
        /// <param name="workOrderNum"></param>
        /// <returns></returns>
        public List<BoxingVO_Info> GetUsedPalleteList(string workOrderNum)  //포장작업에 사용된 팔레트 정보
        {
            BoxingDAC dac = new BoxingDAC();
            List<BoxingVO_Info> list = dac.GetUsedPalleteList(workOrderNum);
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 팔레트 마감(입고여부 'Y', 마감시간 'getdate()')
        /// </summary>
        /// <param name="workOrderNum"></param>
        /// <param name="palleteNum"></param>
        /// <returns></returns>
        public bool FinishPallete(string workOrderNum, string palleteNum, string upEmp)  //팔레트 마감
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.FinishPallete(workOrderNum, palleteNum, upEmp);
            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 작업지시 마감
        /// </summary>
        /// <param name="workOrderNum"></param>
        /// <returns></returns>
        public bool FinishWorkOrder(string workOrderNum)  //작업지시 마감
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.FinishWorkOrder(workOrderNum);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 팔레트 등급상세 수정
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool UpdatePalleteGrade(BoxingVO box)  //팔레트 등급상세 수정
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.UpdatePalleteGrade(box);
            dac.Dispose();

            return result;
        }

        public List<BoxingVO> GetPkgDetail()    //포장등급상세 가져온다
        {
            BoxingDAC dac = new BoxingDAC();
            List<BoxingVO> list = dac.GetPkgDetail();
            dac.Dispose();

            return list;
        }

        public bool InsertPkgDetail(string code, string name, string grade, string emp)       //포장등급상세 추가
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.InsertPkgDetail(code, name, grade, emp);
            dac.Dispose();

            return result;
        }

        public bool DeletePkgDetail(string code)       //포장등급상세 삭제
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.DeletePkgDetail(code);
            dac.Dispose();

            return result;

        }

        public bool UpdatePkgDetail(BoxingVO no)       //포장등급상세 수정 (건별 수정)
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.UpdatePkgDetail(no);
            dac.Dispose();

            return result;
        }


        public bool UseYNSwap(string useYN, string code)    //특정 포장등급상세 사용여부를 변경
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.UseYNSwap(useYN, code);
            dac.Dispose();

            return result;
        }
        /// <summary>
        /// 체크한 모든 작업지시에 대해 마감한다(팔레트가 마감이 안되있으면 팔레트도 마감시킨다)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool FinishAllCheckList(string str)        //체크한 모든 작업지시에 대해 마감한다(팔레트가 마감이 안되있으면 팔레트도 마감시킨다)
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.FinishAllCheckList(str);
            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 바코드가 있는 목록
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public DataTable GetBarcodeList(string barcode)  // 바코드가 있는 목록
        {
            BoxingDAC dac = new BoxingDAC();
            DataTable dt = dac.GetBarcodeList(barcode);
            dac.Dispose();

            return dt;
        }

        /// <summary>
        /// 년도별 LOT
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetLOTList(string year)        //년도별 LOT
        {
            BoxingDAC dac = new BoxingDAC();
            DataTable dt = dac.GetLOTList(year);
            dac.Dispose();

            return dt;
        }
    }
}
