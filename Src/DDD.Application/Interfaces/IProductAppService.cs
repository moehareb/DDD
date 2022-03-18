using System;
using System.Collections.Generic;
using DDD.Application.ViewModels;

namespace DDD.Application.Interfaces
{
    public interface IProductAppService: IDisposable
    {
        void Add(ProductViewModel productViewModel);
        IEnumerable<ProductViewModel> GetAll();
        IEnumerable<ProductStatusCountViewModel> GetProductStatusCount();
        IEnumerable<ProductViewModel> GetAll(int skip, int take);
        ProductViewModel GetById(Guid id);
        void Update(ProductViewModel productViewModel);
        void SellProduct(ProductSellViewModel productSellViewModel);
        void Remove(Guid id);
    }
}
