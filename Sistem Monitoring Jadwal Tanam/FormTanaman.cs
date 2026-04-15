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
    public partial class FormTanaman : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString = "Data Source=MSI\\BAGASWIDHI;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
        public FormTanaman()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("TanamanID", "Tanaman ID");
                dataGridView1.Columns.Add("NamaTanaman", "Nama Tanaman");
                dataGridView1.Columns.Add("LamaMasaTanam", "Lama Masa Tanam (hari)");

                string query = "SELECT * FROM DataTanaman";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["TanamanID"].ToString(),
                        reader["NamaTanaman"].ToString(),
                        reader["LamaMasaTanam"].ToString()
                        );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (txtNamaTanaman.Text == "")
                {
                    MessageBox.Show("Nama Tanaman tidak boleh kosong.");
                    txtNamaTanaman.Focus();
                    return;
                }

                if (txtLamaMasaTanam.Text == "")
                {
                    MessageBox.Show("Lama Masa Tanam tidak boleh kosong.");
                    txtLamaMasaTanam.Focus();
                    return;
                }
                string query = @"INSERT INTO DataTanaman (NamaTanaman, LamaMasaTanam) VALUES (@NamaTanaman, @LamaMasaTanam)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NamaTanaman", txtNamaTanaman.Text);
                cmd.Parameters.AddWithValue("@LamaMasaTanam", txtLamaMasaTanam.Text);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data berhasil ditambahkan.");
                    txtNamaTanaman.Clear();
                    txtLamaMasaTanam.Clear();
                    btn_Load.PerformClick();
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
