using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.Models
{
    internal class RemovalModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string? Date { get; set; }

        public RemovalModel(int id, int warehouseId, string? date)
        {
            Id = id;
            WarehouseId = warehouseId;
            Date = date;
        }

        public RemovalModel(int id)
        {
            Id = id;
        }

        public RemovalModel()
        {
        }
    }
}
