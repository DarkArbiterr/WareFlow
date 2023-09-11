using BackendLibrary.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WareFlowApp
{
    /// <summary>
    /// Logika interakcji dla klasy ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private ObservableCollection<ProductModel> productList = new ObservableCollection<ProductModel>();

        public ProductPage()
        {
            InitializeComponent();

            // Dodaj przykładowe produkty do listy
            productList.Add(new ProductModel { Id = 1, Name = "Produkt 1", Description = "Opis produktu 1" });
            productList.Add(new ProductModel { Id = 2, Name = "Produkt 2", Description = "Opis produktu 2" });

            // Ustaw listę jako źródło danych ListView
            productListView.ItemsSource = productList;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku usuwania
            if (sender is Button button)
            {
                if (button.Tag is ProductModel product)
                {
                    // Usuń produkt z listy
                    productList.Remove(product);
                    // Odśwież listę
                    productListView.ItemsSource = null;
                    productListView.ItemsSource = productList;
                }
            }
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku "Dodaj produkt"

            // Stwórz nowe okno dialogowe
            AddProductDialog addProductDialog = new AddProductDialog();

            // Wyświetl okno dialogowe i poczekaj na zakończenie
            bool? result = addProductDialog.ShowDialog();

            // Jeśli użytkownik zatwierdził dodanie produktu, dodaj go do listy
            if (result.HasValue && result.Value)
            {
                ProductModel newProduct = addProductDialog.GetProductData();
                productList.Add(newProduct);

                // Odśwież listę
                productListView.ItemsSource = null;
                productListView.ItemsSource = productList;
            }
        }
    }
}
