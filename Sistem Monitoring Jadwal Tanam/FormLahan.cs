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

                dataGridView1.Columns.Add("LahanID", "Lahan ID");
                dataGridView1.Columns.Add("NamaLahan", "Nama Tanaman");
                dataGridView1.Columns.Add("luas_lahan", "Luas Lahan (m²)");

                string query = "SELECT * FROM DataLahan";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["LahanID"].ToString(),
                        reader["NamaLahan"].ToString(),
                        reader["luas_lahan"].ToString()
                        );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = @"UPDATE DataLahan SET NamaLahan = @NamaLahan, 
                                                        luas_lahan = @luas_lahan
                                                        WHERE LahanID = @LahanID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NamaLahan", txtNamaLahan.Text);
                cmd.Parameters.AddWithValue("@luas_lahan", txtLuasLahan.Text);
                cmd.Parameters.AddWithValue("@LahanID", txtLahanID.Text);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Yeay, Data berhasil diperbarui!");
                    txtNamaLahan.Clear();
                    txtLuasLahan.Clear();
                    txtLahanID.Clear();
                    btn_Load.PerformClick();
                }
                else
                {
                    MessageBox.Show("Yah, Gagal memperbarui data:(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                DialogResult resultConfirm = MessageBox.Show(
                    "Yakin mau ngehapus data ini?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (resultConfirm == DialogResult.Yes)
                {
                    string query = @"DELETE FROM DataLahan WHERE LahanID = @LahanID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LahanID", txtLahanID.Text);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Yeay, Data berhasil dihapus!");
                        txtLahanID.Clear();
                        btn_Load.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Yah, Datanya ga ketemu:(");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                dataGridView1.Rows.Clear();

                string query = "SELECT * FROM DataLahan WHERE NamaLahan LIKE @SearchText";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchText", "%" + txt_Search.Text + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["LahanID"].ToString(),
                        reader["NamaLahan"].ToString(),
                        reader["luas_lahan"].ToString()
                        );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
