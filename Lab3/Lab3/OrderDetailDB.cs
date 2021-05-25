using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    public static class OrderDetailDB {

        public static List<OrderDetail> GetOrderDetails() {

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            OrderDetail orderDetail;

            //Establish Connection
            using (SqlConnection connection = NorthwindDB.GetConnection()) {

                string query = "SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM [Order Details]";

                //Create Command Object
                using(SqlCommand cmd = new SqlCommand(query, connection)) {
                    connection.Open();

                    //Run command and process data
                    using(SqlDataReader dr = cmd.ExecuteReader()) {

                        while(dr.Read()) {
                            orderDetail = new OrderDetail();
                            orderDetail.OrderID = (int)dr["OrderID"];
                            orderDetail.ProductID = (int)dr["ProductID"];
                            orderDetail.UnitPrice = (decimal)dr["UnitPrice"];
                            orderDetail.Quantity = (int)dr["Quantity"];
                            orderDetail.Discount = (decimal)dr["Discount"];
                            orderDetails.Add(orderDetail);
                        }

                    }
                }
            }

            return orderDetails;
        }

    }
}
