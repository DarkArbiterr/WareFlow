using BackendLibrary.DataAccess;
using BackendLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static WareFlowApp.AddDeliveryDialog;

namespace WareFlowApp
{
    public partial class RemovalPage : Page
    {
        private ObservableCollection<RemovalModel> removalList = new ObservableCollection<RemovalModel>();
        private ObservableCollection<ProductModel> selectedProducts = new ObservableCollection<ProductModel>();

        public RemovalPage()
        {
            InitializeComponent();

            removalList = RemovalData.GetAllRemovals();

            removalListView.ItemsSource = removalList;
        }

        private void RemovalListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (removalListView.SelectedItem is RemovalModel selectedRemoval)
            {
                ShowRemovalDetailsDialog(selectedRemoval);
            }
        }

        private void ShowRemovalDetailsDialog(RemovalModel removal)
        {
            selectedProducts = ProductData.GetProductsByRemoval(removal.Id);

            // Stwórz nowe okno dialogowe do wyświetlenia listy produktów w dostawie
            RemovalProductsDialog removalProductsDialog = new RemovalProductsDialog(removal, selectedProducts);

            // Wyświetl okno dialogowe
            removalProductsDialog.ShowDialog();
        }
    }
}
