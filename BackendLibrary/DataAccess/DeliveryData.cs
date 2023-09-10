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
    public class DeliveryData : SqlConnector
    {
        public static void DeleteDelivery(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM delivery WHERE deliveryId = {id}";

                connection.Execute(sql);
            }
        }

        public static ObservableCollection<DeliveryModel> GetAllDeliveries()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM delivery";
                var data = connection.Query<DeliveryModel>(sql).ToList();

                ObservableCollection<DeliveryModel> data2 = new ObservableCollection<DeliveryModel>(data);

                return data2;
            }
        }

        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT max(deliveryId) FROM delivery";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        public static DeliveryModel GetDelivery(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM delivery " +
                             "WHERE deliveryId = @Id";
                var parameters = new { Id = id };

                try
                {
                    var Delivery = connection.Query<DeliveryModel>(sql, parameters).First();
                    return Delivery;
                }
                catch
                {
                    DeliveryModel errorDelivery = new DeliveryModel(-1);
                    return errorDelivery;
                }
            }
        }

        public static void InsertDelivery(DeliveryModel newDelivery)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO removal" +
                             "(warehouseId, date) VALUES" +
                             "(@WarehouseId, @Date)";
                var parameters = new
                {
                    WarehouseId = newDelivery.WarehouseId,
                    Date = newDelivery.Date,
                };

                connection.Execute(sql, parameters);
            }
        }
    }
}
