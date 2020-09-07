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
    public partial class NhapHang : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn;
        public DataSet ds;
        public SqlDataAdapter da;
        public DataColumn[] key = new DataColumn[1];
        DataColumn[] key1 = new DataColumn[1];
        public NhapHang()
        {
            InitializeComponent();
            kn = new KetNoi();
            ds = new DataSet();

        }
        void load_grid()
        {
            string strselect = "select * from NHAPHANG";
            da = new SqlDataAdapter(strselect, kn.connsql);

            da.Fill(ds, "NHAPHANG");
            key[0] = ds.Tables["NHAPHANG"].Columns["MANH"];
            ds.Tables["NHAPHANG"].PrimaryKey = key;
            dtgv_nhaphang.DataSource = ds.Tables["NHAPHANG"];
            //Databingding(ds.Tables["NHACUNGCAP"]);

        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            load_grid();
        }
    }
}