using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public UserModel(int userId, string? email, string? password, string? name, string? surname)
        {
            UserId = userId;
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
        }

        public UserModel(string? email, string? password, string? name, string? surname)
        {
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
        }

        public UserModel(int userId)
        {
            UserId = userId;
        }

        public UserModel()
        {
        }
    }
}
