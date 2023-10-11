using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace doanmonhocqlbh
{
    public partial class VanChuyen : Form
    {
        public VanChuyen()
        {
            InitializeComponent();
            
        }
        DataSet ds = new DataSet("dsdoanmonhocqlbh");
        SqlDataAdapter SanPham;
        private void VanChuyen_Load(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            string sql = "SELECT * FROM van_chuyen";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ds_vanchuyen.DataSource = dataTable;

                // Đặt tên cho các cột
                ds_vanchuyen.Columns["MaVanChuyen"].HeaderText = "Mã vận chuyển";
                ds_vanchuyen.Columns["DiaChiVanChuyen"].HeaderText = "Địa chỉ vận chuyển";
                ds_vanchuyen.Columns["PhiVanChuyen"].HeaderText = "Phí vận chuyển";
                ds_vanchuyen.Columns["NgayVanChuyen"].HeaderText = "Ngày vận chuyển";
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            string maVanChuyen = txtMavc.Text;
            if (string.IsNullOrEmpty(maVanChuyen))
            {
                MessageBox.Show("Vui lòng nhập mã vận chuyển.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem mã vận chuyển đã tồn tại trong cơ sở dữ liệu haykhông
            bool tonTaiVanChuyen = KiemTraTonTaiVanChuyen(maVanChuyen);
            if (tonTaiVanChuyen)
            {
                MessageBox.Show("Mã vận chuyển đã tồn tại trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string diaChiVanChuyen = txtDiaChi.Text;
            float phiVanChuyen = 0.0f;
            if (!string.IsNullOrEmpty(txtphi.Text))
            {
                if (!float.TryParse(txtphi.Text, out phiVanChuyen))
                {
                    // Xử lý lỗi nếu giá trị không hợp lệ
                }
            }
            DateTime ngayVanChuyen = dateTimePicker1.Value;
            string maKhachHang = txtMaKhachHang.Text;

            string connectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            string sqlInsertVanChuyen = "INSERT INTO van_chuyen (MaVanChuyen, DiaChiVanChuyen, PhiVanChuyen, NgayVanChuyen) VALUES (@MaVanChuyen, @DiaChiVanChuyen, @PhiVanChuyen, @NgayVanChuyen)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Kiểm tra xem mã khách hàng có tồn tại trong cơ sở dữ liệu hay không
                bool khachHangTonTai = KiemTraTonTaiKhachHang(maKhachHang);

                if (!khachHangTonTai)
                {
                    MessageBox.Show("Không tìm thấy mã khách hàng trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm mới vận chuyển vào bảng "van_chuyen"
                SqlCommand commandInsertVanChuyen = new SqlCommand(sqlInsertVanChuyen, connection);
                commandInsertVanChuyen.Parameters.AddWithValue("@MaVanChuyen", maVanChuyen);
                commandInsertVanChuyen.Parameters.AddWithValue("@DiaChiVanChuyen", diaChiVanChuyen);
                commandInsertVanChuyen.Parameters.AddWithValue("@PhiVanChuyen", phiVanChuyen);
                commandInsertVanChuyen.Parameters.AddWithValue("@NgayVanChuyen", ngayVanChuyen);
                int rowsAffected = commandInsertVanChuyen.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                    // Hiển thị thông báo khi thêm thành công
                    MessageBox.Show("Thêm vận chuyển thành công.");
                    // Tìm đơn hàng của khách hàng để cập nhật mã vận chuyển mới
                    string sqlSelectDonHang = "SELECT MaDonHang FROM don_hang WHERE MaKhachHang = @MaKhachHang";
                    SqlCommand commandSelectDonHang = new SqlCommand(sqlSelectDonHang, connection);
                    commandSelectDonHang.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    SqlDataReader reader = commandSelectDonHang.ExecuteReader();

                    while (reader.Read())
                    {
                        string maDonHang = reader["MaDonHang"].ToString();

                        reader.Close(); // Đóng đối tượng SqlDataReader trước khi thực hiện truy vấn SQL mới

                        // Cập nhật mã vận chuyển mới cho đơn hàng tương ứng
                        string sqlUpdateDonHang = "UPDATE don_hang SET MaVanChuyen = @MaVanChuyen WHERE MaDonHang = @MaDonHang";
                        SqlCommand commandUpdateDonHang = new SqlCommand(sqlUpdateDonHang, connection);
                        commandUpdateDonHang.Parameters.AddWithValue("@MaVanChuyen", maVanChuyen);
                        commandUpdateDonHang.Parameters.AddWithValue("@MaDonHang", maDonHang);
                        commandUpdateDonHang.ExecuteNonQuery();

                        // Mở lại đối tượng SqlDataReader để đọc dữ liệu đơn hàng tiếp theo
                        commandSelectDonHang.Parameters.Clear();
                        commandSelectDonHang.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                        reader = commandSelectDonHang.ExecuteReader();
                    }

                    reader.Close();
                }
                string sqlSelectVanChuyen = "SELECT * FROM van_chuyen";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectVanChuyen, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                ds_vanchuyen.DataSource = dt;
            }
        }
        private bool KiemTraTonTaiVanChuyen(string maVanChuyen)
        {
            string connectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            string sqlSelectVanChuyen = "SELECT COUNT(*) FROM van_chuyen WHERE MaVanChuyen = @MaVanChuyen";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlSelectVanChuyen, connection))
            {
                command.Parameters.AddWithValue("@MaVanChuyen", maVanChuyen);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private bool KiemTraTonTaiKhachHang(string maKhachHang)
        {
            string connectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            string sql = "SELECT COUNT(*) FROM khach_hang WHERE MaKhachHang = @MaKhachHang";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                int count = (int)command.ExecuteScalar();

                return (count > 0);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy mã vận chuyển từ DataGridView
            string maVanChuyen = ds_vanchuyen.CurrentRow.Cells["MaVanChuyen"].Value.ToString();

            // Xác nhận việc xóa dữ liệu
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa vận chuyển " + maVanChuyen + "?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string connectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Xóa vận chuyển khỏi bảng "van_chuyen"
                    string sqlDeleteVanChuyen = "DELETE FROM van_chuyen WHERE MaVanChuyen = @MaVanChuyen";
                    SqlCommand commandDeleteVanChuyen = new SqlCommand(sqlDeleteVanChuyen, connection);
                    commandDeleteVanChuyen.Parameters.AddWithValue("@MaVanChuyen", maVanChuyen);
                    int rowsAffected = commandDeleteVanChuyen.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Xóa mã vận chuyển khỏi các đơn hàng tương ứng
                        string sqlUpdateDonHang = "UPDATE don_hang SET MaVanChuyen = NULL WHERE MaVanChuyen = @MaVanChuyen";
                        SqlCommand commandUpdateDonHang = new SqlCommand(sqlUpdateDonHang, connection);
                        commandUpdateDonHang.Parameters.AddWithValue("@MaVanChuyen", maVanChuyen);
                        commandUpdateDonHang.ExecuteNonQuery();

                        // Cập nhật lại DataGridView hiển thị thông tin vận chuyển
                        string sqlSelectVanChuyen = "SELECT * FROM van_chuyen";
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectVanChuyen, connection);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        ds_vanchuyen.DataSource = dt;

                        // Hiển thị thông báo khi xóa thành công
                        MessageBox.Show("Xóa vận chuyển thành công.");
                    }
                }
            }
        }

        private void ds_vanchuyen_SelectionChanged(object sender, EventArgs e)
        {
            if (ds_vanchuyen.SelectedRows.Count > 0)
            {
                // Lấy thông tin vận chuyển từ DataGridView
                string maVanChuyen = ds_vanchuyen.CurrentRow.Cells["MaVanChuyen"].Value.ToString();
                string diaChiVanChuyen = ds_vanchuyen.CurrentRow.Cells["DiaChiVanChuyen"].Value.ToString();
                float phiVanChuyen = float.Parse(ds_vanchuyen.CurrentRow.Cells["PhiVanChuyen"].Value.ToString());
                DateTime ngayVanChuyen = DateTime.Parse(ds_vanchuyen.CurrentRow.Cells["NgayVanChuyen"].Value.ToString());

                // Hiển thị thông tin vận chuyển lên các textbox tương ứng
                txtMavc.Text = maVanChuyen;
                txtDiaChi.Text = diaChiVanChuyen;
                txtphi.Text = phiVanChuyen.ToString();
                dateTimePicker1.Value = ngayVanChuyen;
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            // Lấy thông tin vận chuyển từ các textbox và datetimepicker
            string maVanChuyen = txtMavc.Text;
            string diaChiVanChuyen = txtDiaChi.Text;

            /* float phiVanChuyen;
             if (string.IsNullOrEmpty(txtphi.Text) || !float.TryParse(txtphi.Text, out phiVanChuyen) || phiVanChuyen <= 0)
             {
                 MessageBox.Show("Vui lòng nhập phí vận chuyển hợp lệ!");
                 return;
             }*/
            float phiVanChuyen = 0.0f;
            if (!string.IsNullOrEmpty(txtphi.Text))
            {
                if (!float.TryParse(txtphi.Text, out phiVanChuyen))
                {
                    // Xử lý lỗi nếu giá trị không hợp lệ
                }
            }

            DateTime ngayVanChuyen = dateTimePicker1.Value;
            string maKhachHang = txtMaKhachHang.Text;

            // Cập nhật thông tin vận chuyển vào cơ sở dữ liệu
            string connectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlUpdateVanChuyen = "UPDATE van_chuyen SET DiaChiVanChuyen = @DiaChiVanChuyen, PhiVanChuyen = @PhiVanChuyen, NgayVanChuyen = @NgayVanChuyen WHERE MaVanChuyen = @MaVanChuyen";
                SqlCommand commandUpdateVanChuyen = new SqlCommand(sqlUpdateVanChuyen, connection);
                commandUpdateVanChuyen.Parameters.AddWithValue("@DiaChiVanChuyen", diaChiVanChuyen);
                commandUpdateVanChuyen.Parameters.AddWithValue("@PhiVanChuyen", phiVanChuyen);
                commandUpdateVanChuyen.Parameters.AddWithValue("@NgayVanChuyen", ngayVanChuyen);
                commandUpdateVanChuyen.Parameters.AddWithValue("@MaVanChuyen", maVanChuyen);
                int rowsAffectedVanChuyen = commandUpdateVanChuyen.ExecuteNonQuery();

                if (rowsAffectedVanChuyen > 0)
                {
                    // Tìm đơn hàng của khách hàng để cập nhật mã vận chuyển mới
                    string sqlSelectDonHang = "SELECT MaDonHang FROM don_hang WHERE MaKhachHang = @MaKhachHang";
                    SqlCommand commandSelectDonHang = new SqlCommand(sqlSelectDonHang, connection);
                    commandSelectDonHang.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    SqlDataReader reader = commandSelectDonHang.ExecuteReader();

                    while (reader.Read())
                    {
                        string maDonHang = reader["MaDonHang"].ToString();

                        reader.Close(); // Đóng đối tượng SqlDataReader trước khi thực hiện truy vấn SQL mới

                        // Cập nhật mã vận chuyển mới cho đơn hàng tương ứng
                        string sqlUpdateDonHang = "UPDATE don_hang SET MaVanChuyen = @MaVanChuyen WHERE MaDonHang = @MaDonHang";
                        SqlCommand commandUpdateDonHang = new SqlCommand(sqlUpdateDonHang, connection);
                        commandUpdateDonHang.Parameters.AddWithValue("@MaVanChuyen", maVanChuyen);
                        commandUpdateDonHang.Parameters.AddWithValue("@MaDonHang", maDonHang);
                        commandUpdateDonHang.ExecuteNonQuery();

                        // Mở lại đối tượng SqlDataReader để đọc dữ liệu đơn hàng tiếp theo
                        commandSelectDonHang.Parameters.Clear();
                        commandSelectDonHang.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                        reader = commandSelectDonHang.ExecuteReader();
                    }

                    reader.Close();

                    // Cập nhật lại DataGridView hiển thị thông tin vận chuyển
                    string sqlSelectVanChuyen = "SELECT * FROM van_chuyen";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectVanChuyen, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ds_vanchuyen.DataSource = dt;

                    // Hiển thị thông báo khi sửa thành công
                    MessageBox.Show("Cập nhật thông tin vận chuyển thành công.");
                }
            
        }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maVanChuyen = txtMavc.Text;
            string diaChiVanChuyen = txtDiaChi.Text;
            string ngayVanChuyen = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // Kiểm tra nếu cả hai biến đều rỗng, thì tìm kiếm theo ngày vận chuyển
            if (string.IsNullOrEmpty(maVanChuyen) && string.IsNullOrEmpty(diaChiVanChuyen))
            {
                // Thực hiện kết nối đến cơ sở dữ liệu và thực hiện câu lệnh SQL "SELECT" để tìm kiếm thông tin vận chuyển dựa trên ngày vận chuyển.
                string connectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
                string sqlSelectVanChuyen = "SELECT * FROM van_chuyen WHERE NgayVanChuyen = @NgayVanChuyen";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand commandSelectVanChuyen = new SqlCommand(sqlSelectVanChuyen, connection);
                    commandSelectVanChuyen.Parameters.AddWithValue("@NgayVanChuyen", ngayVanChuyen);

                    SqlDataAdapter adapter = new SqlDataAdapter(commandSelectVanChuyen);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Kiểm tra số hàng trả về của DataTable
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin vận chuyển");
                    }
                    else
                    {
                        // Cập nhật lại DataGridView hiển thị thông tin vận chuyển với kết quả tìm kiếm
                        ds_vanchuyen.DataSource = dt;
                    }
                }
            }
            else
            {
                // Nếu mã hoặc địa chỉ vận chuyển không rỗng, thực hiện tìm kiếm theo mã và/hoặc địa chỉ vận chuyển
                string connectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
                string sqlSelectVanChuyen = "SELECT * FROM van_chuyen WHERE 1=1";

                if (!string.IsNullOrEmpty(maVanChuyen))
                {
                    sqlSelectVanChuyen += " AND MaVanChuyen LIKE '%' + @MaVanChuyen + '%'";
                }
                if (!string.IsNullOrEmpty(diaChiVanChuyen))
                {
                    sqlSelectVanChuyen += " AND DiaChiVanChuyen LIKE '%' + @DiaChiVanChuyen + '%'";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand commandSelectVanChuyen = new SqlCommand(sqlSelectVanChuyen, connection);

                    if (!string.IsNullOrEmpty(maVanChuyen))
                    {
                        commandSelectVanChuyen.Parameters.AddWithValue("@MaVanChuyen", maVanChuyen);
                    }
                    if (!string.IsNullOrEmpty(diaChiVanChuyen))
                    {
                        commandSelectVanChuyen.Parameters.AddWithValue("@DiaChiVanChuyen", diaChiVanChuyen);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(commandSelectVanChuyen);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Kiểm tra số hàng trả về của DataTable
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin vận chuyển");
                    }
                    else
                    {
                        // Cập nhật lại DataGridView hiển thị thông tin vận chuyển với kết quả tìm kiếm
                        ds_vanchuyen.DataSource = dt;
                    }
                }
            }

        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";
            txtMavc.Text = "";
            txtDiaChi.Text = "";
            txtphi.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtMaKhachHang.Text = "";
            // Cập nhật lại DataGridView hiển thị thông tin vận chuyển
            string sqlSelectVanChuyen = "SELECT * FROM van_chuyen";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectVanChuyen, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            ds_vanchuyen.DataSource = dt;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {


                this.Close();
            }
        }

        private void txtMavc_TextChanged(object sender, EventArgs e)
        {
            txtMavc.Text = txtMavc.Text.ToUpper();
            txtMavc.SelectionStart = txtMavc.Text.Length;
        }

        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {
            txtMaKhachHang.Text = txtMaKhachHang.Text.ToUpper();
            txtMaKhachHang.SelectionStart = txtMaKhachHang.Text.Length;
        }

        private void txtphi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtphi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Chỉ được nhập số vào trường phí vận chuyển.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } 
}
    
         
    

