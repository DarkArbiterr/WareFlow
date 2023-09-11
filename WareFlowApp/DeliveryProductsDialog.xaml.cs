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
    /// Logika interakcji dla klasy DeliveryProductsDialog.xaml
    /// </summary>
    public partial class DeliveryProductsDialog : Window
    {
        private readonly DeliveryModel delivery;
        private ObservableCollection<ProductModel> productsList;

        public DeliveryProductsDialog(DeliveryModel delivery, ObservableCollection<ProductModel> productsList)
        {
            InitializeComponent();
            this.delivery = delivery;
            this.productsList = productsList;

            // Ustaw tytuł okna dialogowego
            Title = $"Produkty w dostawie z {delivery.Date}";

            // Pobierz produkty dostarczone w ramach wybranej dostawy
            var deliveredProducts = productsList; // Możesz dostosować to do swoich potrzeb

            // Ustaw listę produktów jako źródło danych ListView
            productsListView.ItemsSource = deliveredProducts;
        }
    }
}
