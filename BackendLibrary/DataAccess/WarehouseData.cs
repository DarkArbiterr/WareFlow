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
    public class WarehouseData : SqlConnector
    {
        public static ObservableCollection<WarehouseModel> GetAllWarehouses()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM warehouse";
                var data = connection.Query<WarehouseModel>(sql).ToList();

                ObservableCollection<WarehouseModel> data2 = new ObservableCollection<WarehouseModel>(data);

                return data2;
            }
        }

        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT max(warehouseId) FROM warehouse";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        public static WarehouseModel GetWarehouse(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM warehouse " +
                             "WHERE warehouseId = @Id;";
                var parameters = new { Id = id };

                try
                {
                    var warehouse = connection.Query<WarehouseModel>(sql, parameters).First();
                    return warehouse;
                }
                catch
                {
                    WarehouseModel errorWarehouse = new WarehouseModel(-1);
                    return errorWarehouse;
                }
            }
        }

        public static void DeleteWarehouse(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM warehouse WHERE warehouseId = {id}";

                connection.Execute(sql);
            }
        }

        public static void InsertWarehouse(WarehouseModel newWarehouse)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO warehouse" +
                             "(userId, warehouseId, name) VALUES" +
                             "(@userId, @id, @name)";
                var parameters = new
                {
                    id = newWarehouse.Id,
                    userId = newWarehouse.UserId,
                    name = newWarehouse.Name,
                };

                connection.Execute(sql, parameters);
            }
        }
    }
}
