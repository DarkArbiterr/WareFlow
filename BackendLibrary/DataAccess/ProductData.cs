using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BackendLibrary.Models;
using System.Data;
using Dapper;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BackendLibrary.DataAccess
{
    public class ProductData : SqlConnector
    {
        public static ObservableCollection<ProductModel> GetAllProducts()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM product";
                var data = connection.Query<ProductModel>(sql).ToList();

                ObservableCollection<ProductModel> data2 = new ObservableCollection<ProductModel>(data);

                return data2;
            }
        }

        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT max(productId) FROM product";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        public static ProductModel GetProductById(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM product " +
                             "WHERE productId = @Id";
                var parameters = new { Id = id };

                try
                {
                    var product = connection.Query<ProductModel>(sql, parameters).First();
                    return product;
                }
                catch
                {
                    ProductModel errProduct = new ProductModel(-1);
                    return errProduct;
                }
            }
        }

        public static ProductModel GetProductByName(string name)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM product " +
                             "WHERE name = @Name";
                var parameters = new { Name = name };

                try
                {
                    var product = connection.Query<ProductModel>(sql, parameters).First();
                    return product;
                }
                catch
                {
                    ProductModel errProduct = new ProductModel(-1);
                    return errProduct;
                }
            }
        }

        public static void InsertProduct(ProductModel newProduct)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO product" +
                    "(`name`, `desc`) VALUES" +
                    "( @Name, @Desc)";

                var parameters = new { Name = newProduct.Name, Desc = newProduct.Description };

                connection.Execute(sql, parameters);
            }
        }

        public static void DeleteProduct(int id, string name)
        {                
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM product WHERE productId = @id AND name = @name";
                var parameters = new { id = id , name = name};

                try
                {
                    connection.Query<ProductModel>(sql, parameters);
                }
                catch
                {
                }
            }
        }

        public static void DeleteProduct(string name)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM product WHERE name = @name";
                var parameters = new {name = name };

                try
                {
                    connection.Query<ProductModel>(sql, parameters);
                }
                catch
                {
                }
            }
        }
    }
}
