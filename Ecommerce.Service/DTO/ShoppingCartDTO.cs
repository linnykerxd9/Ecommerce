using System;

namespace Ecommerce.Service.DTO
{
    public class ShoppingCartDTO : EntityDTO
    {
        public int Quantity { get; set; }
        public decimal TotalPrice  { get; set; }
        public Guid CustomersId { get; set; }
        public Guid ProductId { get; set; }

        public ShoppingCartDTO(int quantity, decimal totalPrice, Guid customersId, Guid productId)
        {
            Quantity = quantity;
            TotalPrice = totalPrice;
            CustomersId = customersId;
            ProductId = productId;
        }
    }
}