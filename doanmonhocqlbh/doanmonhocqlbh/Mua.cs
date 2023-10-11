using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doanmonhocqlbh
{
    public partial class txtMua : Form
    {
        public txtMua()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsdoanmonhocqlbh");
        SqlDataAdapter SanPham;
        private void Mua_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";

            // Lấy dữ liệu từ bảng "SanPham"
            string sQuerySanPham = @"select * from san_pham";
            SqlDataAdapter daSanPham = new SqlDataAdapter(sQuerySanPham, conn);
            daSanPham.Fill(ds, "san_pham");

            // Lấy dữ liệu từ bảng "SanPham"

            ds_sanpham.DataSource = ds.Tables["san_pham"];
            ds_sanpham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            ds_sanpham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            ds_sanpham.Columns["LoaiSanPham"].HeaderText = "Loại sản phẩm";
            ds_sanpham.Columns["MoTa"].HeaderText = "Mô tả";
            ds_sanpham.Columns["Gia"].HeaderText = "Giá";
            ds_sanpham.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
            ds_sanpham.Columns["Anh"].HeaderText = "Ảnh";

        }

        private void ds_sanpham_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có ít nhất một dòng được chọn
            if (ds_sanpham.SelectedRows.Count > 0)
            {
                // Lấy dòng đang được chọn
                DataGridViewRow row = ds_sanpham.SelectedRows[0];
                textMoTa.Text = row.Cells["MoTa"].Value.ToString(); 
                // Lấy hình ảnh từ cột "HinhAnh" của DataGridView
                byte[] imageBytes = (byte[])row.Cells["Anh"].Value;

                // Chuyển đổi hình ảnh từ mảng byte sang đối tượng Image
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtSdt.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!");
                return;
            }
            
            // Lấy thông tin khách hàng và số lượng mua từ các textbox.
            string tenKhachHang = txtTen.Text;
            string email = txtemail.Text;
            string soDienThoai = txtSdt.Text;
            string diaChi = txtDiaChi.Text;

            int soLuongMua;
            if (string.IsNullOrEmpty(txtSoluongmua.Text) || !int.TryParse(txtSoluongmua.Text, out soLuongMua) || soLuongMua <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng mua hợp lệ!");
                return;
            }


            // Kết nối đến cơ sở dữ liệu và thực hiện các thao tác lưu dữ liệu.
            string connectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            string query;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string maKhachHang = "";
                query = "SELECT TOP 1 MaKhachHang FROM khach_hang ORDER BY MaKhachHang DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            maKhachHang = reader.GetString(0);
                        }
                    }
                }

                // Tăng giá trị của mã khách hàng lên 1.
                int maKhachHangNumber = 0;
                if (maKhachHang.StartsWith("KH"))
                {
                    int.TryParse(maKhachHang.Substring(2), out maKhachHangNumber);
                }
                maKhachHangNumber++;
                maKhachHang = "KH" + maKhachHangNumber.ToString("000");

               


                // Thêm thông tin khách hàng vào bảng khách hàng.
                query = "INSERT INTO khach_hang (MaKhachHang, TenKhachHang, Email, SoDienThoai, DiaChi) VALUES (@MaKhachHang, @TenKhachHang, @Email, @SoDienThoai, @DiaChi)";
                using (SqlCommand insertCommand = new SqlCommand(query, connection))
                {
                    insertCommand.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    insertCommand.Parameters.AddWithValue("@TenKhachHang", tenKhachHang);
                    insertCommand.Parameters.AddWithValue("@Email", email);
                    insertCommand.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    insertCommand.Parameters.AddWithValue("@DiaChi", diaChi);
                    insertCommand.ExecuteNonQuery();
                }

                string maSanPham = ds_sanpham.SelectedRows[0].Cells["MaSanPham"].Value?.ToString();
                Debug.WriteLine(maSanPham);

                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để đặt hàng!");
                    return;
                }
                // Tạo một bản ghi mới trong bảng hóa đơn.
                string maDonHang = "";
                query = "SELECT TOP 1 MaDonHang FROM don_hang ORDER BY MaDonHang DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            maDonHang = reader.GetString(0);
                        }
                    }
                }

                // Tăng giá trị của mã đơn hàng lên 1.
                int maDonHangNumber = 0;
                if (maDonHang.StartsWith("DH"))
                {
                    int.TryParse(maDonHang.Substring(2), out maDonHangNumber);
                }
                maDonHangNumber++;
                maDonHang = "DH" + maDonHangNumber.ToString("000");

                // Lấy giá sản phẩm từ bảng san_pham.
                double gia = 0;
                query = "SELECT Gia FROM san_pham WHERE MaSanPham=@MaSanPham";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gia = reader.GetDouble(0);
                        }
                    }
                }

                int  soluongmua = int.Parse(txtSoluongmua.Text);
                // Tính tổng tiền bằng giá nhân số lượng mua.
                double tongTien = gia * soluongmua;

                string maThanhToan = "";
                int maThanhToanNumber = 0;

                // Lấy số thứ tự từ bảng "thanh_toan"
                query = "SELECT TOP 1 MaThanhToan FROM thanh_toan ORDER BY MaThanhToan DESC";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string lastMaThanhToan = result.ToString();
                        if (lastMaThanhToan.StartsWith("TT"))
                        {
                            int.TryParse(lastMaThanhToan.Substring(2), out maThanhToanNumber);
                        }
                    }
                }

                // Tăng số thứ tự lên 1 và tạo mã thanh toán mới
                maThanhToanNumber++;
                maThanhToan = "TT" + maThanhToanNumber.ToString("000");

                // Thêm mã thanh toán mới vào bảng "thanh_toan"
                query = "INSERT INTO thanh_toan (MaThanhToan) VALUES (@MaThanhToan)";
                using (SqlCommand insertCommand = new SqlCommand(query, connection))
                {
                    insertCommand.Parameters.AddWithValue("@MaThanhToan", maThanhToan);
                    insertCommand.ExecuteNonQuery();
                }

                // Sử dụng mã thanh toán mới để thêm đơn hàng vào cơ sở dữ liệu
                query = "INSERT INTO don_hang (MaDonHang, MaKhachHang, MaSanPham, MaThanhToan, NgayDat, SoLuong, TongTien) VALUES (@MaDonHang, @MaKhachHang, @MaSanPham, @MaThanhToan, @NgayDat, @SoLuong, @TongTien)";
                using (SqlCommand insertCommand = new SqlCommand(query, connection))
                {
                    insertCommand.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    insertCommand.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    insertCommand.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    insertCommand.Parameters.AddWithValue("@MaThanhToan", maThanhToan);
                    insertCommand.Parameters.AddWithValue("@NgayDat", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@SoLuong", soLuongMua);
                    insertCommand.Parameters.AddWithValue("@TongTien", tongTien);

                    insertCommand.ExecuteNonQuery();
                }


                // Cập nhật số lượng tồn kho của sản phẩm trong bảng sản phẩm.
                query = "UPDATE San_pham SET SoLuongTon=SoLuongTon-@SoLuongMua WHERE MaSanPham=@MaSanPham";
                using (SqlCommand updateCommand = new SqlCommand(query, connection))
                {
                    updateCommand.Parameters.AddWithValue("@SoLuongMua", soLuongMua);
                    updateCommand.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    updateCommand.ExecuteNonQuery();
                }

                connection.Close();

                // Hiển thị thông báo mua hàng thành công.
                MessageBox.Show("Mua hàng thành công!");
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
                // Thực hiện câu lệnh SQL và hiển thị kết quả trên DataGridView

                textMoTa.Text = "";
                // Reset hình ảnh của PictureBox
                pictureBox1.Image = null;
                txtTen.Text = "";
                txtDiaChi.Text = "";
                txtSdt.Text = "";
                txtSoluongmua.Text = "";
                txtemail.Text = "";
                // Cập nhật lại dữ liệu trên DataGridView
                string sQuerySanPham = @"select * from san_pham";
                SqlDataAdapter daSanPham = new SqlDataAdapter(sQuerySanPham, conn);
                DataTable dt = new DataTable();
                daSanPham.Fill(dt);
                ds_sanpham.DataSource = dt;

            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";

            string tenSanPham = txtTenSP.Text.Trim();
            
            string loaiSanPham = cbLoaiSP.Text.Trim();

            // Nếu không nhập giá trị cho các trường thì không tìm kiếm
            if ( string.IsNullOrEmpty(tenSanPham) && string.IsNullOrEmpty(loaiSanPham))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một trường để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xây dựng câu lệnh SQL tìm kiếm
            string query = "SELECT * FROM san_pham WHERE 1=1";
            
            if (!string.IsNullOrEmpty(tenSanPham))
            {
                query += " AND TenSanPham LIKE '%" + tenSanPham + "%'";
            }
            if (!string.IsNullOrEmpty(loaiSanPham))
            {
                query += " AND LoaiSanPham = '" + loaiSanPham + "'";
            }

            // Thực hiện câu lệnh SQL và hiển thị kết quả trên DataGridView
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            ds_sanpham.DataSource = table;
        }

        private void txtSoluongmua_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            // Thực hiện câu lệnh SQL và hiển thị kết quả trên DataGridView

            textMoTa.Text = "";

         // Reset hình ảnh của PictureBox
            pictureBox1.Image = null;
            // Cập nhật lại dữ liệu trên DataGridView
            string sQuerySanPham = @"select * from san_pham";
            SqlDataAdapter daSanPham = new SqlDataAdapter(sQuerySanPham, conn);
            DataTable dt = new DataTable();
            daSanPham.Fill(dt);
            ds_sanpham.DataSource = dt;
        }
    }
}