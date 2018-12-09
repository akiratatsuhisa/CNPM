using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? Freight { get; set; }
    }
}
