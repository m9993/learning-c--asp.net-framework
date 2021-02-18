using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory_Management_System_with_ADO.Net.Models
{
    public class CategoryModel
    {
        DataAccess dataAccess;
        public CategoryModel()
        {
            dataAccess = new DataAccess();
        }

        public List<Category> GetCategories()
        {
            string sql = "SELECT * FROM Categories";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.CategoryId =(int) reader["CategoryId"];
                category.CategoryName = reader["CategoryName"].ToString();
                categories.Add(category);
            }

            return categories;
        }

        public Category GetCategory(int id)
        {
            string sql = "SELECT * FROM Categories WHERE CategoryId="+id;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Category category = new Category();
            category.CategoryId = (int)reader["CategoryId"];
            category.CategoryName = reader["CategoryName"].ToString();
            return category;
        }
        public int Insert(Category category)
        {
            string sql = "INSERT INTO Categories(CategoryName) VALUES('"+category.CategoryName+"')";
            int result = dataAccess.ExecuteQuery(sql);
            return result;
        }
        public int Update(Category category)
        {
            string sql = "UPDATE Categories SET CategoryName='"+category.CategoryName+"' WHERE CategoryId="+category.CategoryId;
            int result = dataAccess.ExecuteQuery(sql);
            return result;
        }
        public int Delete(int id)
        {
            string sql = "DELETE FROM Categories WHERE CategoryId="+id;
            int result = dataAccess.ExecuteQuery(sql);
            return result;
        }
    }
}