using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doanmonhocqlbh
{
    public partial class DonHang : Form
    {
        public DonHang()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsdoanmonhocqlbh");
        private void DonHang_Load(object sender, EventArgs e)
        {
            
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
                
                string sQueryDonHang = @"select * from  don_hang";
                SqlDataAdapter daDonHang = new SqlDataAdapter(sQueryDonHang, conn);
                daDonHang.Fill(ds, "don_hang");

                

                ds_donhang.DataSource = ds.Tables["don_hang"];
                ds_donhang.Columns["MaDonHang"].HeaderText = "Mã Đơn Hàng ";
                ds_donhang.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                ds_donhang.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
                ds_donhang.Columns["MaVanChuyen"].HeaderText = "Mã Vận Chuyển";
                ds_donhang.Columns["MaThanhToan"].HeaderText = "Mã Thanh Toán";
                ds_donhang.Columns["NgayDat"].HeaderText = "Ngày Đặt";
                ds_donhang.Columns["TrangThai"].HeaderText = "Trạng Thái";
                ds_donhang  .Columns["SoLuong"].HeaderText = "Số Lượng";
                ds_donhang.Columns["TongTien"].HeaderText = "Tổng Tiền";



        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (ds_donhang.SelectedRows.Count > 0)
            {
                string madonhang = ds_donhang.SelectedRows[0].Cells["MaDonHang"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa đơn hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
                    {
                        conn.Open();
                        string sQuery = "DELETE FROM don_hang WHERE MaDonHang = @MaDonHang";
                        SqlCommand cmd = new SqlCommand(sQuery, conn);
                        cmd.Parameters.AddWithValue("@MaDonHang", madonhang);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Xóa đơn hàng thành công!");

                    // Cập nhật lại dữ liệu trên DataGridView
                    string sQueryDonHang = @"select * from don_hang";
                    SqlDataAdapter daDonHang = new SqlDataAdapter(sQueryDonHang, conn);
                    DataTable dt = new DataTable();
                    daDonHang.Fill(dt);
                    ds_donhang.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xóa!");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {


                this.Close();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";

            string maKhachHang = txtMaKhachHang.Text;
            string trangThai = cbtrangthai.SelectedItem != null ? cbtrangthai.SelectedItem.ToString() : null;
            string loaiTimKiem = "";

            // Kiểm tra loại tìm kiếm mà người dùng đã chọn
            if (!string.IsNullOrEmpty(maKhachHang))
            {
                loaiTimKiem = "MaKhachHang";

                // Xây dựng câu lệnh SQL tìm kiếm theo mã khách hàng
                string query = "SELECT * FROM don_hang WHERE MaKhachHang = @maKhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maKhachHang", maKhachHang);

                // Thực hiện câu lệnh SQL và hiển thị kết quả trên DataGridView
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng nào của khách hàng có mã " + maKhachHang, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ds_donhang.DataSource = table;
            }
            else if (!string.IsNullOrEmpty(trangThai))
            {
                loaiTimKiem = "TrangThai";

                // Xây dựng câu lệnh SQL tìm kiếm theo trạng thái đơn hàng
                string query = "SELECT * FROM don_hang WHERE TrangThai = @trangThai";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);

                // Thực hiện câu lệnh SQL và hiển thị kết quả trên DataGridView
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                ds_donhang.DataSource = table;
            }

            // Hiển thị thông báo nếu người dùng chưa chọn loại tìm kiếm hoặc trạng thái đơn hàng
            if (string.IsNullOrEmpty(loaiTimKiem) && string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng chọn loại tìm kiếm hoặc trạng thái đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

            private void btnsua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            // Lấy giá trị trạng thái mới được chọn
            // Lấy giá trị trạng thái mới được chọn
            string trangThai = cbtrangthai.SelectedItem.ToString();

            // Lấy mã đơn hàng được chọn từ DataGridView
            string maDonHang = ds_donhang.CurrentRow.Cells["MaDonHang"].Value.ToString();

            // Cập nhật trạng thái đơn hàng vào cơ sở dữ liệu
            string query = "UPDATE don_hang SET TrangThai = @trangThai WHERE MaDonHang = @maDonHang";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@trangThai", trangThai);
            cmd.Parameters.AddWithValue("@maDonHang", maDonHang);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Cập nhật trạng thái đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Thực hiện lại truy vấn dữ liệu và hiển thị kết quả trên DataGridView
            string sQueryDonHang = @"select * from  don_hang";
            SqlDataAdapter daDonHang = new SqlDataAdapter(sQueryDonHang, conn);
            DataTable table = new DataTable();
            daDonHang.Fill(table);
            ds_donhang.DataSource = table;
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            string sQuerySanPham = @"select * from don_hang";
            txtMaKhachHang.Text = "";
            cbtrangthai.SelectedIndex = -1;
            SqlDataAdapter daSanPham = new SqlDataAdapter(sQuerySanPham, conn);
            DataTable dt = new DataTable();
            daSanPham.Fill(dt);
            ds_donhang.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnvanchuyen_Click(object sender, EventArgs e)
        {
            VanChuyen vanChuyen = new VanChuyen();
            vanChuyen.ShowDialog();
        }

        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {
            txtMaKhachHang.Text = txtMaKhachHang.Text.ToUpper();
            txtMaKhachHang.SelectionStart = txtMaKhachHang.Text.Length;
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang khachhang = new KhachHang();
            khachhang.ShowDialog();
        }
    }
}
