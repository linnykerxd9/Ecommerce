using System;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Product : Entity
    {
        public bool Active { get; private set; }
        public string Name { get; private set; }
        public string BarCode { get; private set; }
        public int QuantityStock { get; private set; }
        public decimal PriceSales { get; private set; }
        public decimal PricePurchase { get; private set; }
        protected Product() { }
        public Product(string name, string barCode, int quantityStock, decimal priceSales, decimal pricePurchase, bool active)
        {
            SetName(name);
            SetBarCode(barCode);
            SetQuantityStock(quantityStock);
            SetPriceSales(priceSales);
            SetPricePurchase(pricePurchase);
            SetActive(active);
        }
        public void SetName(string name){
            StringEmptyOrNull(name,"Product Name");
            Name = name;
        }
        public void SetBarCode(string barCode){
            StringEmptyOrNull(barCode,"Bar Code");

            BarCode = barCode;
        }
        public void SetQuantityStock(int stock){
            QuantityStock = stock;
        }
        public void SetPriceSales(decimal priceSale){
            if(priceSale < 0)
                throw new DomainExceptions("sale price can not be negative");
            
            PriceSales = priceSale;
        }
        public void SetPricePurchase(decimal privePurchase){
            if(privePurchase < 0)
                throw new DomainExceptions("sale price can not be negative");
            
            PricePurchase = privePurchase;
        }
        public void SetActive(bool status) {
            Active = status;
        }

        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }
    }
}