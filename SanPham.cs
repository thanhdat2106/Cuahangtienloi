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
    public partial class SanPham : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn;
        DataTable dt;
        public SanPham()
        {
           // this.Dock = System.Windows.Forms.DockStyle.Fill;
            InitializeComponent();
            kn = new KetNoi();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_luu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(btn_sua.Enabled == false)
            {
                string sql = "set dateformat dmy insert into SANPHAM values(" + int.Parse(cbo_loaisp.SelectedValue.ToString()) + ",'" + txt_ngaysx.Text + "','" + txt_hh.Text + "'," + int.Parse(txt_slt.Text) + ",null)";
                SqlCommand cmd = new SqlCommand(sql,kn.connsql);
                kn.connsql.Open();
                cmd.ExecuteNonQuery();
                kn.connsql.Close();
                MessageBox.Show("Thêm một sản phẩm thành công");
                load_sp();
            }
            else
            {
                string sql = "set dateformat dmy update SANPHAM set MALSP="+ int.Parse(cbo_loaisp.SelectedValue.ToString()) + ",NGAYSX ='"+ txt_ngaysx.Text + "',HANSUDUNG='"+ txt_hh.Text + "', SOLUONGTON ="+ int.Parse(txt_slt.Text) + " where MASP= "+int.Parse(txt_masp.Text)+"";
                SqlCommand cmd = new SqlCommand(sql, kn.connsql);
                kn.connsql.Open();
                cmd.ExecuteNonQuery();
                kn.connsql.Close();
                MessageBox.Show("Chỉnh sửa sản phẩm thành công");
                load_sp();
            }

        }
        void load_sp()
        {
            dtgvSanPham.DataSource = "";
            string strselect = "select MASP,TENLSP,NGAYSX,HANSUDUNG,SOLUONGTON,DONGIA,BARCODE from SANPHAM sp, LOAISP l where sp.MALSP = l.MALSP";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.connsql);
            dt = new DataTable();
            da.Fill(dt);
            dtgvSanPham.DataSource = dt;
            txt_bar.Enabled = false;
            txt_dongia.Enabled = false;
            txt_hh.Enabled = false;
            txt_masp.Enabled = false;
            txt_ngaysx.Enabled = false;
            txt_slt.Enabled = false;
            cbo_loaisp.Enabled = false;
            btn_luu.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            btn_them.Enabled = true;
            Databingding(dt);
        }
        void load_cbo()
        {
            string strselect = "select * from LOAISP";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.connsql);
            DataSet ds = new DataSet();
            da.Fill(ds, "LOAISP");
            cbo_loaisp.DataSource = ds.Tables["LOAISP"];
            cbo_loaisp.DisplayMember = "TENLSP";
            cbo_loaisp.ValueMember = "MALSP";
            cbo_loaisp.SelectedItem = cbo_loaisp.Items[0];
        }
        public void Databingding(DataTable dtb)
        {
            txt_masp.DataBindings.Clear();
            txt_bar.DataBindings.Clear();
            txt_dongia.DataBindings.Clear();
            txt_hh.DataBindings.Clear();
            txt_ngaysx.DataBindings.Clear();
            txt_slt.DataBindings.Clear();
            cbo_loaisp.DataBindings.Clear();


            txt_masp.DataBindings.Add("Text", dtb, "MASP");
            txt_bar.DataBindings.Add("Text", dtb, "BARCODE");
            txt_dongia.DataBindings.Add("Text", dtb, "DONGIA");
            txt_hh.DataBindings.Add("Text", dtb, "HANSUDUNG");
            txt_ngaysx.DataBindings.Add("Text", dtb, "NGAYSX");
            txt_slt.DataBindings.Add("Text", dtb, "SOLUONGTON");
            cbo_loaisp.DataBindings.Add("Text", dtb, "TENLSP");          
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            load_sp();
            load_cbo();
            
            
        }

        private void btn_them_ItemClick(object sender, ItemClickEventArgs e)
        {
            txt_masp.Clear();
            txt_bar.Clear();
            txt_dongia.Clear();
            txt_slt.Clear();
            txt_ngaysx.Enabled = true;
            txt_hh.Enabled = true;
            txt_slt.Enabled = true;
            cbo_loaisp.Enabled = true;
            btn_luu.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        private void btn_sua_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_luu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_them.Enabled = false;
            txt_ngaysx.Enabled = true;
            txt_hh.Enabled = true;
            txt_slt.Enabled = true;
            cbo_loaisp.Enabled = true;
        }

        private void btn_xoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn thật sự muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                try
                {
                    string sql = "delete from SANPHAM where MASP=" + int.Parse(txt_masp.Text) + "";
                    SqlCommand cmd = new SqlCommand(sql, kn.connsql);
                    kn.connsql.Open();
                    cmd.ExecuteNonQuery();
                    kn.connsql.Close();
                    MessageBox.Show("Xóa sản phẩm thành công");
                    load_sp();
                }
                catch
                {
                    MessageBox.Show("Sản phẩm đang được dùng ở bản khác !!");
                    kn.connsql.Close();
                }
            }
        }

        private void SanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn thật sự muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btn_thoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrangChu.ActiveForm.Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEan13 ean = new frmEan13(txt_bar.Text);
            ean.ShowDialog();
        }
    }
}