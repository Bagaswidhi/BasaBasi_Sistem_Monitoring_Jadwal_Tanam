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
    }
}
