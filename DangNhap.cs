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
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn;
        public static string ID_USER = "";
        public static string ma = "";
        public static int maq = 0;
        public DangNhap()
        {
            InitializeComponent();
            kn = new KetNoi();
        }
        private string getID(string username, string pass)
        {
            string id = "";
            try
            {
                kn.connsql.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TAIKHOAN WHERE TENTK ='" + username + "' and MATKHAU='" + pass + "'", kn.connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["TENTK"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                kn.connsql.Close();
            }
            return id;
        }
        private string getMa(string username, string pass)
        {
            string id = "";
            try
            {
                kn.connsql.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TAIKHOAN TK,NHANVIEN NV WHERE TK.MATK=NV.MATK AND TENTK ='" + username + "' and MATKHAU='" + pass + "'", kn.connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["MATK"].ToString();
                    maq = int.Parse(dr["MACV"].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                kn.connsql.Close();
            }
            return id;
        }
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            ma = getMa(txt_tendn.Text, txt_matkhau.Text);
            ID_USER = getID(txt_tendn.Text, txt_matkhau.Text);
            if (ID_USER != "")
            {
                TrangChu qlnt = new TrangChu();
                this.Hide();
                qlnt.Show();
                qlnt.accordionControlElement8.Text = txt_tendn.Text;
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}