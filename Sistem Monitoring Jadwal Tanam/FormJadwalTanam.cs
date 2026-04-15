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

        private void FormJadwalTanam_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellClick += dataGridView1_CellContentClick;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                idJadwalTerpilih = row.Cells["JadwalID"].Value.ToString();
                txtIdTanaman.Text = row.Cells["TanamanID"].Value.ToString();
                txtIdLahan.Text = row.Cells["LahanID"].Value.ToString();
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
            if (txtIdLahan.Text == "" || txtIdTanaman.Text == "")
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
                cmdCheck.Parameters.AddWithValue("@TanamanID", txtIdTanaman.Text);

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
                cmdSimpan.Parameters.AddWithValue("@TanamanID", txtIdTanaman.Text);
                cmdSimpan.Parameters.AddWithValue("@LahanID", txtIdLahan.Text);
                cmdSimpan.Parameters.AddWithValue("@TanggalTanam", tanggalTanam);
                cmdSimpan.Parameters.AddWithValue("@EstimasiPanen", estimasiPanen);
                cmdSimpan.ExecuteNonQuery();

                MessageBox.Show("Jadwal tanam berhasil disimpan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
