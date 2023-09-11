using BackendLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WareFlowApp
{
    /// <summary>
    /// Logika interakcji dla klasy WarehouseProductsDialog.xaml
    /// </summary>
    public partial class WarehouseProductsDialog : Window
    {
        private readonly WarehouseModel warehouse;
        private ObservableCollection<ProductModel> productsList = new ObservableCollection<ProductModel>();

        public WarehouseProductsDialog(WarehouseModel warehouse)
        {
            InitializeComponent();
            this.warehouse = warehouse;

            // Ustaw tytuł okna dialogowego
            Title = $"Produkty w magazynie: {warehouse.Name}";

            // Przykładowe dane produktów w magazynie (możesz dostosować to do swoich potrzeb)
            productsList.Add(new ProductModel { Id = 1, Name = "Produkt 1", Description = "Opis produktu 1" });
            productsList.Add(new ProductModel { Id = 2, Name = "Produkt 2", Description = "Opis produktu 2" });

            // Filtruj produkty, aby wyświetlić tylko te należące do wybranego magazynu
            var warehouseProducts = productsList.Where(p => p.Id % 2 == 0); // Przykład filtrowania

            // Ustaw listę produktów jako źródło danych ListView
            productsListView.ItemsSource = warehouseProducts.ToList();
        }
    }
}
