using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;

namespace CuaHangTienLoi
{
    public partial class HoaDon : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn;
        DataTable dt;
        DataTable dt1;
        public HoaDon()
        {
            InitializeComponent();
            kn = new KetNoi();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TrangChu tc = new TrangChu();
            //tc.fluentDesignFormContainer1.Controls.Clear();
            LapHoaDon tb = new LapHoaDon();
            tb.TopLevel = false;
            this.tableLayoutPanel1.Controls.Add(tb);
            tb.Show();

            //this.tableLayoutPanel1.Controls.Clear();
            //LapHoaDon tb = new LapHoaDon();
            //tb.TopLevel = false;
            //this.tableLayoutPanel1.Controls.Add(tb);
            //tb.Show();
        }
        void load_hoadon()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from HOADON", kn.connsql);
             dt = new DataTable();
            da.Fill(dt);
            dgv_hoadon.DataSource = dt;
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            load_hoadon();
            Databingding1(dt);
            
        }
        void Databingding1(DataTable dtb)
        {
            txt_nv.DataBindings.Clear();
            txt_ngaylap.DataBindings.Clear();
            txt_tongtien.DataBindings.Clear();
            txt_mahd.DataBindings.Clear();

            txt_nv.DataBindings.Add("Text", dtb, "MANV");
            txt_mahd.DataBindings.Add("Text", dtb, "MAHD");
            txt_ngaylap.DataBindings.Add("Text", dtb, "NGAYLAP");
            txt_tongtien.DataBindings.Add("Text", dtb, "TONGTIEN");
            
        }
        void Databingding(DataTable dtb)
        {
            txt_ma.DataBindings.Clear();
            txt_soluong.DataBindings.Clear();
            txt_dongia.DataBindings.Clear();
            txt_tensp.DataBindings.Clear();
            txt_ngayhh.DataBindings.Clear();
            txt_ngaysx.DataBindings.Clear();
            txt_thanhtien.DataBindings.Clear();
            txt_km.DataBindings.Clear();

            txt_ma.DataBindings.Add("Text", dtb, "MASP");
            txt_tensp.DataBindings.Add("Text", dtb, "TENLSP");
            txt_dongia.DataBindings.Add("Text", dtb, "DONGIA");
            txt_soluong.DataBindings.Add("Text", dtb, "SOLUONGSP");
            txt_ngaysx.DataBindings.Add("Text", dtb, "NGAYSX");
            txt_ngayhh.DataBindings.Add("Text", dtb, "HANSUDUNG");
            txt_thanhtien.DataBindings.Add("Text", dtb, "THANHTIEN");
            txt_km.DataBindings.Add("Text", dtb, "KHUYENMAI");

        }
        private void txt_mahd_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select MAHD,ct.MASP,TENLSP,NGAYSX,HANSUDUNG,SOLUONGSP,DONGIA,KHUYENMAI,THANHTIEN from CT_HOADON ct  join SANPHAM sp on ct.MASP = sp.MASP and ct.MAHD ="+int.Parse(txt_mahd.Text)+"  join LOAISP l on l.MALSP = sp.MALSP left join KHUYENMAI km on ct.MASP = km.MASP and km.NGAYKETTHUC >= '"+DateTime.Now.ToString("MM/dd/yyyy")+"'", kn.connsql);
            dt1 = new DataTable();
            da.Fill(dt1);
            dgv_cthoadon.DataSource = dt1;
            Databingding(dt1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}