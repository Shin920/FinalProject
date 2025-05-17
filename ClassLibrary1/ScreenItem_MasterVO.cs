using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class ScreenItem_MasterVO
    {
        public string Screen_Code { get; set; } //화면코드    nvarchar
        public string Screen_Name { get; set; } //화면명 nvarchar
        public int Sort_index { get; set; } //정렬순서    int
        public string Type { get; set; }   // 화면타입 nvarchar
        public string Screen_Path { get; set; } //화면경로    nvarchar
        public string ContentDLL { get; set; } //화면DLL명 nvarchar
        public string Monitoring_YN { get; set; }// 모니터링화면여부    nchar
        public string Use_YN { get; set; } //사용여부 nchar
        public DateTime Ins_Date { get; set; }//최초입력일자  datetime
        public string Ins_Emp { get; set; } //최초입력자 nvarchar
        public DateTime Up_Date { get; set; }// 최종수정일자  datetime
        public string Up_Emp { get; set; }// 최종수정자 nvarchar

        public string UserGroup_Code { get; set; } //사용자그룹코드 nvarchar 
        public string Pre_Type { get; set; } // 권한  nvarcharCRUD(추가, 조회, 수정, 삭제)


    }
    public class ScreenItem_AuthorityVO//화면권한
    {
        public string UserGroup_Code { get; set; }// 사용자그룹코드     
        public string Screen_Code { get; set; } //화면코드
        public string Screen_Path { get; set; }// 화면이름
        public string Type { get; set; }
        public string Pre_Type { get; set; }// 권한
        public string Use_YN { get; set; }// 사용여부
        public int Sort_index { get; set; }// 정렬순서
        public DateTime Ins_Date { get; set; }// 최초입력일자
         public string Ins_Emp { get; set; }// 최초입력자
        public DateTime Up_Date { get; set; }// 최종수정일자
        public string Up_Emp { get; set; }// 최종수정자

        public int Seq { get; set; }
        public string Menu_Name { get; set; }
        public int Parent_Screen_Code { get; set; }
        public int Menu_level { get; set; }
        public string Program_Name { get; set; }

    }

}
