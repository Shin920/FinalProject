using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
    public class MenuTreeMasterVO
    {
        public int Seq { get; set; }// 메뉴순번
        public string Parent_Screen_Code { get; set; }// 상위화면코드
        public string Screen_Code { get; set; }// 화면코드
        public string Screen_Name { get; set; }// 화면이름   
        public int Sort_index { get; set; }// 정렬순서 
        public DateTime Ins_Date { get; set; }// 최초입력일자
        public string Ins_Emp { get; set; }// 최초입력자                     
        public DateTime Up_Date { get; set; }  //최종수정일자
        public string Up_Emp { get; set; }// 최종수정자
    }
        public class BookMark_VO// 즐겨찾기vo
    {
            public long Seq { get; set; }//즐겨찾기순번     
            public string User_ID { get; set; }//사용자ID
            public string Screen_Code { get; set; }//화면코드
            public string Screen_Name { get; set; }
            public string Parent_Screen_Code { get; set; }//부모코드
            public string Type { get; set; }//즐겨찾기타입
            public int Sort_index { get; set; }//정렬순서
            public DateTime Ins_Date { get; set; }//최초입력일자
            public string Ins_Emp { get; set; }//최초입력자
            public DateTime Up_Date { get; set; }//최종수정일자
            public string Up_Emp { get; set; }//최종수정자


        }
    }
