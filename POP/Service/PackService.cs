using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Service
{
    public class PackService
    {
        internal DataTable GetPackGradeList()
        {
            BoxingDAC dac = new BoxingDAC();
            DataTable dt = new DataTable();
            dt = dac.GetPackGradeList();
            dac.Dispose();
            return dt;
        }

        internal List<BoxingVO> GetPalNoList(string workorderno)
        {
            BoxingDAC dac = new BoxingDAC();
            List<BoxingVO> list = dac.GetPalNoList(workorderno);
            dac.Dispose();
            return list;
        }

        internal string CreateNewPalNo(string workorderno)
        {
            BoxingDAC dac = new BoxingDAC();
            string newPalNo = dac.CreateNewPalNo(workorderno);
            dac.Dispose();
            return newPalNo;
        }

        internal bool InsertPackHistory(BoxingVO bv)
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.InsertPackHistory(bv);
            dac.Dispose();
            return result;
        }

        internal List<BoxingVO> GetPalList(string workorderno)
        {
            BoxingDAC dac = new BoxingDAC();
            List<BoxingVO> list = dac.GetPalList(workorderno);
            dac.Dispose();
            return list;
        }

        internal bool UpdatePal(string barcodeno, int qty, int canPrdQty, string managerid)
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.UpdatePal(barcodeno, qty, canPrdQty, managerid);
            dac.Dispose();
            return result;
        }

        internal bool DelPal(string barcodeNo)
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.DelPal(barcodeNo);
            dac.Dispose();
            return result;
        }

        internal DataTable GetBarcodeInfo(string barcodeno)
        {
            BoxingDAC dac = new BoxingDAC();
            DataTable dt = new DataTable();
            dt = dac.GetBarcodeInfo(barcodeno);
            dac.Dispose();
            return dt;
        }

        internal DataTable LoadPalList(string workorderno)
        {
            BoxingDAC dac = new BoxingDAC();
            DataTable dt = new DataTable();
            dt = dac.LoadPalList(workorderno);
            dac.Dispose();
            return dt;
        }

        internal DataTable GetPalSize(string unit)
        {
            BoxingDAC dac = new BoxingDAC();
            DataTable dt = new DataTable();
            dt = dac.GetPalSize(unit);
            dac.Dispose();
            return dt;
        }

        internal DataTable GetPalletList(string workorderno)
        {
            BoxingDAC dac = new BoxingDAC();
            DataTable dt = new DataTable();
            dt = dac.GetPalletList(workorderno);
            dac.Dispose();
            return dt;
        }

        internal bool UnloadingToPallet(string managerid, string workorderno, int tARGET_Barcodeno, int qty, int status_Seq, string oRIGIN_GV_CODE, long hist_Seq, int sEQ)
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.UnloadingToPallet(managerid, workorderno, tARGET_Barcodeno, qty, status_Seq, oRIGIN_GV_CODE, hist_Seq, sEQ);
            dac.Dispose();
            return result;
        }

        internal bool InPallet(string barcodeno, string seq, string managerid)
        {
            BoxingDAC dac = new BoxingDAC();
            bool result = dac.InPallet(barcodeno, seq, managerid);
            dac.Dispose();
            return result;
        }
        /// <summary>
        /// 잔여수량있는 소성대차 있는지 여부 확인
        /// </summary>
        /// <param name="workorderno"></param>
        /// <returns></returns>
        internal int IsFireCarExist(string workorderno)
        {
            CartDAC dac = new CartDAC();
            int count = dac.IsFireCarExist(workorderno);
            dac.Dispose();
            return count;
        }

        internal int IsPalletDone(string workorderno)
        {
            BoxingDAC dac = new BoxingDAC();
            int count = dac.IsPalletDone(workorderno);
            dac.Dispose();
            return count;
        }
    }
}
