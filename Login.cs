using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CuaHangTienLoi
{
    public partial class Login : Form
    {
        KetNoi kn;
        public static string ID_USER = "";
        public static string ma = "";
        public static int maq = 0;
        public Login()
        {
            kn = new KetNoi();
            InitializeComponent();
            this.MaximizeBox = false;
        }
        private string getID(string username, string pass)
        {
            string id = "";
            try
            {
                kn.connsql.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TAIKHOAN WHERE TENTK ='" + username + "' and MatKhau='" + pass + "'", kn.connsql);
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM AD WHERE TENTK ='" + username + "' and MatKhau='" + pass + "'", kn.connsql);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["MATK"].ToString();
                  //  maq = int.Parse(dr["MACV"].ToString());
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
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            //ma = getMa(txt_tendn.Text, txt_matkhau.Text);
            ID_USER = getID(txt_tendn.Text, txt_matkhau.Text);
            if (ID_USER != "")
            {
                TrangChu qlnt = new TrangChu();
                this.Hide();
                qlnt.Show();
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

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn thật sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
