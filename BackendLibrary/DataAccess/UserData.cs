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
    public class UserData : SqlConnector
    {
        public static void DeleteUser(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM user WHERE userId = {id}";

                connection.Execute(sql);
            }
        }

        public static ObservableCollection<UserModel> GetAllUsers()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM user";
                var data = connection.Query<UserModel>(sql).ToList();

                ObservableCollection<UserModel> data2 = new ObservableCollection<UserModel>(data);

                return data2;
            }
        }

        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT max(userId) FROM user";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        public static UserModel GetUser(string email, string password)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM user " +
                             "WHERE email = @Email AND password = @Password";
                var parameters = new { Email = email, Password = password };

                try
                {
                    var user = connection.Query<UserModel>(sql, parameters).First();
                    return user;
                }
                catch
                {
                    UserModel errorUser = new UserModel(-1);
                    return errorUser;
                }
            }
        }

        public static void InsertUser(UserModel newUser)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString)) 
            {
                string sql = "INSERT INTO user" +
                             "(email, password, firstName, secondName) VALUES" +
                             "(@Email, @Password, @Name, @Surname)";
                var parameters = new { Email = newUser.Email, Password = newUser.Password, 
                                       Name = newUser.Name, Surname = newUser.Surname };

                connection.Execute(sql, parameters);
            }
        }
    }
}
