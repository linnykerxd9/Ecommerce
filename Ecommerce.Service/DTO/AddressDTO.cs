using System;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class AddressDTO 
    {
        public string ZipCode { get;  set; }
        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Complement { get;  set; }
        public string Reference { get;  set; }
        public Guid SupplierId { get; set; }

        public AddressDTO(string zipCode, string street, string number, string neighborhood, string city, string state, string complement, string reference, Guid supplierId)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement;
            Reference = reference;
            SupplierId = supplierId;
        }
        public  ValidationResult Validate(){
            return new AddressValidator().Validate(this);
        }
    }
    public class AddressValidator : AbstractValidator<AddressDTO>
    {
        public AddressValidator()
        {
            RuleFor(x => x.City)
                    .MaximumLength(256)
                    .WithMessage("the city field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("City is null");
            RuleFor(x => x.Street)
                    .MaximumLength(256)
                    .WithMessage("the street field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("street is null");
            RuleFor(x => x.State)
                    .MaximumLength(100)
                    .WithMessage("the street field for can have up to 100 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("State is null");
            RuleFor(x => x.Neighborhood)
                    .MaximumLength(256)
                    .WithMessage("the Neighborhood field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Neighborhood is null");
            RuleFor(x => x.Number)
                    .Length(10)
                    .WithMessage("the Neighborhood field for can have up to 10 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Number is null");
            RuleFor(x => x.ZipCode)
                    .Length(8)
                    .WithMessage("the field needs to be 8 characters long")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("ZipCode is null");
            RuleFor(x => x.Complement)
                    .MaximumLength(256)
                    .WithMessage("the Complement field for can have up to 256 characters");
            RuleFor(x => x.Reference)
                    .MaximumLength(256)
                    .WithMessage("the Reference field for can have up to 256 characters");
        }
    }
}