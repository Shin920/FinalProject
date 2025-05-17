using FinalProjectDAC;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service
{
    public class ItemService
    {
        public List<ItemVO> GetItemList() // 품목정보 조회
        {
            ItemDAC dac = new ItemDAC();
            List<ItemVO> list = dac.GetItemList();
            dac.Dispose();

            return list;
        }

        public bool InsertItem(string code, string name, string ename, string alias, string type, string spec, string unit, decimal stock, decimal pph, decimal ppb, int cavity, int lpq, int spq, int dgq, int hgq, string lvl1, string lvl2, string lvl3, string lvl4, string lvl5, string emp)
        {
            ItemDAC dac = new ItemDAC();
            bool result = dac.InsertItem(code, name, ename, alias, type, spec, unit, stock, pph, ppb, cavity, lpq, spq, dgq, hgq, lvl1, lvl2, lvl3, lvl4, lvl5, emp);
            dac.Dispose();

            return result;
        }

        public bool DeleteItem(string code)       //품목 삭제
        {
            ItemDAC dac = new ItemDAC();
            bool result = dac.DeleteItem(code);
            dac.Dispose();

            return result;
        }

        public bool UpdateItem(ItemVO no)       //품목 수정 (건별 수정)
        {
            ItemDAC dac = new ItemDAC();
            bool result = dac.UpdateItem(no);
            dac.Dispose();

            return result;
        }

        public bool UseYNSwapItem(string useYN, string code)    //특정 품목분류 사용여부를 변경
        {
            ItemDAC dac = new ItemDAC();
            bool result = dac.UseYNSwapItem(useYN, code);
            dac.Dispose();

            return result;
        }

        public List<ComboItemVO> GetItemType() // 품목타입
        {
            ItemDAC dac = new ItemDAC();
            List<ComboItemVO> list = dac.GetItemType();
            dac.Dispose();

            return list;
        }

        public List<ItemLevelVO> GetItemLevelList()      //품목분류 목록조회.
        {
            ItemDAC dac = new ItemDAC();
            List<ItemLevelVO> list = dac.GetItemLevelList();
            dac.Dispose();

            return list;
        }


        public bool InsertItemLevel(string code, string name, int bqty, int pqty, decimal mqty, string emp)       //품목분류 추가
        {
            ItemDAC dac = new ItemDAC();
            bool result = dac.InsertItemLevel(code, name, bqty, pqty, mqty, emp);
            dac.Dispose();

            return result;
        }

        public bool DeleteItemLevel(string code)       //품목분류 삭제
        {
            ItemDAC dac = new ItemDAC();
            bool result = dac.DeleteItemLevel(code);
            dac.Dispose();

            return result;
        }

        public bool UpdateItemLevel(ItemLevelVO no)       //품목분류 수정 (건별 수정)
        {
            ItemDAC dac = new ItemDAC();
            bool result = dac.UpdateItemLevel(no);
            dac.Dispose();

            return result;
        }


        public bool UseYNSwap(string useYN, string code)    //특정 품목분류 사용여부를 변경
        {
            ItemDAC dac = new ItemDAC();
            bool result = dac.UseYNSwap(useYN, code);
            dac.Dispose();

            return result;
        }
    }
}
