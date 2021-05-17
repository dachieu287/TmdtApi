using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tmdt.Application.Features.CartsFeature.Commands;
using Tmdt.Application.Features.CartsFeature.Queries;
using Tmdt.Application.Features.CartsFeature.Responses;
using Tmdt.Infrastructure.Identity.Interfaces;

namespace Tmdt.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;

        public CartsController(IMediator mediator, IIdentityService identityService)
        {
            _mediator = mediator;
            _identityService = identityService;
        }

        [HttpPost]
        [Authorize]
        public async Task AddToCart([FromBody] AddToCartCommand request)
        {
            var userId = _identityService.GetUserId(User);
            request.UserId = userId;
            await _mediator.Send(request);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCartTotal()
        {
            var userId = _identityService.GetUserId(User);
            var query = new GetCartTotalQuery(userId);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCartDetail()
        {
            var userId = _identityService.GetUserId(User);
            var request = new GetCartDetailQuery(userId);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangeQuantity([FromBody] ChangeQuantityCommand request)
        {
            var userId = _identityService.GetUserId(User);
            request.UserId = userId;
            await _mediator.Send(request);
            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int productId)
        {
            var userId = _identityService.GetUserId(User);
            var request = new DeleteCartItemCommand
            {
                ProductId = productId,
                UserId = userId
            };
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
