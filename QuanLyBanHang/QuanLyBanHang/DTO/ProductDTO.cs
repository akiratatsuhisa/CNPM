using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class ProductDTO
    {
        [DisplayName("Mã SP")]
        public int ProductID { get; set; }
        [DisplayName("Tên")]
        public string ProductName { get; set; }
        [DisplayName("Ngày nhập")]
        public DateTime AddedDate { get; set; }
        [DisplayName("Đơn vị đo")]
        public string QuantityPerUnit { get; set; }
        [DisplayName("Giá")]
        public decimal UnitPrice { get; set; }
        [DisplayName("SL trong kho")]
        public int UnitsInStock { get; set; }
        [DisplayName("SL trong đơn")]
        public int UnitsOnInvoice { get; set; }
        [DisplayName("Tình trạng")]
        public string Discontinued { get; set; }
    }
}
