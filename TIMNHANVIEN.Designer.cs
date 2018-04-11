namespace PhanMemQLNS
{
    partial class TIMNHANVIEN
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
            this.bt_find = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_theoten = new System.Windows.Forms.RadioButton();
            this.rdb_theoma = new System.Windows.Forms.RadioButton();
            this.txt_manv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_nhanvien = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_find
            // 
            this.bt_find.Location = new System.Drawing.Point(36, 77);
            this.bt_find.Name = "bt_find";
            this.bt_find.Size = new System.Drawing.Size(75, 23);
            this.bt_find.TabIndex = 17;
            this.bt_find.Text = "Tìm kiếm";
            this.bt_find.UseVisualStyleBackColor = true;
            this.bt_find.Click += new System.EventHandler(this.bt_find_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_find);
            this.groupBox1.Controls.Add(this.rdb_theoten);
            this.groupBox1.Controls.Add(this.rdb_theoma);
            this.groupBox1.Controls.Add(this.txt_manv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(39, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 106);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm Nhân Viên";
            // 
            // rdb_theoten
            // 
            this.rdb_theoten.AutoSize = true;
            this.rdb_theoten.Location = new System.Drawing.Point(243, 45);
            this.rdb_theoten.Name = "rdb_theoten";
            this.rdb_theoten.Size = new System.Drawing.Size(72, 17);
            this.rdb_theoten.TabIndex = 16;
            this.rdb_theoten.TabStop = true;
            this.rdb_theoten.Text = "Theo Tên";
            this.rdb_theoten.UseVisualStyleBackColor = true;
            // 
            // rdb_theoma
            // 
            this.rdb_theoma.AutoSize = true;
            this.rdb_theoma.Location = new System.Drawing.Point(140, 45);
            this.rdb_theoma.Name = "rdb_theoma";
            this.rdb_theoma.Size = new System.Drawing.Size(67, 17);
            this.rdb_theoma.TabIndex = 16;
            this.rdb_theoma.TabStop = true;
            this.rdb_theoma.Text = "Theo mã";
            this.rdb_theoma.UseVisualStyleBackColor = true;
            // 
            // txt_manv
            // 
            this.txt_manv.Location = new System.Drawing.Point(140, 19);
            this.txt_manv.MaxLength = 10;
            this.txt_manv.Name = "txt_manv";
            this.txt_manv.Size = new System.Drawing.Size(185, 20);
            this.txt_manv.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập";
            // 
            // dgv_nhanvien
            // 
            this.dgv_nhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nhanvien.Location = new System.Drawing.Point(39, 127);
            this.dgv_nhanvien.Name = "dgv_nhanvien";
            this.dgv_nhanvien.Size = new System.Drawing.Size(454, 199);
            this.dgv_nhanvien.TabIndex = 9;
            // 
            // TIMNHANVIEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 346);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_nhanvien);
            this.Name = "TIMNHANVIEN";
            this.Text = "TIMNHANVIEN";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button bt_find;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rdb_theoten;
        public System.Windows.Forms.RadioButton rdb_theoma;
        public System.Windows.Forms.TextBox txt_manv;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgv_nhanvien;
    }
}