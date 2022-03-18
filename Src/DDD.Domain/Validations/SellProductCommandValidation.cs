using DDD.Domain.Commands;

namespace DDD.Domain.Validations
{
    public class SellProductCommandValidation: ProductValidation<SellProductCommand>
    {
        public SellProductCommandValidation()
        {
            ValidateSellProduct();
        }
    }
}
