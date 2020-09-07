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
    public partial class LoaiSP : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn;
        public DataSet ds;
        public SqlDataAdapter da;
        public DataColumn[] key = new DataColumn[1];
        DataColumn[] key1 = new DataColumn[1];
        public LoaiSP()
        {
            InitializeComponent();
            kn = new KetNoi();
            ds = new DataSet();
        }
        void load_grid()
        {
            string strselect = "select MALSP,TENLSP,DONGIA,TENNCC,TENCL from LOAISP LSP,NHACUNGCAP NCC,CHUNGLOAI CL WHERE LSP.MANCC=NCC.MANCC AND LSP.MACL=CL.MACL";
            da = new SqlDataAdapter(strselect, kn.connsql);

            da.Fill(ds, "LOAISP");
            key[0] = ds.Tables["LOAISP"].Columns["LOAISP"];
            ds.Tables["LOAISP"].PrimaryKey = key;
            dtgv_loaisp.DataSource = ds.Tables["LOAISP"];
          Databingding(ds.Tables["LOAISP"]);

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void Databingding(DataTable dtb)
        {
            ma_loaisp.DataBindings.Clear();
            txt_tenloai.DataBindings.Clear();
            txt_dongia.DataBindings.Clear();
            cbo_chungloai.DataBindings.Clear();
            cbo_ncc.DataBindings.Clear();



            ma_loaisp.DataBindings.Add("Text", dtb, "MALSP");
            txt_tenloai.DataBindings.Add("Text", dtb, "TENLSP");
            txt_dongia.DataBindings.Add("Text", dtb, "DONGIA");
            cbo_chungloai.DataBindings.Add("Text", dtb, "TENCL");
            cbo_ncc.DataBindings.Add("Text", dtb, "TENNCC");


        }
        private void LoaiSP_Load(object sender, EventArgs e)
        {
            load_grid();
            Databingding(ds.Tables["LOAISP"]);
        }
    }
}