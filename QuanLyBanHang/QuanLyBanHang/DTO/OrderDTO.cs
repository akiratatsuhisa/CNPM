using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class OrderDTO
    {
        [DisplayName("Mã HĐ")]
        public int OrderID { get; set; }
        [DisplayName("Mã NV")]
        public int EmployeeID { get; set; }
        [DisplayName("Tên NV")]
        public string EmployeeName { get; set; }
        [DisplayName("Mã SP")]
        public int CustomerID { get; set; }
        [DisplayName("Tên SP")]
        public string CustomerName { get; set; }
        [DisplayName("Ngày đặt hàng")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Phí")]
        public decimal? Freight { get; set; }
    }
}
