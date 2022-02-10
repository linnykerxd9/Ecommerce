using System.Collections.Generic;
using ECommerce.Domain.Interface;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Category : Entity, IAggregateRoot
    {
        public bool Active { get; }
        public string Name { get; }
        public IEnumerable<Product> Products { get; } = new List<Product>();
        protected Category() { }
    }
}