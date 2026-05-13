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
        private readonly string connectionString = "Data Source=MSI\\BAGAS;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
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
                 using (SqlCommand cmd = new SqlCommand("sp_InsertLahan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NamaLahan", txtNamaLahan.Text);
                    cmd.Parameters.AddWithValue("@luas_lahan", txtLuasLahan.Text);
                    int result = cmd.ExecuteNonQuery();
                    if (result < 0 )
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

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT * FROM v_GetLahan";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Menggunakan SqlDataAdapter untuk menarik data sekaligus
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                // Masukkan semua data dari database ke dalam DataTable
                adapter.Fill(dt);

                // Berikan data tersebut ke BindingSource.
                // DataGridView otomatis akan terisi dan ter-refresh!
                dataLahanBindingSource.DataSource = dt;
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

                using (SqlCommand cmd = new SqlCommand("sp_UpdateLahan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LahanID", Convert.ToInt32(txtLahanID.Text));
                    cmd.Parameters.AddWithValue("@NamaLahan", txtNamaLahan.Text);
                    cmd.Parameters.AddWithValue("@luas_lahan", txtLuasLahan.Text);

                    int result = cmd.ExecuteNonQuery();

                    if (result < 0)
                    {
                        MessageBox.Show("Data tanaman berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_Load.PerformClick();
                    }
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
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteLahan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LahanID", Convert.ToInt32(txtLahanID.Text));

                        int result = cmd.ExecuteNonQuery();

                        if (result < 0)
                        {
                            MessageBox.Show("Data LahanID berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btn_Load.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void text_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // 1. Jika kotak pencarian kosong, tampilkan semua data kembali
                if (string.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    dataLahanBindingSource.RemoveFilter(); // Menghapus filter
                }
                else
                {
                    // 2. Jika ada teks, saring data yang ada di BindingSource
                    // Kita menggunakan Convert() agar tipe data angka (LahanID) bisa dicari seperti teks (LIKE)
                    dataLahanBindingSource.Filter = $"Convert(LahanID, 'System.String') LIKE '%{text_Search.Text}%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat pencarian: " + ex.Message);
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtLahanID.Text = row.Cells["LahanID"].Value.ToString();
            txtNamaLahan.Text = row.Cells["NamaLahan"].Value.ToString();
            txtLuasLahan.Text = row.Cells["luas_lahan"].Value.ToString();
        }

        private void FormLahan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_SMJT_DataLahanSet.DataLahan' table. You can move, or remove it, as needed.
            this.dataLahanTableAdapter.Fill(this.dB_SMJT_DataLahanSet.DataLahan);
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }
    }
}
