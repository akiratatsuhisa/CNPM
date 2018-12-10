using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class CustomersDAO
    {
        public List<Customer> GetList()
        {
            using (var dataContext = new SalesManagementEntities())
            {
                return dataContext.Customers.ToList();
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
        public bool AddCustomer(Customer obj, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    dataContext.Customers.Add(obj);
                    dataContext.SaveChanges();
                    serverMessage = "Customer Name: " + obj.Name + ", ID: " + obj.CustomerID + " is added.";
                }
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
        public bool EditCustomer(Customer obj, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    Customer objE = dataContext.Customers.Single(o => o.CustomerID == obj.CustomerID);
                    objE.Name = obj.Name;
                    objE.Gender = obj.Gender;
                    objE.PhoneNumber = obj.PhoneNumber;
                    objE.Address = obj.Address;
                    objE.Email = obj.Email;
                    dataContext.SaveChanges();
                    serverMessage = "Customer Name: " + obj.Name + ", ID: " + obj.CustomerID + " is edited.";
                }
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
        public bool DeleteCustomer(int id, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    Customer obj = dataContext.Customers.Single(o => o.CustomerID == id);
                    dataContext.Customers.Remove(obj);
                    dataContext.SaveChanges();
                    serverMessage = "Customer Name: " + obj.Name + ", ID: " + obj.CustomerID + " is deleted.";
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
