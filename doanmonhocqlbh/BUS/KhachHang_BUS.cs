using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BUS
{
    public class KhachHang_BUS
    {

        public static List<DTO_KhachHang> LayKhachHang()
        {
            return KhachHang_DAL.LayKhachHang();
        }
    }
    
}
