using System;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Address : Entity
    {
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Complement { get; private set; }
        public string Reference { get; private set; }

        protected Address() { }
        public Address(string zipCode, string street, string number, string neighborhood, string city, string state)
        {
            SetZipCode(zipCode);
            SetStreet(street);
            SetNumber(number);
            SetNeighborhood(neighborhood);
            SetCity(city);
            SetState(state);
        }
        public void SetState(string state)
        {
            IsNullOrEmpty(state,State);
            State = state;
        }

        public void SetCity(string city)
        {
            IsNullOrEmpty(city,City);
            City = city;
        }

        public void SetNeighborhood(string neighborhood)
        {
            IsNullOrEmpty(neighborhood,Neighborhood);
            Neighborhood = neighborhood;
        }

        public void SetNumber(string number)
        {
            IsNullOrEmpty(number,Number);
            Number = number;
        }

        public void SetStreet(string street)
        {
            IsNullOrEmpty(street,Street);
            Street = street;
        }

        public void SetZipCode(string zipCode)
        {
            IsNullOrEmpty(zipCode,ZipCode);
            ZipCode = zipCode;
        }
        public void SetComplement(string complement)
        {
            IsNullOrEmpty(complement,Complement);
            Complement = complement;
        }
        public void SetReference(string reference)
        {
            IsNullOrEmpty(reference,Reference);
            Reference = reference;
        }
        private void IsNullOrEmpty(string text, string message){
            if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"the {message} attribute cannot be null");
        }
    }
}