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
using BackendLibrary.DataAccess;
using System.Collections.Concurrent;

namespace WareFlowApp
{

    /// <summary>
    /// Logika interakcji dla klasy DeliveryPage.xaml
    /// </summary>
    public partial class DeliveryPage : Page
    {
        private ObservableCollection<DeliveryModel> deliveryList = new ObservableCollection<DeliveryModel>();
        private ObservableCollection<ProductModel> productList = new ObservableCollection<ProductModel>();
        private ObservableCollection<ProductModel> selectedProducts = new ObservableCollection<ProductModel>();

        public DeliveryPage()
        {
            InitializeComponent();

            deliveryList = DeliveryData.GetAllDeliveries();

            // Ustaw listę dostaw jako źródło danych ListView
            deliveryListView.ItemsSource = deliveryList;

            productList = ProductData.GetAllProducts();
        }

        private void AddDeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            // Stwórz nowe okno dialogowe do dodawania dostawy
            AddDeliveryDialog addDeliveryDialog = new AddDeliveryDialog(productList);

            // Wyświetl okno dialogowe i poczekaj na zakończenie
            bool? result = addDeliveryDialog.ShowDialog();

            // Jeśli użytkownik zatwierdził dodanie dostawy, dodaj ją do listy
            if (result.HasValue && result.Value)
            {
                DeliveryModel newDelivery = addDeliveryDialog.GetDeliveryData();
                selectedProducts = new ObservableCollection<ProductModel>(addDeliveryDialog.GetSelectedProducts());
                deliveryList.Add(newDelivery);

                DeliveryData.InsertDelivery(newDelivery);
                
                DeliveryData.InsertDeliveryProducts(DeliveryData.GetMaxId(), selectedProducts);
                
                // Odśwież listę dostaw
                deliveryListView.ItemsSource = null;
                deliveryListView.ItemsSource = deliveryList;
            }
        }
        
        private void DeliveryListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (deliveryListView.SelectedItem is DeliveryModel selectedDelivery)
            {
                // Stwórz nowe okno dialogowe do wyświetlenia listy produktów w dostawie
                ShowDeliveryProductsDialog(selectedDelivery);
            }
        }

        private void ShowDeliveryProductsDialog(DeliveryModel delivery)
        {
            selectedProducts = ProductData.GetProductsByDelivery(delivery.Id);

            // Stwórz nowe okno dialogowe do wyświetlenia listy produktów w dostawie
            DeliveryProductsDialog deliveryProductsDialog = new DeliveryProductsDialog(delivery, selectedProducts);

            // Wyświetl okno dialogowe
            deliveryProductsDialog.ShowDialog();
        
        }
        
    }
}
