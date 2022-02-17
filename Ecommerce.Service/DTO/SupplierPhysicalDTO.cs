using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class SupplierPhysicalDTO : SupplierDTO
    {
        public string FullName { get;  set; }
        public string Cpf { get;  set; }
        public DateTime BirthDate  { get;  set; }
        public SupplierPhysicalDTO(string fullName, string cpf, DateTime birthDate,bool active,
                                   string fantasyName, EmailDTO email, AddressDTO address,
                                    ICollection<PhoneDTO> phone) : base(active, fantasyName, email, address, phone)
        {
            FullName = fullName;
            Cpf = cpf;
            BirthDate = birthDate;
        }
        public override ValidationResult Validate(){
            return new SupplierPhysicalValidator().Validate(this);
        }
    }
    public class SupplierPhysicalValidator : AbstractValidator<SupplierPhysicalDTO>
    {
        public SupplierPhysicalValidator()
        {
                RuleFor(x => x.FullName)
                    .MaximumLength(256)
                    .WithMessage("the Full Name field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Name is null");
                RuleFor(x => x.Cpf)
                    .Length(11)
                    .WithMessage("the field needs to be 11 characters long")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Cpf is null");
                RuleFor(x => x.BirthDate)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("BirthDate is null");
        }
    }
}