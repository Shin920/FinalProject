using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class WorkCenterService
    {
        public List<WorkCenterVO> GetWorkCenterList()    //작업장 목록을 가져온다
        {
            WorkCenterDAC dac = new WorkCenterDAC();
            List<WorkCenterVO> list = dac.GetWorkCenterList();
            dac.Dispose();

            return list;
        }

        public bool InsertWorkCenter(string code, string name, string pcode, string remark, string emp)       //작업장정보 추가
        {
            WorkCenterDAC dac = new WorkCenterDAC();
            bool result = dac.InsertWorkCenter(code, name, pcode, remark, emp);
            dac.Dispose();

            return result;
        }

        public bool DeleteWorkCenter(string code)       //작업장정보 삭제
        {
            WorkCenterDAC dac = new WorkCenterDAC();
            bool result = dac.DeleteWorkCenter(code);
            dac.Dispose();

            return result;
        }

        public bool UpdateWorkCenter(WorkCenterVO no)       //작업장정보 수정 (건별 수정)
        {
            WorkCenterDAC dac = new WorkCenterDAC();
            bool result = dac.UpdateWorkCenter(no);
            dac.Dispose();

            return result;
        }


        public bool UseYNSwap(string useYN, string code)    //특정 작업장정보 사용여부를 변경
        {
            ProcessDAC dac = new ProcessDAC();
            bool result = dac.UseYNSwap(useYN, code);
            dac.Dispose();

            return result;
        }

        public List<WorkCenterVO> GetWorkCenterSmallList()      //작업장명과 코드 목록만 조회 (김수호)
        {
            WorkCenterDAC dac = new WorkCenterDAC();
            List<WorkCenterVO> list = dac.GetWorkCenterSmallList();
            dac.Dispose();

            return list;
        }
    }
}
