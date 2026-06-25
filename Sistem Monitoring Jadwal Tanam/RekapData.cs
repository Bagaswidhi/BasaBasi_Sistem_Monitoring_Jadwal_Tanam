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
    public partial class RekapData : Form
    {
        KoneksiDB conn = new KoneksiDB();
        public RekapData()
        {
            InitializeComponent();
        }

        private void RekapData_Load(object sender, EventArgs e)
        {
            dtpTglTanam.Format = DateTimePickerFormat.Custom;
            dtpTglTanam.CustomFormat = "yyyy";
            dtpTglTanam.ShowUpDown = true;
            dtpTglTanam.MinDate = new DateTime(2021, 1, 1);
            dtpTglTanam.MaxDate = DateTime.Now;

            cmbNamaTanaman.DropDownStyle = ComboBoxStyle.DropDownList;
            btnCetak.Enabled = false;

            try
            {
                // Membuka koneksi database secara aman dengan 'using'
                using (SqlConnection conn = new SqlConnection(KoneksiDB.GetConnectionString()))
                {
                    conn.Open();

                    // Query untuk mengambil daftar nama tanaman unik untuk isi ComboBox
                    string query = "SELECT DISTINCT namatanaman FROM datatanaman";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        DataTable dtTanaman = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtTanaman);
                        }

                        // ISI DATA KE COMBOBOX (Ganti 'comboBox1' sesuai nama komponenmu)
                        cmbNamaTanaman.DataSource = dtTanaman;
                        cmbNamaTanaman.DisplayMember = "namatanaman";
                        cmbNamaTanaman.ValueMember = "namatanaman";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data awal ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                int tahunPilihan = dtpTglTanam.Value.Year;
                string tanamanPilihan = cmbNamaTanaman.SelectedValue?.ToString();

                using (SqlConnection conn = new SqlConnection(KoneksiDB.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ReportRPT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                       
                        cmd.Parameters.AddWithValue("@tahun", tahunPilihan);
                        cmd.Parameters.AddWithValue("@namaTanaman", tanamanPilihan ?? (object)DBNull.Value);

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        // Tampilkan hasil join ke DataGridView
                        dataGridView1.DataSource = dt;
                    }
                    btnCetak.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan: " + ex.Message);
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            CetakRekap cetakRekap = new CetakRekap(cmbNamaTanaman.SelectedValue.ToString(), dtpTglTanam.Value);
            cetakRekap.Show();
            this.Hide();
        }
    }
}
