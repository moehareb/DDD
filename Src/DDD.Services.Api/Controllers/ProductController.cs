using System;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers
{
    public class ProductController: ApiController
    {
        private readonly IProductAppService _prodcutAppService;

        public ProductController(
            IProductAppService prodcutAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _prodcutAppService = prodcutAppService;
        }

        [HttpGet]
        [Route("product-management")]
        public IActionResult Get()
        {
            return Response(_prodcutAppService.GetAll());
        }

        [HttpGet]
        [Route("product-management/count")]
        public IActionResult GetProductStatusCount()
        {
            return Response(_prodcutAppService.GetProductStatusCount());
        }

        [HttpGet]
        [Route("product-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var productViewModel = _prodcutAppService.GetById(id);

            return Response(productViewModel);
        }

        [HttpPost]
        [Route("product-management")]
        public IActionResult Post([FromBody] ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _prodcutAppService.Add(productViewModel);

            return Response(productViewModel);
        }

        [HttpPut]
        [Route("product-management")]
        public IActionResult Put([FromBody] ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _prodcutAppService.Update(productViewModel);

            return Response(productViewModel);
        }

        [HttpPut]
        [Route("product-management/sell")]
        public IActionResult SellProduct([FromBody] ProductSellViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _prodcutAppService.SellProduct(productViewModel);

            return Response(productViewModel);
        }


        [HttpDelete]
        [Route("product-management")]
        public IActionResult Delete(Guid id)
        {
            _prodcutAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [Route("product-management/pagination")]
        public IActionResult Pagination(int skip, int take)
        {
            return Response(_prodcutAppService.GetAll(skip, take));
        }
    }
}
