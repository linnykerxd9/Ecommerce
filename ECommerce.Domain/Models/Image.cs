using System;
using ECommerce.Domain.Tools;

namespace ECommerce.Domain.Models
{
    public class Image : Entity
    {
        public string ImagePath { get; private set; }
        protected Image() { }
        public Image(string imagePath)
        {
            SetImage(imagePath);
        }
        public void SetImage(string imagePath){
            if(string.IsNullOrEmpty(imagePath)) throw new DomainExceptions("imagePath is null");

            ImagePath = imagePath;
        }
    }
}