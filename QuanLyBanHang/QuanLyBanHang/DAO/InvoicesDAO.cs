using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class InvoicesDAO
    {
        public List<Invoice> GetList()
        {
            using (var dataContext = new SalesManagementEntities())
            {
                return dataContext.Invoices.ToList();
            }
        }
        public List<InvoiceDetail> GetListInvoiceDetail(int id)
        {
            using (var dataContext = new SalesManagementEntities())
            {
                return dataContext.InvoiceDetails.Where(obj => obj.InvoiceID == id).ToList();
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
        public bool AddInvoice(Invoice obj, List<InvoiceDetail> listObj, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    using (var transaction = dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            dataContext.Invoices.Add(obj);
                            dataContext.SaveChanges();
                            foreach (var objD in listObj)
                            {
                                var prdE = dataContext.Products.Single(o => o.ProductID == objD.ProductID);
                                if (!prdE.Discontinued)
                                {
                                    objD.InvoiceID = obj.InvoiceID;
                                    dataContext.InvoiceDetails.Add(objD);
                                    prdE.UnitsInStock -= objD.Quantity;
                                    prdE.UnitsOnInvoice += objD.Quantity;
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
                            serverMessage = obj.InvoiceID.ToString();
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
        public bool EditInvoice(Invoice obj, List<InvoiceDetail> listObj, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    using (var transaction = dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            Invoice objE = dataContext.Invoices.Single(o => o.InvoiceID == obj.InvoiceID);
                            objE.EmployeeID = obj.EmployeeID;
                            objE.CustomerID = obj.CustomerID;
                            objE.Freight = obj.Freight;
                            objE.InvoiceDate = obj.InvoiceDate;
                            dataContext.SaveChanges();
                            var listObjE = dataContext.InvoiceDetails.Where(o => o.InvoiceID == obj.InvoiceID).ToList();
                            foreach (var objD in listObj)
                            {
                                var objDE = listObjE.Single(i => i.ProductID == objD.ProductID);
                                var prdE = dataContext.Products.Single(o => o.ProductID == objD.ProductID);
                                if (!prdE.Discontinued)
                                {
                                    int quantity = objD.Quantity - objDE.Quantity;
                                    prdE.UnitsInStock -= quantity;
                                    prdE.UnitsOnInvoice += quantity;
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
                            serverMessage = obj.InvoiceID.ToString();
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
        public bool DeleteInvoice(int id, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    using (var transaction = dataContext.Database.BeginTransaction())
                    {
                        try
                        {
                            var listObj = dataContext.InvoiceDetails.Where(o => o.InvoiceID == id).ToList();
                            foreach (var objD in listObj)
                            {
                                var prdE = dataContext.Products.Single(o => o.ProductID == objD.ProductID);
                                prdE.UnitsInStock += objD.Quantity;
                                prdE.UnitsOnInvoice -= objD.Quantity;
                                dataContext.InvoiceDetails.Remove(objD);
                                dataContext.SaveChanges();
                            }
                            Invoice obj = dataContext.Invoices.Single(o => o.InvoiceID == id);
                            dataContext.Invoices.Remove(obj);
                            dataContext.SaveChanges();
                            transaction.Commit();
                            serverMessage = obj.InvoiceID.ToString();
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
