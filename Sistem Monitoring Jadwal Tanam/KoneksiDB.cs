using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace Sistem_Monitoring_Jadwal_Tanam
{
    internal class KoneksiDB
    {
        static string connectionString = "Data Source=MSI\\BAGAS;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";

        public static string GetConnectionString()
        {
            string connectionString = "Data Source=192.168.1.113\\BAGAS;Initial Catalog=DBSistemMonitoringMasaTanam;User ID=sa;Password=bagas3005;";
            return connectionString;
        }
    }
}
