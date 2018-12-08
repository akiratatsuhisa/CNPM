using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class EmployeesBUS
    {
        private EmployeesDAO _employeesContext = new EmployeesDAO();
        public List<EmployeeDTO> GetList() => _employeesContext.GetList().Select(obj => new EmployeeDTO
        {
            EmployeeID = obj.EmployeeID,
            Name = obj.Name,
            BirthDate = obj.BirthDate,
            Gender = obj.Gender ? "Nam" : "Nữ",
            ID = obj.ID,
            PhoneNumber = obj.PhoneNumber,
            Address = obj.Address,
            JobTitle = obj.JobTitle,
        }).ToList();
        private Employee ConvertToEmployee(EmployeeDTO obj) => new Employee
        {
            EmployeeID = obj.EmployeeID,
            Name = obj.Name,
            BirthDate = obj.BirthDate,
            Gender = obj.Gender == "Nam"?true:false,
            ID = obj.ID,
            PhoneNumber = obj.PhoneNumber,
            Address = obj.Address,
            JobTitle = obj.JobTitle,
        };
        public bool AddEmployee(EmployeeDTO obj, out string serverMessage) => _employeesContext.AddEmployee(ConvertToEmployee(obj), out serverMessage);
        public bool EditEmployee(EmployeeDTO obj, out string serverMessage) => _employeesContext.EditEmployee(ConvertToEmployee(obj), out serverMessage);
        public bool DeleteEmployee(int id, out string serverMessage) => _employeesContext.DeleteEmployee(id, out serverMessage);
    }
}
