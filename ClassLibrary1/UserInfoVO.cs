using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVO
{
  public  class UserInfoVO
    {
        public string User_ID { get; set; }// 사용자ID
        public string User_Name { get; set; }// 사용자명
        public string User_PW { get; set; }// 사용자패스워드
        public string Customer_Code { get; set; }// 거래처코드
        public string User_Type { get; set; }// 사용자구분
        public string IP_Security_YN { get; set; }// 가격컬럼Visible여부
        public int Pw_Reset_Count { get; set; }// 패스워드리셋 회수
        public string Default_Screen_Code { get; set; }// 기본화면코드
        public string Default_Process_Code { get; set; }// 기본공정코드
        public string Monitoring_YN { get; set; }// 모니터링사용여부
        public string Use_YN { get; set; }// 사용여부
        public DateTime Ins_Date { get; set; }// 최초입력일자

        public string Ins_Emp { get; set; }// 최초입력자
        public DateTime Up_Date { get; set; }// 최종수정일자

        public string Up_Emp { get; set; }// 최종수정자
    }
    public class Login_History
    {
        public string Session_ID { get; set; }
        public string User_ID { get; set; }
        public DateTime Login_Day { get; set; }
        public DateTime Login_Date { get; set; }
        public string Login_Ipaddress { get; set; }
        public string Client_HostName { get; set; }
        public string Execute_Flag { get; set; }
        public string ERP_Execute_Flag { get; set; }
        public string Login_Success { get; set; } //로그인성공
        public string Ins_Date { get; set; }
        public string Ins_Emp { get; set; } 
    }
}
