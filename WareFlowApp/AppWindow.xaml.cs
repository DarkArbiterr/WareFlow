using System;
using System.ServiceProcess;
using System.Diagnostics;
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
    /// Logika interakcji dla klasy AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        string serviceName = "WareflowLoggerService";
        ServiceController serviceController = new ServiceController("WareflowLoggerService");
        public AppWindow()
        {
            InitializeComponent();

            try
            {
                if (serviceController.Status != ServiceControllerStatus.Running)
                {
                    string[] args = {"TestUser"};

                    serviceController.Start(args);
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(5));
                    Console.WriteLine("Service started successfully.");
                    serviceController.ExecuteCommand(200);
                }
                else
                {
                    Console.WriteLine("Service is already running.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!Error starting the service: " + ex.Message);
            }
        }

        ~AppWindow()
        {
            try
            {
                if (serviceController.Status != ServiceControllerStatus.Stopped)
                {
                    serviceController.Stop();
                    serviceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(5));
                    Console.WriteLine("Service stopped successfully.");
                }
                else
                {
                    Console.WriteLine("Service is already stopped.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error stopping the service: " + ex.Message);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
