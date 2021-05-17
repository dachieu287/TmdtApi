using MediatR;
using System.Collections.Generic;
using Tmdt.Application.Features.InvoicesFeature.Responses;

namespace Tmdt.Application.Features.InvoicesFeature.Queries
{
    public class GetHistoryOrderQuery : IRequest<IEnumerable<InvoiceResponse>>
    {
        public string UserId { get; set; }
        public GetHistoryOrderQuery(string userId)
        {
            UserId = userId;
        }
    }
}
