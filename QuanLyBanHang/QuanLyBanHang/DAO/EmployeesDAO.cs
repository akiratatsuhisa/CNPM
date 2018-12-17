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
        public List<Employee> GetList()
        {
            using (var dataContext = new SalesManagementEntities())
            {
                return dataContext.Employees.ToList();
            }
        }
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
                using (var dataContext = new SalesManagementEntities())
                {
                    dataContext.Employees.Add(obj);
                    dataContext.SaveChanges();
                    serverMessage = obj.EmployeeID.ToString();
                }
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
                using (var dataContext = new SalesManagementEntities())
                {
                    Employee objE = dataContext.Employees.Single(o => o.EmployeeID == obj.EmployeeID);
                    objE.Name = obj.Name;
                    objE.BirthDate = obj.BirthDate;
                    objE.Gender = obj.Gender;
                    objE.ID = obj.ID;
                    objE.PhoneNumber = obj.PhoneNumber;
                    objE.Address = obj.Address;
                    objE.JobTitle = obj.JobTitle;
                    dataContext.SaveChanges();
                    serverMessage = obj.EmployeeID.ToString();
                }
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
                using (var dataContext = new SalesManagementEntities())
                {
                    Employee obj = dataContext.Employees.Single(o => o.EmployeeID == id);
                    dataContext.Employees.Remove(obj);
                    dataContext.SaveChanges();
                    serverMessage = obj.EmployeeID.ToString();
                }
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
