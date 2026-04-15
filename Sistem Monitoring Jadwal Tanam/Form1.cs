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
    public partial class Form1: Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString = "Data Source=MSI\\BAGASWIDHI;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void ConnectDatabase()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                MessageBox.Show("Yeay, Koneksi Ke Database Berhasil!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_DataTanaman_Click(object sender, EventArgs e)
        {
            FormTanaman formTanaman = new FormTanaman();
            
            formTanaman.Show();

            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_DataLahan_Click(object sender, EventArgs e)
        {
            FormLahan formLahan = new FormLahan();
            formLahan.Show();
            this.Hide();
        }

        private void btn_JadwalTanam_Click(object sender, EventArgs e)
        {
            FormJadwalTanam formJadwalTanam = new FormJadwalTanam();
            formJadwalTanam.Show();
            this.Hide();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            FormReport formReport = new FormReport();
            formReport.Show();
            this.Hide();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectDatabase();
        }
    }
}
