﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace ShopBridgeAPI.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
