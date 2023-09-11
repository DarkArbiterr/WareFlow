using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.DataAccess
{
    public class SqlConnector
    {
        public static readonly string connectionString =
            "Server=" + ConfigurationManager.AppSettings["DbServer"] +
            ";User Id=" + ConfigurationManager.AppSettings["DbUser"] +
            ";Password=" + ConfigurationManager.AppSettings["DbPassword"] +
            ";Database=" + ConfigurationManager.AppSettings["DbName"];
    }
}
