using DDD.Domain.Models;

namespace DDD.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public Product GetByBarcode(string barcode);        
    }
}
