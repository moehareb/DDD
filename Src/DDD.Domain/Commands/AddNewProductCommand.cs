using DDD.Domain.Models;
using DDD.Domain.Validations;

namespace DDD.Domain.Commands
{
    public class AddNewProductCommand: ProductCommand
    {
        public AddNewProductCommand(string name,string barcode,string description,float weight,int qty,Status status)
        {
            Name = name;
            Barcode = barcode;
            Description = description;
            Weight = weight;
            ProductSatus = status;
            Quantity = qty;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
