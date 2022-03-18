using DDD.Application.Interfaces;
using DDD.Application.Services;
using DDD.Domain.CommandHandlers;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Events;
using DDD.Domain.Core.Notifications;
using DDD.Domain.EventHandlers;
using DDD.Domain.Events;
using DDD.Domain.Interfaces;
using DDD.Domain.Services;
using DDD.Infra.CrossCutting.Bus;
using DDD.Infra.Data.Repository;
using DDD.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddHttpContextAccessor();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

            // Domain - Commands

            services.AddScoped<IRequestHandler<AddNewProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<SellProductCommand, bool>, ProductCommandHandler>();

            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
