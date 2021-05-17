using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.CartsFeature.Commands;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.CartsFeature.Handlers
{
    public class ChangeQuantityHandler : IRequestHandler<ChangeQuantityCommand>
    {
        private readonly ICartService _cartService;

        public ChangeQuantityHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<Unit> Handle(ChangeQuantityCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartService.GetByIdAsync(request.UserId, request.ProductId);
            if (cartItem == null)
            {
                return Unit.Value;
            }
            cartItem.Quantity += request.Increment ? 1 : -1;
            if (cartItem.Quantity == 0)
            {
                await _cartService.DeleteAsync(cartItem);
            }
            else
            {
                await _cartService.UpdateAsync(cartItem);
            }
            return Unit.Value;
        }
    }
}
