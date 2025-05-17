using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectDAC;
using FinalProjectVO;

namespace FinalProject
{
    public class MenuService
    {
        public DataTable GetMenu()      //메뉴 목록 정렬해서 가져오기
        {
            MenuDAC dac = new MenuDAC();
            DataTable dt = dac.GetMenu();
            dac.Dispose();

            return dt;
        }

        public DataTable GetMenuAuthList()
        {
            MenuDAC dac = new MenuDAC();
            DataTable dt = dac.GetMenuAuthList();
            dac.Dispose();

            return dt;
        }

        public DataTable GetAuthList()
        {
            MenuDAC dac = new MenuDAC();
            DataTable dt = dac.GetAuthList();
            dac.Dispose();

            return dt;
        }

        public bool SaveMenuAuth(int menu_id, List<string> authList)
        {
            MenuDAC dac = new MenuDAC();
            bool result = dac.SaveMenuAuth(menu_id, authList);
            dac.Dispose();

            return result;
        }

        public DataTable GetUserMenuList(string groupCode)
        {
            MenuDAC dac = new MenuDAC();
            DataTable dt = dac.GetUserMenuList(groupCode);
            dac.Dispose();

            return dt;
        }

        public bool InsertBookMark(string userId, string formName)     //해당 폼을 즐겨찾기 리스트에 추가
        {
            MenuDAC dac = new MenuDAC();
            bool result = dac.InsertBookMark(userId, formName);
            dac.Dispose();

            return result;
        }
      
        public bool DeleteBookMark(string userId, string programName)     //해당 폼을 즐겨찾기 리스트에서 삭제
        {
            MenuDAC dac = new MenuDAC();
            bool result = dac.DeleteBookMark(userId, programName);
            dac.Dispose();

            return result;
        }
       
        public DataTable GetBookMarkList(string userID)     //해당 사용자의 즐겨찾기 목록
        {
            MenuDAC dac = new MenuDAC();
            DataTable dt = dac.GetBookMarkList(userID);
            dac.Dispose();

            return dt;
        }

        public string GetUserNote(string userID)        //사용자의 메모내용을 불러온다
        {
            MenuDAC dac = new MenuDAC();
            string result = dac.GetUserNote(userID);
            dac.Dispose();

            return result;
        }
        public void InsertNewNote(string userID, string note)        //메모를 처음 등록하는지 원래 있었는지 확인후 insert하거나 update
        {
            MenuDAC dac = new MenuDAC();
            dac.InsertNewNote(userID, note);
            dac.Dispose();
            
        }
      
        public DataTable GetUserInfo(string userID)     //사용자 이름,그룹
        {
            MenuDAC dac = new MenuDAC();
            DataTable dt = dac.GetUserInfo(userID);
            dac.Dispose();

            return dt;
        }
    }
}
