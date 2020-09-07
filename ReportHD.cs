using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

namespace CuaHangTienLoi
{
    public partial class ReportHD : DevExpress.XtraReports.UI.XtraReport
    {
        int a;
        KetNoi kn;
        public ReportHD()
        {
            InitializeComponent();
        }
        public ReportHD( int mahd)
        {
            InitializeComponent();
            a = mahd;
            kn = new KetNoi();

        }
        //void load()
        //{
        //    string strselect = "select MASP,TENLSP,NGAYSX,HANSUDUNG,SOLUONGTON,DONGIA,BARCODE from SANPHAM sp, LOAISP l where sp.MALSP = l.MALSP";
        //    SqlDataAdapter da = new SqlDataAdapter(strselect, kn.connsql);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
            
        //}


    }
}
