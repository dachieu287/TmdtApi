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
    public class DeleteCartItemHandler : IRequestHandler<DeleteCartItemCommand>
    {
        private readonly ICartService _cartService;

        public DeleteCartItemHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartService.GetByIdAsync(request.UserId, request.ProductId);
            await _cartService.DeleteAsync(cartItem);
            return Unit.Value;
        }
    }
}
