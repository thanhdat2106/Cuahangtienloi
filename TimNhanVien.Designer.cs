namespace CuaHangTienLoi
{
    partial class TimNhanVien
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_tim = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rdo_manv = new System.Windows.Forms.RadioButton();
            this.rdo_tennv = new System.Windows.Forms.RadioButton();
            this.rdo_matk = new System.Windows.Forms.RadioButton();
            this.rdo_tendn = new System.Windows.Forms.RadioButton();
            this.rdo_chucvu = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_tim = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(806, 270);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btn_tim, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 210);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_tim
            // 
            this.btn_tim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_tim.Location = new System.Drawing.Point(643, 76);
            this.btn_tim.Name = "btn_tim";
            this.btn_tim.Size = new System.Drawing.Size(154, 57);
            this.btn_tim.TabIndex = 1;
            this.btn_tim.Text = "Tìm kiếm";
            this.btn_tim.UseVisualStyleBackColor = true;
            this.btn_tim.Click += new System.EventHandler(this.btn_tim_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.rdo_manv, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rdo_tennv, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.rdo_matk, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.rdo_tendn, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.rdo_chucvu, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 219);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(800, 48);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // rdo_manv
            // 
            this.rdo_manv.AutoSize = true;
            this.rdo_manv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdo_manv.Location = new System.Drawing.Point(3, 3);
            this.rdo_manv.Name = "rdo_manv";
            this.rdo_manv.Size = new System.Drawing.Size(154, 42);
            this.rdo_manv.TabIndex = 0;
            this.rdo_manv.TabStop = true;
            this.rdo_manv.Text = "Mã nhân viên";
            this.rdo_manv.UseVisualStyleBackColor = true;
            // 
            // rdo_tennv
            // 
            this.rdo_tennv.AutoSize = true;
            this.rdo_tennv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdo_tennv.Location = new System.Drawing.Point(163, 3);
            this.rdo_tennv.Name = "rdo_tennv";
            this.rdo_tennv.Size = new System.Drawing.Size(154, 42);
            this.rdo_tennv.TabIndex = 1;
            this.rdo_tennv.TabStop = true;
            this.rdo_tennv.Text = "Tên nhân viên";
            this.rdo_tennv.UseVisualStyleBackColor = true;
            // 
            // rdo_matk
            // 
            this.rdo_matk.AutoSize = true;
            this.rdo_matk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdo_matk.Location = new System.Drawing.Point(323, 3);
            this.rdo_matk.Name = "rdo_matk";
            this.rdo_matk.Size = new System.Drawing.Size(154, 42);
            this.rdo_matk.TabIndex = 2;
            this.rdo_matk.TabStop = true;
            this.rdo_matk.Text = "Mã tài khoản";
            this.rdo_matk.UseVisualStyleBackColor = true;
            this.rdo_matk.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rdo_tendn
            // 
            this.rdo_tendn.AutoSize = true;
            this.rdo_tendn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdo_tendn.Location = new System.Drawing.Point(483, 3);
            this.rdo_tendn.Name = "rdo_tendn";
            this.rdo_tendn.Size = new System.Drawing.Size(154, 42);
            this.rdo_tendn.TabIndex = 3;
            this.rdo_tendn.TabStop = true;
            this.rdo_tendn.Text = "Tên đăng nhập";
            this.rdo_tendn.UseVisualStyleBackColor = true;
            // 
            // rdo_chucvu
            // 
            this.rdo_chucvu.AutoSize = true;
            this.rdo_chucvu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdo_chucvu.Location = new System.Drawing.Point(643, 3);
            this.rdo_chucvu.Name = "rdo_chucvu";
            this.rdo_chucvu.Size = new System.Drawing.Size(154, 42);
            this.rdo_chucvu.TabIndex = 4;
            this.rdo_chucvu.TabStop = true;
            this.rdo_chucvu.Text = "Chức vụ";
            this.rdo_chucvu.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel4.Controls.Add(this.txt_tim, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 76);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(634, 57);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // txt_tim
            // 
            this.txt_tim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_tim.Location = new System.Drawing.Point(3, 3);
            this.txt_tim.Multiline = true;
            this.txt_tim.Name = "txt_tim";
            this.txt_tim.Size = new System.Drawing.Size(596, 51);
            this.txt_tim.TabIndex = 0;
            // 
            // TimNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 270);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TimNhanVien";
            this.Text = "TimNhanVien";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button btn_tim;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton rdo_manv;
        private System.Windows.Forms.RadioButton rdo_tennv;
        private System.Windows.Forms.RadioButton rdo_matk;
        private System.Windows.Forms.RadioButton rdo_tendn;
        private System.Windows.Forms.RadioButton rdo_chucvu;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        public System.Windows.Forms.TextBox txt_tim;
    }
}