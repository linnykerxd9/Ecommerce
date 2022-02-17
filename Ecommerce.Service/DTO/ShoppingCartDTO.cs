using System;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class ShoppingCartDTO 
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
    public ValidationResult Validate(){
            return new ShoppingCartValidator().Validate(this);
        }
    }
    public class ShoppingCartValidator : AbstractValidator<ShoppingCartDTO>
    {
        public ShoppingCartValidator()
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