using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class OrdersBUS
    {
        private OrdersDAO _ordersContext = new OrdersDAO();
        public List<OrderDTO> GetList() => _ordersContext.GetList().Select(obj => new OrderDTO
        {
            OrderID = obj.OrderID,
            CustomerID = obj.CustomerID,
            CustomerName = obj.Customer.Name,
            EmployeeID = obj.EmployeeID,
            EmployeeName = obj.Employee.Name,
            OrderDate = obj.OrderDate,
            Freight = obj.Freight,
        }).ToList();
        public List<OrderDetailDTO> GetListOrderDetail(int id) => _ordersContext.GetListOrderDetail(id).Select(obj => new OrderDetailDTO
        {
            OrderID = obj.OrderID,
            ProductID = obj.ProductID,
            ProductName = obj.Product.ProductName,
            Quantity = obj.Quantity,
            UnitPrice = obj.UnitPrice
        }).ToList();
        private Order ConvertToOrder(OrderDTO obj) => new Order
        {
            OrderID = obj.OrderID,
            EmployeeID = obj.EmployeeID,
            CustomerID = obj.CustomerID,
            OrderDate = obj.OrderDate,
            Freight = obj.Freight
        };
        private List<OrderDetail> ConvertToListOrderDetail(List<OrderDetailDTO> listItem) => listItem.Select(item => new OrderDetail
        {
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        }).ToList();
        public bool AddOrder(OrderDTO obj, List<OrderDetailDTO> listItem, out string serverMessage) => _ordersContext.AddOrder(ConvertToOrder(obj), ConvertToListOrderDetail(listItem), out serverMessage);
        public bool EditOrder(OrderDTO obj, List<OrderDetailDTO> listItem, out string serverMessage) => _ordersContext.EditOrder(ConvertToOrder(obj), ConvertToListOrderDetail(listItem), out serverMessage);
        public bool DeleteOrder(int id, out string serverMessage) => _ordersContext.DeleteOrder(id, out serverMessage);
    }
}
