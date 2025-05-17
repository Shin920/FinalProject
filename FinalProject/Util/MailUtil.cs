using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Util
{
    public class MailUtil
    {
        public static void ReleaseMail(string comName, string comEmail, string orderDate, string beginDate, string arriveDate)
        {
            string strConn = ConfigurationManager.ConnectionStrings["team3"].ConnectionString;

            //html 파일을 읽어들인다.
            FileStream fs = new FileStream("ThanksMail.html", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            string tempStr = sr.ReadToEnd();    //html파일을 처음부터 끝까지 읽어서 하나의 문자열로 담은것

            //SmtpClient객체
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);  //서버주소,서버포트
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;   //별도로 주려고 false
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("k8325172@gmail.com", "ksh30603#");    //gmail 계정,gmail 암호

            //****그리고 구글계정의 보안으로 들어가서 보안수준이 낮은 앱도 액세스 허용으로 해줘야 메일이 가능

            try
            {

                //메일발송
                //메일본문을 실제 조회된 데이터로 변경
                //string bodyStr = tempStr.Replace("$업체명", "삼조라면"); //html을 열어보면 업체명 자리에 $업체명 이라고 해놔서 그걸 지우고 회사명 넣는것. 그걸 다시 tempStr에 주고
                //bodyStr = bodyStr.Replace("$이메일", comEmail);

                //주문하신 상품에 대해 배송이 시작되었습니다.
                //예상도착일은 06/14일입니다.

                //메일발송
                MailAddress from = new MailAddress("k8325172@naver.com", "관리자");        //보내는 사람, 디스플레이될 이름
                MailAddress to = new MailAddress(comEmail, comName);
                MailMessage message = new MailMessage(from, to);
                message.Subject = $"{comName}님의 주문내역입니다. -삼조라면";
                message.Body = $"{comName}님의 {orderDate} 주문이 {beginDate} 배송이 등록되었습니다.\n예상 도착일은 {arriveDate}입니다.";
                //message.IsBodyHtml = true;  //html 형식으로 메일을 발송하는 경우
                message.BodyEncoding = Encoding.UTF8;
                message.SubjectEncoding = Encoding.UTF8;

                client.Send(message);
                message.Dispose();

                //메일발송리스트에 주문번호 추가



            }
            catch (Exception err)
            {
                //LogWorker.WriteErrorLog("오류 발생");     근데 어차피 이 함수를 호출한쪽에 try catch로 해놔서 거기에 err을 던져줘도 된다.
                throw err;
            }
        }

        public static void OrderMail(string comName, string comEmail, string fileName)
        {

            ////html 파일을 읽어들인다.
            //FileStream fs = new FileStream("ThanksMail.html", FileMode.Open, FileAccess.Read);
            //StreamReader sr = new StreamReader(fs, Encoding.Default);
            //string tempStr = sr.ReadToEnd();    //html파일을 처음부터 끝까지 읽어서 하나의 문자열로 담은것

            //SmtpClient객체
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);  //서버주소,서버포트
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;   //별도로 주려고 false
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("k8325172@gmail.com", "ksh30603#");    //gmail 계정,gmail 암호

            //****그리고 구글계정의 보안으로 들어가서 보안수준이 낮은 앱도 액세스 허용으로 해줘야 메일이 가능

            //List<string> orderIDs = new List<string>();     //메일발송이 성공한 주문번호를 저장하는 리스트(스트링빌더로 할수도있다)

            try
            {


                //메일발송
                //메일본문을 실제 조회된 데이터로 변경
                //string bodyStr = tempStr.Replace("$업체명", "삼조라면"); //html을 열어보면 업체명 자리에 $업체명 이라고 해놔서 그걸 지우고 회사명 넣는것. 그걸 다시tempSt에고
                //bodyStr = bodyStr.Replace("$이메일", comEmail);
                string msg = $"삼조라면 - {DateTime.Now.ToShortDateString()} 주문입니다.";

                //메일발송
                MailAddress from = new MailAddress("k8325172@naver.com", "홍길동");        //보내는 사람, 디스플레이될 이름
                MailAddress to = new MailAddress(comEmail, comName);
                MailMessage message = new MailMessage(from, to);
                message.Subject = msg;
                message.Body = msg;
                //message.IsBodyHtml = true;  //html 형식으로 메일을 발송하는 경우
                message.BodyEncoding = Encoding.UTF8;
                message.SubjectEncoding = Encoding.UTF8;
                /*message.Attachments.Add(new Attachment(new FileStream(fileName, FileMode.Open, FileAccess.Read), );*/      //"이거 윗단계에서 엑셀 저장하는 경로와 이름을 여기다 넣기"
                                                                                                                             //첨부파일 추가C:\Users\k8325\Desktop\발주목록 엑셀
                Attachment attachment = new Attachment(fileName);
                message.Attachments.Add(attachment);

                client.Send(message);
                message.Dispose();





                ////메일발송이 성공된 OrderID의 IsEmailSend 컬럼 업데이트
                //if (orderIDs.Count > 0)
                //{
                //    int iRowAffect = cmd.ExecuteNonQuery();
                //    //LogWorker.WriteLog($"배치 작업 {iRowAffect}건 완료");
                //}

            }
            catch (Exception err)
            {
                //LogWorker.WriteErrorLog("오류 발생");     근데 어차피 이 함수를 호출한쪽에 try catch로 해놔서 거기에 err을 던져줘도 된다.
                throw err;
            }
        }
    }
}
