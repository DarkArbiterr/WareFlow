using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Org.BouncyCastle.Crypto.Tls;
using BackendLibrary.Models;
using BackendLibrary.DataAccess;

namespace WareFlowApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDragging = false;
        private UserModel loggedUser = new UserModel();

        public void Login()
        {
            string email = emailBox.Text;
            string password = passwordBox.Password;
            loggedUser.UserId = -1;
            if (UserData.GetUser(email, password).UserId != -1)
            {
                loggedUser = UserData.GetUser(email, password);
                Console.WriteLine("Successfull login!");
            }
            else
            {
                Console.WriteLine("Wrong email or password");
                //TODO - dodanie pojawienie się okna z informacją o złych danych
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Exit Click!");
            Close();
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Minimize Click!");
            WindowState = WindowState.Minimized;
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Login Clicked!");
            Login();
            
            if(loggedUser.UserId != -1)
            {
                AppWindow appWindow = new AppWindow();
                this.Visibility = Visibility.Hidden;
                appWindow.Show();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = true;
                this.DragMove();
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }
    }
}