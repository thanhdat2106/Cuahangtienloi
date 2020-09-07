namespace CuaHangTienLoi
{
    partial class frmEan13
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
            this.txt_soluong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCountryCode = new System.Windows.Forms.TextBox();
            this.butCreateBitmap = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboScale = new System.Windows.Forms.ComboBox();
            this.txtChecksumDigit = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtManufacturerCode = new System.Windows.Forms.TextBox();
            this.butPrint = new System.Windows.Forms.Button();
            this.butDraw = new System.Windows.Forms.Button();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_soluong
            // 
            this.txt_soluong.Location = new System.Drawing.Point(303, 385);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.Size = new System.Drawing.Size(193, 26);
            this.txt_soluong.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Số lượng";
            // 
            // txtCountryCode
            // 
            this.txtCountryCode.Location = new System.Drawing.Point(303, 31);
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.Size = new System.Drawing.Size(193, 26);
            this.txtCountryCode.TabIndex = 44;
            // 
            // butCreateBitmap
            // 
            this.butCreateBitmap.Location = new System.Drawing.Point(604, 172);
            this.butCreateBitmap.Name = "butCreateBitmap";
            this.butCreateBitmap.Size = new System.Drawing.Size(160, 42);
            this.butCreateBitmap.TabIndex = 43;
            this.butCreateBitmap.Text = "Create Bitmap";
            this.butCreateBitmap.Click += new System.EventHandler(this.butCreateBitmap_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Scale Factor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Checksum Digit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Product Code :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Manufacturer Code :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Country Code :";
            // 
            // cboScale
            // 
            this.cboScale.FormattingEnabled = true;
            this.cboScale.Items.AddRange(new object[] {
            "0.8",
            "0.9",
            "1.0",
            "1.1",
            "1.2",
            "1.3",
            "1.4",
            "1.5",
            "1.6",
            "1.7",
            "1.8",
            "1.9",
            "2.0"});
            this.cboScale.Location = new System.Drawing.Point(303, 316);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(193, 28);
            this.cboScale.TabIndex = 37;
            // 
            // txtChecksumDigit
            // 
            this.txtChecksumDigit.Location = new System.Drawing.Point(303, 245);
            this.txtChecksumDigit.Name = "txtChecksumDigit";
            this.txtChecksumDigit.Size = new System.Drawing.Size(193, 26);
            this.txtChecksumDigit.TabIndex = 36;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(303, 176);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(193, 26);
            this.txtProductCode.TabIndex = 35;
            // 
            // txtManufacturerCode
            // 
            this.txtManufacturerCode.Location = new System.Drawing.Point(303, 104);
            this.txtManufacturerCode.Name = "txtManufacturerCode";
            this.txtManufacturerCode.Size = new System.Drawing.Size(193, 26);
            this.txtManufacturerCode.TabIndex = 34;
            // 
            // butPrint
            // 
            this.butPrint.Location = new System.Drawing.Point(604, 101);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(160, 41);
            this.butPrint.TabIndex = 32;
            this.butPrint.Text = "Print Barcode";
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // butDraw
            // 
            this.butDraw.Location = new System.Drawing.Point(604, 28);
            this.butDraw.Name = "butDraw";
            this.butDraw.Size = new System.Drawing.Size(160, 46);
            this.butDraw.TabIndex = 31;
            this.butDraw.Text = "Draw Barcode";
            this.butDraw.Click += new System.EventHandler(this.butDraw_Click);
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(519, 253);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(259, 170);
            this.picBarcode.TabIndex = 33;
            this.picBarcode.TabStop = false;
            // 
            // frmEan13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_soluong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCountryCode);
            this.Controls.Add(this.butCreateBitmap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboScale);
            this.Controls.Add(this.txtChecksumDigit);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtManufacturerCode);
            this.Controls.Add(this.picBarcode);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.butDraw);
            this.Name = "frmEan13";
            this.Text = "frmEan13";
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_soluong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCountryCode;
        private System.Windows.Forms.Button butCreateBitmap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboScale;
        private System.Windows.Forms.TextBox txtChecksumDigit;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtManufacturerCode;
        private System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.Button butPrint;
        private System.Windows.Forms.Button butDraw;
    }
}