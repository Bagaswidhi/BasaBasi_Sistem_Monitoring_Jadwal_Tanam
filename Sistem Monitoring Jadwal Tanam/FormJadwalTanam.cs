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
        private readonly string connectionString = "Data Source=MSI\\BAGAS;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
        private string idJadwalTerpilih = "";
        public FormJadwalTanam()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            dtpTanggalTanam.MaxDate = DateTime.Today;
        }

        private void MuatComboBox()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // ==========================================
                // 1. MENGISI COMBOBOX TANAMAN (Pakai BindingSource)
                // ==========================================
                string queryTanaman = "SELECT * FROM v_Get_CMB_DataTanaman";
                SqlDataAdapter daTanaman = new SqlDataAdapter(queryTanaman, conn);
                DataTable dtTanaman = new DataTable();
                daTanaman.Fill(dtTanaman);

                // Buat jembatan BindingSource
                BindingSource bsTanaman = new BindingSource();
                bsTanaman.DataSource = dtTanaman; // Masukkan data tabel ke jembatan

                // Pasangkan jembatan ke ComboBox
                cmbTanaman.DataSource = bsTanaman;
                cmbTanaman.DisplayMember = "NamaTanaman";
                cmbTanaman.ValueMember = "TanamanID";
                cmbTanaman.SelectedIndex = -1;


                // ==========================================
                // 2. MENGISI COMBOBOX LAHAN (Pakai BindingSource)
                // ==========================================
                string queryLahan = "SELECT * FROM v_Get_CMB_DataLahan";
                SqlDataAdapter daLahan = new SqlDataAdapter(queryLahan, conn);
                DataTable dtLahan = new DataTable();
                daLahan.Fill(dtLahan);

                // Buat jembatan BindingSource
                BindingSource bsLahan = new BindingSource();
                bsLahan.DataSource = dtLahan; // Masukkan data tabel ke jembatan

                // Pasangkan jembatan ke ComboBox
                cmbLahan.DataSource = bsLahan;
                cmbLahan.DisplayMember = "NamaLahan";
                cmbLahan.ValueMember = "LahanID";
                cmbLahan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat pilihan: " + ex.Message);
            }
        }

        private void FormJadwalTanam_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_SMJT_JadwalTanamSet.JadwalTanam' table. You can move, or remove it, as needed.
            this.jadwalTanamTableAdapter.Fill(this.dB_SMJT_JadwalTanamSet.JadwalTanam);
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellClick += dataGridView1_CellContentClick;

            MuatComboBox();
            btn_Load.PerformClick();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                idJadwalTerpilih = row.Cells["JadwalID"].Value.ToString();
                cmbTanaman.SelectedValue = row.Cells["TanamanID"].Value.ToString();
                cmbLahan.SelectedValue = row.Cells["LahanID"].Value.ToString();
                dtpTanggalTanam.Value = Convert.ToDateTime(row.Cells["TanggalTanam"].Value);
                txtEstimasiPanen.Text = Convert.ToDateTime(row.Cells["EstimasiPanen"].Value).ToString("yyyy-MM-dd");

                if (row.Cells["TanggalTanam"].Value != DBNull.Value)
                {
                    dtpTanggalTanam.Value = Convert.ToDateTime(row.Cells["TanggalTanam"].Value);
                }

                if (row.Cells["EstimasiPanen"].Value != DBNull.Value)
                {
                    DateTime est = Convert.ToDateTime(row.Cells["EstimasiPanen"].Value);
                    txtEstimasiPanen.Text = est.ToString("yyyy-MM-dd");
                }
            }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if (cmbLahan.Text == "" || cmbTanaman.Text == "")
            {
                MessageBox.Show("ID Tanaman atau ID Lahan harus diisi.");
                return;
            }
            try
            {
                // Mengecek Data Tanaman pada tabel DataTanaman
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string queryCheck = "SELECT LamaMasaTanam FROM DataTanaman WHERE TanamanID = @TanamanID";
                SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                cmdCheck.Parameters.AddWithValue("@TanamanID", cmbTanaman.SelectedValue);

                object result = cmdCheck.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Tanaman dengan ID tersebut tidak ditemukan.");
                    return;
                }

                // Jika tanaman ditemukan, lanjutkan dengan kalkulasi estimasi panen
                DateTime tanggalTanam = dtpTanggalTanam.Value.Date;

                // Hitung Estimasi
                int masaTanamHari = Convert.ToInt32(result);
                DateTime estimasiPanen = tanggalTanam.AddDays(masaTanamHari);
                txtEstimasiPanen.Text = estimasiPanen.ToString("yyyy-MM-dd");


                string querySimpan = @"INSERT INTO JadwalTanam (TanamanID, LahanID, TanggalTanam, EstimasiPanen) 
                                       VALUES (@TanamanID, @LahanID, @TanggalTanam, @EstimasiPanen)";
                SqlCommand cmdSimpan = new SqlCommand(querySimpan, conn);
                cmdSimpan.Parameters.AddWithValue("@TanamanID", cmbTanaman.SelectedValue);
                cmdSimpan.Parameters.AddWithValue("@LahanID", cmbLahan.SelectedValue);
                cmdSimpan.Parameters.AddWithValue("@TanggalTanam", tanggalTanam);
                cmdSimpan.Parameters.AddWithValue("@EstimasiPanen", estimasiPanen);
                cmdSimpan.ExecuteNonQuery();


                MessageBox.Show("Jadwal tanam berhasil disimpan.");
                btn_Load.PerformClick();
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
                string queryCheck = "SELECT LamaMasaTanam FROM DataTanaman WHERE TanamanID = @TanamanID";
                SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                cmdCheck.Parameters.AddWithValue("@TanamanID", cmbTanaman.SelectedValue);

                object result = cmdCheck.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Tanaman dengan ID tersebut tidak ditemukan.");
                    return;
                }

                DateTime tanggalTanam = dtpTanggalTanam.Value.Date;
                int masaTanamHari = Convert.ToInt32(result);
                DateTime estimasiPanen = tanggalTanam.AddDays(masaTanamHari);

                txtEstimasiPanen.Text = estimasiPanen.ToString("yyyy-MM-dd");

                string queryUpdate = @"UPDATE JadwalTanam SET TanamanID = @TanamanID, 
                                                        LahanID = @LahanID, 
                                                        TanggalTanam = @TanggalTanam, 
                                                        EstimasiPanen = @EstimasiPanen
                                                        WHERE JadwalID = @JadwalID";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn);
                cmdUpdate.Parameters.AddWithValue("@TanamanID", cmbTanaman.SelectedValue);
                cmdUpdate.Parameters.AddWithValue("@LahanID",  cmbLahan.SelectedValue);
                cmdUpdate.Parameters.AddWithValue("@TanggalTanam", tanggalTanam);
                cmdUpdate.Parameters.AddWithValue("@EstimasiPanen", estimasiPanen);
                cmdUpdate.Parameters.AddWithValue("@JadwalID", idJadwalTerpilih);
                int resultUpdate = cmdUpdate.ExecuteNonQuery();
                if (resultUpdate > 0)
                {
                    MessageBox.Show("Jadwal tanam berhasil diperbarui.");
                    idJadwalTerpilih = "";
                    btn_Load.PerformClick();
                }
                else
                {
                    MessageBox.Show("Jadwal tanam tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin menghapus jadwal tanam ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    string queryDelete = "DELETE FROM JadwalTanam WHERE JadwalID = @JadwalID";
                    SqlCommand cmdDelete = new SqlCommand(queryDelete, conn);
                    cmdDelete.Parameters.AddWithValue("@JadwalID", idJadwalTerpilih);
                    int resultDelete = cmdDelete.ExecuteNonQuery();
                    if (resultDelete > 0)
                    {
                        MessageBox.Show("Jadwal tanam berhasil dihapus.");
                        idJadwalTerpilih = "";
                        btn_Load.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Jadwal tanam tidak ditemukan.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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

                string query = "SELECT * FROM v_GetJadwal";
                SqlCommand cmd = new SqlCommand(query, conn);
        
                // Menggunakan SqlDataAdapter untuk menarik data sekaligus
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                // Masukkan semua data dari database ke dalam DataTable
                adapter.Fill(dt);

                // Berikan data tersebut ke BindingSource.
                // DataGridView otomatis akan terisi dan ter-refresh!
                jadwalTanamBindingSource.DataSource = dt;
            }
            catch (Exception ex)
            {
            MessageBox.Show("Error: " + ex.Message);
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

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // 1. Jika kotak pencarian kosong, tampilkan semua data kembali
                if (string.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    jadwalTanamBindingSource.RemoveFilter(); // Menghapus filter
                }
                else
                {
                    // 2. Jika ada teks, saring data yang ada di BindingSource
                    // Kita menggunakan Convert() agar tipe data angka (JadwalID) bisa dicari seperti teks (LIKE)
                    jadwalTanamBindingSource.Filter = $"Convert(JadwalID, 'System.String') LIKE '%{txt_Search.Text}%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat pencarian: " + ex.Message);
            }
        }
    }
}