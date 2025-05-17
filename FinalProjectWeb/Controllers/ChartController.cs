using FinalProjectWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectWeb.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            //1997년에 많이 팔린 제품3개의 월별 판매량 데이터 바인딩
            ProductManager db = new ProductManager();
            List<OrderStats> list = db.GetOrderBestProduct();

            var statGroup = from stat in list
                            orderby stat.MM
                            group stat by stat.ProductName;

            int k = 1;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            foreach (var prodGroup in statGroup)
            {
                List<int> qtys = new List<int>();
                foreach (var prodStat in prodGroup)
                {
                    qtys.Add(prodStat.Qty);

                    if (k == 1)
                        sb.Append(prodStat.MM + "월,");
                }

                if (k == 1)
                {
                    ViewBag.Label1 = prodGroup.Key;
                    ViewBag.data1 = "[" + string.Join(",", qtys) + "]";
                }
                else if (k == 2)
                {
                    ViewBag.Label2 = prodGroup.Key;
                    ViewBag.data2 = "[" + string.Join(",", qtys) + "]";
                }
                else if (k == 3)
                {
                    ViewBag.Label3 = prodGroup.Key;
                    ViewBag.data3 = "[" + string.Join(",", qtys) + "]";
                }

                k++;
            }

            ViewBag.Labels = sb.ToString().TrimEnd(','); // "1월,2월,3월,....12월"

            return View();
        }
    }
}