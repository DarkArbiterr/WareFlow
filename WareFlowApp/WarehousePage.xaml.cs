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

namespace WareFlowApp
{
    /// <summary>
    /// Logika interakcji dla klasy WarehousePage.xaml
    /// </summary>
    public partial class WarehousePage : Page
    {
        private ObservableCollection<WarehouseModel> warehouseList = new ObservableCollection<WarehouseModel>();

        public WarehousePage()
        {
            InitializeComponent();

            warehouseList = WarehouseData.GetAllWarehouses();

            // Ustaw listę jako źródło danych ListView
            warehouseListView.ItemsSource = warehouseList;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku usuwania
            if (sender is Button button)
            {
                if (button.Tag is WarehouseModel warehouse)
                {
                    // Usuń magazyn z listy
                    warehouseList.Remove(warehouse);
                    // Odśwież listę
                    warehouseListView.ItemsSource = null;
                    warehouseListView.ItemsSource = warehouseList;

                    WarehouseData.DeleteWarehouse(warehouse.Id);

                    AppWindow.serviceController.ExecuteCommand(216);
                }
            }
        }

        private void AddWarehouseButton_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku "Dodaj magazyn"

            // Stwórz nowe okno dialogowe do dodawania magazynu
            AddWarehouseDialog addWarehouseDialog = new AddWarehouseDialog();

            // Wyświetl okno dialogowe i poczekaj na zakończenie
            bool? result = addWarehouseDialog.ShowDialog();

            // Jeśli użytkownik zatwierdził dodanie magazynu, dodaj go do listy
            if (result.HasValue && result.Value)
            {
                WarehouseModel newWarehouse = addWarehouseDialog.GetWarehouseData();
                warehouseList.Add(newWarehouse);

                WarehouseData.InsertWarehouse(newWarehouse);

                // Odśwież listę
                warehouseListView.ItemsSource = null;
                warehouseListView.ItemsSource = warehouseList;

                AppWindow.serviceController.ExecuteCommand(206);
            }
        }

        private void WarehouseListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Obsługa podwójnego kliknięcia na magazynie

            if (warehouseListView.SelectedItem is WarehouseModel selectedWarehouse)
            {
                // Stwórz nowe okno dialogowe do wyświetlenia listy produktów w magazynie
                ShowWarehouseProductsDialog(selectedWarehouse);
            }
        }

        private void ShowWarehouseProductsDialog(WarehouseModel warehouse)
        {
            // Stwórz nowe okno dialogowe do wyświetlenia listy produktów w magazynie
            WarehouseProductsDialog warehouseProductsDialog = new WarehouseProductsDialog(warehouse);

            // Wyświetl okno dialogowe
            warehouseProductsDialog.ShowDialog();
        }
    }
}
