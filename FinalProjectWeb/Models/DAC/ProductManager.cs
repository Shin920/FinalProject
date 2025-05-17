using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;

namespace FinalProjectWeb.Models
{
    public class ProductManager : IDisposable
    {
        SqlConnection conn;

        public ProductManager()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
        }

        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }


        public List<OrderStats> GetOrderBestProduct()
        {
            string sql = @" with Best3Product as
 (
	select top 3 OD.ProductID, P.ProductName
	from Orders O inner join [Order Details] OD on O.OrderID = OD.OrderID
	                    inner join Products P on OD.ProductID = P.ProductID    
	where O.OrderDate between '1997-01-01' and '1997-12-31'
	group by OD.ProductID, P.ProductName
	order by Sum(OD.Quantity) desc
 ), BaseData as
 (
	select ProductID, ProductName, seq as mon
	 from Best3Product, copy_t
    where seq < 13
 )
 -- select * from BaseData
 -- select * from Best3Product
 select B.ProductID, B.ProductName, B.mon MM, isnull(O.qty, 0) qty
  from BaseData B left outer join
			(select OD.ProductID, P.ProductName, Month(O.OrderDate) MM, sum(OD.Quantity) qty
			  from Orders O inner join [Order Details] OD on O.OrderID = OD.OrderID
								  inner join Best3Product P on OD.ProductID = P.ProductID
			 where O.OrderDate between '1997-01-01' and '1997-12-31'
			 group by OD.ProductID, P.ProductName, Month(O.OrderDate)
			 ) O 
			 on B.ProductID = O.ProductID and B.mon = O.MM
 order by 1, 2";

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;

                cmd.Connection.Open();
                List<OrderStats> list = Helper.DataReaderMapToList<OrderStats>(cmd.ExecuteReader());
                cmd.Connection.Close();

                return list;
            }
        }
    }
}