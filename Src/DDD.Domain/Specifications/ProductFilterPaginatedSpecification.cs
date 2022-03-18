using DDD.Domain.Models;

namespace DDD.Domain.Specifications
{
    public class ProductFilterPaginatedSpecification : BaseSpecification<Product>
    {
        public ProductFilterPaginatedSpecification(int skip,int take): base(i=> true)
        {
            ApplyPaging(skip,take);
        }
    }
}
