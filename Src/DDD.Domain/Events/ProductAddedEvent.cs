using System;
using DDD.Domain.Core.Events;
using DDD.Domain.Models;

namespace DDD.Domain.Events
{
    public class ProductAddedEvent : Event
    {
        public ProductAddedEvent(Guid id,string name,string barcode,string description,float weight,Status status)
        {
            Id = id;
            Name = name;
            Barcode = barcode;
            Description = description;
            Weight = weight;
            Status = status;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Barcode { get; private set; }
        public string Description { get; private set; }
        public float Weight { get; private set; }
        public Status Status { get; private set; }
    }
}
