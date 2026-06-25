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
    public partial class CetakRekap : Form
    {
        SqlConnection conn = new SqlConnection(KoneksiDB.GetConnectionString());
        SqlDataAdapter da;
        DataTable dtJadwal;

        CrystalReport1 notaTanam = new CrystalReport1();
        string namaTanaman { get; set; }
        DateTime tanggalTanam { get; set; }
        public CetakRekap(string NamaTanaman, DateTime TanggalTanam)
        {
            InitializeComponent();

            namaTanaman = NamaTanaman;
            tanggalTanam = TanggalTanam;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("sp_ReportRPT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tahun", tanggalTanam.Year);
                cmd.Parameters.AddWithValue("@namaTanaman", namaTanaman);

                da = new SqlDataAdapter(cmd);
                dtJadwal = new DataTable();
                da.Fill(dtJadwal);

                conn.Close();

                notaTanam.SetDataSource(dtJadwal); 

                crystalReportViewer1.ReportSource = notaTanam;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data laporan: " + ex.Message);
            }
        }
    }
}

