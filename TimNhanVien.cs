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
    public partial class TimNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public int i = 0;
        KetNoi kn;
        DataSet ds;
        SqlDataAdapter da;
        DataColumn[] key = new DataColumn[1];
        DataColumn[] key1 = new DataColumn[1];
        public TimNhanVien()
        {
            InitializeComponent();
            kn = new KetNoi();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void btn_tim_Click(object sender, EventArgs e)
        {
            NhanVien a = new NhanVien();
            TrangChu tc = new TrangChu();
            if (txt_tim.Text.Length != 0)
            {
                if (rdo_manv.Checked == true)
                {
                    string strselect = "select * from TAIKHOAN TK,NHANVIEN NV,CHUCVU CV where TK.MATK=NV.MATK AND NV.MACV=CV.MACV AND NV.MANV=" + txt_tim.Text ;
                    a.da = new SqlDataAdapter(strselect, kn.connsql);

                    a.da.Fill(a.ds, "NHANVIEN");
                    a.key[0] = a.ds.Tables["NHANVIEN"].Columns["MANV"];
                    a.ds.Tables["NHANVIEN"].PrimaryKey = a.key;
                    a.dtgvNhanVien.DataSource = a.ds.Tables["NHANVIEN"];
                    // a.Databingding(a.ds.Tables["NHANVIEN"]);
                    this.Close();
                    tc.fluentDesignFormContainer1.Controls.Clear();
                    a.TopLevel = false;
                    a.Dock = DockStyle.Fill;
                    tc.fluentDesignFormContainer1.Controls.Add(a);
                    tc.Show();
                    a.Show();
                   

                }
                else if (rdo_tennv.Checked == true)
                    i = 2;
                else if (rdo_matk.Checked == true)
                    i = 3;
                else if (rdo_tendn.Checked == true)
                    i = 4;
                else if (rdo_chucvu.Checked == true)
                    i = 5;
                else
                    MessageBox.Show("Bạn chưa chọn đối tượng tìm kiếm");
            }
            else
                errorProvider1.SetError(txt_tim,"Đối tượng tìm kiếm không được trống");


        }
    }
}