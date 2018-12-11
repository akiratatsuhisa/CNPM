using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class ProductsBUS
    {
        private ProductsDAO _productsContext = new ProductsDAO();
        public List<ProductDTO> GetList() => _productsContext.GetList().
            Select(obj => ConvertToProductDTO(obj)).ToList();
        public List<ProductDTO> GetProductCanBuy() => _productsContext.GetList().
            Where(obj => !obj.Discontinued && obj.UnitsInStock > 0).
            Select(obj => ConvertToProductDTO(obj)).ToList();
        public List<ProductDTO> GetSearchListProduct(string searchName, decimal? minUnitPrice, decimal? maxUnitPrice, out bool? result) 
            => _productsContext.GetSearchListProduct(ConvertToSearchQuery(searchName,minUnitPrice,maxUnitPrice), out result).
            Where(obj => !obj.Discontinued && obj.UnitsInStock > 0).
            Select(obj => ConvertToProductDTO(obj)).ToList();
        private string ConvertToSearchQuery(string searchName, decimal? minUnitPrice, decimal? maxUnitPrice)
        {
            string query = "";

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                query += "P.ProductName Like N'%" + searchName +"%'" + " AND ";
            }
            if (minUnitPrice != null)
            {
                query += "P.UnitPrice >= " + minUnitPrice + " AND ";
            }
            if (maxUnitPrice != null)
            {
                query += "P.UnitPrice <= " + maxUnitPrice + " AND ";
            }
            return query = query.Remove(query.Length-5);
        }
        private ProductDTO ConvertToProductDTO(Product obj) => new ProductDTO
        {
            ProductID = obj.ProductID,
            ProductName = obj.ProductName,
            AddedDate = obj.AddedDate,
            QuantityPerUnit = obj.QuantityPerUnit,
            UnitPrice = obj.UnitPrice,
            UnitsInStock = obj.UnitsInStock,
            UnitsOnOrder = obj.UnitsOnOrder,
            Discontinued = obj.Discontinued ? "Dừng bán" : "Bán"
        };
        private Product ConvertToProduct(ProductDTO obj) => new Product
        {
            ProductID = obj.ProductID,
            ProductName = obj.ProductName,
            AddedDate = obj.AddedDate,
            QuantityPerUnit = obj.QuantityPerUnit,
            UnitPrice = obj.UnitPrice,
            UnitsInStock = obj.UnitsInStock,
            UnitsOnOrder = obj.UnitsOnOrder,
            Discontinued = obj.Discontinued == "Dừng bán" ? true : false,
        };
        public bool AddProduct(ProductDTO obj, out string serverMessage) => _productsContext.AddProduct(ConvertToProduct(obj), out serverMessage);
        public bool EditProduct(ProductDTO obj, out string serverMessage) => _productsContext.EditProduct(ConvertToProduct(obj), out serverMessage);
        public bool DeleteProduct(int id, out string serverMessage) => _productsContext.DeleteProduct(id, out serverMessage);
    }
}
