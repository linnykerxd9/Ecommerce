using System.Collections.Generic;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Costumer : Entity, IAggregateRoot
    {
        public string FullName { get;private set; }
        public string Cpf { get;private set; }
        public Email Email { get;private set; }
        public IEnumerable<ShoppingCart> ShoppingCarts { get;private set; }

        public Costumer(string fullname, string cpf, Email email)
        {
            SetFullName(fullname);
            SetCpf(cpf);
            SetEmail(email);
        }
        public void SetFullName(string fullName){
            StringEmptyOrNull(fullName,"Full name");

            FullName = fullName;
        }
        public void SetCpf(string cpf){
           StringEmptyOrNull(cpf,Cpf);

            Cpf = cpf;
        }
        public void SetEmail(Email email){
            Email = email;
        }

        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }
    }
}