using System;

namespace Ecommerce.Service.DTO
{
    public class AddressDto : EntityDTO
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

        public AddressDto(string zipCode, string street, string number, string neighborhood, string city, string state, string complement, string reference, Guid supplierId)
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
    }
}