using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class OrdersDAO
    {
        public List<Order> GetList() => DataProvider.Instance.DataContext.Orders.ToList();
        public List<OrderDetail> GetListOrderDetail(int id) => DataProvider.Instance.DataContext.OrderDetails.Where(obj => obj.OrderID == id).ToList();
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
        public bool AddOrder(Order obj, List<OrderDetail> listItem, out string serverMessage)
        {
            using (var transaction = DataProvider.Instance.DataContext.Database.BeginTransaction())
            {
                try
                {
                    DataProvider.Instance.DataContext.Orders.Add(obj);
                    DataProvider.Instance.DataContext.SaveChanges();
                    foreach (var item in listItem)
                    {
                        DataProvider.Instance.DataContext.OrderDetails.Add(item);
                        DataProvider.Instance.DataContext.SaveChanges();
                    }
                    transaction.Commit();
                    serverMessage = "Order ID: " + obj.OrderID + ", Customer Name: " + obj.Customer.Name + " is added.";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    serverMessage = ExceptionMessage(ex);
                    return false;
                }
            }
        }
        public bool EditOrder(Order obj, List<OrderDetail> listItem, out string serverMessage)
        {
            using (var transaction = DataProvider.Instance.DataContext.Database.BeginTransaction())
            {
                try
                {
                    Order objE = DataProvider.Instance.DataContext.Orders.Single(o => o.OrderID == obj.OrderID);
                    objE.EmployeeID = obj.EmployeeID;
                    objE.CustomerID = obj.CustomerID;
                    objE.Freight = obj.Freight;
                    objE.OrderDate = obj.OrderDate;
                    DataProvider.Instance.DataContext.SaveChanges();
                    var listItemE = DataProvider.Instance.DataContext.OrderDetails.Where(o => o.OrderID == obj.OrderID).ToList();
                    foreach (var item in listItem)
                    {
                        var itemE = listItemE.Single(i => i.ProductID == item.ProductID);
                        itemE.Quantity = item.Quantity;
                        itemE.UnitPrice = item.UnitPrice;
                        DataProvider.Instance.DataContext.SaveChanges();
                    }
                    transaction.Commit();
                    serverMessage = "Order ID: " + obj.OrderID + ", Customer Name: " + obj.Customer.Name + " is edited.";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    serverMessage = ExceptionMessage(ex);
                    return false;
                }
            }
        }
        public bool DeleteOrder(int id, out string serverMessage)
        {
            using (var transaction = DataProvider.Instance.DataContext.Database.BeginTransaction())
            {
                try
                {
                    var listItem = DataProvider.Instance.DataContext.OrderDetails.Where(o => o.OrderID == id).ToList();
                    foreach (var item in listItem)
                    {
                        DataProvider.Instance.DataContext.OrderDetails.Remove(item);
                        DataProvider.Instance.DataContext.SaveChanges();
                    }
                    Order obj = DataProvider.Instance.DataContext.Orders.Single(o => o.OrderID == id);
                    DataProvider.Instance.DataContext.Orders.Remove(obj);
                    DataProvider.Instance.DataContext.SaveChanges();
                    transaction.Commit();
                    serverMessage = "Order ID: " + obj.OrderID + ", Customer Name: " + obj.Customer.Name + " is deleted.";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    serverMessage = ExceptionMessage(ex);
                    return false;
                }
            }
        }
    }
}
