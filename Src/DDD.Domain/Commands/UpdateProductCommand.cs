using System;
using DDD.Domain.Models;
using DDD.Domain.Validations;

namespace DDD.Domain.Commands
{
    public class UpdateProductCommand: ProductCommand
    {
        public UpdateProductCommand(Guid id,string name,string barcode,string description,float weight,int qty,Status productStatus)
        {
            Id = id;
            Name = name;
            Barcode = barcode;
            Description = description;
            Weight = weight;
            ProductSatus = productStatus;
            Quantity = qty;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class SellProductCommand : ProductCommand
    {
        public SellProductCommand(Guid id,int qty)
        {
            Id = id;
            Quantity -= qty;
        }

        public override bool IsValid()
        {
            ValidationResult = new SellProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
