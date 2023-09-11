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
using System.Windows.Shapes;

namespace WareFlowApp
{
    /// <summary>
    /// Logika interakcji dla klasy AddWarehouseDialog.xaml
    /// </summary>
    public partial class AddWarehouseDialog : Window
    {
        public AddWarehouseDialog()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku "Dodaj"

            // Pobierz dane magazynu wprowadzone przez użytkownika
            string name = nameTextBox.Text;

            // Sprawdź, czy dane są poprawne i zatwierdź dialog
            if (!string.IsNullOrEmpty(name))
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Wprowadź nazwę magazynu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public WarehouseModel GetWarehouseData()
        {
            // Pobierz dane magazynu
            return new WarehouseModel { Name = nameTextBox.Text };
        }
    }
}
