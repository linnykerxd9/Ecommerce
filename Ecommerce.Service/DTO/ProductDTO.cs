using System;
using System.Collections.Generic;

namespace Ecommerce.Service.DTO
{
    public class ProductDTO : EntityDTO
    {
         public bool Active { get;  set; }
        public string Name { get;  set; }
        public string BarCode { get;  set; }
        public int QuantityStock { get;  set; }
        public decimal PriceSales { get;  set; }
        public decimal PricePurchase { get;  set; }
        public ICollection<ImageDTO> Images { get; set; } = new List<ImageDTO>();
        public Guid SupplierId { get; set; }
        public Guid CategoryId { get; set; }

        public ProductDTO(bool active, string name, string barCode, int quantityStock, decimal priceSales, decimal pricePurchase, ICollection<ImageDTO> images, Guid supplierId, Guid categoryId)
        {
            Active = active;
            Name = name;
            BarCode = barCode;
            QuantityStock = quantityStock;
            PriceSales = priceSales;
            PricePurchase = pricePurchase;
            Images = images;
            SupplierId = supplierId;
            CategoryId = categoryId;
        }
    }
}