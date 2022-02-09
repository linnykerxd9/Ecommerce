using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Category : Entity
    {
        public bool Active { get; }
        public string Name { get; }
        protected Category() { }
    }
}