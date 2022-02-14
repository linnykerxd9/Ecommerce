using System;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Purchases : Entity
    {
        public int Quantity { get;private set; }
        public decimal TotalPrice  { get;private set; }
        public string CodePurchase  { get;private set; }
        public Guid CustomersId { get; set; }
        public Guid ProductId { get;private set; }
        public Product Product { get;private set; }
        public Purchases(int quantity, decimal totalPrice, Guid productId, Guid customersId)
        {
            SetQuantity(quantity);
            SetTotalPrice(totalPrice);
            SetProductId(productId);
            SetCustomersId(customersId);
            CodePurchase = GeneratorCodePurchase();
        }
        public void SetQuantity(int quantity){
            if(quantity < 0 )
                 throw new DomainExceptions("Quantity can not be negative");
            Quantity = quantity;
        }
        public void SetTotalPrice(decimal price){
            if(price < 0 )
                 throw new DomainExceptions("Quantity can not be negative");
            TotalPrice = price;
        }
        public void SetProductId(Guid Id)
        {
            if(Id == Guid.Empty) throw new DomainExceptions("the Product Id attribute cannot be null");
            ProductId = Id;
        }
        public void SetCustomersId(Guid Id)
        {
            if(Id == Guid.Empty) throw new DomainExceptions("the Costumer Id attribute cannot be null");
            CustomersId = Id;
        }
        private string GeneratorCodePurchase(){
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            return new String(Charsarr);
        }
    }
}