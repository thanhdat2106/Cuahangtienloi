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
using System.IO;
using DevExpress.Utils.Extensions;

namespace CuaHangTienLoi
{
    public partial class NhanVien : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn;
        public DataSet ds;
        public SqlDataAdapter da;
        public DataColumn[] key = new DataColumn[1];
        DataColumn[] key1 = new DataColumn[1];
        public NhanVien()
        {
            InitializeComponent();
            kn = new KetNoi();
            ds = new DataSet();
           
        }
        void load_grid()
        {
            string strselect = "select NV.MANV,TENNV,GIOITINH,NGAYSINH,DIACHI,CMND,SDT,ANH,TENCV,TENTK,MATKHAU,NV.MATK,NV.MACV from NHANVIEN NV,CHUCVU CV,TAIKHOAN TK where NV.MATK=TK.MATK AND NV.MACV=CV.MACV";
            da = new SqlDataAdapter(strselect, kn.connsql);

            da.Fill(ds, "NHANVIEN");
            key[0] = ds.Tables["NHANVIEN"].Columns["MANV"];
            ds.Tables["NHANVIEN"].PrimaryKey = key;
            dtgvNhanVien.DataSource = ds.Tables["NHANVIEN"];
            Databingding(ds.Tables["NHANVIEN"]);

        }

        public void loadCV()
        {
            string strselect = "select * from CHUCVU";
            da = new SqlDataAdapter(strselect, kn.connsql);
            da.Fill(ds, "CHUCVU");
            cbo_chucvu.DataSource = ds.Tables["CHUCVU"];
            cbo_chucvu.DisplayMember = "TENCV";
            cbo_chucvu.ValueMember = "MACV";
            cbo_chucvu.SelectedItem = cbo_chucvu.Items[0];

        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            load_grid();
            loadCV();
            dtgvNhanVien.ReadOnly = true;
            dtgvNhanVien.AllowUserToAddRows = false;
            Sửa.Enabled = Xóa.Enabled = Lưu.Enabled = false;
            Databingding(ds.Tables["NHANVIEN"]);
        }
        public void Databingding(DataTable dtb)
        {
            try
            {
                txt_tennv.DataBindings.Clear();
                txt_ngaysinh.DataBindings.Clear();
                txt_diachi.DataBindings.Clear();
                txt_cmnd.DataBindings.Clear();
                txt_sdt.DataBindings.Clear();
                txt_anh.DataBindings.Clear();
                cbo_chucvu.DataBindings.Clear();
                txt_tentk.DataBindings.Clear();
                txt_mk.DataBindings.Clear();
                txt_manv.DataBindings.Clear();
                txt_matk.DataBindings.Clear();


                txt_matk.DataBindings.Add("Text", dtb, "MATK");
                txt_manv.DataBindings.Add("Text", dtb, "MANV");
                txt_tennv.DataBindings.Add("Text", dtb, "TENNV");
                txt_ngaysinh.DataBindings.Add("Text", dtb, "NGAYSINH");
                txt_diachi.DataBindings.Add("Text", dtb, "DIACHI");
                txt_cmnd.DataBindings.Add("Text", dtb, "CMND");
                txt_sdt.DataBindings.Add("Text", dtb, "SDT");
                txt_anh.DataBindings.Add("Text", dtb, "ANH");
                cbo_chucvu.DataBindings.Add("Text", dtb, "TENCV");
                txt_tentk.DataBindings.Add("Text", dtb, "TENTK");
                txt_mk.DataBindings.Add("Text", dtb, "MATKHAU");
                if (dtgvNhanVien.Rows[dtgvNhanVien.CurrentRow.Index].Cells[2].Value.ToString().Equals("Nam") == true)
                {
                    rd_nam.Checked = true;
                    rd_nu.Checked = false;
                }
                else
                {
                    rd_nu.Checked = true;
                    rd_nam.Checked = false;
                }

                ptb_nv.Image = Image.FromFile(txt_anh.Text);
                ptb_nv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }
            catch { }
        }


        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Control item in tableLayoutPanel3.Controls)
            {
                if (item.GetType() == typeof(TextBox) || item.GetType() == typeof(DateTimePicker) || item.GetType() == typeof(RadioButton) || item.GetType() == typeof(ComboBox))
                {
                    item.Enabled = true;
                }
                btnLuu.Enabled = true;
                btn_chon.Enabled = true;
                rd_nam.Enabled = true;
                rd_nu.Enabled = true;
            }
            txt_cmnd.Clear();
            txt_tennv.Clear();
            txt_diachi.Clear();
            txt_anh.Clear();
            txt_sdt.Clear();
            txt_tentk.Clear();
            txt_mk.Clear();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txt_manv.Enabled = false;
            txt_matk.Enabled = false;

        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrangChu.ActiveForm.Close();
        }

        private void NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn thật sự muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
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

                if (btnSua.Enabled == true && btnThem.Enabled == false)
                {
                    DataRow dr1 = dt.Tables["TAIKHOAN"].Rows.Find(txt_matk.Text);
                    DataRow dr = ds.Tables["NHANVIEN"].Rows.Find(txt_manv.Text);
                    dr["TENNV"] = txt_tennv.Text;
                    dr["NGAYSINH"] = DateTime.Parse(txt_ngaysinh.Text).ToString();
                    dr["CMND"] = txt_cmnd.Text;
                    dr["DIACHI"] = txt_diachi.Text;
                    dr["ANH"] = txt_anh.Text;
                    dr["MATK"] = txt_matk.Text;
                    dr["SDT"] = txt_sdt.Text;
                    dr["MACV"] = cbo_chucvu.SelectedValue.ToString();
                    if (rd_nam.Checked)
                        dr["GIOITINH"] = "Nam";
                    else
                        dr["GIOITINH"] = "Nữ";
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "NHANVIEN");
                    dr1["TENTK"] = txt_tentk.Text;
                    dr1["MATKHAU"] = txt_mk.Text;
                    SqlCommandBuilder cb1 = new SqlCommandBuilder(dasl);
                    dasl.Update(dt, "TAIKHOAN");
                    dtgvNhanVien.Refresh();
                    MessageBox.Show("Bạn đã chỉnh sửa thành công");
                }
                else
                {
                    string gt;
                    if (rd_nam.Checked)
                        gt = "Nam";
                    else
                        gt = "Nữ";
                    string sql_tk = "insert into TAIKHOAN values ('" + txt_tentk.Text + "','" + txt_mk.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql_tk, kn.connsql);
                    kn.connsql.Open();
                    cmd.ExecuteNonQuery();
                    kn.connsql.Close();
                    kn.connsql.Open();
                    string ma = "select MATK from TAIKHOAN where TENTK='" + txt_tentk.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(ma, kn.connsql);
                    var ma1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection);
                    int id_tk = 0;
                    if (ma1.HasRows)
                    {
                        while (ma1.Read())
                        {
                            id_tk = ma1.GetInt32(0);
                        }
                    }
                    kn.connsql.Close();
                    kn.connsql.Open();
                    string sql = "set dateformat dmy insert into NHANVIEN values (N'" + txt_tennv.Text + "',N'" + gt + "','" + DateTime.Parse(txt_ngaysinh.Text).ToString("dd/MM/yyyy") + "',N'" + txt_diachi.Text + "','" + cbo_chucvu.SelectedValue.ToString() + "','" + txt_anh.Text + "','" + txt_sdt.Text + "','" + txt_cmnd.Text + "','" + id_tk.ToString() + "')";
                    SqlCommand cmd2 = new SqlCommand(sql, kn.connsql);
                    cmd2.ExecuteNonQuery();
                    kn.connsql.Close();
                    MessageBox.Show("Bạn đã thêm thành công");
                }
                load_grid();
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                foreach (Control item in tableLayoutPanel3.Controls)
                {
                    if (item.GetType() == typeof(TextBox) || item.GetType() == typeof(DateTimePicker) ||
                        item.GetType() == typeof(RadioButton))
                    {
                        item.Enabled = false;
                    }
                   
                    rd_nam.Enabled = false;
                    rd_nu.Enabled = false;
                }
                cbo_chucvu.Enabled = false;

        }
            catch
            {
                MessageBox.Show("Thất bại");

            }


}

private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            foreach (Control item in tableLayoutPanel3.Controls)
            {
                if (item.GetType() == typeof(TextBox) || item.GetType() == typeof(DateTimePicker) || item.GetType() == typeof(RadioButton) || item.GetType() == typeof(ComboBox))
                {
                    item.Enabled = true;
                }
                btnLuu.Enabled = true;
                btn_chon.Enabled = true;
                rd_nam.Enabled = true;
                rd_nu.Enabled = true;
            }
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txt_manv.Enabled = false;
            txt_matk.Enabled = false;


        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn thật sự muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                try
                {
                    string strselect = "select * from NHANVIEN";
                    da = new SqlDataAdapter(strselect, kn.connsql);
                    ds = new DataSet();
                    da.Fill(ds, "NHANVIEN");
                    key[0] = ds.Tables["NHANVIEN"].Columns[0];
                    ds.Tables["NHANVIEN"].PrimaryKey = key;
                    DataRow dr = ds.Tables["NHANVIEN"].Rows.Find(dtgvNhanVien.CurrentRow.Cells[0].Value.ToString());
                    if (dr != null)
                    {
                        dr.Delete();
                        dtgvNhanVien.Refresh();
                    }
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "NHANVIEN");
                    MessageBox.Show("Xóa thành công");
                    load_grid();
                    Databingding(ds.Tables["NHANVIEN"]);
                }
                catch
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            foreach (Control item in tableLayoutPanel3.Controls)
            {
                if (item.GetType() == typeof(TextBox) || item.GetType() == typeof(DateTimePicker) ||
                    item.GetType() == typeof(RadioButton))
                {
                    item.Enabled = false;
                }
                rd_nam.Enabled = false;
                rd_nu.Enabled = false;
            }
            cbo_chucvu.Enabled = false;
        }

        private void Thêm_ItemClick(object sender, ItemClickEventArgs e)
        {
            Lưu.Enabled = true;
            dtgvNhanVien.ReadOnly = false;
            dtgvNhanVien.AllowUserToAddRows = true;
            for (int i = 0; i < dtgvNhanVien.Rows.Count - 1; i++)
            {
                dtgvNhanVien.Rows[i].ReadOnly = true;
            }
            dtgvNhanVien.FirstDisplayedScrollingRowIndex = dtgvNhanVien.Rows.Count - 1;
        }

        private void dtgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
            Xóa.Enabled = Sửa.Enabled = true;
        }

        private void Sửa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Lưu.Enabled = true;
            dtgvNhanVien.ReadOnly = false;
            for (int i = 0; i < dtgvNhanVien.Rows.Count - 1; i++)
            {
                dtgvNhanVien.Rows[i].ReadOnly = false;
            }
            dtgvNhanVien.Columns[0].ReadOnly = true;
            dtgvNhanVien.AllowUserToAddRows = false;
        }

        private void Lưu_ItemClick(object sender, ItemClickEventArgs e)
        {
            string strselect = "select * from NHANVIEN";
            da = new SqlDataAdapter(strselect, kn.connsql);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "NHANVIEN");
            Databingding(ds.Tables["NHANVIEN"]);
            MessageBox.Show("Thành công");
            Lưu.Enabled = false;
        }

        private void btn_chonanh_Click(object sender, EventArgs e)
        {
            // txt_anh.Text = Path.GetFileName("D:\\Study\\CNPM\\CuaHangTienLoi\\img\\");
        }

        private void Thoát_ItemClick(object sender, ItemClickEventArgs e)
        {
            // label1.Text = dt.Tables["TaiKhoan"].Rows[0][dt.Tables["TAIKHOAN"].Rows.Count - 1].ToString();
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                txt_anh.Text = fileName;
                ptb_nv.Image = Image.FromFile(fileName);
                ptb_nv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }

        }

        private void txt_anh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ptb_nv.Image = Image.FromFile(txt_anh.Text);
                ptb_nv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }
            catch
            {

            }
        }

        private void dtgvNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (dtgvNhanVien.Rows[dtgvNhanVien.CurrentRow.Index].Cells[2].Value.ToString().Equals("Nam") == true)
            //{
            //    rd_nam.Checked = true;
            //    rd_nu.Checked = false;
            //}
            //else
            //{
            //    rd_nu.Checked = true;
            //    rd_nam.Checked = false;
            //}

        }

        private void dtgvNhanVien_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvNhanVien.Rows[dtgvNhanVien.CurrentRow.Index].Cells[2].Value.ToString().Equals("Nam") == true)
            {
                rd_nam.Checked = true;
                rd_nu.Checked = false;
            }
            else
            {
                rd_nu.Checked = true;
                rd_nam.Checked = false;
            }
        }

        private void btnTim_ItemClick(object sender, ItemClickEventArgs e)
        {
      
            
            //string strselect = "select * from TAIKHOAN TK,NHANVIEN NV,CHUCVU CV where TK.MATK=NV.MATK AND NV.MACV=CV.MACV AND MATK='" + btnTim.EditValue + "'";
            //da = new SqlDataAdapter(strselect, kn.connsql);

            //da.Fill(ds, "NHANVIEN");
            //key[0] = ds.Tables["NHANVIEN"].Columns["MANV"];
            //ds.Tables["NHANVIEN"].PrimaryKey = key;
            //dtgvNhanVien.DataSource = ds.Tables["NHANVIEN"];
            //Databingding(ds.Tables["NHANVIEN"]);
        }

        private void btnTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TimNhanVien search = new TimNhanVien();
            //search.ShowDialog();
            //search.btn_tim_Click(search.btn_tim,e);
            //string strselect = "select * from TAIKHOAN TK,NHANVIEN NV,CHUCVU CV where TK.MATK=NV.MATK AND NV.MACV=CV.MACV AND NV.MANV = " + txt_tim.EditValue.ToString();
            //da = new SqlDataAdapter(strselect, kn.connsql);

            //da.Fill(ds, "NHANVIEN");
            //key[0] = ds.Tables["NHANVIEN"].Columns["MANV"];
            //ds.Tables["NHANVIEN"].PrimaryKey = key;
            //dtgvNhanVien.DataSource = ds.Tables["NHANVIEN"];
            //Databingding(ds.Tables["NHANVIEN"]);
            //dtgvNhanVien.Refresh();


        }

        private void barEditItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void txt_tim_ItemPress(object sender, ItemClickEventArgs e)
        {
            
        }

        private void txt_tim_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            //string strselect = "select * from TAIKHOAN TK,NHANVIEN NV,CHUCVU CV where TK.MATK=NV.MATK AND NV.MACV=CV.MACV AND NV.MANV = " + txt_tim.EditValue.ToString();
            //da = new SqlDataAdapter(strselect, kn.connsql);
            //ds = new DataSet();
            //da.Fill(ds, "NHANVIEN");
            //key[0] = ds.Tables["NHANVIEN"].Columns["MANV"];
            //ds.Tables["NHANVIEN"].PrimaryKey = key;
            //dtgvNhanVien.DataSource = ds.Tables["NHANVIEN"];
            //dtgvNhanVien.Refresh();
            //Databingding(ds.Tables["NHANVIEN"]);
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //label1.Text = txt_tim.EditValue.ToString();
            //string strselect = "select * from TAIKHOAN TK,NHANVIEN NV,CHUCVU CV where TK.MATK=NV.MATK AND NV.MACV=CV.MACV AND NV.MANV = " + txt_tim.EditValue.ToString();
            //da = new SqlDataAdapter(strselect, kn.connsql);

            //da.Fill(ds, "NHANVIEN");
            //key[0] = ds.Tables["NHANVIEN"].Columns["MANV"];
            //ds.Tables["NHANVIEN"].PrimaryKey = key;
            //dtgvNhanVien.DataSource = ds.Tables["NHANVIEN"];

            //dtgvNhanVien.Refresh();
            //Databingding(ds.Tables["NHANVIEN"]);
        }

        private void txt_tim_EditValueChanged(object sender, EventArgs e)
        {
            //string strselect = "select * from TAIKHOAN TK,NHANVIEN NV,CHUCVU CV where TK.MATK=NV.MATK AND NV.MACV=CV.MACV AND NV.MANV = " + txt_tim.EditValue.ToString();
            //da = new SqlDataAdapter(strselect, kn.connsql);

            //da.Fill(ds, "NHANVIEN");
            //key[0] = ds.Tables["NHANVIEN"].Columns["MANV"];
            //ds.Tables["NHANVIEN"].PrimaryKey = key;
            //dtgvNhanVien.DataSource = ds.Tables["NHANVIEN"];

            //dtgvNhanVien.Refresh();
            //Databingding(ds.Tables["NHANVIEN"]);
        }

        private void txt_tim_ShownEditor(object sender, ItemClickEventArgs e)
        {

        }

        private void txt_timkiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (txt_tim.EditValue == null)
                {
                    MessageBox.Show("Bạn phải nhập từ khóa muốn tìm");
                }
                else
                {
                    try
                    {
                     
                            string strselect = "select * from TAIKHOAN TK,NHANVIEN NV,CHUCVU CV where TK.MATK=NV.MATK AND NV.MACV=CV.MACV AND NV.MANV = " + txt_tim.EditValue.ToString();
                            da = new SqlDataAdapter(strselect, kn.connsql);
                            ds = new DataSet();
                            da.Fill(ds, "NHANVIEN");
                            key[0] = ds.Tables["NHANVIEN"].Columns["MANV"];
                            ds.Tables["NHANVIEN"].PrimaryKey = key;
                            dtgvNhanVien.DataSource = ds.Tables["NHANVIEN"];
                            dtgvNhanVien.Refresh();
                            Databingding(ds.Tables["NHANVIEN"]);
                       
                    }
                    catch
                    {
                        try
                        {
                            string strselect = "select * from TAIKHOAN TK,NHANVIEN NV,CHUCVU CV where TK.MATK=NV.MATK AND NV.MACV=CV.MACV AND NV.TENNV like N'%" + txt_tim.EditValue.ToString() + "%'";
                            da = new SqlDataAdapter(strselect, kn.connsql);
                            ds = new DataSet();
                            da.Fill(ds, "NHANVIEN");
                            key[0] = ds.Tables["NHANVIEN"].Columns["MANV"];
                            ds.Tables["NHANVIEN"].PrimaryKey = key;
                            dtgvNhanVien.DataSource = ds.Tables["NHANVIEN"];
                            dtgvNhanVien.Refresh();
                            Databingding(ds.Tables["NHANVIEN"]);
                        }
                        catch { }
                    }
                    //Databingding(ds.Tables["NHANVIEN"]);
                }
            }
            catch { }
        }
    }
}