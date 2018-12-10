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
        public List<Job> ListJob => new List<Job>
        {
            new Job{DisplayName = "Giám đốc", Title = "GĐ"},
            new Job{DisplayName = "Quản lý", Title = "QL"},
            new Job{DisplayName = "Bán hàng", Title = "BH"},
            new Job{DisplayName = "Chăm sóc KH", Title = "CSKH"},
            new Job{DisplayName = "Bảo vệ", Title = "BV"},
            new Job{DisplayName = "Vô công", Title = "VC"}
        };
        public List<EmployeeDTO> GetList() => _employeesContext.GetList().Select(obj => ConvertToEmployeeDTO(obj)).ToList();
        public List<int> GetSalesEmployees() => _employeesContext.GetList().Where(obj => obj.JobTitle =="BH").
            Select(obj => obj.EmployeeID).ToList();
        private EmployeeDTO ConvertToEmployeeDTO(Employee obj) => new EmployeeDTO
        {
            EmployeeID = obj.EmployeeID,
            Name = obj.Name,
            BirthDate = obj.BirthDate,
            Gender = obj.Gender ? "Nam" : "Nữ",
            ID = obj.ID,
            PhoneNumber = obj.PhoneNumber,
            Address = obj.Address,
            JobTitle = ListJob.SingleOrDefault(o => o.Title == obj.JobTitle)?.DisplayName ?? "Vô công",
        };
        private Employee ConvertToEmployee(EmployeeDTO obj) => new Employee
        {
            EmployeeID = obj.EmployeeID,
            Name = obj.Name,
            BirthDate = obj.BirthDate,
            Gender = obj.Gender == "Nam"?true:false,
            ID = obj.ID,
            PhoneNumber = obj.PhoneNumber,
            Address = obj.Address,
            JobTitle = ListJob.SingleOrDefault(o => o.DisplayName == obj.JobTitle)?.Title ?? "VC"
        };
        public bool AddEmployee(EmployeeDTO obj, out string serverMessage) => _employeesContext.AddEmployee(ConvertToEmployee(obj), out serverMessage);
        public bool EditEmployee(EmployeeDTO obj, out string serverMessage) => _employeesContext.EditEmployee(ConvertToEmployee(obj), out serverMessage);
        public bool DeleteEmployee(int id, out string serverMessage) => _employeesContext.DeleteEmployee(id, out serverMessage);
    }
    public class Job
    {
        public string DisplayName { get; set; }
        public string Title { get; set; }
    }
}
