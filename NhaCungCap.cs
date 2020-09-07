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
    public partial class NhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn;
        public DataSet ds;
        public SqlDataAdapter da;
        public DataColumn[] key = new DataColumn[1];
        DataColumn[] key1 = new DataColumn[1];
        public NhaCungCap()
        {
            InitializeComponent();
            kn = new KetNoi();
            ds = new DataSet();
        }
        void load_grid()
        {
            string strselect = "select * from NHACUNGCAP";
            da = new SqlDataAdapter(strselect, kn.connsql);

            da.Fill(ds, "NHACUNGCAP");
            key[0] = ds.Tables["NHACUNGCAP"].Columns["MANCC"];
            ds.Tables["NHACUNGCAP"].PrimaryKey = key;
            dtgv_ncc.DataSource = ds.Tables["NHACUNGCAP"];
           Databingding(ds.Tables["NHACUNGCAP"]);

        }
        public void Databingding(DataTable dtb)
        {
            txt_mancc.DataBindings.Clear();
            txt_tenncc.DataBindings.Clear();
            txt_diachi.DataBindings.Clear();
            txt_sdt.DataBindings.Clear();
          


            txt_mancc.DataBindings.Add("Text", dtb, "MANCC");
            txt_tenncc.DataBindings.Add("Text", dtb, "TENNCC");
            txt_diachi.DataBindings.Add("Text", dtb, "DIACHI");
            txt_sdt.DataBindings.Add("Text", dtb, "SDT");
           
           
        }
        private void barEditItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            load_grid();
            Databingding(ds.Tables["NHACUNGCAP"]);
        }
    }
}