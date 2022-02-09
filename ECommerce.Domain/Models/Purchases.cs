using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Purchases : Entity
    {
         public int Quantity { get;private set; }
        public decimal TotalPrice  { get;private set; }
        public string CodePurchase  { get;private set; }

        public Purchases(int quantity, decimal totalPrice)
        {
            SetQuantity(quantity);
            SetTotalPrice(totalPrice);
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
    }
}