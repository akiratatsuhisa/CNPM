using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class EmployeeDTO
    {
        [DisplayName("Mã NV")]
        public int EmployeeID { get; set; }
        [DisplayName("Họ và tên")]
        public string Name { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Giới tính")]
        public string Gender { get; set; }
        [DisplayName("CMND")]
        public string ID { get; set; }
        [DisplayName("Điện thoại")]
        public string PhoneNumber { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Chức vụ")]
        public string JobTitle { get; set; }
    }
}
