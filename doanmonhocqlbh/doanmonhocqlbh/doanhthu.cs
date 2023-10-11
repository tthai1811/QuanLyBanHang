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
using System.Windows.Forms.DataVisualization.Charting;

namespace doanmonhocqlbh
{
    public partial class doanhthu : Form
    {
        public doanhthu()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void doanhthu_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VPSR0NB\SQLEXPRESS;Initial Catalog=quanlydoancuoicung1;Integrated Security=True";

           
                // Mở kết nối đến cơ sở dữ liệu
                conn.Open();

                // Lấy dữ liệu từ bảng sản phẩm và đơn hàng
                string sQuery = @"SELECT sp.TenSanPham, SUM(dh.TongTien) AS DoanhThu 
                      FROM san_pham sp 
                      JOIN don_hang dh ON sp.MaSanPham = dh.MaSanPham 
                      GROUP BY sp.TenSanPham 
                      ORDER BY SUM(dh.TongTien) DESC";
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Tạo đối tượng Series và thêm dữ liệu vào đó
                Series series = new Series("Doanh thu");
                while (reader.Read())
                {
                    string productName = reader["TenSanPham"].ToString();
                    double revenue = Convert.ToDouble(reader["DoanhThu"]);

                    // Thêm dữ liệu vào đối tượng Series
                    series.Points.AddXY(productName, revenue);
                }
            // Thêm đối tượng Series vào đối tượng Chart
            chart1.Series.Add(series);

            // Thiết lập các thuộc tính của biểu đồ
            chart1.Titles.Add("Sản phẩm được mua nhiều nhất");
            chart1.ChartAreas[0].AxisX.Title = "Sản phẩm";
            chart1.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:#,##0}";

            // Thiết lập loại biểu đồ
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            // Thiết lập kích thước và vị trí của đối tượng Chart trên form
            chart1.Size = new Size(600, 400);
            chart1.Location = new Point(50, 50);

            // Thêm đối tượng Chart vào form
            Controls.Add(chart1);
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form= new Form1();
            form.ShowDialog();
        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DonHang donhang  = new DonHang();
            donhang.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang khachhang = new KhachHang();
            khachhang.ShowDialog();
        }

        private void vậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
                VanChuyen vanchuyen = new VanChuyen();
            vanchuyen.ShowDialog();
        }
    }
    
}
