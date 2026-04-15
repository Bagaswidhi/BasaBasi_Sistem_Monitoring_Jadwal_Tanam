using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Monitoring_Jadwal_Tanam
{
    public partial class FormLahan: Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString = "Data Source=MSI\\BAGASWIDHI;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
        public FormLahan()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }
        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (txtNamaLahan.Text == "")
                {
                    MessageBox.Show("Nama Lahan tidak boleh kosong.");
                    txtNamaLahan.Focus();
                    return;
                }

                if (txtLuasLahan.Text == "")
                {
                    MessageBox.Show("Luas Lahan tidak boleh kosong.");
                    txtLuasLahan.Focus();
                    return;
                }
                string query = @"INSERT INTO DataLahan (NamaLahan, luas_Lahan) VALUES (@NamaLahan, @LuasLahan)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NamaLahan", txtNamaLahan.Text);
                cmd.Parameters.AddWithValue("@LuasLahan", txtLuasLahan.Text);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data berhasil ditambahkan.");
                    txtNamaLahan.Clear();
                    txtLuasLahan.Clear();
                    btn_Load.PerformClick();
                }
                else
                {
                    MessageBox.Show("Gabisa nambahin data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
