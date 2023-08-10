using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public UserModel(int id, string? name, string? surname, string? email, string? password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }

        public UserModel(string? name, string? surname, string? email, string? password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }

        public UserModel(int id)
        {
            Id = id;
        }

        public UserModel()
        {
        }
    }
}
