using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmdt.Application.Features.CartsFeature.Responses;

namespace Tmdt.Application.Features.CartsFeature.Queries
{
    public class GetCartDetailQuery : IRequest<IEnumerable<GetCartDetailResponse>>
    {
        public string UserId { get; set; }
        public GetCartDetailQuery(string userId)
        {
            UserId = userId;
        }
    }
}
