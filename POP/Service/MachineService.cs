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
    public class MachineService
    {
        /// <summary>
        /// 사용중인 기계 목록을 가져온다
        /// </summary>
        /// <returns></returns>
        public List<WorkOrderVO> GetUsingMachine()  //사용중인 기계목록을 가져온다
        {
            POPMachineDAC dac = new POPMachineDAC();
            List<WorkOrderVO>list = dac.GetUsingMachine();
            dac.Dispose();

            return list;
        }

        /// <summary>
        /// 작업지시에 기계를 사용등록한다.
        /// </summary>
        /// <param name="macName"></param>
        /// <param name="workOrderNum"></param>
        /// <returns></returns>
        public bool InsertUsingMachine(string macName, string workOrderNum)  //작업지시에 기계를 사용등록한다.
        {
            POPMachineDAC dac = new POPMachineDAC();
            bool result = dac.InsertUsingMachine(macName, workOrderNum);
            dac.Dispose();

            return result;

        }
    }
}
