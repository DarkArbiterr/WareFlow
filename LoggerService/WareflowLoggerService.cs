using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public partial class WareflowLoggerService : ServiceBase
    {
        public static string username = "user";

        public WareflowLoggerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            username = args[0];

            if (!EventLog.SourceExists("WareflowLoggerServiceSource"))
            {
                EventLog.CreateEventSource("WareflowLoggerServiceSource", "Application");
            }

            try
            {
                EventLog.WriteEntry("Service started.", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to event log: " + ex.Message);
            }

            LoggerServiceFileWriter.ServiceOnStart();
        }

        protected override void OnStop()
        {
            LoggerServiceFileWriter.ServiceOnStop();
            EventLog.WriteEntry("Service stopped.");
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);

            switch(command)
            {
                case 200:
                    LoggerServiceFileWriter.ServiceOnTest(username);
                    EventLog.WriteEntry("Service test command used by user " + username + ".");

                    break;
                case 201:
                    LoggerServiceFileWriter.ServiceOnLogin(username);
                    EventLog.WriteEntry("User " + username + " logged in.");

                    break;

                case 202:
                    LoggerServiceFileWriter.ServiceOnLogout(username);
                    EventLog.WriteEntry("User " + username + " logged out.");

                    break;

                case 203:
                    LoggerServiceFileWriter.ServiceOnProductAdd(username);
                    EventLog.WriteEntry("User " + username + " added a new product.");

                    break;

                case 204:
                    LoggerServiceFileWriter.ServiceOnDeliveryAdd(username);
                    EventLog.WriteEntry("User " + username + " added a new delivery.");

                    break;

                case 205:
                    LoggerServiceFileWriter.ServiceOnRemovalAdd(username);
                    EventLog.WriteEntry("User " + username + " added a new removal.");

                    break;

                case 206:
                    LoggerServiceFileWriter.ServiceOnWarehouseAdd(username);
                    EventLog.WriteEntry("User " + username + " added a new warehouse.");

                    break;
            }
        }
    }
}
