using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class CustomerDTO
    {
        [DisplayName("Mã KH")]
        public int CustomerID { get; set; }
        [DisplayName("Họ và tên")]
        public string Name { get; set; }
        [DisplayName("Giới tính")]
        public string Gender { get; set; }
        [DisplayName("Điện thoại")]
        public string PhoneNumber { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
