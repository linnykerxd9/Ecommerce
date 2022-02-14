using System.Collections.Generic;

namespace Ecommerce.Service.DTO
{
    public class SupplierDTO : EntityDTO
    {
        public bool Active { get;  set; }
        public string FantasyName { get;  set; }
        public EmailDTO Email { get; set; }
        public AddressDto Address { get; set; }
        public ICollection<PhoneDTO> Phone { get; set; } = new List<PhoneDTO>();

        public SupplierDTO(bool active, string fantasyName, EmailDTO email, AddressDto address, ICollection<PhoneDTO> phone)
        {
            Active = active;
            FantasyName = fantasyName;
            Email = email;
            Address = address;
            Phone = phone;
        }
    }
}