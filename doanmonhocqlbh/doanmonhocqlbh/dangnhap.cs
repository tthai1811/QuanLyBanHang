using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace doanmonhocqlbh
{
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }
        public string user1 = "hai";
        public string pass1 = "123";
        public string user = "hai123";
        public string pass = "123";
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (user1.Equals(txtdangnhap.Text) && pass1.Equals(txtpass.Text))
            {
               
                doanhthu f1 = new doanhthu();
                f1.ShowDialog();

                this.txtdangnhap.ResetText();
                this.txtpass.ResetText();

            }
            if (user.Equals(txtdangnhap.Text) && pass.Equals(txtpass.Text))
            {

               txtMua txtMua = new txtMua();
                txtMua.ShowDialog();

                this.txtdangnhap.ResetText();
                this.txtpass.ResetText();

            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }

        }

        private void txtdangnhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void dangnhap_Load(object sender, EventArgs e)
        {
        }

        private void btnhien_Click(object sender, EventArgs e)
        {
            if (txtpass.PasswordChar == '*')
            {
                txtpass.PasswordChar = '\0'; // Hiển thị các ký tự nhập vào
                btnhien.Text = "Ẩn mật khẩu";
            }
            else
            {
                txtpass.PasswordChar = '*'; // Ẩn các ký tự nhập vào
                btnhien.Text = "Hiển thị mật khẩu";
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
