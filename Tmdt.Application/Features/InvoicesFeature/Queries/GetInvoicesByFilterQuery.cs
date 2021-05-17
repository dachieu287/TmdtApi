using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmdt.Application.Features.InvoicesFeature.Responses;

namespace Tmdt.Application.Features.InvoicesFeature.Queries
{
    public class GetInvoicesByFilterQuery : IRequest<GetInvoicesByFilterResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
