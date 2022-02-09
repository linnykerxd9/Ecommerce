using System;

namespace ECommerce.Domain.Tools
{
    public class DomainExceptions : Exception
    {
        public DomainExceptions(string message) : base(message)
        {
        }
    }
}