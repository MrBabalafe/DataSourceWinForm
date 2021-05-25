using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    public static class SupplierDB {

        public static List<Supplier> GetSuppliers() {
            List<Supplier> suppliers = new List<Supplier>();
            Supplier supplier;

            //Establish Connection
            using (SqlConnection connection = NorthwindDB.GetConnection()) {

                string query = "SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, " +
                    "City, Region, PostalCode, Country, Phone, Fax, HomePage " +
                    "FROM Suppliers";
                
                //Create Command Object
                using(SqlCommand cmd = new SqlCommand(query, connection)) {
                    connection.Open();
                    
                    //Run command and process data
                    using(SqlDataReader dr = cmd.ExecuteReader()) {
                        while(dr.Read()) {
                            supplier = new Supplier();
                            supplier.SupplierID = (int)dr["SupplierID"];
                            supplier.CompanyName = dr["CompanyName"].ToString();
                            supplier.ContactName = dr["ContactName"].ToString();
                            supplier.ContactTitle = dr["ContactTitle"].ToString();
                            supplier.Address = dr["Address"].ToString();
                            supplier.City = dr["City"].ToString();
                            supplier.Region = dr["Region"].ToString();
                            supplier.PostalCode = dr["PostalCode"].ToString();
                            supplier.Country = dr["Country"].ToString();
                            supplier.Phone = dr["Phone"].ToString();
                            supplier.Fax = dr["Fax"].ToString();
                            supplier.HomePage = dr["HomePage"].ToString();
                            suppliers.Add(supplier);
                        }
                    }
                }
            }

            return suppliers;
        }
    }
}
