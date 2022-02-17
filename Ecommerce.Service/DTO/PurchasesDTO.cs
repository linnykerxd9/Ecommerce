using System;
using ECommerce.Domain.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class PurchasesDTO 
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
        public ValidationResult Validate(){
            return new PurchasesValidator().Validate(this);
        }
        public Purchases ToDomain()
        {
            return new Purchases(Quantity,TotalPrice,ProductId,CustomersId);
        }
    }
    public class PurchasesValidator : AbstractValidator<PurchasesDTO>
    {
        public PurchasesValidator()
        {
            RuleFor(x => x.Quantity)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Quantity is null");
            RuleFor(x => x.TotalPrice)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Total Price is null");
            RuleFor(x => x.CustomersId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("there is no buyer for this product ");
            RuleFor(x => x.ProductId)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("There is no product for this purchase ");
        }
    }
}