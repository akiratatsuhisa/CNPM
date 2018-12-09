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
            Select(obj => new ProductDTO
            {
                ProductName = obj.ProductName,
                AddedDate = obj.AddedDate,
                QuantityPerUnit = obj.QuantityPerUnit,
                UnitPrice = obj.UnitPrice,
                UnitsInStock = obj.UnitsInStock,
                UnitsOnOrder = obj.UnitsOnOrder,
                Discontinued = obj.Discontinued?"Đã dừng":"Còn bán",
            }).ToList();
        private Product ConvertToProduct(ProductDTO obj) => new Product
        {
            ProductName = obj.ProductName,
            AddedDate = obj.AddedDate,
            QuantityPerUnit = obj.QuantityPerUnit,
            UnitPrice = obj.UnitPrice,
            UnitsInStock = obj.UnitsInStock,
            UnitsOnOrder = obj.UnitsOnOrder,
            Discontinued = obj.Discontinued == "Đã dừng" ? true : false,
        };
        public bool AddProduct(ProductDTO obj, out string serverMessage) => _productsContext.AddProduct(ConvertToProduct(obj), out serverMessage);
        public bool EditProduct(ProductDTO obj, out string serverMessage) => _productsContext.EditProduct(ConvertToProduct(obj), out serverMessage);
        public bool DeleteProduct(int id, out string serverMessage) => _productsContext.DeleteProduct(id, out serverMessage);
    }
}
