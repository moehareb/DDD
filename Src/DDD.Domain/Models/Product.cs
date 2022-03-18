using System;
using System.Collections.Generic;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Product : EntityAudit
    {
        public Product(Guid id,string name, string barcode, string description, float weight,int qty, Status productSatus, ICollection<Category> categories)
        {
            Id = id;
            Name = name;
            Barcode = barcode;
            Description = description;
            Weight = weight;
            ProductSatus = productSatus;
            Categories = categories;
            Quantity = qty;
        }

        protected Product() { }

        public string Name { get; private set; }
        public string Barcode { get; private set; }
        public string Description { get; private set; }
        public float Weight { get; private set; }
        public int Quantity { get; set; }

        public Status ProductSatus { get; private set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
