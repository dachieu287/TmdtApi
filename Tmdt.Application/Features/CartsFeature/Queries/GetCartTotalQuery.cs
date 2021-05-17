using MediatR;
using Tmdt.Application.Features.CartsFeature.Responses;

namespace Tmdt.Application.Features.CartsFeature.Queries
{
    public class GetCartTotalQuery : IRequest<GetCartTotalResponse>
    {
        public string UserId { get; set; }
        public GetCartTotalQuery(string userId)
        {
            UserId = userId;
        }
    }
}
