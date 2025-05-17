using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service
{
    public class MoldService
    {
        public List<MoldVO> GetMoldList()  //금형정보 리스트 조회
        {
            MoldDAC dac = new MoldDAC();
            List<MoldVO> list = dac.GetMoldList();
            dac.Dispose();

            return list;
        }
        public List<MoldVO> selectMoldGroup()// 금형그룹조회
        {
            MoldDAC dac = new MoldDAC();
            return dac.SelectMoldGroup();
        }
        public DataSet MoldWorkCenter()// 금형정보 등록에 필요한 작업장정보 조회
        {
            MoldDAC dac = new MoldDAC();
            return dac.MoldWorkCenter();
        }

        public MoldVO GetMoldInfo(int mold_code) //셀클릭시 그 행의 금형 정보 조회
        {
            MoldDAC dac = new MoldDAC();
            MoldVO mtr = dac.GetMoldInfo(mold_code);
            dac.Dispose();
            return mtr;
        }
        public bool DeleteMold(string code)       //금형정보 삭제
        {
            MoldDAC dac = new MoldDAC();
            bool result = dac.DeleteMold(code);
            dac.Dispose();

            return result;
        }
        public bool InsertMold(MoldVO minfo)// 금형정보등록
        {
            MoldDAC dac = new MoldDAC();
            return dac.InsertMold(minfo);
        }
        public List<Mold_J_Item_Wc_MuseVO> SelectMold_Item_Wc_Muse()// 금형사용정보조회
        {    
            MoldDAC dac = new MoldDAC();
            List<Mold_J_Item_Wc_MuseVO> list = dac.SelectMold_Item_Wc_Muse();
            dac.Dispose();

            return list;
        }

    }
}
