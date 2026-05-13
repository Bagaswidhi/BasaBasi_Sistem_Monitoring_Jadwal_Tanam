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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJadwalTanam));
            this.btn_Insert = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.JadwalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaTanaman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaLahan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanamanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LahanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalTanam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimasiPanen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jadwalTanamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dB_SMJT_JadwalTanamSet = new Sistem_Monitoring_Jadwal_Tanam.DB_SMJT_JadwalTanamSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstimasiPanen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTanggalTanam = new System.Windows.Forms.DateTimePicker();
            this.btn_Back = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.jadwalTanamTableAdapter = new Sistem_Monitoring_Jadwal_Tanam.DB_SMJT_JadwalTanamSetTableAdapters.JadwalTanamTableAdapter();
            this.cmbTanaman = new System.Windows.Forms.ComboBox();
            this.cmbLahan = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jadwalTanamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_SMJT_JadwalTanamSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
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
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JadwalID,
            this.NamaTanaman,
            this.NamaLahan,
            this.TanamanID,
            this.LahanID,
            this.TanggalTanam,
            this.EstimasiPanen});
            this.dataGridView1.DataSource = this.jadwalTanamBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 249);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // JadwalID
            // 
            this.JadwalID.DataPropertyName = "JadwalID";
            this.JadwalID.HeaderText = "JadwalID";
            this.JadwalID.MinimumWidth = 6;
            this.JadwalID.Name = "JadwalID";
            this.JadwalID.ReadOnly = true;
            this.JadwalID.Width = 125;
            // 
            // NamaTanaman
            // 
            this.NamaTanaman.DataPropertyName = "NamaTanaman";
            this.NamaTanaman.HeaderText = "NamaTanaman";
            this.NamaTanaman.MinimumWidth = 6;
            this.NamaTanaman.Name = "NamaTanaman";
            this.NamaTanaman.Width = 125;
            // 
            // NamaLahan
            // 
            this.NamaLahan.DataPropertyName = "NamaLahan";
            this.NamaLahan.HeaderText = "NamaLahan";
            this.NamaLahan.MinimumWidth = 6;
            this.NamaLahan.Name = "NamaLahan";
            this.NamaLahan.Width = 125;
            // 
            // TanamanID
            // 
            this.TanamanID.DataPropertyName = "TanamanID";
            this.TanamanID.HeaderText = "TanamanID";
            this.TanamanID.MinimumWidth = 6;
            this.TanamanID.Name = "TanamanID";
            this.TanamanID.Visible = false;
            this.TanamanID.Width = 125;
            // 
            // LahanID
            // 
            this.LahanID.DataPropertyName = "LahanID";
            this.LahanID.HeaderText = "LahanID";
            this.LahanID.MinimumWidth = 6;
            this.LahanID.Name = "LahanID";
            this.LahanID.Visible = false;
            this.LahanID.Width = 125;
            // 
            // TanggalTanam
            // 
            this.TanggalTanam.DataPropertyName = "TanggalTanam";
            this.TanggalTanam.HeaderText = "TanggalTanam";
            this.TanggalTanam.MinimumWidth = 6;
            this.TanggalTanam.Name = "TanggalTanam";
            this.TanggalTanam.Width = 125;
            // 
            // EstimasiPanen
            // 
            this.EstimasiPanen.DataPropertyName = "EstimasiPanen";
            this.EstimasiPanen.HeaderText = "EstimasiPanen";
            this.EstimasiPanen.MinimumWidth = 6;
            this.EstimasiPanen.Name = "EstimasiPanen";
            this.EstimasiPanen.Width = 125;
            // 
            // jadwalTanamBindingSource
            // 
            this.jadwalTanamBindingSource.DataMember = "JadwalTanam";
            this.jadwalTanamBindingSource.DataSource = this.dB_SMJT_JadwalTanamSet;
            // 
            // dB_SMJT_JadwalTanamSet
            // 
            this.dB_SMJT_JadwalTanamSet.DataSetName = "DB_SMJT_JadwalTanamSet";
            this.dB_SMJT_JadwalTanamSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID Lahan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "ID Tanaman";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(75, 28);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(594, 22);
            this.txt_Search.TabIndex = 10;
            this.txt_Search.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tanggal Tanam";
            // 
            // txtEstimasiPanen
            // 
            this.txtEstimasiPanen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jadwalTanamBindingSource, "EstimasiPanen", true));
            this.txtEstimasiPanen.Location = new System.Drawing.Point(630, 330);
            this.txtEstimasiPanen.Name = "txtEstimasiPanen";
            this.txtEstimasiPanen.ReadOnly = true;
            this.txtEstimasiPanen.Size = new System.Drawing.Size(100, 22);
            this.txtEstimasiPanen.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Estimasi Panen";
            // 
            // dtpTanggalTanam
            // 
            this.dtpTanggalTanam.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.jadwalTanamBindingSource, "TanggalTanam", true));
            this.dtpTanggalTanam.Location = new System.Drawing.Point(384, 328);
            this.dtpTanggalTanam.MaxDate = new System.DateTime(2026, 5, 13, 0, 0, 0, 0);
            this.dtpTanggalTanam.Name = "dtpTanggalTanam";
            this.dtpTanggalTanam.Size = new System.Drawing.Size(200, 22);
            this.dtpTanggalTanam.TabIndex = 17;
            this.dtpTanggalTanam.Value = new System.DateTime(2026, 5, 12, 0, 0, 0, 0);
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.Red;
            this.btn_Back.Location = new System.Drawing.Point(711, 27);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 18;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AllowDrop = true;
            this.bindingNavigator1.BindingSource = this.jadwalTanamBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(800, 27);
            this.bindingNavigator1.TabIndex = 19;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // jadwalTanamTableAdapter
            // 
            this.jadwalTanamTableAdapter.ClearBeforeFill = true;
            // 
            // cmbTanaman
            // 
            this.cmbTanaman.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.jadwalTanamBindingSource, "TanamanID", true));
            this.cmbTanaman.FormattingEnabled = true;
            this.cmbTanaman.Location = new System.Drawing.Point(53, 330);
            this.cmbTanaman.Name = "cmbTanaman";
            this.cmbTanaman.Size = new System.Drawing.Size(121, 24);
            this.cmbTanaman.TabIndex = 20;
            // 
            // cmbLahan
            // 
            this.cmbLahan.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.jadwalTanamBindingSource, "LahanID", true));
            this.cmbLahan.FormattingEnabled = true;
            this.cmbLahan.Location = new System.Drawing.Point(217, 328);
            this.cmbLahan.Name = "cmbLahan";
            this.cmbLahan.Size = new System.Drawing.Size(121, 24);
            this.cmbLahan.TabIndex = 21;
            // 
            // FormJadwalTanam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbLahan);
            this.Controls.Add(this.cmbTanaman);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.dtpTanggalTanam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEstimasiPanen);
            this.Controls.Add(this.label4);
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
            ((System.ComponentModel.ISupportInitialize)(this.jadwalTanamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_SMJT_JadwalTanamSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstimasiPanen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTanggalTanam;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private DB_SMJT_JadwalTanamSet dB_SMJT_JadwalTanamSet;
        private System.Windows.Forms.BindingSource jadwalTanamBindingSource;
        private DB_SMJT_JadwalTanamSetTableAdapters.JadwalTanamTableAdapter jadwalTanamTableAdapter;
        private System.Windows.Forms.ComboBox cmbTanaman;
        private System.Windows.Forms.ComboBox cmbLahan;
        private System.Windows.Forms.DataGridViewTextBoxColumn JadwalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaTanaman;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaLahan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanamanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LahanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalTanam;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimasiPanen;
    }
}