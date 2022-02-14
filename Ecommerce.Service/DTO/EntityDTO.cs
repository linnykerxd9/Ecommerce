using System;

namespace Ecommerce.Service.DTO
{
    public abstract class EntityDTO
    {
        public Guid Id { get; private set; }
        public DateTime InsertDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        protected EntityDTO()
        {
            Id = Guid.NewGuid();
        }
    }
}