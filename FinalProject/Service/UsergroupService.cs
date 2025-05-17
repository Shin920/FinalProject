using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service
{
    public class UsergroupService
    {
        public void InsertUpdateUserGroup_Mapping(List<UserGroup_MappingVO> List)
        {
            UsergroupDAC dac = new UsergroupDAC();
            dac.InsertUpdateUserGroup_Mapping(List);
        }
        public void DeleteUserGroup_Mapping(List<UserGroup_MappingVO> List)// 그룹에서 사용하던 유저들을 더이상 사용하지않을때.
        {
            UsergroupDAC dac = new UsergroupDAC();
            dac.DeleteUserGroup_Mapping(List);
        }
        public List<UsergroupVO> GetAllUserGroup() //가져오기 
        {
            UsergroupDAC dac = new UsergroupDAC();
            return dac.GetAllUserGroup();
        }
        public List<UserGroup_MappingVO> GetAllUserGroup_Mapping()
        {
            UsergroupDAC dac = new UsergroupDAC();
            List<UserGroup_MappingVO> list = dac.GetAllUserGroup_Mapping();
            dac.Dispose();
            return list;
        }

        public List<UsergroupVO> GetUsergroupList()  //사용자그룹 리스트 조회
        {
            UsergroupDAC dac = new UsergroupDAC();
            List<UsergroupVO> list = dac.GetUsergroupList();
            dac.Dispose();

            return list;
        }
      
        public bool InsertUsergroup(UsergroupVO list) //사용자그룹 등록
        {
            UsergroupDAC dac = new UsergroupDAC();
            bool result = dac.InsertUsergroup(list);
            dac.Dispose();
            return result;

        }
        public UsergroupVO GetUsergroupInfo(string Usergroupcode) //셀클릭시 그 행의 재료 정보 조회
        {
            UsergroupDAC dac = new UsergroupDAC();
            UsergroupVO userG = dac.GetUsergroupInfo(Usergroupcode);
            dac.Dispose();
            return userG;
        }
        public bool UPdateUsergroup(UsergroupVO list) // 수정 
        {
            UsergroupDAC dac = new UsergroupDAC();
            bool result = dac.UPdateUsergroup(list);
            dac.Dispose();
            return result;
        }

        public bool UPdateUsergroupUseYN(string userCode, string useYN) // 수정 
        {
            UsergroupDAC dac = new UsergroupDAC();
            bool result = dac.UPdateUsergroupUseYN(userCode, useYN);
            dac.Dispose();
            return result;
        }
    }
}
