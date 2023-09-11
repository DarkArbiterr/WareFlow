using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ProductModel(int id, string? name, string? description) : this(id)
        {
            Name = name;
            Description = description;
        }

        public ProductModel(string? name, string? description)
        {
            Name = name;
            Description = description;
        }

        public ProductModel(int id)
        {
            Id = id;
        }

        public ProductModel()
        {
        }
    }
}
