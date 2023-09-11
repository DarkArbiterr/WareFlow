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
    /// Logika interakcji dla klasy AddDeliveryDialog.xaml
    /// </summary>
    public partial class AddDeliveryDialog : Window
    {
        private ObservableCollection<ProductModel> productList;

        public AddDeliveryDialog(ObservableCollection<ProductModel> productList)
        {
            InitializeComponent();
            this.productList = productList;

            // Ustaw źródło danych dla ListView z listą produktów
            productListView.ItemsSource = productList;
        }

            private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku "Dodaj"

            // Pobierz datę dostawy i wybrane produkty
            DateTime? deliveryDate = datePicker.SelectedDate;
            ObservableCollection<ProductModel> selectedProducts = new ObservableCollection<ProductModel>();

            foreach (var product in productList.Where(p => p.IsSelected))
            {
                Console.WriteLine(product.Name);
                selectedProducts.Add(product);
            }

            // Sprawdź, czy dane są poprawne i zatwierdź dialog
            if (deliveryDate.HasValue && selectedProducts.Count > 0)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Wprowadź datę dostawy i wybierz co najmniej jeden produkt.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public DeliveryModel GetDeliveryData()
        {
            // Pobierz dane dostawy
            DateTime? deliveryDate = datePicker.SelectedDate;
            return new DeliveryModel { Date = deliveryDate?.ToString("yyyy-MM-dd") };
        }

        public ObservableCollection<ProductModel> GetSelectedProducts()
        {
            // Pobierz wybrane produkty
            ObservableCollection<ProductModel> selectedProducts = new ObservableCollection<ProductModel>();

            foreach (var product in productList.Where(p => p.IsSelected))
            {
                selectedProducts.Add(product);
            }

            return selectedProducts;
        }
    }
}
