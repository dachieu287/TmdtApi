using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.InvoicesFeature.Queries;
using Tmdt.Application.Features.InvoicesFeature.Responses;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.InvoicesFeature.Handlers
{
    public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceResponse>
    {
        private readonly IInvoiceService _invoiceService;

        public GetInvoiceByIdHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public async Task<InvoiceResponse> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceService.GetByIdAsync(request.InvoiceId);
            var response = ApplicationMapper.Mapper.Map<InvoiceResponse>(invoice);

            return response;
        }
    }
}
