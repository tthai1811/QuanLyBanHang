using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace doanmonhocqlbh
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsdoanmonhocqlbh");
        SqlDataAdapter SanPham;
        private void KhachHang_Load(object sender, EventArgs e)
        {
            List<DTO_KhachHang> lstKhachHang = KhachHang_BUS.LayKhachHang();
            ds_khachhang.DataSource = lstKhachHang;
            /*SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";


            string sQuerySanPham = @"select * from khach_hang";
            SqlDataAdapter daSanPham = new SqlDataAdapter(sQuerySanPham, conn);
            daSanPham.Fill(ds, "khach_hang");*/

        }

        private void ds_khachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonHang donHang = new DonHang();
            donHang.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DonHang donhang = new DonHang();
            donhang.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doanhthu doanhthu = new doanhthu();
            doanhthu.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)

        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            string tenKhachHang = tenkhachhang.Text;
            string maKhachHang = txtMaKhachHang.Text;

            // Kiểm tra xem người dùng đã nhập thông tin tìm kiếm hay chưa
            if (string.IsNullOrEmpty(tenKhachHang) && string.IsNullOrEmpty(maKhachHang))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xây dựng câu lệnh SQL tìm kiếm khách hàng theo tên hoặc mã khách hàng
            string query = "SELECT * FROM khach_hang WHERE 1=1";
            if (!string.IsNullOrEmpty(tenKhachHang))
            {
                query += " AND TenKhachHang LIKE @tenKhachHang";
            }
            if (!string.IsNullOrEmpty(maKhachHang))
            {
                query += " AND MaKhachHang LIKE @maKhachHang";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            if (!string.IsNullOrEmpty(tenKhachHang))
            {
                cmd.Parameters.AddWithValue("@tenKhachHang", tenKhachHang + "%");
            }
            if (!string.IsNullOrEmpty(maKhachHang))
            {
                cmd.Parameters.AddWithValue("@maKhachHang", maKhachHang + "%");
            }

            // Thực hiện câu lệnh SQL và hiển thị kết quả trên DataGridView
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            ds_khachhang.DataSource = table;

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào bắt đầu bằng " + tenKhachHang + " hoặc " + maKhachHang, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ds_khachhang_SelectionChanged(object sender, EventArgs e)
        {
            List<DTO_KhachHang> lstKhachHang = KhachHang_BUS.LayKhachHang();

            if (ds_khachhang.CurrentRow != null) // Kiểm tra xemcó dòng nào được chọn hay không
            {
                int rowIndex = ds_khachhang.CurrentRow.Index; // Lấy chỉ số của dòng hiện tại đang được chọn

                if (rowIndex >= 0 && rowIndex < lstKhachHang.Count) // Kiểm tra xem chỉ số rowIndex có hợp lệ hay không
                {
                    DTO_KhachHang khachHang = lstKhachHang[rowIndex]; // Lấy đối tượng tương ứng từ danh sách đối tượng

                    txtMaKhachHang.Text = khachHang.KhachHang; // Gán giá trị của thuộc tính "KhachHang" cho TextBox "txtMaKhachHang"
                    tenkhachhang.Text = khachHang.TenKhachHang; // Gán giá trị của thuộc tính "TenKhachHang" cho TextBox "txtTenKhachHang"
                    txtsdt.Text = khachHang.SoDienThoai; // Gán giá trị của thuộc tính "SoDienThoai" cho TextBox "txtSoDienThoai"
                    txtemail.Text = khachHang.Email; // Gán giá trị của thuộc tính "Email" cho TextBox "txtEmail"
                    txtdiachi.Text = khachHang.DiaChi; // Gángiá trị của thuộc tính "DiaChi" cho TextBox "txtDiaChi"
                }
                else
                {
                    // Xử lý lỗi nếu chỉ số rowIndex không hợp lệ
                    MessageBox.Show(" Ok tiếp theo !!!!!!! ");
                }
            }

        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cập nhật thông tin khách hàng vào cơ sở dữ liệu
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            conn.Open();
            string query = "UPDATE khach_hang SET TenKhachHang = @tenKhachHang, SoDienThoai = @soDienThoai, Email = @email, DiaChi = @diaChi WHERE MaKhachHang = @maKhachHang";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@tenKhachHang", tenkhachhang.Text);
            cmd.Parameters.AddWithValue("@soDienThoai", txtsdt.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@diaChi", txtdiachi.Text);
            cmd.Parameters.AddWithValue("@maKhachHang", txtMaKhachHang.Text);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Đã cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lại dữ liệu từ cơ sở dữ liệu và gán vào DataSource của DataGridView
                string selectQuery = "SELECT * FROM khach_hang";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                ds_khachhang.DataSource = table;
            }
            conn.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa khách hàng
            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Xóa thông tin khách hàng khỏi cơ sở dữ liệu
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
                conn.Open();
                string query = "DELETE FROM khach_hang WHERE MaKhachHang = @maKhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maKhachHang", txtMaKhachHang.Text);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Đã xóa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load lại dữ liệu từ cơ sở dữ liệu và gán vào DataSource của DataGridView
                    string selectQuery = "SELECT * FROM khach_hang";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    ds_khachhang.DataSource = table;
                }
                conn.Close();
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            List<DTO_KhachHang> lstKhachHang = KhachHang_BUS.LayKhachHang();//sử dụng 4
            ds_khachhang.DataSource = lstKhachHang;
            // SqlConnection conn = new SqlConnection();
            // conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            // string sQuerySanPham = @"select * from khach_hang";
            txtMaKhachHang.Text = "";
            tenkhachhang.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            txtdiachi.Text = "";

            //  SqlDataAdapter daSanPham = new SqlDataAdapter(sQuerySanPham, conn);
            //  DataTable dt = new DataTable();
            //  daSanPham.Fill(dt);
            //  ds_khachhang.DataSource = dt;
        }

        private void btnvip_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            string sQuerySanPham = @"SELECT kh.TenKhachHang, kh.SoDienThoai, kh.Email, kh.DiaChi, COUNT(hd.MaDonHang) AS SoLuotMua 
FROM khach_hang AS kh 
LEFT JOIN don_hang AS hd ON kh.MaKhachHang = hd.MaKhachHang 
GROUP BY kh.TenKhachHang, kh.SoDienThoai, kh.Email, kh.DiaChi 
ORDER BY SoLuotMua DESC";
            SqlDataAdapter daSanPham = new SqlDataAdapter(sQuerySanPham, conn);
            DataTable dt = new DataTable();
            daSanPham.Fill(dt);
            ds_khachhang.DataSource = dt;

            ds_khachhang.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
            ds_khachhang.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            ds_khachhang.Columns["Email"].HeaderText = "Email";
            ds_khachhang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            ds_khachhang.Columns["SoLuotMua"].HeaderText = "Số Lượt Mua";
        }

        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {
            txtMaKhachHang.Text = txtMaKhachHang.Text.ToUpper();
            txtMaKhachHang.SelectionStart = txtMaKhachHang.Text.Length;
        }

        private void ds_khachhang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
    
}
