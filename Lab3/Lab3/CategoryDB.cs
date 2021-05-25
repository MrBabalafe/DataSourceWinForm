using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    public static class CategoryDB {

        public static List<Category> GetCategories() {
            List<Category> categories = new List<Category>();
            Category category;

            //Establish Connection
            using(SqlConnection connection = NorthwindDB.GetConnection()) {

                string query = "SELECT CategoryID, CategoryName, Description FROM Categories";
                
                //Create Command Object
                using(SqlCommand cmd = new SqlCommand(query, connection)) {
                    connection.Open();
                    //Run command and process data
                    using(SqlDataReader dr = cmd.ExecuteReader()) {
                        while(dr.Read()) {
                            category = new Category();
                            category.CategoryID = (int)dr["CategoryID"];
                            category.CategoryName = dr["CategoryName"].ToString();
                            category.Description = dr["Description"].ToString();
                            categories.Add(category);
                        }
                    }
                }
            }

            return categories;
        }

    }
}
