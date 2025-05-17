using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class CarriageService
    {
        /// <summary>
        /// 대차 이력 조회
        /// </summary>
        /// <returns></returns>
        public List<CarriageVO> GetCarriageHistory(string begDate, string endDate)    //대차 이력 조회
        {
            CarriageDAC dac = new CarriageDAC();
            List<CarriageVO> list = dac.GetCarriageHistory(begDate, endDate);
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 대차코드, 이름 목록만 조회
        /// </summary>
        /// <returns></returns>
        public List<CarriageVO> GetCarriageSmallList()    //대차코드, 이름 목록만 조회
        {
            CarriageDAC dac = new CarriageDAC();
            List<CarriageVO> list = dac.GetCarriageSmallList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 품목코드, 이름 목록만 조회
        /// </summary>
        /// <returns></returns>
        public List<ItemVO> GetItemSmallList()    //품목코드, 이름 목록만 조회
        {
            CarriageDAC dac = new CarriageDAC();
            List<ItemVO> list = dac.GetItemSmallList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 대차그룹명, 대차이름 목록만 조회
        /// </summary>
        /// <returns></returns>
        public List<CarriageVO> GetCarriageGroupSmallList()    //대차그룹명, 대차이름 목록만 조회
        {
            CarriageDAC dac = new CarriageDAC();
            List<CarriageVO> list = dac.GetCarriageGroupSmallList();
            dac.Dispose();

            return list;
        }
        /// <summary>
        /// 대차현황 목록
        /// </summary>
        /// <returns></returns>
        public List<CarriageVO> GetCarriageStatusList()    //대차 현황 목록
        {
            CarriageDAC dac = new CarriageDAC();
            List<CarriageVO> list = dac.GetCarriageStatusList();
            dac.Dispose();

            return list;

        }

        public List<CarriageVO> GetCarriageList()    //대차목록을 가져온다
        {
            CarriageDAC dac = new CarriageDAC();
            List<CarriageVO> list = dac.GetCarriageList();
            dac.Dispose();

            return list;
        }

        public bool InsertCarriage(string code, string name, string group, string emp)       //대차정보 추가
        {
            CarriageDAC dac = new CarriageDAC();
            bool result = dac.InsertCarriage(code, name, group, emp);
            dac.Dispose();

            return result;
        }

        public bool DeleteCarriage(string code)       //대차정보 삭제
        {
            CarriageDAC dac = new CarriageDAC();
            bool result = dac.DeleteCarriage(code);
            dac.Dispose();

            return result;
        }

        public bool UpdateCarriage(CarriageVO no)       //대차정보 수정 (건별 수정)
        {
            CarriageDAC dac = new CarriageDAC();
            bool result = dac.UpdateCarriage(no);
            dac.Dispose();

            return result;
        }


        public bool UseYNSwap(string useYN, string code)    //특정 대차정보 사용여부를 변경
        {
            CarriageDAC dac = new CarriageDAC();
            bool result = dac.UseYNSwap(useYN, code);
            dac.Dispose();

            return result;
        }
    }
}
