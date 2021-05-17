using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.InvoicesFeature.Queries;
using Tmdt.Application.Features.InvoicesFeature.Responses;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.InvoicesFeature.Handlers
{
    public class GetHistoryOrderHandler : IRequestHandler<GetHistoryOrderQuery, IEnumerable<InvoiceResponse>>
    {
        private readonly IInvoiceService _invoiceService;

        public GetHistoryOrderHandler(IInvoiceService invoiceService)
        { 
            _invoiceService = invoiceService;
        }
        public async Task<IEnumerable<InvoiceResponse>> Handle(GetHistoryOrderQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceService.GetByUserIdAsync(request.UserId);
            var response = ApplicationMapper.Mapper.Map<IEnumerable<InvoiceResponse>>(invoices);
            return response;
        }
    }
}
