using DDD.Domain.Commands;

namespace DDD.Domain.Validations
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
