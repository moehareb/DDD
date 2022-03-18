using System.Linq;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Product GetByBarcode(string barcode)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Barcode == barcode);
        }
    }
}
