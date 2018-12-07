using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class CustomersBUS
    {
        private CustomersDAO _customersContext = new CustomersDAO();
        public List<CustomerDTO> GetList() => _customersContext.GetList().
            Select(c => new CustomerDTO
            {
                CustomerID = c.CustomerID,
                Name = c.Name,
                Gender = c.Gender?"Nam":"Nữ",
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                Email = c.Email
            }).ToList();
        private Customer ConvertToCustomer(CustomerDTO obj) => new Customer
        {
            CustomerID = obj.CustomerID,
            Name = obj.Name,
            Gender = obj.Gender == "Nam" ? true : false,
            PhoneNumber = obj.PhoneNumber,
            Address = obj.Address,
            Email = obj.Email,
        };
        public bool AddCustomer(CustomerDTO obj, out string serverMessage) => _customersContext.AddCustomer(ConvertToCustomer(obj), out serverMessage);
        public bool EditCustomer(CustomerDTO obj, out string serverMessage) => _customersContext.EditCustomer(ConvertToCustomer(obj), out serverMessage);
        public bool DeleteCustomer(int id, out string serverMessage) => _customersContext.DeleteCustomer(id, out serverMessage);
    }
}
