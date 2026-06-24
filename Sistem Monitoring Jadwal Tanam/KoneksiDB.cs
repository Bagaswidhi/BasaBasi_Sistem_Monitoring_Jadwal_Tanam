using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Monitoring_Jadwal_Tanam
{
    internal class KoneksiDB
    {
        static string connectionString = "Data Source=MSI\\BAGAS;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
