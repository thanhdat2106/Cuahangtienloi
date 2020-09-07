using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace CuaHangTienLoi
{
    public partial class LapHoaDon : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn;
        int b;
        public LapHoaDon()
        {
            InitializeComponent();
            kn = new KetNoi();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LapHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn thật sự muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void LapHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_soluong.Enabled = true;
            btn_xoa.Enabled = false;
        }

        private void LapHoaDon_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from NHANVIEN where MATK=" + DangNhap.ma[0].ToString() + "", kn.connsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txt_tennv.Text = dt.Rows[0].Field<String>("TENNV").ToString();
            txt_ngaylap.Text = DateTime.Now.ToString();
            txt_tennv.Enabled = false;
            txt_ngaylap.Enabled = false;
            txt_masp.Enabled = false;
            txt_soluong.Enabled = false;
            txt_tongtien.Enabled = false;
            txt_tensanpham.Enabled = false;
            btn_luu.Enabled = false;
            btn_xoa.Enabled = false;
            btn_sua.Enabled = false;
        }
        int kt(int a)
        {
            foreach (ListViewItem item in lv_hoadon.Items)
            {
                if (int.Parse(item.SubItems[0].Text) == a)
                    return item.Index;

            }
            return -1;
        }
        int khuyenmai (int a)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from KHUYENMAI", kn.connsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MASP"].ToString() == a.ToString() && DateTime.Parse(dr["NGAYKETTHUC"].ToString()) >= DateTime.Now)
                {
                    return int.Parse(dr["KHUYENMAI"].ToString());
                    
                }

            }
            return 0;
        }
        private void txt_masp_TextChanged(object sender, EventArgs e)
        {
            int count = txt_masp.Text.Length;

            if (count == 13)
            {
                int a = int.Parse(txt_masp.Text.Substring(7, count - 8));
                SqlDataAdapter da = new SqlDataAdapter("Select * from SANPHAM sp join LOAISP l on sp.MALSP = l.MALSP and MASP = " + a + " ", kn.connsql);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    if (kt(a) == -1)
                    {
                        ListViewItem masp = new ListViewItem(dr["MASP"].ToString());
                        ListViewItem.ListViewSubItem ten = new ListViewItem.ListViewSubItem(masp, dr["TENLSP"].ToString());
                        masp.SubItems.Add(ten);

                        if (txt_soluong.Text == "")
                        {
                             b = khuyenmai(a);
                            ListViewItem.ListViewSubItem soluong = new ListViewItem.ListViewSubItem(masp, "1");
                            ListViewItem.ListViewSubItem thanhtien = new ListViewItem.ListViewSubItem(masp, (float.Parse(dr["DONGIA"].ToString())-float.Parse(b.ToString())).ToString());
                            masp.SubItems.Add(soluong);
                            ListViewItem.ListViewSubItem dongia = new ListViewItem.ListViewSubItem(masp, dr["DONGIA"].ToString());
                            masp.SubItems.Add(dongia);
                            
                            ListViewItem.ListViewSubItem km = new ListViewItem.ListViewSubItem(masp,b.ToString() );
                            masp.SubItems.Add(km);
                            masp.SubItems.Add(thanhtien);
                        }
                        else
                        {
                             b = khuyenmai(a);
                            ListViewItem.ListViewSubItem soluong = new ListViewItem.ListViewSubItem(masp, txt_soluong.Text);
                            ListViewItem.ListViewSubItem thanhtien = new ListViewItem.ListViewSubItem(masp, ((float.Parse(dr["DONGIA"].ToString()) * float.Parse(txt_soluong.Text))-(float.Parse(b.ToString())*float.Parse(txt_soluong.Text))).ToString());
                            masp.SubItems.Add(soluong);
                            ListViewItem.ListViewSubItem dongia = new ListViewItem.ListViewSubItem(masp, dr["DONGIA"].ToString());
                            masp.SubItems.Add(dongia);

                            ListViewItem.ListViewSubItem km = new ListViewItem.ListViewSubItem(masp, b.ToString());
                            masp.SubItems.Add(km);
                            masp.SubItems.Add(thanhtien);
                        }
                        lv_hoadon.Items.Add(masp);
                        txt_masp.Clear();
                    }
                    else
                    {
                        lv_hoadon.Items[kt(a)].SubItems[2].Text = (int.Parse(lv_hoadon.Items[kt(a)].SubItems[2].Text) + 1).ToString();
                        lv_hoadon.Items[kt(a)].SubItems[4].Text = (int.Parse(lv_hoadon.Items[kt(a)].SubItems[4].Text) + int.Parse(lv_hoadon.Items[kt(a)].SubItems[4].Text)).ToString();
                        lv_hoadon.Items[kt(a)].SubItems[5].Text = ((int.Parse(lv_hoadon.Items[kt(a)].SubItems[2].Text) * float.Parse(lv_hoadon.Items[kt(a)].SubItems[3].Text))-(float.Parse(lv_hoadon.Items[kt(a)].SubItems[4].Text))).ToString();
                        txt_masp.Clear();
                    }




                }
            }
            float tt = 0;
            foreach (ListViewItem item in lv_hoadon.Items)
            {
                tt = tt + float.Parse(item.SubItems[5].Text);
            }
            txt_tongtien.Text = tt.ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_masp.Enabled = true;
            txt_soluong.Enabled = true;
            txt_tensanpham.Enabled = false;
            btn_xoa.Enabled = false;
            btn_sua.Enabled = false;
            btn_luu.Enabled = false;
            txt_masp.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_soluong.Enabled == true)
            {
                if (lv_hoadon.SelectedItems[0].SubItems[4].Text == "0")
                {
                    lv_hoadon.SelectedItems[0].SubItems[2].Text = txt_soluong.Text;
                    lv_hoadon.SelectedItems[0].SubItems[5].Text = (float.Parse(txt_soluong.Text) * float.Parse(lv_hoadon.SelectedItems[0].SubItems[3].Text)).ToString();
                }
                else
                {
                    
                    lv_hoadon.SelectedItems[0].SubItems[2].Text = txt_soluong.Text;
                    lv_hoadon.SelectedItems[0].SubItems[4].Text = (int.Parse(txt_soluong.Text) * khuyenmai(int.Parse(txt_masp.Text))).ToString();
                    lv_hoadon.SelectedItems[0].SubItems[5].Text = (float.Parse(txt_soluong.Text) * float.Parse(lv_hoadon.SelectedItems[0].SubItems[3].Text) - float.Parse(lv_hoadon.SelectedItems[0].SubItems[4].Text)).ToString();
                }
            }
            txt_soluong.Enabled = false;
            float tt = 0;
            foreach (ListViewItem item in lv_hoadon.Items)
            {
                tt = tt + float.Parse(item.SubItems[5].Text);
            }
            txt_tongtien.Text = tt.ToString();
        }
        void Databingding(DataTable dtb)
        {
            txt_masp.DataBindings.Clear();
            txt_soluong.DataBindings.Clear();
            txt_tensanpham.DataBindings.Clear();


            txt_masp.DataBindings.Add("Text", dtb, "MASP");
            txt_soluong.DataBindings.Add("Text", dtb, "SOLUONGSP");
            txt_tensanpham.DataBindings.Add("Text", dtb, "TENLSP");

        }

        private void lv_hoadon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_masp.Clear();
                txt_tensanpham.Clear();
                txt_soluong.Clear();
                txt_masp.Text = lv_hoadon.SelectedItems[0].SubItems[0].Text;
                txt_tensanpham.Text = lv_hoadon.SelectedItems[0].SubItems[1].Text;
                txt_soluong.Text = lv_hoadon.SelectedItems[0].SubItems[2].Text;
                btn_sua.Enabled = true;
                btn_xoa.Enabled = true;
                btn_them.Enabled = false;
                btn_luu.Enabled = true;
                txt_masp.Enabled = false;
                txt_soluong.Enabled = false;
            }
            catch
            {
                btn_sua.Enabled = false;
                btn_xoa.Enabled = false;
                btn_them.Enabled = true;
                btn_luu.Enabled = false;
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r;
                r = MessageBox.Show("Bạn thật sự muốn xóa sản phẩm này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    lv_hoadon.Items.Remove(lv_hoadon.SelectedItems[0]);
                }
            }
            catch
            {
                MessageBox.Show("Sản phẩm đang được sử dụng ở bản khác");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = "set dateformat dmy insert into HOADON values ('" + txt_ngaylap.Text + "'," + int.Parse(DangNhap.ma[0].ToString()) + ",0)";
            SqlCommand cmd = new SqlCommand(sql, kn.connsql);
            kn.connsql.Open();
            cmd.ExecuteNonQuery();
            kn.connsql.Close();
            //
            string sql1 = "select Top 1 MAHD from HOADON order by MAHD DESC";
            SqlCommand cmd1 = new SqlCommand(sql1, kn.connsql);
            kn.connsql.Open();
            int a = int.Parse(cmd1.ExecuteScalar().ToString());
            kn.connsql.Close();
            foreach (ListViewItem item in lv_hoadon.Items)
            {
                string sql2 = " insert into CT_HOADON(MAHD,MASP,SOLUONGSP) values (" + a + "," + int.Parse(item.SubItems[0].Text) + "," + int.Parse(item.SubItems[2].Text) + ")";
                SqlCommand cmd2 = new SqlCommand(sql2, kn.connsql);
                kn.connsql.Open();
                cmd2.ExecuteNonQuery();
                kn.connsql.Close();

            }
            MessageBox.Show("Thêm hóa đơn thành công");
            ShowReport dv = new ShowReport(a);
            dv.Show();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}