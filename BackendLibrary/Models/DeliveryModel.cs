using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.Models
{
    public class DeliveryModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string? Date { get; set; }

        public DeliveryModel(int id, int warehouseId, string? date)
        {
            Id = id;
            WarehouseId = warehouseId;
            Date = date;
        }

        public DeliveryModel(int warehouseId, string? date)
        {
            WarehouseId = warehouseId;
            Date = date;
        }

        public DeliveryModel(int id)
        {
            Id = id;
        }

        public DeliveryModel()
        {
        }
    }
}
