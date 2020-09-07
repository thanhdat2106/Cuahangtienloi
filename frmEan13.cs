using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangTienLoi
{
    public partial class frmEan13 : Form
    {
		private Ean13 ean13 = null;
		string a;
		public frmEan13()
		{
			InitializeComponent();
			cboScale.SelectedIndex = 2;
		}
		public frmEan13(string b)
		{
			InitializeComponent();
			cboScale.SelectedIndex = 2;
			a = b;
			txtCountryCode.Text = int.Parse(a.Substring(0, 3)).ToString();
			txtManufacturerCode.Text = int.Parse(a.Substring(3, 4)).ToString();
			int c = int.Parse(a.Substring(7).ToString());
			if (c < 10)
			{
				txtProductCode.Text = "0000" + double.Parse(a.Substring(7)).ToString();
			}
			else if (c >= 10 && c < 100)
			{
				txtProductCode.Text = "000" + double.Parse(a.Substring(7)).ToString();
			}
			else
			{
				txtProductCode.Text = "00" + double.Parse(a.Substring(7)).ToString();
			}
		}
		private void CreateEan13()
		{
			ean13 = new Ean13();
			ean13.CountryCode = txtCountryCode.Text;
			ean13.ManufacturerCode = txtManufacturerCode.Text;
			ean13.ProductCode = txtProductCode.Text;
			if (txtChecksumDigit.Text.Length > 0)
				ean13.ChecksumDigit = txtChecksumDigit.Text;
		}

		private void butDraw_Click(object sender, EventArgs e)
		{
			System.Drawing.Graphics g = this.picBarcode.CreateGraphics();

			g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
				new Rectangle(0, 0, picBarcode.Width, picBarcode.Height));

			CreateEan13();
			ean13.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);
			ean13.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
			txtChecksumDigit.Text = ean13.ChecksumDigit;
			g.Dispose();
		}

		private void butPrint_Click(object sender, EventArgs e)
		{
			int a = int.Parse(txt_soluong.Text);
			for (int i = 0; i < a; i++)
			{
				System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
				pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
				pd.Print();
			}
		}

		private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
		{
			CreateEan13();
			ean13.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);
			ean13.DrawEan13Barcode(ev.Graphics, new System.Drawing.Point(0, 0));
			txtChecksumDigit.Text = ean13.ChecksumDigit;

			// Add Code here to print other information.
			ev.Graphics.Dispose();
		}

		private void butCreateBitmap_Click(object sender, EventArgs e)
		{
			CreateEan13();
			ean13.Scale = (float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);

			System.Drawing.Bitmap bmp = ean13.CreateBitmap();
			this.picBarcode.Image = bmp;
		}
	}
}
