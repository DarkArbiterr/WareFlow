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
    /// Logika interakcji dla klasy AddProductDialog.xaml
    /// </summary>
    public partial class AddProductDialog : Window
    {
        public AddProductDialog()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku "Dodaj"

            // Pobierz dane produktu wprowadzone przez użytkownika
            string name = nameTextBox.Text;
            string description = descriptionTextBox.Text;

            // Sprawdź, czy dane są poprawne i zatwierdź dialog
            if (!string.IsNullOrEmpty(name))
            {
                ProductModel newProduct = new ProductModel { Name = name, Description = description };
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Wprowadź nazwę produktu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ProductModel GetProductData()
        {
            // Pobierz dane produktu
            return new ProductModel { Name = nameTextBox.Text, Description = descriptionTextBox.Text };
        }
    }
}
