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
        KoneksiDB conn = new KoneksiDB();
        //private readonly SqlConnection conn;
        //private readonly string connectionString = "Data Source=MSI\\BAGAS;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
        private string idJadwalTerpilih = "";
        public FormJadwalTanam()
        {
            InitializeComponent();

            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtpTanggalTanam.MaxDate = lastDayOfMonth;
            dtpTanggalTanam.MinDate = firstDayOfMonth;
        }

        private void MuatComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(KoneksiDB.GetConnectionString()))
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
            try
            {
                using (SqlConnection conn = new SqlConnection(KoneksiDB.GetConnectionString()))
                {
                    // Mengecek Data Tanaman pada tabel DataTanaman
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (cmbTanaman.SelectedValue is null)
                    {
                        MessageBox.Show("Nama Tanaman tidak boleh kosong.");
                        cmbTanaman.Focus();
                        return;
                    }

                    if (cmbLahan.SelectedValue is null)
                    {
                        MessageBox.Show("Nama lahan tidak boleh kosong.");
                        cmbLahan.Focus();
                        return;
                    }
                    object result = null;

                    using (SqlCommand cmdCheck = new SqlCommand("sp_Get_LamaMasaTanam", conn))
                    {
                        cmdCheck.CommandType = CommandType.StoredProcedure;
                        cmdCheck.Parameters.AddWithValue("@TanamanID", cmbTanaman.SelectedValue);
                        result = cmdCheck.ExecuteScalar();
                    }

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


                    using (SqlCommand cmdSimpan = new SqlCommand("sp_InsertJadwal", conn))
                    {
                        cmdSimpan.CommandType = CommandType.StoredProcedure;

                        // Masukkan 4 parameter yang diminta SP
                        cmdSimpan.Parameters.AddWithValue("@TanamanID", cmbTanaman.SelectedValue);
                        cmdSimpan.Parameters.AddWithValue("@LahanID", cmbLahan.SelectedValue);
                        cmdSimpan.Parameters.AddWithValue("@TanggalTanam", tanggalTanam);
                        cmdSimpan.Parameters.AddWithValue("@EstimasiPanen", estimasiPanen);

                        int resultSimpan = cmdSimpan.ExecuteNonQuery();

                        if (resultSimpan < 0)
                        {
                            MessageBox.Show("Jadwal tanam berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btn_Load.PerformClick();
                            cmbTanaman.SelectedIndex = -1;
                            cmbLahan.SelectedIndex = -1;
                            txtEstimasiPanen.Clear();
                            dtpTanggalTanam.Value = DateTime.Today;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Peringatan Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(KoneksiDB.GetConnectionString()))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    object result = null;
                    int jadwalIDTerpilih = Convert.ToInt32(dataGridView1.CurrentRow.Cells["JadwalID"].Value);

                    using (SqlCommand cmdCheck = new SqlCommand("sp_Get_LamaMasaTanam", conn))
                    {
                        cmdCheck.CommandType = CommandType.StoredProcedure;
                        cmdCheck.Parameters.AddWithValue("@TanamanID", cmbTanaman.SelectedValue);
                        result = cmdCheck.ExecuteScalar();
                    }

                    if (result == null)
                    {
                        MessageBox.Show("Tanaman dengan ID tersebut tidak ditemukan.");
                        return;
                    }

                    DateTime tanggalTanam = dtpTanggalTanam.Value.Date;
                    int masaTanamHari = Convert.ToInt32(result);
                    DateTime estimasiPanen = tanggalTanam.AddDays(masaTanamHari);

                    txtEstimasiPanen.Text = estimasiPanen.ToString("yyyy-MM-dd");

                    using (SqlCommand cmdUpdate = new SqlCommand("sp_UpdateJadwal", conn))
                    {
                        cmdUpdate.CommandType = CommandType.StoredProcedure;

                        cmdUpdate.Parameters.AddWithValue("@JadwalID", jadwalIDTerpilih);
                        cmdUpdate.Parameters.AddWithValue("@TanamanID", cmbTanaman.SelectedValue);
                        cmdUpdate.Parameters.AddWithValue("@LahanID", cmbLahan.SelectedValue);
                        cmdUpdate.Parameters.AddWithValue("@TanggalTanam", tanggalTanam);
                        cmdUpdate.Parameters.AddWithValue("@EstimasiPanen", estimasiPanen);

                        int resultUpdate = cmdUpdate.ExecuteNonQuery();

                        if (resultUpdate < 0)
                        {
                            MessageBox.Show("Jadwal tanam berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Bersihkan variabel dan layar setelah sukses
                            idJadwalTerpilih = "";
                            cmbTanaman.SelectedIndex = -1;
                            cmbLahan.SelectedIndex = -1;
                            txtEstimasiPanen.Clear();
                            dtpTanggalTanam.Value = DateTime.Today;

                            // Refresh tabel
                            btn_Load.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Peringatan Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin menghapus jadwal tanam ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(KoneksiDB.GetConnectionString()))
                    {
                        if (conn.State == System.Data.ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        int jadwalIDTerpilih = Convert.ToInt32(dataGridView1.CurrentRow.Cells["JadwalID"].Value);
                        using (SqlCommand cmdDelete = new SqlCommand("sp_DeleteJadwal", conn))
                        {
                            cmdDelete.CommandType = CommandType.StoredProcedure;

                            // Masukkan parameter ID jadwal yang akan dihapus
                            cmdDelete.Parameters.AddWithValue("@JadwalID", jadwalIDTerpilih);

                            int result = cmdDelete.ExecuteNonQuery();

                            if (result < 0)
                            {
                                MessageBox.Show("Jadwal tanam berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                idJadwalTerpilih = "";
                                cmbTanaman.SelectedIndex = -1;
                                cmbLahan.SelectedIndex = -1;
                                txtEstimasiPanen.Clear();
                                dtpTanggalTanam.Value = DateTime.Today;

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
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(KoneksiDB.GetConnectionString()))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();

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
                }
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