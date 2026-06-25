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
            string connectionString = $"Data Source={GetLocalIpAddress()};Initial Catalog=DBSistemMonitoringMasaTanam;User ID =sa; Password=bagas3005;";
            return connectionString;
        }
        public static string GetLocalIpAddress()
        {
            string localIP = string.Empty;
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting local IP address: " + ex.Message);
            }
            return localIP;
        }
    }
}
