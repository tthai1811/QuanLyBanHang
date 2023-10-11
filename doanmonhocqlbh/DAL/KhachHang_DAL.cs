using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class KhachHang_DAL
    {
        static SqlConnection con;
        public static List<DTO_KhachHang> LayKhachHang()
        {
            string sTruyVan = "select *from khach_hang";
            con = Connect.MoKetNoi();
            DataTable dt = Connect.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DTO_KhachHang> listKhachHang = new List<DTO_KhachHang>();
            {
                for(int i = 0;i< dt.Rows.Count;i++)
                {
                    DTO_KhachHang kh = new DTO_KhachHang();
                    kh.KhachHang = dt.Rows[i]["MaKhachHang"].ToString();
                    kh.TenKhachHang=dt.Rows[i]["TenKhachHang"].ToString();
                    kh.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                    kh.SoDienThoai = dt.Rows[i]["SoDienThoai"].ToString();
                    kh.email = dt.Rows[i]["Email"].ToString();
                    listKhachHang.Add(kh);
                }
                return listKhachHang;
            }

        }

    }
}
