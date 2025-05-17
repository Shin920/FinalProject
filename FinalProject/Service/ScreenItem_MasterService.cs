using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service
{
   public class ScreenItem_MasterService
    {
     
        public List<ScreenItem_MasterVO> GetALLScreenItem()
        {
            ScreenItem_MasterDAC dac = new ScreenItem_MasterDAC();
            List<ScreenItem_MasterVO> list = dac.GetALLScreenItem();
            dac.Dispose();
            return list;
  
        }
        public bool UsedScreenItem_MasterVO(string screencode, string used)
        {
            ScreenItem_MasterDAC dac = new ScreenItem_MasterDAC();
            bool result = dac.UsedScreenItem_MasterVO(screencode, used);
            dac.Dispose();
            return result;
       
        }

        public List<ScreenItem_AuthorityVO> GetUseGroupScreenItem(string groupCode)//선택화면가져오기
        {
            ScreenItem_MasterDAC dac = new ScreenItem_MasterDAC();
            List<ScreenItem_AuthorityVO> list = dac.GetUseGroupScreenItem(groupCode);
            dac.Dispose();

            return list;
        }
        public List<ScreenItem_AuthorityVO> GetNotUseGroupScreenItem(string groupCode)// 그룹에서 사용하지않는 화면
        {
            ScreenItem_MasterDAC dac = new ScreenItem_MasterDAC();
            List<ScreenItem_AuthorityVO> list = dac.GetNotUseGroupScreenItem(groupCode);
            dac.Dispose();

            return list;    
        }
        public void InsertUpdateScreenItem_Authority(List<ScreenItem_AuthorityVO> List)// 추가한 항목 저장
        {
            ScreenItem_MasterDAC dac = new ScreenItem_MasterDAC();

            dac.InsertUpdateScreenItem_Authority(List);
        }

        public void DeleteGroupUseScreenItem_Authority(string group, List<ScreenItem_AuthorityVO> List)// 그룹에서 사용하던 화면을 더이상 사용하지않을때. Use_YN==N으로 변경
        {
            ScreenItem_MasterDAC dac = new ScreenItem_MasterDAC();

            dac.DeleteGroupUseScreenItem_Authority(group, List);
        }
    }
}
