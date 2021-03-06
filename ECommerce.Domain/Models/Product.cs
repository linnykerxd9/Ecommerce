using System;
using System.Collections.Generic;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public bool Active { get; private set; }
        public string Name { get; private set; }
        public string BarCode { get; private set; }
        public int QuantityStock { get; private set; }
        public decimal PriceSales { get; private set; }
        public decimal PricePurchase { get; private set; }
        public ICollection<Image> Images { get;private set; } = new List<Image>();
        public Guid SupplierId { get;private set; }
        public Guid CategoryId { get;private set; }
        public Category Category { get;private set; }
        public Supplier Supplier { get;private set; }
        protected Product() { }
        public Product(string name, string barCode, int quantityStock,
                        decimal priceSales, decimal pricePurchase, bool active,
                        List<Image> images,Guid supplierId, Guid categoryId)
        {
            SetName(name);
            SetBarCode(barCode);
            SetQuantityStock(quantityStock);
            SetPriceSales(priceSales);
            SetPricePurchase(pricePurchase);
            SetActive(active);
            SetSupplierId(supplierId);
            SetCategory(categoryId);
            SetImage(images);
        }

        private void SetImage(List<Image> images)
        {
          if(images == null) throw new DomainExceptions("Images cannot be null");
          Images = images;
        }
        private void SetImage(Image image)
        {
          if(image == null) throw new DomainExceptions("Images cannot be null");
          Images.Add(image);
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
        public void SetSupplierId(Guid Id)
        {
            if(Id == Guid.Empty) throw new DomainExceptions("the Supplier Id attribute cannot be null");
            SupplierId = Id;
        }
        public void SetCategory(Guid Id)
        {
            if(Id == Guid.Empty) throw new DomainExceptions("the Category Id attribute cannot be null");
            CategoryId = Id;
        }
        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }
    }
}