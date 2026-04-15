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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = @"UPDATE DataTanaman SET NamaTanaman = @NamaTanaman, 
                                                        LamaMasaTanam = @LamaMasaTanam 
                                                        WHERE TanamanID = @TanamanID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NamaTanaman", txtNamaTanaman.Text);
                cmd.Parameters.AddWithValue("@LamaMasaTanam", txtLamaMasaTanam.Text);
                cmd.Parameters.AddWithValue("@TanamanID", txtTanamanID.Text);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data berhasil diperbarui.");
                    txtNamaTanaman.Clear();
                    txtLamaMasaTanam.Clear();
                    txtTanamanID.Clear();
                    btn_Load.PerformClick();
                }
                else
                {
                    MessageBox.Show("Gagal memperbarui data.");
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
                    "Apakah Anda yakin ingin menghapus data ini?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (resultConfirm == DialogResult.Yes)
                {
                    string query = @"DELETE FROM DataTanaman WHERE TanamanID = @TanamanID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TanamanID", txtTanamanID.Text);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus.");
                        txtTanamanID.Clear();
                        btn_Load.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtTanamanID.Text = row.Cells["TanamanID"].Value.ToString();
            txtNamaTanaman.Text = row.Cells["NamaTanaman"].Value.ToString();
            txtLamaMasaTanam.Text = row.Cells["LamaMasaTanam"].Value.ToString();
        }

        private void FormTanaman_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Form formHome = Application.OpenForms["Form1"];

            if(formHome != null)
            {
                formHome.Show();
            }
            this.Close();
        }
    }
}
