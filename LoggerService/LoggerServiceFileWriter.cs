using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace LoggerService
{
    public static class LoggerServiceFileWriter
    {
        public static void WriteToFile(string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;// + Properties.Settings.Default.pathLog;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //string filepath = AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.nameLog + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";

            StreamWriter sw;
            if (!File.Exists(filepath))
            {
                using (sw = File.CreateText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (sw = File.AppendText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
        }

        public static void ServiceOnTest()
        {
            WriteToFile("[" + DateTime.Now + "]: Service test performed.");
        }

        public static void ServiceOnStart()
        {
            WriteToFile("[" + DateTime.Now + "]: Service start.");
        }

        public static void ServiceOnStop()
        {
            WriteToFile("[" + DateTime.Now + "]: Service stop.");
        }

        public static void ServiceOnLogin(string username)
        {
            WriteToFile("[" + DateTime.Now + "]: User " + username + " logged in");
        }
        public static void ServiceOnLogout(string username)
        {
            WriteToFile("[" + DateTime.Now + "]: User " + username + " logged out");
        }

        public static void ServiceOnProductAdd(string username)
        {
            WriteToFile("[" + DateTime.Now + "]: User " + username + " added a new product");
        }

        public static void ServiceOnDeliveryAdd(string username)
        {
            WriteToFile("[" + DateTime.Now + "]: User " + username + " added a new delivery");
        }

        public static void ServiceOnRemovalAdd(string username)
        {
            WriteToFile("[" + DateTime.Now + "]: User " + username + " added a new removal");
        }

        public static void ServiceOnWarehouseAdd(string username)
        {
            WriteToFile("[" + DateTime.Now + "]: User " + username + " added a new warehouse");
        }
    }
}
