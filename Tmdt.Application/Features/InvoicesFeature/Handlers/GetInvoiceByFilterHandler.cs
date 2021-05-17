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
    public class GetInvoiceByFilterHandler : IRequestHandler<GetInvoicesByFilterQuery, GetInvoicesByFilterResponse>
    {
        private readonly IInvoiceService _invoiceService;

        public GetInvoiceByFilterHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public async Task<GetInvoicesByFilterResponse> Handle(GetInvoicesByFilterQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceService.GetByFilter(request.PageNumber, request.PageSize);
            var totalRecord = await _invoiceService.GetTotalInvoice();
            var response = new GetInvoicesByFilterResponse
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecords = totalRecord,
                TotalPages = Convert.ToInt32(Math.Ceiling((double)totalRecord / request.PageSize)),
                Invoices = ApplicationMapper.Mapper.Map<IEnumerable<InvoiceResponse>>(invoices)
            };
            return response;
        }
    }
}
