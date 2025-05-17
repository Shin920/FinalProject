using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class MainFormService
    {
        public bool InsertMenuTree_Master_VO(MenuTreeMasterVO menu)
        {
            MainFormDAC dac = new MainFormDAC();

            return dac.InsertMenuTree_Master_VO(menu);
        }
        public List<MenuTreeMasterVO> GetAll_MenuTree_Master()// 메뉴 정보
        {
            MainFormDAC dac = new MainFormDAC();
            List<MenuTreeMasterVO> list = dac.GetAll_MenuTree_Master();
            dac.Dispose();

            return list;
        }
        public bool DeleteMenuTree_Master_VO(string check, string parent, string code) // 메뉴 부모,자식 삭제
        {
            MainFormDAC dac = new MainFormDAC();
            bool result = dac.DeleteMenuTree_Master_VO(check, parent, code);
            dac.Dispose();

            return result;
        }
        public bool UpdateManu(string parent, string son)    // 메뉴 부모 변경
        {
            MainFormDAC dac = new MainFormDAC();
            bool result = dac.UpdateManu(parent, son);
            dac.Dispose();

            return result;
        }
     }
}
