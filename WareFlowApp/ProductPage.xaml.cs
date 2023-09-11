using BackendLibrary.Models;
using BackendLibrary.DataAccess;
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
using System.ServiceProcess;

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

            productList = ProductData.GetAllProducts();
            
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
                    //Usuń produkt z bazy
                    ProductData.DeleteProduct(product.Id);
                    // Dodaj log
                    AppWindow.serviceController.ExecuteCommand(213);
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

                //Dodaj do bazy
                ProductData.InsertProduct(newProduct);

                // Odśwież listę
                productListView.ItemsSource = null;
                productListView.ItemsSource = productList;

                // Dodaj log
                AppWindow.serviceController.ExecuteCommand(203);
            }
        }
    }
}
