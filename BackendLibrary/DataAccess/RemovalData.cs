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
    public class RemovalData : SqlConnector
    {
        public static ObservableCollection<RemovalModel> GetAllRemovals()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT `removalId` AS Id, `warehouseId` AS WarehouseId, `date` AS Date FROM removal";
                var data = connection.Query<RemovalModel>(sql).ToList();

                ObservableCollection<RemovalModel> data2 = new ObservableCollection<RemovalModel>(data);

                return data2;
            }
        }

        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT max(removalId) FROM removal";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        public static RemovalModel GetRemoval(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM removal " +
                             "WHERE removalId = @Id";
                var parameters = new { Id = id };

                try
                {
                    var removal = connection.Query<RemovalModel>(sql, parameters).First();
                    return removal;
                }
                catch
                {
                    RemovalModel errorRemoval = new RemovalModel(-1);
                    return errorRemoval;
                }
            }
        }

        public static void InsertRemoval(RemovalModel newRemoval)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO removal" +
                             "(warehouseId, date) VALUES" +
                             "(@WarehouseId, @Date)";
                var parameters = new
                {
                    WarehouseId = newRemoval.WarehouseId,
                    Date = newRemoval.Date,

                };

                connection.Execute(sql, parameters);
            }
        }

        public static void DeleteRemoval(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM removal WHERE removalId = {id}";

                connection.Execute(sql);
            }
        }

        public static void InsertRemovalProducts(int removalId, ObservableCollection<ProductModel> selectedProducts)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                foreach (var product in selectedProducts)
                {
                    string sql = "INSERT INTO productremoval (removalId, productId) VALUES (@RemovalId, @ProductId);";
                    var parameters = new
                    {
                        RemovalId = removalId,
                        ProductId = product.Id,
                    };

                    connection.Execute(sql, parameters);
                }
            }
        }
    }
}
