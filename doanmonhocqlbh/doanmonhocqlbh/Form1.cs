using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace doanmonhocqlbh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsdoanmonhocqlbh");
        SqlDataAdapter SanPham;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";

            // Tạo câu lệnh SQL để thêm dữ liệu vào bảng "san_pham"
            // Kiểm tra ràng buộc không trùng mã sản phẩm
            string sQueryCheck = "select count(*) from san_pham where MaSanPham = @maSP";
            SqlCommand cmdCheck = new SqlCommand(sQueryCheck, conn);
            cmdCheck.Parameters.AddWithValue("@maSP", txtMaSP.Text);
            conn.Open();
            int count = (int)cmdCheck.ExecuteScalar();
            conn.Close();
            if (count > 0)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!");
                return;
            }

            // Kiểm tra ràng buộc không bỏ trống các dữ liệu
            if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtTenSP.Text) || string.IsNullOrEmpty(cbLoaiSP.Text) || string.IsNullOrEmpty(txtMoTa.Text) || string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrEmpty(txtSoLuong.Text) || pictureBox1.Image == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!");
                return;
            }


            // Thêm sản phẩm mới vào bảng "san_pham"
            string sQueryInsert = "insert into san_pham (MaSanPham, TenSanPham, LoaiSanPham, MoTa, Gia, SoLuongTon, Anh) values (@maSP, @tenSP, @loaiSP, @moTa, @donGia, @soLuong, @hinhAnh)";
            SqlCommand cmdInsert = new SqlCommand(sQueryInsert, conn);
            cmdInsert.Parameters.AddWithValue("@maSP", txtMaSP.Text);
            cmdInsert.Parameters.AddWithValue("@tenSP", txtTenSP.Text);
            cmdInsert.Parameters.AddWithValue("@loaiSP", cbLoaiSP.Text);
            cmdInsert.Parameters.AddWithValue("@moTa", txtMoTa.Text);
            cmdInsert.Parameters.AddWithValue("@donGia", txtDonGia.Text);
            cmdInsert.Parameters.AddWithValue("@soLuong", txtSoLuong.Text);
            cmdInsert.Parameters.AddWithValue("@hinhAnh", ConvertImageToBytes(pictureBox1.Image));
            conn.Open();
            int result = cmdInsert.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                MessageBox.Show("Thêm sản phẩm mới thành công!");
            }
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            cbLoaiSP.SelectedIndex = -1;
            txtMoTa.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";

            // Reset hình ảnh của PictureBox
            pictureBox1.Image = null;
            // Cập nhật lại dữ liệu trên DataGridView
            string sQuerySanPham = @"select * from san_pham";
            SqlDataAdapter daSanPham = new SqlDataAdapter(sQuerySanPham, conn);
            DataTable dt = new DataTable();
            daSanPham.Fill(dt);
            ds_sanpham.DataSource = dt;
        }
        private byte[] ConvertImageToBytes(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
        private Image ConvertBytesToImage(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            Image image = Image.FromStream(ms);
            return image;
        }
        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null) return null;
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        private void ds_sanpham_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có ít nhất một dòng được chọn
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng SqlConnection mới với chuỗi kết nối
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True");
            // Lấy DataRow tương ứng với sản phẩm được chọn từ DataGridView
            if (ds_sanpham.SelectedRows.Count > 0)
            {
                DataRowView rowView = ds_sanpham.SelectedRows[0].DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    DataRow row = rowView.Row;

                    // Kiểm tra mã sản phẩm mới có trùng với mã sản phẩm của các sản phẩm khác trong cơ sở dữ liệu hay không
                    string maSanPham = row["MaSanPham"].ToString();
                    string newMaSanPham = txtMaSP.Text;
                    if (newMaSanPham != maSanPham)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM san_pham WHERE MaSanPham=@maSanPham AND MaSanPham!=@oldMaSanPham", conn);
                        cmd.Parameters.AddWithValue("@maSanPham", newMaSanPham);
                        cmd.Parameters.AddWithValue("@oldMaSanPham", maSanPham);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        conn.Close();

                        if (count > 0)
                        {
                            MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng nhập mã sản phẩm khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Kiểm tra các giá trị nhập vào
                    if (string.IsNullOrEmpty(txtTenSP.Text) || string.IsNullOrEmpty(cbLoaiSP.Text) || string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrEmpty(txtSoLuong.Text) || string.IsNullOrEmpty(txtMoTa.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    float gia;
                    if (!float.TryParse(txtDonGia.Text, out gia))
                    {
                        MessageBox.Show("Giá sản phẩm không hợp lệ. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("CẬP NHẬT THÀNH CÔNG !");
                    // Cập nhật các giá trị mới vào DataRow
                    // Gán giá trị cho các cột tương ứng trong DataRow
                    row["MaSanPham"] = newMaSanPham;
                    row["TenSanPham"] = txtTenSP.Text;
                    row["LoaiSanPham"] = cbLoaiSP.Text;
                    row["MoTa"] = txtMoTa.Text;
                    row["Gia"] = Convert.ToDecimal(txtDonGia.Text);
                    row["SoLuongTon"] = Convert.ToInt32(txtSoLuong.Text);
                    // row["Anh"] = ConvertImageToByteArray(pictureBox1.Image);

                    // Cập nhật lại cơ sở dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM san_pham", conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds.Tables["san_pham"]);
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            // Kiểm tra xem người dùng đã chọn sản phẩm để xóa chưa
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa!");
                return;
            }

            // Tạo câu lệnh SQL để xóa dữ liệu trong bảng "san_pham"
            string sQueryDelete = "delete from san_pham where MaSanPham = @maSP";
            SqlCommand cmdDelete = new SqlCommand(sQueryDelete, conn);

            // Thêm tham số cho câu lệnh SQL
            cmdDelete.Parameters.AddWithValue("@maSP", txtMaSP.Text);

            // Mở kết nối đến cơ sở dữ liệu
            conn.Open();

            // Thực thi truy vấn DELETE và lấy số bản ghi bị xóa
            int result = cmdDelete.ExecuteNonQuery();

            // Đóng kết nối đến cơ sở dữ liệu
            conn.Close();

            // Kiểm tra số bản ghi bị xóa, nếu lớn hơn 0 thì thông báo xóa thành công
            if (result > 0)
            {
                MessageBox.Show("Xóa sản phẩm thành công!");
                txtMaSP.Text = "";
                txtTenSP.Text = "";
                cbLoaiSP.SelectedIndex = -1;
                txtMoTa.Text = "";
                txtDonGia.Text = "";
                txtSoLuong.Text = "";

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

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            // Reset giá trị của các TextBox và ComboBox
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            cbLoaiSP.SelectedIndex = -1;
            txtMoTa.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";

            // Reset hình ảnh của PictureBox
            pictureBox1.Image = null;
            // Cập nhật lại dữ liệu trên DataGridView
            string sQuerySanPham = @"select * from san_pham";
            SqlDataAdapter daSanPham = new SqlDataAdapter(sQuerySanPham, conn);
            DataTable dt = new DataTable();
            daSanPham.Fill(dt);
            ds_sanpham.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        public static string RemoveUnicode(string str)
        {
            string[] patterns = new string[]
            {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "éèẹẻẽêếềệểễ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "úùụủũưứừựửữ",
        "íìịỉĩ",
        "đ",
        "ýỳỵỷỹ"
            };

            for (int i = 1; i < patterns.Length; i++)
            {
                for (int j = 0; j < patterns[i].Length; j++)
                {
                    str = str.Replace(patterns[i][j], patterns[0][i - 1]);
                }
            }

            return str;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";

            string maSanPham = txtMaSP.Text.Trim();
            string tenSanPham = txtTenSP.Text.Trim();
            string loaiSanPham = cbLoaiSP.Text.Trim();

            // Nếu không nhập giá trị cho các trường thì không tìm kiếm
            if (string.IsNullOrEmpty(maSanPham) && string.IsNullOrEmpty(tenSanPham) && string.IsNullOrEmpty(loaiSanPham))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một trường để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xây dựng câu lệnh SQL tìm kiếm
            string query = "SELECT * FROM san_pham WHERE 1=1";
            if (!string.IsNullOrEmpty(maSanPham))
            {
                query += " AND MaSanPham LIKE '" + maSanPham + "%'";
            }
            if (!string.IsNullOrEmpty(tenSanPham))
            {
                string tenSanPhamKhongDau = RemoveUnicode(tenSanPham);
                query += " AND (UPPER(REPLACE(REPLACE(REPLACE(TenSanPham, ' ', ''), '.', ''), ',', '')) LIKE '%" + tenSanPhamKhongDau.ToUpper() + "%'" +
                         " OR UPPER(LEFT(REPLACE(REPLACE(REPLACE(TenSanPham, ' ', ''), '.', ''), ',', ''), 1)) LIKE '%" + tenSanPham.ToUpper()[0] + "%')";
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

        private void btnthoat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {


                this.Close();
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang khachhang = new KhachHang();
            khachhang.ShowDialog();
            
        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DonHang donHang = new DonHang();
            donHang.ShowDialog();
            
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doanhthu doanhthu = new doanhthu();
            doanhthu.ShowDialog();
          
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            txtMaSP.Text = txtMaSP.Text.ToUpper();
            txtMaSP.SelectionStart = txtMaSP.Text.Length;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ds_sanpham_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem dòng được chọn có hợp lệ không
            if (e.RowIndex > 0 )
            {
                // Lấy dòng được chọn
                DataGridViewRow row = ds_sanpham.Rows[e.RowIndex];

                // Đổ dữ liệu từ dòng đang được chọn lên các TextBox tương ứng
                txtMaSP.Text = row.Cells["MaSanPham"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSanPham"].Value.ToString();
                cbLoaiSP.Text = row.Cells["LoaiSanPham"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                txtDonGia.Text = row.Cells["Gia"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuongTon"].Value.ToString();

                // Lấy hình ảnh từ cột "Anh" của DataGridView
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
    }
}

