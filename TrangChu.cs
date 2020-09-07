using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuaHangTienLoi
{
    public partial class TrangChu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        KetNoi kn;
        public TrangChu()
        {
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeComponent();
            kn = new KetNoi();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            TaiKhoan tk = new TaiKhoan();
            tk.TopLevel = false;
            tk.Dock = DockStyle.Fill;
            this.fluentDesignFormContainer1.Controls.Add(tk);
            tk.Show();
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            SanPham tk = new SanPham();
            tk.TopLevel = false;
            tk.Dock = DockStyle.Fill;
            this.fluentDesignFormContainer1.Controls.Add(tk);
            tk.Show();
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            NhaCungCap tk = new NhaCungCap();
            tk.TopLevel = false;
            tk.Dock = DockStyle.Fill;
            this.fluentDesignFormContainer1.Controls.Add(tk);
            tk.Show();
        }
        public void LHD()
        {
            //  this.fluentDesignFormContainer1.Controls.Clear();
            LapHoaDon tk = new LapHoaDon();
            //  tk.TopLevel = false;
            //  tk.Dock = DockStyle.Fill;
            // this.fluentDesignFormContainer1.Controls.Add(tk);
            tk.ShowDialog();
        }
        private void accordionControlElement16_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            LoaiSP tk = new LoaiSP();
            tk.TopLevel = false;
            tk.Dock = DockStyle.Fill;
            this.fluentDesignFormContainer1.Controls.Add(tk);
            tk.Show();
        }

        public void accordionControlElement11_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            HoaDon tk = new HoaDon();
            tk.TopLevel = false;
            tk.Dock = DockStyle.Fill;
            this.fluentDesignFormContainer1.Controls.Add(tk);
            tk.Show();
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {

            this.fluentDesignFormContainer1.Controls.Clear();
            NhanVien tk = new NhanVien();
            tk.TopLevel = false;
            tk.Dock = DockStyle.Fill;
            this.fluentDesignFormContainer1.Controls.Add(tk);
            tk.Show();
        }

        private void accordionControlElement17_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            ChungLoai tk = new ChungLoai();
            tk.TopLevel = false;
            tk.Dock = DockStyle.Fill;
            this.fluentDesignFormContainer1.Controls.Add(tk);
            tk.Show();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }
        void load_chart()
        {
            string strselect = "select SUM(TONGTIEN) AS TONGTIEN from HOADON where YEAR(NGAYLAP)=2020 and MONTH(NGAYLAP)=7 and DAY(NGAYLAP)<=7";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.connsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Series series1 = new Series("Doanh thu bán hàng",ViewType.Bar);
            series1.Points.Add(new SeriesPoint("Tuần 1 tháng 7", double.Parse(dt.Rows[0].Field<double>("TONGTIEN").ToString())));
            //
            string strselect1 = "select SUM(TONGTIEN) AS TONGTIEN from HOADON where YEAR(NGAYLAP)=2020 and MONTH(NGAYLAP)=7 and DAY(NGAYLAP)>7 and DAY(NGAYLAP)<=14";
            SqlDataAdapter da1 = new SqlDataAdapter(strselect1, kn.connsql);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            series1.Points.Add(new SeriesPoint("Tuần 2 tháng 7", double.Parse(dt1.Rows[0].Field<double>("TONGTIEN").ToString())));
            //
            string strselect2 = "select SUM(TONGTIEN) AS TONGTIEN from HOADON where YEAR(NGAYLAP)=2020 and MONTH(NGAYLAP)=7 and DAY(NGAYLAP)>14 and DAY(NGAYLAP)<=21";
            SqlDataAdapter da2 = new SqlDataAdapter(strselect2, kn.connsql);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            series1.Points.Add(new SeriesPoint("Tuần 3 tháng 7", double.Parse(dt2.Rows[0].Field<double>("TONGTIEN").ToString())));
            //
            string strselect3 = "select SUM(TONGTIEN) AS TONGTIEN from HOADON where YEAR(NGAYLAP)=2020 and MONTH(NGAYLAP)=7 and DAY(NGAYLAP)>21 and DAY(NGAYLAP)<=31";
            SqlDataAdapter da3 = new SqlDataAdapter(strselect3, kn.connsql);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            series1.Points.Add(new SeriesPoint("Tuần 4 tháng 7", double.Parse(dt3.Rows[0].Field<double>("TONGTIEN").ToString())));
            chartControl1.Series.Add(series1);
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {

            //this.fluentDesignFormContainer1.Controls.Clear();
            //TaiKhoan tk = new TaiKhoan();
            //tk.TopLevel = false;
            //tk.Dock = DockStyle.Fill;
            //this.fluentDesignFormContainer1.Controls.Add(tk);
            //tk.Show();
            load_chart();
            if (DangNhap.maq == 1)
            {
                accordionControlElement2.Enabled = true;
                accordionControlElement15.Enabled = true;
                accordionControlElement11.Enabled = true;
                accordionControlElement3.Enabled = true;
                accordionControlElement5.Enabled = true;
                accordionControlElement6.Enabled = true;
                accordionControlElement13.Enabled = true;

            }
            if (DangNhap.maq == 3)
            {
                accordionControlElement13.Enabled = true;
            }
            if (DangNhap.maq == 4 || DangNhap.maq == 2)
            {
                accordionControlElement11.Enabled = true;
                accordionControlElement2.Enabled = true;
                accordionControlElement3.Enabled = true;


            }
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn thật sự muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
        public void close()
        {
            this.Close();
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn thật sự muốn đăng xuất khỏi tài khoản " + this.accordionControlElement8.Text + "?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                this.Hide();
                DangNhap dn = new DangNhap();
                dn.Show();
            }

        }

        private void accordionControlElement15_Click_1(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            NhapHang tk = new NhapHang();
            tk.TopLevel = false;
            tk.Dock = DockStyle.Fill;
            this.fluentDesignFormContainer1.Controls.Add(tk);
            tk.Show();
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {

        }
    }
}
