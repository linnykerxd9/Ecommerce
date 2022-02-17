using System;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class EmailDTO 
    {
        public string EmailAddress { get; set; }
        public Guid SupplierId { get; set; }

        public EmailDTO(string emailAddress, Guid supplierId)
        {
            EmailAddress = emailAddress;
            SupplierId = supplierId;
        }
    public ValidationResult Validate(){
            return new EmailValidator().Validate(this);
        }
    }
    public class EmailValidator : AbstractValidator<EmailDTO>
    {
        public EmailValidator()
        {
            RuleFor(x => x.EmailAddress)
                    .MaximumLength(256)
                    .WithMessage("the Email address field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Email address is null");
        }
    }
}