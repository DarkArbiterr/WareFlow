using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.Models
{
    public class ProductModel : INotifyPropertyChanged
    {
        private bool isSelected;

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [AllowNull]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
