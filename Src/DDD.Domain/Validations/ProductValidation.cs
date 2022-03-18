using System;
using DDD.Domain.Commands;
using FluentValidation;

namespace DDD.Domain.Validations
{
    public abstract class ProductValidation<T>: AbstractValidator<T> where T: ProductCommand
    {
        protected void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateWeight()
        {
            RuleFor(p => p.Weight)
                .Must(HaveMinimumAndMaxWightRange)
                .WithMessage("Weight must be between 0.5Kg and 100Kg");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateSellProduct()
        {
            RuleFor(p => p.Quantity)
                .Must(ProductQuantityMustBeGreateerThanZero)
                .WithMessage("No Suffient Qty");
        }

        protected static bool HaveMinimumAndMaxWightRange(float weight)
        {
            return weight > 0.5 && weight < 200;
        }

        protected static bool ProductQuantityMustBeGreateerThanZero(int qty)
        {
            return qty >= 0;
        }
    }
}
