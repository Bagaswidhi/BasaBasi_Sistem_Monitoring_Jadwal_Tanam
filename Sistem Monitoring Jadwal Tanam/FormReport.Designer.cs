namespace Sistem_Monitoring_Jadwal_Tanam
{
    partial class FormReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_Back = new System.Windows.Forms.Button();
            this.dtpTglTanam = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.chartTanaman = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbTipe = new System.Windows.Forms.ComboBox();
            this.btnRekapData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartTanaman)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(713, 12);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 1;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // dtpTglTanam
            // 
            this.dtpTglTanam.Location = new System.Drawing.Point(12, 13);
            this.dtpTglTanam.Name = "dtpTglTanam";
            this.dtpTglTanam.Size = new System.Drawing.Size(200, 22);
            this.dtpTglTanam.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(218, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(306, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(84, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chartTanaman
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTanaman.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTanaman.Legends.Add(legend1);
            this.chartTanaman.Location = new System.Drawing.Point(12, 41);
            this.chartTanaman.Name = "chartTanaman";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTanaman.Series.Add(series1);
            this.chartTanaman.Size = new System.Drawing.Size(776, 397);
            this.chartTanaman.TabIndex = 5;
            this.chartTanaman.Text = "chart1";
            // 
            // cmbTipe
            // 
            this.cmbTipe.FormattingEnabled = true;
            this.cmbTipe.Location = new System.Drawing.Point(489, 10);
            this.cmbTipe.Name = "cmbTipe";
            this.cmbTipe.Size = new System.Drawing.Size(121, 24);
            this.cmbTipe.TabIndex = 6;
            // 
            // btnRekapData
            // 
            this.btnRekapData.Location = new System.Drawing.Point(616, 11);
            this.btnRekapData.Name = "btnRekapData";
            this.btnRekapData.Size = new System.Drawing.Size(91, 23);
            this.btnRekapData.TabIndex = 7;
            this.btnRekapData.Text = "Rekap Data";
            this.btnRekapData.UseVisualStyleBackColor = true;
            this.btnRekapData.Click += new System.EventHandler(this.btnRekapData_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRekapData);
            this.Controls.Add(this.cmbTipe);
            this.Controls.Add(this.chartTanaman);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dtpTglTanam);
            this.Controls.Add(this.btn_Back);
            this.Name = "FormReport";
            this.Text = "FormReport";
            ((System.ComponentModel.ISupportInitialize)(this.chartTanaman)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.DateTimePicker dtpTglTanam;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTanaman;
        private System.Windows.Forms.ComboBox cmbTipe;
        private System.Windows.Forms.Button btnRekapData;
    }
}