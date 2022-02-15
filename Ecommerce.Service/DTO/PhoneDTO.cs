using System;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class PhoneDTO 
    {
         public string Ddd { get;  set; }
        public string Number { get;  set; }
        public Guid SupplierId { get; set; }

        public PhoneDTO(string ddd, string number, Guid supplierId)
        {
            Ddd = ddd;
            Number = number;
            SupplierId = supplierId;
        }
    public ValidationResult IsValid(){
            return new PhoneValidator().Validate(this);
        }
    }
    public class PhoneValidator : AbstractValidator<PhoneDTO>
    {
        public PhoneValidator()
        {
            RuleFor(x => x.Ddd)
                    .Length(2,3)
                    .WithMessage("the phone's ddd must be 2 or 3 digits")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Phone's DDD is null");
            RuleFor(x => x.Number)
                    .Length(8,9)
                    .WithMessage("the phone number must have 8 or 9 digits")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Phone's number is null");
        }
    }
}