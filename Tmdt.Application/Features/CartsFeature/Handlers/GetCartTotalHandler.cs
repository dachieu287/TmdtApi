using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.CartsFeature.Queries;
using Tmdt.Application.Features.CartsFeature.Responses;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.CartsFeature.Handlers
{
    public class GetCartTotalHandler : IRequestHandler<GetCartTotalQuery, GetCartTotalResponse>
    {
        private readonly ICartService _cartService;

        public GetCartTotalHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<GetCartTotalResponse> Handle(GetCartTotalQuery request, CancellationToken cancellationToken)
        {
            var carts = await _cartService.GetByUserId(request.UserId);
            var response = ApplicationMapper.Mapper.Map<GetCartTotalResponse>(carts);
            return response;
        }
    }
}
