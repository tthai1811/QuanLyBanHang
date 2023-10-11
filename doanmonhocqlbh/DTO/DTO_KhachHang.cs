using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        private string maKhachHang;
        public string KhachHang

        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
        private string tenKhachHang;
        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set { tenKhachHang = value;}
        }
        private string diaChi;
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string soDienThoai;
        public string SoDienThoai
        {
            get { return soDienThoai;}

          set
            {
                soDienThoai = value;
            }
        }
        public string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
