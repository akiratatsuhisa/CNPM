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
        public bool AddOrder(Order obj, List<OrderDetail> listObj, out string serverMessage)
        {
            using (var transaction = DataProvider.Instance.DataContext.Database.BeginTransaction())
            {
                try
                {
                    DataProvider.Instance.DataContext.Orders.Add(obj);
                    DataProvider.Instance.DataContext.SaveChanges();
                    foreach (var objD in listObj)
                    {
                        var prdE = DataProvider.Instance.DataContext.Products.Single(o => o.ProductID == objD.ProductID);
                        if (!prdE.Discontinued)
                        {
                            DataProvider.Instance.DataContext.OrderDetails.Add(objD);
                            prdE.UnitsInStock -= objD.Quantity;
                            prdE.UnitsOnOrder += objD.Quantity;   
                        }
                        else
                        {
                            transaction.Rollback();
                            serverMessage = "The product: " + prdE.ProductName + " has been discontinued";
                            return false;
                        }
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
        public bool EditOrder(Order obj, List<OrderDetail> listObj, out string serverMessage)
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
                    var listObjE = DataProvider.Instance.DataContext.OrderDetails.Where(o => o.OrderID == obj.OrderID).ToList();
                    foreach (var objD in listObj)
                    {
                        var objDE = listObjE.Single(i => i.ProductID == objD.ProductID);
                        var prdE = DataProvider.Instance.DataContext.Products.Single(o => o.ProductID == objD.ProductID);
                        if (!prdE.Discontinued)
                        {
                            int quantity = objD.Quantity - objDE.Quantity;
                            prdE.UnitsInStock -= quantity;
                            prdE.UnitsOnOrder += quantity;
                            objDE.Quantity = objD.Quantity;
                            objDE.UnitPrice = objD.UnitPrice;
                        }
                        else
                        {
                            transaction.Rollback();
                            serverMessage = "The product: " + prdE.ProductName + " has been discontinued";
                            return false;
                        }
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
                    var listObj = DataProvider.Instance.DataContext.OrderDetails.Where(o => o.OrderID == id).ToList();
                    foreach (var objD in listObj)
                    {
                        var prdE = DataProvider.Instance.DataContext.Products.Single(o => o.ProductID == objD.ProductID);
                        prdE.UnitsInStock += objD.Quantity;
                        prdE.UnitsOnOrder -= objD.Quantity;
                        DataProvider.Instance.DataContext.OrderDetails.Remove(objD);
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
