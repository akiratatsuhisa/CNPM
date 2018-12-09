using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class EmployeesDAO
    {
        public List<Employee> GetList() => DataProvider.Instance.DataContext.Employees.ToList();
        private string ExceptionMessage(Exception ex)
        {
            string message = ex.InnerException != null ? ex.InnerException.InnerException.Message : ex.Message;
            if (ex is DbEntityValidationException dbEx)
            {
                foreach (var validationError in dbEx.EntityValidationErrors)
                {
                    foreach (var item in validationError.ValidationErrors)
                    {
                        message += "\n";
                        message += item.ErrorMessage;
                    }
                }
            }
            return message;
        }
        public bool AddEmployee(Employee obj, out string serverMessage)
        {
            try
            {
                DataProvider.Instance.DataContext.Employees.Add(obj);
                DataProvider.Instance.DataContext.SaveChanges();
                serverMessage = "Employee Name: " + obj.Name + ", ID: " + obj.EmployeeID + " is added.";
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
        public bool EditEmployee(Employee obj, out string serverMessage)
        {
            try
            {
                Employee objE = DataProvider.Instance.DataContext.Employees.Single(o => o.EmployeeID == obj.EmployeeID);
                objE.Name = obj.Name;
                objE.BirthDate = obj.BirthDate;
                objE.Gender = obj.Gender;
                objE.ID = obj.ID;
                objE.PhoneNumber = obj.PhoneNumber;
                objE.Address = obj.Address;
                objE.JobTitle = obj.JobTitle;
                DataProvider.Instance.DataContext.SaveChanges();
                serverMessage = "Employee Name: " + obj.Name + ", ID: " + obj.EmployeeID + " is edited.";
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
        public bool DeleteEmployee(int id, out string serverMessage)
        {
            try
            {
                Employee obj = DataProvider.Instance.DataContext.Employees.Single(o => o.EmployeeID == id);
                DataProvider.Instance.DataContext.Employees.Remove(obj);
                DataProvider.Instance.DataContext.SaveChanges();
                serverMessage = "Employee Name: " + obj.Name + ", ID: " + obj.EmployeeID + " is deleted.";
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
    }
}
