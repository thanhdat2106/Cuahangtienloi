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
    public partial class TaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn;
        DataSet ds;
        SqlDataAdapter da;
        DataColumn[] key = new DataColumn[1];
        DataColumn[] key1 = new DataColumn[1];
        DataColumn[] key2 = new DataColumn[1];
        string fileName;
        public TaiKhoan()
        {
            InitializeComponent();
            kn = new KetNoi();
            ds = new DataSet();   

        }

            private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        void loadAD()
        {
            kn.connsql.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN NV,CHUCVU CV,TAIKHOAN TK WHERE NV.MATK=TK.MATK AND CV.MACV=NV.MACV AND NV.MATK ='" + DangNhap.ma + "'", kn.connsql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txt_tendn.Text = dr["TENTK"].ToString();
                txt_tennv.Text = dr["TENNV"].ToString();
                txt_cmnd.Text = dr["CMND"].ToString();
                txt_sdt.Text = dr["SDT"].ToString();
                txt_matkhau.Text = dr["MATKHAU"].ToString();
                txt_diachi.Text = dr["DIACHI"].ToString();
                txt_chucvu.Text = dr["TENCV"].ToString();
                txt_manv.Text= dr["MANV"].ToString();
                txt_ngaysinh.Text = dr["NGAYSINH"].ToString();
                // txt_ngaysinh.Text = (DateTime.Parse(dr["NGAYSINH"].ToString())).ToString("MM/dd/yyyy");
                if (dr["GIOITINH"].ToString().Equals("Nam"))
                {
                    rdo_nam.Checked = true;
                    rdo_nu.Checked = false;
                }
                else
                {
                    rdo_nam.Checked = false;
                    rdo_nu.Checked = true;
                }
                ptb_tk.Image = Image.FromFile(dr["ANH"].ToString());
                ptb_tk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                fileName = dr["ANH"].ToString();
            }
            
            kn.connsql.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            loadAD();
        }
            private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_cmnd.Enabled = txt_diachi.Enabled = txt_matkhau.Enabled = txt_ngaysinh.Enabled = txt_sdt.Enabled = txt_tendn.Enabled = txt_tennv.Enabled = true;
            btn_luu.Enabled =rdo_nam.Enabled=rdo_nu.Enabled= true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                string strselect = "select * from NHANVIEN";
                da = new SqlDataAdapter(strselect, kn.connsql);
                ds = new DataSet();
                da.Fill(ds, "NHANVIEN");
                key[0] = ds.Tables["NHANVIEN"].Columns[0];
                ds.Tables["NHANVIEN"].PrimaryKey = key;
                string selectSL = "select * from TAIKHOAN";
                SqlDataAdapter dasl = new SqlDataAdapter(selectSL, kn.connsql);
                DataSet dt = new DataSet();
                dasl.Fill(dt, "TAIKHOAN");
                key1[0] = dt.Tables["TAIKHOAN"].Columns[0];
                dt.Tables["TAIKHOAN"].PrimaryKey = key1;
                //  label1.Text = dt.Tables["TAIKHOAN"].Rows[dt.Tables["TAIKHOAN"].Rows.Count - 1][0].ToString();


                DataRow dr1 = dt.Tables["TAIKHOAN"].Rows.Find(DangNhap.ma);
                DataRow dr = ds.Tables["NHANVIEN"].Rows.Find(txt_manv.Text);
                dr["TENNV"] = txt_tennv.Text;
                dr["NGAYSINH"] = DateTime.Parse(txt_ngaysinh.Text).ToString();
                dr["CMND"] = txt_cmnd.Text;
                dr["DIACHI"] = txt_diachi.Text;
                dr["MATK"] = DangNhap.ma;
                dr["SDT"] = txt_sdt.Text;
                dr["ANH"] = fileName.ToString();
                if (rdo_nam.Checked)
                    dr["GIOITINH"] = rdo_nam.Text;
                else
                    dr["GIOITINH"] = rdo_nu.Text;
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "NHANVIEN");
                dr1["TENTK"] = txt_tendn.Text;
                dr1["MATKHAU"] = txt_matkhau.Text;
                SqlCommandBuilder cb1 = new SqlCommandBuilder(dasl);
                dasl.Update(dt, "TAIKHOAN");
                // dtgvNhanVien.Refresh();
                loadAD();
                MessageBox.Show("Bạn đã chỉnh sửa thành công");
                txt_cmnd.Enabled = txt_diachi.Enabled = txt_matkhau.Enabled = txt_ngaysinh.Enabled = txt_sdt.Enabled = txt_tendn.Enabled = txt_tennv.Enabled = false;
                btn_chon.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra trong khi sửa.Bạn vui lòng kiểm tra lại.");
            }
            
        }

        private void TaiKhoan_Load_1(object sender, EventArgs e)
        {
            loadAD();
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                
                fileName = dlg.FileName;
               // txt_anh.Text = fileName;
                ptb_tk.Image = Image.FromFile(fileName);
                ptb_tk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            //this.Close();
            TrangChu.ActiveForm.Close();
        }

        private void TaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}