namespace Sistem_Monitoring_Jadwal_Tanam
{
    partial class FormTanaman
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
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Insert = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamaTanaman = new System.Windows.Forms.TextBox();
            this.txtLamaMasaTanam = new System.Windows.Forms.TextBox();
            this.txtTanamanID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(12, 379);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(148, 37);
            this.btn_Load.TabIndex = 0;
            this.btn_Load.Text = "Menampilkan Data";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Insert
            // 
            this.btn_Insert.Location = new System.Drawing.Point(215, 379);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(148, 37);
            this.btn_Insert.TabIndex = 1;
            this.btn_Insert.Text = "Menambah Data";
            this.btn_Insert.UseVisualStyleBackColor = true;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(427, 379);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(148, 37);
            this.btn_Update.TabIndex = 2;
            this.btn_Update.Text = "Mengubah Data";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(640, 379);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(148, 37);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Menghapus Data";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(563, 277);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nama Tanaman";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lama Masa Tanam";
            // 
            // txtNamaTanaman
            // 
            this.txtNamaTanaman.Location = new System.Drawing.Point(603, 170);
            this.txtNamaTanaman.Multiline = true;
            this.txtNamaTanaman.Name = "txtNamaTanaman";
            this.txtNamaTanaman.Size = new System.Drawing.Size(165, 31);
            this.txtNamaTanaman.TabIndex = 9;
            // 
            // txtLamaMasaTanam
            // 
            this.txtLamaMasaTanam.Location = new System.Drawing.Point(603, 270);
            this.txtLamaMasaTanam.Multiline = true;
            this.txtLamaMasaTanam.Name = "txtLamaMasaTanam";
            this.txtLamaMasaTanam.Size = new System.Drawing.Size(165, 31);
            this.txtLamaMasaTanam.TabIndex = 10;
            // 
            // txtTanamanID
            // 
            this.txtTanamanID.Location = new System.Drawing.Point(603, 77);
            this.txtTanamanID.Multiline = true;
            this.txtTanamanID.Name = "txtTanamanID";
            this.txtTanamanID.ReadOnly = true;
            this.txtTanamanID.Size = new System.Drawing.Size(165, 31);
            this.txtTanamanID.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "TanamanID";
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Back.Location = new System.Drawing.Point(713, 12);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 13;
            this.btn_Back.Text = "Kembali";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(86, 13);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(489, 22);
            this.txt_Search.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Search :";
            // 
            // FormTanaman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTanamanID);
            this.Controls.Add(this.txtLamaMasaTanam);
            this.Controls.Add(this.txtNamaTanaman);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Insert);
            this.Controls.Add(this.btn_Load);
            this.Name = "FormTanaman";
            this.Text = "FormTanaman";
            this.Load += new System.EventHandler(this.FormTanaman_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_Insert;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaTanaman;
        private System.Windows.Forms.TextBox txtLamaMasaTanam;
        private System.Windows.Forms.TextBox txtTanamanID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label4;
    }
}