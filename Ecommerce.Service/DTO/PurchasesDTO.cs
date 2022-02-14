using System;

namespace Ecommerce.Service.DTO
{
    public class PurchasesDTO : EntityDTO
    {
        public int Quantity { get; set; }
        public decimal TotalPrice  { get; set; }
        public string CodePurchase  { get; set; }
        public Guid CustomersId { get; set; }
        public Guid ProductId { get; set; }

        public PurchasesDTO(int quantity, decimal totalPrice, string codePurchase, Guid customersId, Guid productId)
        {
            Quantity = quantity;
            TotalPrice = totalPrice;
            CodePurchase = codePurchase;
            CustomersId = customersId;
            ProductId = productId;
        }
    }
}