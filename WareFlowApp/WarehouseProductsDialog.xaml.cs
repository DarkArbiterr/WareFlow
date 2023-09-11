using BackendLibrary.Models;
using BackendLibrary.DataAccess;
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
            productsList = ProductData.GetProductsByWarehouse(warehouse.Id);

            // Ustaw listę produktów jako źródło danych ListView
            productsListView.ItemsSource = productsList.ToList();
        }
    }
}
