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
        public List<Product> GetList() => DataProvider.Instance.DataContext.Products.ToList();
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
                DataProvider.Instance.DataContext.Products.Add(obj);
                DataProvider.Instance.DataContext.SaveChanges();
                serverMessage = "Product Name: " + obj.ProductName + ", ID: " + obj.ProductID + " is added.";
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
                Product objE = DataProvider.Instance.DataContext.Products.Single(o => o.ProductID == obj.ProductID);
                objE.ProductName = obj.ProductName;
                objE.AddedDate = obj.AddedDate;
                objE.QuantityPerUnit = obj.QuantityPerUnit;
                objE.UnitPrice = obj.UnitPrice;
                objE.UnitsInStock = obj.UnitsInStock;
                objE.UnitsOnOrder = obj.UnitsOnOrder;
                objE.Discontinued = obj.Discontinued;
                DataProvider.Instance.DataContext.SaveChanges();
                serverMessage = "Product Name: " + obj.ProductName + ", ID: " + obj.ProductID + " is edited.";
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
                Product obj = DataProvider.Instance.DataContext.Products.Single(o => o.ProductID == id);
                DataProvider.Instance.DataContext.Products.Remove(obj);
                DataProvider.Instance.DataContext.SaveChanges();
                serverMessage = "Product Name: " + obj.ProductName + ", ID: " + obj.ProductID + " is deleted.";
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
                string query = "Select * From Products P Where " + where;
                var list = DataProvider.Instance.DataContext.Database.SqlQuery<Product>(query).ToList();
                if (list.Count == 0)
                {
                    result = null;
                    list = GetList();
                    return list;
                }
                else
                {
                    result = true;
                    return list;
                }
            }
            catch (Exception)
            {
                result = false;
                return null;
            }

        }
    }
}
