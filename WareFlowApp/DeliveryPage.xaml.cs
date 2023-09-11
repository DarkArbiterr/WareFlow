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

            // Dodaj przykładowe dostawy do listy
            deliveryList.Add(new DeliveryModel(1, 1, "2023-09-15"));
            deliveryList.Add(new DeliveryModel(2, 2, "2023-09-16"));

            // Ustaw listę dostaw jako źródło danych ListView
            deliveryListView.ItemsSource = deliveryList;

            // Przykładowe dane produktów (możesz dostosować to do swoich potrzeb)
            productList.Add(new ProductModel { Id = 1, Name = "Produkt 1", Description = "Opis produktu 1" });
            productList.Add(new ProductModel { Id = 2, Name = "Produkt 2", Description = "Opis produktu 2" });
            productList.Add(new ProductModel { Id = 3, Name = "Produkt 3", Description = "Opis produktu 3" });
            productList.Add(new ProductModel { Id = 4, Name = "Produkt 4", Description = "Opis produktu 4" });
        }

        private void AddDeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku "Dodaj dostawę"

            // Stwórz nowe okno dialogowe do dodawania dostawy
            AddDeliveryDialog addDeliveryDialog = new AddDeliveryDialog(productList);

            // Wyświetl okno dialogowe i poczekaj na zakończenie
            bool? result = addDeliveryDialog.ShowDialog();

            // Jeśli użytkownik zatwierdził dodanie dostawy, dodaj ją do listy
            if (result.HasValue && result.Value)
            {
                DeliveryModel newDelivery = addDeliveryDialog.GetDeliveryData();
                deliveryList.Add(newDelivery);

                // Odśwież listę dostaw
                deliveryListView.ItemsSource = null;
                deliveryListView.ItemsSource = deliveryList;
            }
        }

        private void DeliveryListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Obsługa podwójnego kliknięcia na dostawie

            if (deliveryListView.SelectedItem is DeliveryModel selectedDelivery)
            {
                // Stwórz nowe okno dialogowe do wyświetlenia listy produktów w dostawie
                ShowDeliveryProductsDialog(selectedDelivery);
            }
        }

        private void ShowDeliveryProductsDialog(DeliveryModel delivery)
        {
            // Pobierz produkty dostarczone w ramach wybranej dostawy (możesz dostosować to do swoich potrzeb)
            selectedProducts.Clear();
            selectedProducts.Add(new ProductModel { Id = 1, Name = "Produkt 1", Description = "Opis produktu 1" });
            selectedProducts.Add(new ProductModel { Id = 2, Name = "Produkt 2", Description = "Opis produktu 2" });

            // Stwórz nowe okno dialogowe do wyświetlenia listy produktów w dostawie
            DeliveryProductsDialog deliveryProductsDialog = new DeliveryProductsDialog(delivery, selectedProducts);

            // Wyświetl okno dialogowe
            deliveryProductsDialog.ShowDialog();
        }
    }
}
