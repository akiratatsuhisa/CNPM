using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class ProductsDAO
    {
        public List<Product> GetList()
        {
            using (var dataContext = new SalesManagementEntities())
            {
                return dataContext.Products.ToList();
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
        public bool AddProduct(Product obj, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    dataContext.Products.Add(obj);
                    dataContext.SaveChanges();
                    serverMessage = obj.ProductID.ToString();
                }
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
        public bool EditProduct(Product obj, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    Product objE = dataContext.Products.Single(o => o.ProductID == obj.ProductID);
                    objE.ProductName = obj.ProductName;
                    objE.AddedDate = obj.AddedDate;
                    objE.QuantityPerUnit = obj.QuantityPerUnit;
                    objE.UnitPrice = obj.UnitPrice;
                    objE.UnitsInStock = obj.UnitsInStock;
                    objE.UnitsOnInvoice = obj.UnitsOnInvoice;
                    objE.Discontinued = obj.Discontinued;
                    dataContext.SaveChanges();
                    serverMessage = obj.ProductID.ToString();
                }
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
        public bool DeleteProduct(int id, out string serverMessage)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    Product obj = dataContext.Products.Single(o => o.ProductID == id);
                    dataContext.Products.Remove(obj);
                    dataContext.SaveChanges();
                    serverMessage = obj.ProductID.ToString();
                }
                return true;
            }
            catch (Exception ex)
            {
                serverMessage = ExceptionMessage(ex);
                return false;
            }
        }
        public List<Product> GetSearchListProduct(string where, out bool? result)
        {
            try
            {
                using (var dataContext = new SalesManagementEntities())
                {
                    string query = "Select * From Products P Where " + where;
                    var list = dataContext.Database.SqlQuery<Product>(query).ToList();
                    if (list.Count == 0)
                    {
                        // không tìm ra kết quả  null rỗng
                        // trả về list rỗng
                        result = null;
                        return new List<Product>();
                    }
                    else
                    {
                        // tìm thành công
                        result = true;
                        return list;
                    }
                }
            }
            catch (Exception)
            {
                // lỗi trong quá trình tìm, query, database ...
                result = false;
                return new List<Product>();
            }

        }
    }
}
