using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class SupplierDTO 
    {
        public bool Active { get;  set; }
        public string FantasyName { get;  set; }
        public EmailDTO Email { get; set; }
        public AddressDTO Address { get; set; }
        public ICollection<PhoneDTO> Phone { get; set; } = new List<PhoneDTO>();

        public SupplierDTO(bool active, string fantasyName, EmailDTO email, AddressDTO address, ICollection<PhoneDTO> phone)
        {
            Active = active;
            FantasyName = fantasyName;
            Email = email;
            Address = address;
            Phone = phone;
        }
    public virtual ValidationResult Validate(){
            return new SupplierValidator().Validate(this);
        }
    }
    public class SupplierValidator : AbstractValidator<SupplierDTO>
    {
        public SupplierValidator()
        {
            RuleFor(x => x.Active)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Active is null");
            RuleFor(x => x.FantasyName)
                    .MaximumLength(256)
                    .WithMessage("the Fantasy Name field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Fantasy Name is null");
        }
    }
}