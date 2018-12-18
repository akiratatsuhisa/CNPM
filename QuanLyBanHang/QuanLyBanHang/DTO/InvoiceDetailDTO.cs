using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class InvoiceDetailDTO
    {
        [DisplayName("Mã HĐ")]
        public int InvoiceID { get; set; }
        [DisplayName("Mã SP")]
        public int ProductID { get; set; }
        [DisplayName("Tên SP")]
        public string ProductName { get; set; }
        [DisplayName("Giá")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
    }
}
