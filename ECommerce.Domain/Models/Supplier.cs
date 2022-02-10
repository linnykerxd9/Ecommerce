using System.Collections.Generic;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public abstract class Supplier : Entity,IAggregateRoot
    {
         public bool Active { get; private set; }
        public string FantasyName { get; private set; }
        public Email Email { get;private set; }
        public Address Address { get;private set; }
        public ICollection<Phone> Phone { get;private set; } = new List<Phone>();
        public IEnumerable<Product> Product {get;private set;} = new List<Product>();

        protected Supplier(){}

        protected Supplier(bool active, Address address,Email email,List<Phone> phone,string fantasyName)
        {
            SetActive(active);
            SetFantasyName(fantasyName);
            SetAddress(address);
            SetEmail(email);
            SetPhone(phone);
        }
        public void SetActive(bool status) {
            Active = status;
        }
        public void SetEmail(Email email){
            Email = email;
        }
        public void SetAddress(Address address){
            Address = address;
        }
        public void SetPhone(ICollection<Phone> phone){
            foreach (var item in phone)
            {
                  if(string.IsNullOrEmpty(item.Ddd))
                    throw new DomainExceptions("DDD is invalid");
                 if(string.IsNullOrEmpty(item.Number))
                    throw new DomainExceptions("Number is invalid");
            }
            Phone = phone;
        }
          public void SetFantasyName(string fantasyName){
            if(string.IsNullOrEmpty(fantasyName)) 
            throw new DomainExceptions("Fantasy name cannot be empty");

            FantasyName = fantasyName;
        }
    }
}