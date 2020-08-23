using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ws_3500332015
{
    /// <summary>
    /// Descripción breve de servicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class servicio : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos utec...prueba 1";
        }
        //metodo que recibirá un parámetro el cual es el numero de la orden y retornara el monto
        //total de la orden
        [WebMethod]
        public DataSet GetConsultaMontoOrdenes(int Orden)
        {
            SqlConnection conn = new SqlConnection("Data Source=MRISQL;Initial Catalog=Adventureworks2014;Integrated Security=true;");
            conn.Open();
            SqlCommand sql = new SqlCommand("Select Freight, TotalDue, TaxAmt, SUM(UnitPrice * OrderQty) AS totalFactura FROM Sales.SalesOrderHeader INNER JOIN Sales.SalesOrderDetail ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID where SalesOrderHeader.SalesOrderID=@order GROUP BY SalesOrderHeader.SalesOrderID, Freight, TotalDue, TaxAmt", conn);
            sql.Parameters.AddWithValue("@order", Orden);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
    }
}
