using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.CartsFeature.Commands;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.CartsFeature.Handlers
{
    public class AddToCartHandler : IRequestHandler<AddToCartCommand>
    {
        private readonly ICartService _cartService;

        public AddToCartHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<Unit> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = ApplicationMapper.Mapper.Map<Cart>(request);
            await _cartService.AddAsync(cart);
            return Unit.Value;
        }
    }
}
