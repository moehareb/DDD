using System;
using DDD.Domain.Core.Events;
using DDD.Domain.Models;

namespace DDD.Domain.Events
{
    public class ProductUpdatedEvent: Event
    {
        public ProductUpdatedEvent(Guid id, string name, string barcode, string description, float weight,int qty, Status productStatus)
        {
            Id = id;
            Name = name;
            Barcode = barcode;
            Description = description;
            Weight = weight;
            Quantity = qty;
            ProductStatus = productStatus;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
        public Status ProductStatus{ get; set; }
    }
}
