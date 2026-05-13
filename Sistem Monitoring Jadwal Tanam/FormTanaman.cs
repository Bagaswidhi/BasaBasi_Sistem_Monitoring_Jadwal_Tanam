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
        private readonly string connectionString = "Data Source=MSI\\BAGAS;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
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

                string query = "SELECT * FROM v_GetTanaman";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Menggunakan SqlDataAdapter untuk menarik data sekaligus
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                // Masukkan semua data dari database ke dalam DataTable
                adapter.Fill(dt);

                // Berikan data tersebut ke BindingSource.
                // DataGridView otomatis akan terisi dan ter-refresh!
                dataTanamanBindingSource.DataSource = dt;
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
                using (SqlCommand cmd = new SqlCommand("sp_InsertTanaman", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NamaTanaman", txtNamaTanaman.Text);
                    cmd.Parameters.AddWithValue("@LamaMasaTanam", txtLamaMasaTanam.Text);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0 )
                    {
                        MessageBox.Show("Data tanaman berhasil ditambahkan.");
                        btn_Load.PerformClick();
                    }
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
            // TODO: This line of code loads data into the 'dB_SMJT_DataTanamanSet.DataTanaman' table. You can move, or remove it, as needed.
            this.dataTanamanTableAdapter.Fill(this.dB_SMJT_DataTanamanSet.DataTanaman);
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Form formHome = Application.OpenForms["Form1"];

            if (formHome != null)
            {
                formHome.Show();
            }
            this.Close();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                dataGridView1.Rows.Clear();

                string query = "SELECT * FROM DataTanaman WHERE NamaTanaman LIKE @SearchText";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchText", "%" + txt_Search.Text + "%");

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
    }
}