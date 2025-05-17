using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service
{
    public class NoticeService
    {
        internal DataTable GetNoticeList()
        {
            NoticeDAC dac = new NoticeDAC();
            DataTable dt = dac.GetNoticeList();
            dac.Dispose();
            return dt;
        }

        public List<NoticeVO> GetUsedNoticeList()
        {
            NoticeDAC dac = new NoticeDAC();
            List<NoticeVO> list = dac.GetUsedNoticeList();
            dac.Dispose();
            return list;
        }
        internal bool InsertNotice(NoticeVO nv)
        {
            NoticeDAC dac = new NoticeDAC();
            bool result = dac.InsertNotice(nv);
            dac.Dispose();
            return result;
        }
        internal bool UpdateNotice(NoticeVO nv, int seq)
        {
            NoticeDAC dac = new NoticeDAC();
            bool result = dac.UpdateNotice(nv, seq);
            dac.Dispose();
            return result;
        }
        public bool DeleteNotice(int seq)
        {
            NoticeDAC dac = new NoticeDAC();
            bool result = dac.DeleteNotice(seq);
            dac.Dispose();
            return result;
        }
        public DataTable GetSearchedNoticeList(string fromdate, string todate, string tag, char useYN)
        {
            NoticeDAC dac = new NoticeDAC();
            DataTable dt = dac.GetSearchedNoticeList(fromdate, todate, tag, useYN);
            dac.Dispose();
            return dt;
        }
    }
}
