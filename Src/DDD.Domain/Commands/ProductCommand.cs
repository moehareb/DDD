using System;
using DDD.Domain.Core.Commands;
using DDD.Domain.Models;

namespace DDD.Domain.Commands
{
    public abstract class ProductCommand: Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
        public string Barcode { get; protected set; }
        public string Description { get; protected set; }
        public float Weight { get; protected set; }
        public int Quantity { get; protected set; }
        public Status ProductSatus { get; protected set; }
    }
}
