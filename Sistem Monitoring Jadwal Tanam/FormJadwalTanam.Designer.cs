namespace Sistem_Monitoring_Jadwal_Tanam
{
    partial class FormJadwalTanam
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
            this.btn_Insert = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.txtIdTanaman = new System.Windows.Forms.TextBox();
            this.txtIdLahan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstimasiPanen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTanggalTanam = new System.Windows.Forms.DateTimePicker();
            this.btn_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Insert
            // 
            this.btn_Insert.Location = new System.Drawing.Point(232, 374);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(132, 42);
            this.btn_Insert.TabIndex = 0;
            this.btn_Insert.Text = "Menambah Data";
            this.btn_Insert.UseVisualStyleBackColor = true;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(16, 374);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(132, 42);
            this.btn_Load.TabIndex = 1;
            this.btn_Load.Text = "Menampilkan Data";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(449, 374);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(135, 42);
            this.btn_Update.TabIndex = 2;
            this.btn_Update.Text = "Mengubah Data";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(666, 374);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(122, 42);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Menghapus Data";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 252);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID Lahan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "ID Tanaman";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(77, 6);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(594, 22);
            this.txt_Search.TabIndex = 10;
            this.txt_Search.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // txtIdTanaman
            // 
            this.txtIdTanaman.Location = new System.Drawing.Point(46, 327);
            this.txtIdTanaman.Name = "txtIdTanaman";
            this.txtIdTanaman.Size = new System.Drawing.Size(60, 22);
            this.txtIdTanaman.TabIndex = 11;
            // 
            // txtIdLahan
            // 
            this.txtIdLahan.Location = new System.Drawing.Point(157, 327);
            this.txtIdLahan.Name = "txtIdLahan";
            this.txtIdLahan.Size = new System.Drawing.Size(55, 22);
            this.txtIdLahan.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tanggal Tanam";
            // 
            // txtEstimasiPanen
            // 
            this.txtEstimasiPanen.Location = new System.Drawing.Point(513, 329);
            this.txtEstimasiPanen.Name = "txtEstimasiPanen";
            this.txtEstimasiPanen.ReadOnly = true;
            this.txtEstimasiPanen.Size = new System.Drawing.Size(100, 22);
            this.txtEstimasiPanen.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Estimasi Panen";
            // 
            // dtpTanggalTanam
            // 
            this.dtpTanggalTanam.Location = new System.Drawing.Point(267, 327);
            this.dtpTanggalTanam.Name = "dtpTanggalTanam";
            this.dtpTanggalTanam.Size = new System.Drawing.Size(200, 22);
            this.dtpTanggalTanam.TabIndex = 17;
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.Red;
            this.btn_Back.Location = new System.Drawing.Point(713, 5);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 18;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // FormJadwalTanam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.dtpTanggalTanam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEstimasiPanen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdLahan);
            this.Controls.Add(this.txtIdTanaman);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_Insert);
            this.Name = "FormJadwalTanam";
            this.Text = "FormJadwalTanam";
            this.Load += new System.EventHandler(this.FormJadwalTanam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Insert;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.TextBox txtIdTanaman;
        private System.Windows.Forms.TextBox txtIdLahan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstimasiPanen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTanggalTanam;
        private System.Windows.Forms.Button btn_Back;
    }
}