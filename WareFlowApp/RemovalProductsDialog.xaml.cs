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
    /// Logika interakcji dla klasy RemovalProductsDialog.xaml
    /// </summary>
    public partial class RemovalProductsDialog : Window
    {
        private readonly RemovalModel removal;
        private ObservableCollection<ProductModel> productsList;
        public RemovalProductsDialog(RemovalModel Removal, ObservableCollection<ProductModel> productsList)
        {
            InitializeComponent();
            this.removal = removal;
            this.productsList = productsList;

            // Ustaw tytuł okna dialogowego
            //Title = $"Produkty z {removal.Date}";

            // Pobierz produkty dostarczone w ramach wybranej dostawy
            var deliveredProducts = productsList;

            // Ustaw listę produktów jako źródło danych ListView
            productsListView.ItemsSource = deliveredProducts;
        }
    }
}
