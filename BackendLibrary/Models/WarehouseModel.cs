using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }

        public WarehouseModel(int id, int userId, string? name)
        {
            Id = id;
            UserId = userId;
            Name = name;
        }

        public WarehouseModel(int id)
        {
            Id = id;
        }

        public WarehouseModel()
        {
        }
    }
}
