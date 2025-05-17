using FinalProjectDAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class ReportService
    {
        public DataTable GetMaterialList(string date)       //건조 리스트
        {
            ReportDAC dac = new ReportDAC();
            DataTable dt = dac.GetMaterialList();
            dac.Dispose();

            return dt;

        }
        public DataTable GetPackingList(string date)       //포장 리스트
        {
            ReportDAC dac = new ReportDAC();
            DataTable dt = dac.GetPackingList(date);
            dac.Dispose();

            return dt;

        }
    }
}
