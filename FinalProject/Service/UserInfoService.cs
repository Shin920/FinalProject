using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service
{
public class UserInfoService
    {
        public List<UserInfoVO> GetAllUser()
        {
            UserDAC dac = new UserDAC();
            List<UserInfoVO> list = dac.GetAllUser();
            dac.Dispose();
            return list;
        }  
        public bool DeleteUserInfoVO(string userid)// 사용자 삭제
        {
            UserDAC dac = new UserDAC();
            bool result = dac.DeleteUserInfoVO(userid);
            dac.Dispose();

            return result;
        }
        public bool InsertUser(UserInfoVO user)
        {
            UserDAC dac = new UserDAC();
            return dac.InsertUser(user);
        }
        public List<SearchLoginScreenHistoryVO> GetUser_Screen_Login(DateTime start, DateTime end, string screencode, string userid)// 기간별 사용자 화면 사용 로그인 내역
        {
            UserDAC dac = new UserDAC();
            return dac.GetUser_Screen_Login(start, end, screencode, userid);
        }

    }
}
