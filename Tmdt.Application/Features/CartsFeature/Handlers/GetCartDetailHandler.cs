using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.CartsFeature.Queries;
using Tmdt.Application.Features.CartsFeature.Responses;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.CartsFeature.Handlers
{
    public class GetCartDetailHandler : IRequestHandler<GetCartDetailQuery, IEnumerable<GetCartDetailResponse>>
    {
        private readonly ICartService _cartService;

        public GetCartDetailHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IEnumerable<GetCartDetailResponse>> Handle(GetCartDetailQuery request, CancellationToken cancellationToken)
        {
            var carts = await _cartService.GetByUserId(request.UserId);
            var response = ApplicationMapper.Mapper.Map<IEnumerable<GetCartDetailResponse>>(carts);
            return response;
        }
    }
}
