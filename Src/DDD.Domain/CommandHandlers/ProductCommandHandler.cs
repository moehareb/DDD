using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Events;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using MediatR;

namespace DDD.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<AddNewProductCommand, bool>,
        IRequestHandler<UpdateProductCommand, bool>,
        IRequestHandler<RemoveProductCommand, bool>,
        IRequestHandler<SellProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public ProductCommandHandler(IProductRepository productRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            Bus = bus;
        }

        public Task<bool> Handle(AddNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var product = new Product(Guid.NewGuid(), message.Name, message.Barcode, message.Description, message.Weight, message.Quantity, message.ProductSatus, null);

            if (_productRepository.GetByBarcode(product.Barcode) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The product barcode has already been used."));
                return Task.FromResult(false);
            }

            _productRepository.Add(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductAddedEvent(product.Id, product.Name, product.Barcode, product.Description, product.Weight, product.ProductSatus));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var product = new Product(message.Id, message.Name, message.Barcode, message.Description, message.Weight, message.Quantity, message.ProductSatus, null);
            var existingProdcut = _productRepository.GetByBarcode(product.Barcode);

            if (existingProdcut != null && existingProdcut.Id != product.Id)
            {
                if (!existingProdcut.Equals(product))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The product barcode has already been used."));
                    return Task.FromResult(false);
                }
            }

            _productRepository.Update(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductUpdatedEvent(message.Id, message.Name, message.Barcode, message.Description, message.Weight, message.Quantity, message.ProductSatus));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(SellProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingProdcut = _productRepository.GetById(message.Id);
            var product = new Product(existingProdcut.Id, existingProdcut.Name, existingProdcut.Barcode, existingProdcut.Description, existingProdcut.Weight, existingProdcut.Quantity, message.ProductSatus, null);

            if (existingProdcut != null && existingProdcut.Id != product.Id)
            {
                if (!existingProdcut.Equals(product))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The product barcode has already been used."));
                    return Task.FromResult(false);
                }
            }

            _productRepository.Update(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductUpdatedEvent(message.Id, message.Name, message.Barcode, message.Description, message.Weight, message.Quantity, message.ProductSatus));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _productRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }

        
    }

}
