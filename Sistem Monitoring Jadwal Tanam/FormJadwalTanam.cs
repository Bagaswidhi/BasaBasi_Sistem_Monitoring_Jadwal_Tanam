using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistem_Monitoring_Jadwal_Tanam
{
    public partial class FormJadwalTanam : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString = "Data Source=MSI\\BAGASWIDHI;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
        private string idJadwalTerpilih = "";
        public FormJadwalTanam()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);

        }

        private void BersihkanForm()
        {
            txtIdTanaman.Clear();
            txtIdLahan.Clear();
            txtEstimasiPanen.Clear(); // TextBox ini diset ReadOnly=true

            // Kembalikan kalender ke hari ini
            dtpTanggalTanam.Value = DateTime.Now;

            idJadwalTerpilih = "";
            txtIdTanaman.Focus();
        }
    }
}
