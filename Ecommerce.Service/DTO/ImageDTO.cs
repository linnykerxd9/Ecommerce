using System;

namespace Ecommerce.Service.DTO
{
    public class ImageDTO : EntityDTO
    {
         public string ImagePath { get; set; }
        public Guid ProductId { get; set; }

        public ImageDTO(string imagePath, Guid productId)
        {
            ImagePath = imagePath;
            ProductId = productId;
        }
    }
}