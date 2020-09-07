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
    public partial class ShowReport : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        int mahd  ;
        KetNoi kn;
        public ShowReport()
        {
            InitializeComponent();
        }
        public ShowReport(int ma)
        {
            mahd = ma;
            InitializeComponent();
            kn = new KetNoi();
        }

        private void documentViewer1_Load(object sender, EventArgs e)
        {
            //SqlDataAdapter da = new SqlDataAdapter("Select * from NHANVIEN where MATK=" + DangNhap.ma[0].ToString() + "", kn.connsql);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            ReportHD rp = new ReportHD();
            //rp.Parameters["TenNV"].Value = dt.Rows[0].Field<String>("TENNV").ToString();
            //SqlDataAdapter dahd = new SqlDataAdapter("Select * from HOADON where MAHD=" + mahd + "", kn.connsql);
            //DataTable dthd = new DataTable();
            //dahd.Fill(dthd);
            ////rp.Parameters["NgayLap"].Value = dthd.Rows[0].Field<String>("NGAYLAP").ToString();
            //////
            //SqlDataAdapter dact = new SqlDataAdapter("Select SOLUONGSP, THANHTIEN, DONGIA, TENLSP from CT_HOADON ct, SANPHAM sp, LOAISP l where ct.MASP = sp.MASP and sp.MALSP =l.MALSP and  MAHD=" + mahd + "", kn.connsql);
            //DataTable dtct = new DataTable();
            //dact.Fill(dtct);
            //foreach(DataRow dr in dtct.Rows)
            //{
            //    rp.Parameters["soluong"].Value = dr["SOLUONGSP"].ToString();
            //    rp.Parameters["tensp"].Value = dr["TENLSP"].ToString();
            //    rp.Parameters["dongia"].Value = dr["DONGIA"].ToString();
            //    rp.Parameters["thanhtien"].Value = dr["THANHTIEN"].ToString();
            //}    
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from NHANVIEN where MATK=" + DangNhap.ma[0].ToString() + "", kn.connsql);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            rp.Parameters["nhanvien"].Value = dt1.Rows[0].Field<String>("TENNV").ToString();
            string strselect = "Select * from HOADON hd join CT_HOADON ct on hd.MAHD=ct.MAHD and hd.MAHD = " + mahd + "   join SANPHAM sp on ct.MASP = sp.MASP  join LOAISP l on l.MALSP = sp.MALSP left join KHUYENMAI km on ct.MASP = km.MASP and km.NGAYKETTHUC >= '" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
            SqlDataAdapter da = new SqlDataAdapter(strselect, kn.connsql);
                DataTable dt = new DataTable();
                da.Fill(dt);
            rp.DataSource = dt;
            documentViewer1.DocumentSource = rp;
          
        }
    }
}