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
        public List<Order> GetList()
        {
            using (var dataContext = new SalesManagementEntities())
            {
                return dataContext.Orders.ToList();
            }
        }
        public List<OrderDetail> GetListOrderDetail(int id)
        {
            using (var dataContext = new SalesManagementEntities())
            {
                return dataContext.OrderDetails.Where(obj => obj.OrderID == id).ToList();
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
        public bool AddOrder(Order obj, List<OrderDetail> listObj, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    using (var transaction = dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            dataContext.Orders.Add(obj);
                            dataContext.SaveChanges();
                            foreach (var objD in listObj)
                            {
                                var prdE = dataContext.Products.Single(o => o.ProductID == objD.ProductID);
                                if (!prdE.Discontinued)
                                {
                                    objD.OrderID = obj.OrderID;
                                    dataContext.OrderDetails.Add(objD);
                                    prdE.UnitsInStock -= objD.Quantity;
                                    prdE.UnitsOnOrder += objD.Quantity;
                                }
                                else
                                {
                                    // roll back lại nếu như sản phẩm ko còn bán nữa
                                    transaction.Rollback();
                                    serverMessage = "The product: " + prdE.ProductName + " has been discontinued";
                                    return false;
                                }
                                dataContext.SaveChanges();
                            }
                            transaction.Commit();
                            serverMessage = obj.OrderID.ToString();
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
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
        public bool EditOrder(Order obj, List<OrderDetail> listObj, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    using (var transaction = dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            Order objE = dataContext.Orders.Single(o => o.OrderID == obj.OrderID);
                            objE.EmployeeID = obj.EmployeeID;
                            objE.CustomerID = obj.CustomerID;
                            objE.Freight = obj.Freight;
                            objE.OrderDate = obj.OrderDate;
                            dataContext.SaveChanges();
                            var listObjE = dataContext.OrderDetails.Where(o => o.OrderID == obj.OrderID).ToList();
                            foreach (var objD in listObj)
                            {
                                var objDE = listObjE.Single(i => i.ProductID == objD.ProductID);
                                var prdE = dataContext.Products.Single(o => o.ProductID == objD.ProductID);
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
                                    // roll back lại nếu như sản phẩm ko còn bán nữa
                                    transaction.Rollback();
                                    serverMessage = "The product: " + prdE.ProductName + " has been discontinued";
                                    return false;
                                }
                                dataContext.SaveChanges();
                            }
                            transaction.Commit();
                            serverMessage = obj.OrderID.ToString();
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
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
        public bool DeleteOrder(int id, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    using (var transaction = dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            var listObj = dataContext.OrderDetails.Where(o => o.OrderID == id).ToList();
                            foreach (var objD in listObj)
                            {
                                var prdE = dataContext.Products.Single(o => o.ProductID == objD.ProductID);
                                prdE.UnitsInStock += objD.Quantity;
                                prdE.UnitsOnOrder -= objD.Quantity;
                                dataContext.OrderDetails.Remove(objD);
                                dataContext.SaveChanges();
                            }
                            Order obj = dataContext.Orders.Single(o => o.OrderID == id);
                            dataContext.Orders.Remove(obj);
                            dataContext.SaveChanges();
                            transaction.Commit();
                            serverMessage = obj.OrderID.ToString();
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
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
    }
}
