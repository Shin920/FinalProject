using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
  public class UsergroupVO
    {
        //UserGroup_Master
        public string UserGroup_Code { get; set; } //사용자 그룹코드
        public string UserGroup_Name { get; set; } //사용자그룹명
        public string Admin { get; set; } //관리자권한여부
        public string Use_YN { get; set; } //사용여부
        public DateTime Ins_Date { get; set; } //최초입력일자
        public string Ins_Emp { get; set; } //최초입력자
        public DateTime Up_Date { get; set; }//최종수정일자
        public string Up_Emp { get; set; } //최종수정자
        //UserGroup_Mapping
         public string User_ID { get; set; } //사용자아이디
    }
    public class UserGroup_MappingVO// 조인된 유저 목록
    {
        public string UserGroup_Code { get; set; }// 유저그릅코드     
        public string User_ID { get; set; }// 유저아이디
        public DateTime Ins_Date { get; set; }// 등록일자
        public string Ins_Emp { get; set; }// 등록자
        public DateTime Up_Date { get; set; }// 수정일자
        public string Up_Emp { get; set; }// 수정자
    }
}
