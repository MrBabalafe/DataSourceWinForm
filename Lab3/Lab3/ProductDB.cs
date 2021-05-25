using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    public static class ProductDB {

        public static List<Product> GetProducts() {

            List<Product> products = new List<Product>();
            Product product;

            //Establish Connection
            using(SqlConnection connection = NorthwindDB.GetConnection()) {

                string query = "SELECT ProductID, ProductName, SupplierID, CategoryID, " + 
                    "QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued " +
                    "FROM Products";

                //Create Command Object
                using (SqlCommand cmd = new SqlCommand(query, connection)) {
                    connection.Open();

                    //Run command and process data
                    using (SqlDataReader dr = cmd.ExecuteReader()) {

                        while(dr.Read()) {
                            product = new Product();
                            product.ProductID = (int)dr["ProductID"];
                            product.ProductName = dr["ProductName"].ToString();
                            product.SupplierID = (int)dr["SupplierID"];
                            product.CategoryID = (int)dr["CategoryID"];
                            product.QuantityPerUnit = dr["QuantityPerUnit"].ToString();
                            product.UnitPrice = (decimal)dr["UnitPrice"];
                            product.UnitsInStock = (int)dr["UnitsInStock"];
                            product.UnitsOnOrder = (int)dr["UnitsOnOrder"];
                            product.ReorderLevel = (int)dr["ReorderLevel"];
                            product.Discontinued = (int)dr["Discontinued"];
                            products.Add(product);
                        }
                    }
                }
            }

            return products;

        }

        public static void DeleteProduct(int prodID) {

        }
    }
}
