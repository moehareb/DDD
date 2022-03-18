using AutoMapper;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;

namespace DDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, AddNewProductCommand>()
                .ConstructUsing(p => new AddNewProductCommand(p.Name, p.Barcode, p.Description, p.Weight, p.Quantity, p.ProductSatus));
            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(p => new UpdateProductCommand(p.Id, p.Name, p.Barcode, p.Description, p.Weight, p.Quantity, p.ProductSatus));
            CreateMap<ProductSellViewModel, SellProductCommand>()
                .ConstructUsing(p => new SellProductCommand(p.Id, p.Quantity));
        }
    }
}
