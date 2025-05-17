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
    public class LoginService
    {
        public string IsUserLogin(string userid, string pwd)   //로그인 하는 사용자의 정보가 맞는지 확인하고 맞으면 사용자이름 넘겨준다
        {
            LoginDAC dac = new LoginDAC();
            string result = dac.IsUserLogin(userid, pwd);
            dac.Dispose();

            return result;
        }
        public bool UpdatePassWord(string id, string pwd)       //비밀번호 신규생성 한걸로 업데이트
        {
            LoginDAC dac = new LoginDAC();
            bool result = dac.UpdatePassWord(id, pwd);
            dac.Dispose();

            return result;
        }
        public bool isOverlap(string id)       //아이디 중복체크
        {
            LoginDAC dac = new LoginDAC();
            bool result = dac.isOverlap(id);
            dac.Dispose();

            return result;
        }

        public bool InsertNewUser(UserVO user)       //새 유저 등록
        {
            LoginDAC dac = new LoginDAC();
            bool result = dac.InsertNewUser(user);
            dac.Dispose();

            return result;
        }
        public DataTable GetGroupList()       //그룹코드와 이름
        {
            LoginDAC dac = new LoginDAC();
            DataTable dt = dac.GetGroupList();
            dac.Dispose();

            return dt;
        }
    }
}
