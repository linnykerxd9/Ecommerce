using System;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Image : Entity
    {
        public string ImagePath { get; private set; }
        public Guid ProductId { get; set; }
        protected Image() { }
        public Image(string imagePath, Guid productId)
        {
            SetImage(imagePath);
            SetProductId(productId);
        }
        public void SetImage(string imagePath){
            if(string.IsNullOrEmpty(imagePath)) throw new DomainExceptions("imagePath is null");

            ImagePath = imagePath;
        }
         public void SetProductId(Guid Id)
        {
            if(Id == Guid.Empty) throw new DomainExceptions("the Product Id attribute cannot be null");
            ProductId = Id;
        }
    }
}