using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class UserDefCodeService
    {
        
        public List<UserDefCodeVO> GetUserDefCodeList()      //사용자정의코드 대분류 목록조회.
        {
            UserDefCodeDAC dac = new UserDefCodeDAC();
            List<UserDefCodeVO> list = dac.GetUserDefCodeList();
            dac.Dispose();

            return list;
        }

        
        public bool InsertUserDefCode(string code, string name, string remark, string empName)       //사용자정의코드 대분류 추가
        {
            UserDefCodeDAC dac = new UserDefCodeDAC();
            bool result = dac.InsertUserDefCode(code, name, remark, empName);
            dac.Dispose();

            return result;
        }
        
        public bool DeleteUserDefCode(string code)       //사용자정의코드 대분류 삭제
        {
            UserDefCodeDAC dac = new UserDefCodeDAC();
            bool result = dac.DeleteUserDefCode(code);
            dac.Dispose();

            return result;
        }

        public bool UpdateUserDefCode(UserDefCodeVO no)       //사용자정의코드 대분류 수정 (건별 수정)
        {
            UserDefCodeDAC dac = new UserDefCodeDAC();
            bool result = dac.UpdateUserDefCode(no);
            dac.Dispose();

            return result;
        }


        public bool UseYNSwap(string useYN, string code, bool isDetail)    //특정 사용자정의코드 대분류 사용여부를 변경. 대분류/상세분류 둘다 쓰여서 상세분류인지를 bool 타입으로 입력하게
        {
            UserDefCodeDAC dac = new UserDefCodeDAC();
            bool result = dac.UseYNSwap(useYN, code, isDetail);
            dac.Dispose();

            return result;
        }

        
        public List<UserDefCodeVO> GetUserDefCodeDetailList()     //사용자정의코드 상세분류 목록 조회
        {
            UserDefCodeDAC dac = new UserDefCodeDAC();
            List<UserDefCodeVO> list = dac.GetUserDefCodeDetailList();
            dac.Dispose();

            return list;
        }

        
        public bool InsertUserDefCodeDetail(UserDefCodeVO no)       //사용자정의코드 상세분류 추가 (건별 추가)
        {
            UserDefCodeDAC dac = new UserDefCodeDAC();
            bool result = dac.InsertUserDefCodeDetail(no);
            dac.Dispose();

            return result;
        }

        public bool DeleteUserDefCodeDetail(string code)       //사용자정의코드 상세분류 삭제
        {
            UserDefCodeDAC dac = new UserDefCodeDAC();
            bool result = dac.DeleteUserDefCodeDetail(code);
            dac.Dispose();

            return result;
        }
        

        public bool UpdateUserDefCodeDetail(UserDefCodeVO no)       //사용자정의코드 상세분류 수정
        {
            UserDefCodeDAC dac = new UserDefCodeDAC();
            bool result = dac.UpdateDetail(no);
            dac.Dispose();

            return result;
        }
        
       
    }
}
