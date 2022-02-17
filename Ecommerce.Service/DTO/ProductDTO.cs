using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class ProductDTO
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
   public ValidationResult Validate(){
            return new ProductValidator().Validate(this);
        }
    }
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Active)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Active is null");
            RuleFor(x => x.Name)
                    .MaximumLength(256)
                    .WithMessage("the Name field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Name is null");
            RuleFor(x => x.BarCode)
                    .MaximumLength(100)
                    .WithMessage("the Bar code for can have up to 100 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("BarCode is null");
            RuleFor(x => x.QuantityStock)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Quantity Stock is null");
            RuleFor(x => x.PriceSales)
                    .NotNull()
                    .WithMessage("Price Sales is null");
            RuleFor(x => x.PricePurchase)
                    .NotNull()
                    .WithMessage("Price Purchase is null");
        }
    }
}