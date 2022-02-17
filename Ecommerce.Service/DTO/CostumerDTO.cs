using Ecommerce.Service.Tools;
using ECommerce.Domain.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Service.DTO
{
    public class CostumerDTO 
    {
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public EmailDTO Email { get; set; }

        public CostumerDTO(string fullName, string cpf, EmailDTO email)
        {
            FullName = fullName;
            Cpf = cpf;
            Email = email;
        }
        public ValidationResult Validate(){
            return new CostumerValidator().Validate(this);
        }
        public Costumer ToDomain()
        {
            return new Costumer(FullName,Cpf,new Email(Email.EmailAddress));
        }
    }
    public class CostumerValidator : AbstractValidator<CostumerDTO>
    {
        public CostumerValidator()
        {
            RuleFor(x => x.FullName)
                    .MaximumLength(256)
                    .WithMessage("the Full Name field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Full Name is null");
            RuleFor(x => x.Cpf)
                    .Length(11)
                    .WithMessage("the field needs to be 11 characters long")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Cpf is null");
        }
    }
}