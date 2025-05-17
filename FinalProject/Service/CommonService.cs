using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service
{
   public class CommonService
    {
        
         public List<ComboItemVO> GetMold_CategoryCode() //금형 콤보박스로가져오기
        {
            CommonDAC dac = new CommonDAC();
            List<ComboItemVO> list = dac.GetMold_CategoryCode();
            dac.Dispose();
            return list;
        }
        public List<ComboItemVO> GetUserGroup_CategoryCode() //회원 그룹 코드 콤보박스로가져오기
        {
            CommonDAC dac = new CommonDAC();
            List<ComboItemVO> list = dac.GetUserGroup_CategoryCode();
            dac.Dispose();
            return list;
        }
    }
}
