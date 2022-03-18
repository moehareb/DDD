using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Interfaces;
using DDD.Domain.Specifications;

namespace DDD.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler Bus;
        public ProductAppService(IProductRepository productRepository,IMapper mapper,IMediatorHandler bus)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            Bus = bus;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _productRepository.GetAll().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<ProductStatusCountViewModel> GetProductStatusCount()
        {
            var products = _productRepository.GetAll().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);

            var objToReturn = products.Select(x => new ProductStatusCountViewModel()
            {
                ProductSatus = x.ProductSatus,
                Count = products.Count(p=>p.ProductSatus == x.ProductSatus)
            }).Distinct();

            return objToReturn;
        }

        public IEnumerable<ProductViewModel> GetAll(int skip, int take)
        {
            return _productRepository.GetAll(new ProductFilterPaginatedSpecification(skip, take))
                            .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public void Add(ProductViewModel productViewModel)
        {
            var addCommand = _mapper.Map<AddNewProductCommand>(productViewModel);
            Bus.SendCommand(addCommand);
        }
        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProductCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(ProductViewModel productViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
            Bus.SendCommand(updateCommand);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void SellProduct(ProductSellViewModel productViewModel)
        {
            var sellCommand = _mapper.Map<SellProductCommand>(productViewModel);
            Bus.SendCommand(sellCommand);
        }
    }
}
