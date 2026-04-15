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
    public partial class FormReport: Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString = "Data Source=MSI\\BAGASWIDHI;Initial Catalog=DBSistemMonitoringMasaTanam;Integrated Security=True";
        public FormReport()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
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
    }
}
