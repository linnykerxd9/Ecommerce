using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class SupplierJuridicalDTO : SupplierDTO
    {
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public DateTime OpenDate { get; set; }

        public SupplierJuridicalDTO(string companyName, string cnpj, DateTime openDate,bool active,
                                    string fantasyName, EmailDTO email, AddressDTO address,
                                    ICollection<PhoneDTO> phone) : base(active, fantasyName, email, address, phone)
        {
            CompanyName = companyName;
            Cnpj = cnpj;
            OpenDate = openDate;
        }
        public override ValidationResult IsValid(){
            return new SupplierJuridicalValidator().Validate(this);
        }
    }
    public class SupplierJuridicalValidator : AbstractValidator<SupplierJuridicalDTO>
    {
        public SupplierJuridicalValidator()
        {
            RuleFor(x => x.CompanyName)
                    .MaximumLength(256)
                    .WithMessage("the Company Name field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Company Name is null");
            RuleFor(x => x.Cnpj)
                    .MaximumLength(14)
                    .WithMessage("the CNPJ field for can have up to 14 digits")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("CNPJ is null");
        }
    }
}