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
using System.Windows.Forms.DataVisualization.Charting;

namespace Sistem_Monitoring_Jadwal_Tanam
{
    public partial class FormReport: Form
    {
        KoneksiDB conn = new KoneksiDB();
        //private readonly SqlConnection conn;
        //private readonly string connectionString = "Data Source=MSI\\BAGAS;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
        DataTable dt;
        int button = 0;
        bool isInitializing = true;
        public FormReport()
        {
            InitializeComponent();
            dtpTglTanam.MinDate = new DateTime(2021, 1, 1);
            dtpTglTanam.Format = DateTimePickerFormat.Custom;
            dtpTglTanam.CustomFormat = "yyyy";
            dtpTglTanam.ShowUpDown = true;
            dtpTglTanam.MaxDate = DateTime.Now;

            cmbTipe.DropDownStyle = ComboBoxStyle.DropDownList;
            var items = new List<KeyValuePair<string, SeriesChartType>>
            {
                new KeyValuePair<string, SeriesChartType>("Kolom", SeriesChartType.Column),
                new KeyValuePair<string, SeriesChartType>("Pie", SeriesChartType.Pie)
            };

            cmbTipe.DataSource = items;
            cmbTipe.DisplayMember = "Key";
            cmbTipe.ValueMember = "Value";
            cmbTipe.SelectedIndex = 0;

            isInitializing = false;
            loadDataChart();
        }

        public void loadDataChart(int tahun = 0)
        {
            chartTanaman.Series.Clear();
            chartTanaman.Titles.Clear();
            chartTanaman.Legends.Clear();
            chartTanaman.ChartAreas.Clear();

            Title title = new Title("Laporan Jadwal Tanam 2021 - 2026", Docking.Top, new Font("Arial", 14, FontStyle.Bold), Color.DarkBlue);
            chartTanaman.Titles.Add(title);

            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Right; 
            chartTanaman.Legends.Add(legend);


            ChartArea ca = new ChartArea("MainArea");
            ca.AxisY.Title = "Jumlah Tanam";
            ca.AxisX.LabelStyle.Angle = -45;
            ca.BackColor = Color.Transparent;
            chartTanaman.ChartAreas.Add(ca);

            try
            {
                using (SqlConnection conn = new SqlConnection(KoneksiDB.GetConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    Series s = new Series("Data Tanam");

                    if (cmbTipe.SelectedValue != null)
                    {
                        var pilihanAktif = (KeyValuePair<string, SeriesChartType>)cmbTipe.SelectedItem;
                        s.ChartType = pilihanAktif.Value;
                        s.IsValueShownAsLabel = true;
                        s.Label = "#VAL";

                        if (s.ChartType == SeriesChartType.Pie)
                        {
                            s.LegendText = "#VALX";
                            string[] namaBulan = { "Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agt", "Sep", "Okt", "Nov", "Des" };

                            for (int i = 1; i <= 12; i++)
                            {
                                chartTanaman.ChartAreas[0].AxisX.CustomLabels.Add(i - 0.5, i + 0.5, namaBulan[i - 1]);
                            }
                        }
                        else
                        {
                            s.LegendText = "Jumlah Tanam"; 
                        }

                    }

                    if (tahun == 0)
                    {
                        ca.AxisX.Title = "Tahun";

                        cmd.CommandText = "sp_REPORT";
                        s.XValueMember = "Tahun";
                        s.YValueMembers = "TotalTanam";

                        chartTanaman.ChartAreas[0].AxisX.CustomLabels.Clear();
                        chartTanaman.ChartAreas[0].AxisX.Minimum = 2021;
                        chartTanaman.ChartAreas[0].AxisX.Maximum = 2026;
                        chartTanaman.ChartAreas[0].AxisX.Interval = 1;
                    }
                    else
                    {
                        ca.AxisX.Title = "Bulan";

                        cmd.CommandText = "sp_DashboardPerTahun";
                        cmd.Parameters.AddWithValue("@tahun", tahun.ToString());
                        s.XValueMember = "Bulan";
                        s.YValueMembers = "TotalTanam";

                        chartTanaman.ChartAreas[0].AxisX.Minimum = 1;
                        chartTanaman.ChartAreas[0].AxisX.Maximum = 12;
                        chartTanaman.ChartAreas[0].AxisX.Interval = 1;

                        chartTanaman.ChartAreas[0].AxisX.CustomLabels.Clear();

                        string[] namaBulan = {"Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agt", "Sep", "Okt", "Nov", "Des" };

                        for (int i = 1; i <= 12; i++)
                        {
                            chartTanaman.ChartAreas[0].AxisX.CustomLabels.Add(i - 0.5, i + 0.5, namaBulan[i - 1]);
                        }
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (tahun == 0)
                    {
                        for (int y = 2021; y <= 2026; y++)
                        {
                            bool adaData = false;
                            foreach (DataRow row in dt.Rows)
                            {
                                if (Convert.ToInt32(row["Tahun"]) == y)
                                {
                                    adaData = true;
                                    break;
                                }
                            }

                            if (!adaData)
                            {
                                DataRow newRow = dt.NewRow();
                                newRow["Tahun"] = y;
                                newRow["TotalTanam"] = 0;
                                dt.Rows.Add(newRow);
                            }
                        }

                        DataView dv = dt.DefaultView;
                        dv.Sort = "Tahun ASC";
                        dt = dv.ToTable();
                    }

                    chartTanaman.DataSource = dt;
                    chartTanaman.Series.Add(s);
                    chartTanaman.DataBind();

                    if (tahun != 0 && s.ChartType == SeriesChartType.Pie)
                    {
                        string[] namaBulan = { "Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agt", "Sep", "Okt", "Nov", "Des" };

                        foreach (DataPoint pt in s.Points)
                        {
                            int angkaBulan = Convert.ToInt32(pt.XValue);    // Ambil nilai angka bulannya (misal: 2, 4, 5)

                            if (angkaBulan >= 1 && angkaBulan <= 12)        // Pastikan angkanya valid (1-12) agar tidak error
                            {
                                pt.LegendText = namaBulan[angkaBulan - 1];  // Timpa angka di legenda dengan nama bulan yang sesuai
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data chart: " + ex.Message);
            }
        }

        private void cmbTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                int tahunAktif = dtpTglTanam.Value.Year;

                loadDataChart(tahunAktif);
            }
            else
            {

            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Form formHome = Application.OpenForms["Form1"];
            if (formHome != null)
            {
                formHome.Show();
            }
            this.Hide();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int tahunAktif = dtpTglTanam.Value.Year;

            loadDataChart(tahunAktif);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            button = 0;
            loadDataChart();
        }

        private void btnRekapData_Click(object sender, EventArgs e)
        {
            RekapData rekapdata = new RekapData();
            rekapdata.Show();

            this.Hide();
        }
    }
}
