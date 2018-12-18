using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class InvoicesBUS
    {
        private InvoicesDAO _invoicesContext = new InvoicesDAO();
        public List<InvoiceDTO> GetList() => _invoicesContext.GetList().Select(obj => ConvertToInvoiceDTO(obj)).ToList();
        public List<InvoiceDetailDTO> GetListInvoiceDetail(int id) => _invoicesContext.GetListInvoiceDetail(id).Select(obj => ConvertToInvoiceDetailDTO(obj)).ToList();
        private InvoiceDTO ConvertToInvoiceDTO(Invoice obj) => new InvoiceDTO
        {
            InvoiceID = obj.InvoiceID,
            CustomerID = obj.CustomerID,
            CustomerName = obj.Customer.Name,
            EmployeeID = obj.EmployeeID,
            EmployeeName = obj.Employee.Name,
            InvoiceDate = obj.InvoiceDate,
            Freight = obj.Freight,
        };
        private InvoiceDetailDTO ConvertToInvoiceDetailDTO(InvoiceDetail obj) => new InvoiceDetailDTO
        {
            InvoiceID = obj.InvoiceID,
            ProductID = obj.ProductID,
            ProductName = obj.Product.ProductName,
            Quantity = obj.Quantity,
            UnitPrice = obj.UnitPrice
        };
        private Invoice ConvertToInvoice(InvoiceDTO obj) => new Invoice
        {
            InvoiceID = obj.InvoiceID,
            EmployeeID = obj.EmployeeID,
            CustomerID = obj.CustomerID,
            InvoiceDate = obj.InvoiceDate,
            Freight = obj.Freight
        };
        private List<InvoiceDetail> ConvertToListInvoiceDetail(List<InvoiceDetailDTO> listObj) => listObj.Select(obj => new InvoiceDetail
        {
            InvoiceID = obj.InvoiceID,
            ProductID = obj.ProductID,
            Quantity = obj.Quantity,
            UnitPrice = obj.UnitPrice
        }).ToList();
        public bool AddInvoice(InvoiceDTO obj, List<InvoiceDetailDTO> listObj, out string serverMessage) => _invoicesContext.AddInvoice(ConvertToInvoice(obj), ConvertToListInvoiceDetail(listObj), out serverMessage);
        public bool EditInvoice(InvoiceDTO obj, List<InvoiceDetailDTO> listObj, out string serverMessage) => _invoicesContext.EditInvoice(ConvertToInvoice(obj), ConvertToListInvoiceDetail(listObj), out serverMessage);
        public bool DeleteInvoice(int id, out string serverMessage) => _invoicesContext.DeleteInvoice(id, out serverMessage);
    }
}
