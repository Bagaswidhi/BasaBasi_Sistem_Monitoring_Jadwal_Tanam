namespace Sistem_Monitoring_Jadwal_Tanam
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_JadwalTanam = new System.Windows.Forms.Button();
            this.btn_DataLahan = new System.Windows.Forms.Button();
            this.btn_DataTanaman = new System.Windows.Forms.Button();
            this.btn_report = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_JadwalTanam
            // 
            this.btn_JadwalTanam.Location = new System.Drawing.Point(47, 197);
            this.btn_JadwalTanam.Name = "btn_JadwalTanam";
            this.btn_JadwalTanam.Size = new System.Drawing.Size(126, 45);
            this.btn_JadwalTanam.TabIndex = 0;
            this.btn_JadwalTanam.Text = "Jadwal Tanam";
            this.btn_JadwalTanam.UseVisualStyleBackColor = true;
            this.btn_JadwalTanam.Click += new System.EventHandler(this.btn_JadwalTanam_Click);
            // 
            // btn_DataLahan
            // 
            this.btn_DataLahan.Location = new System.Drawing.Point(435, 340);
            this.btn_DataLahan.Name = "btn_DataLahan";
            this.btn_DataLahan.Size = new System.Drawing.Size(126, 45);
            this.btn_DataLahan.TabIndex = 1;
            this.btn_DataLahan.Text = "Data Lahan";
            this.btn_DataLahan.UseVisualStyleBackColor = true;
            this.btn_DataLahan.Click += new System.EventHandler(this.btn_DataLahan_Click);
            // 
            // btn_DataTanaman
            // 
            this.btn_DataTanaman.Location = new System.Drawing.Point(227, 340);
            this.btn_DataTanaman.Name = "btn_DataTanaman";
            this.btn_DataTanaman.Size = new System.Drawing.Size(126, 45);
            this.btn_DataTanaman.TabIndex = 2;
            this.btn_DataTanaman.Text = "Data Tanaman";
            this.btn_DataTanaman.UseVisualStyleBackColor = true;
            this.btn_DataTanaman.Click += new System.EventHandler(this.btn_DataTanaman_Click);
            // 
            // btn_report
            // 
            this.btn_report.Location = new System.Drawing.Point(603, 197);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(126, 45);
            this.btn_report.TabIndex = 3;
            this.btn_report.Text = "Report";
            this.btn_report.UseVisualStyleBackColor = true;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_report);
            this.Controls.Add(this.btn_DataTanaman);
            this.Controls.Add(this.btn_DataLahan);
            this.Controls.Add(this.btn_JadwalTanam);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_JadwalTanam;
        private System.Windows.Forms.Button btn_DataLahan;
        private System.Windows.Forms.Button btn_DataTanaman;
        private System.Windows.Forms.Button btn_report;
    }
}

