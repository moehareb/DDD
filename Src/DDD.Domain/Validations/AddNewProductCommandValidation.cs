using DDD.Domain.Commands;

namespace DDD.Domain.Validations
{
    public class AddNewProductCommandValidation : ProductValidation<AddNewProductCommand>
    {
        public AddNewProductCommandValidation()
        {
            ValidateName();
            ValidateWeight();
        }
    }
}
