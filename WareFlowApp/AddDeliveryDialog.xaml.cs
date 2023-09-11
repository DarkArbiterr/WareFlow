using BackendLibrary.DataAccess;
using BackendLibrary.Models;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
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
        public class SelectedProduct
        {
            public ProductModel Product { get; set; }
            public bool IsSelected { get; set; }
        }

        private ObservableCollection<SelectedProduct> selectedProducts;
        private ObservableCollection<ProductModel> productList;

        public AddDeliveryDialog(ObservableCollection<ProductModel> productList)
        {
            InitializeComponent();
            this.productList = productList;

            // Initialize the list of selected products
            selectedProducts = new ObservableCollection<SelectedProduct>(
                productList.Select(product => new SelectedProduct { Product = product, IsSelected = false })
            );

            // Set the ListView's ItemsSource to the selectedProducts collection
            productListView.ItemsSource = selectedProducts;
        }

        // Method to get a list of selected ProductModel items
        public List<ProductModel> GetSelectedProducts()
        {
            List<ProductModel> selectedProductModels = selectedProducts
                .Where(selectedProduct => selectedProduct.IsSelected)
                .Select(selectedProduct => selectedProduct.Product)
                .ToList();

            return selectedProductModels;
        }

        // Event handler for the "Dodaj" (Add) button click
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            List<ProductModel> selectedProducts = GetSelectedProducts();

            DialogResult = true;
        }


        public DeliveryModel GetDeliveryData()
        {
            // Pobierz dane dostawy
            DateTime? deliveryDate = datePicker.SelectedDate;
            return new DeliveryModel { WarehouseId = Convert.ToInt32(warehouseIdTextBox.Text), Date = deliveryDate?.ToString("yyyy-MM-dd") };
        }

    }
}
