using MediatR;
using Tmdt.Application.Features.InvoicesFeature.Responses;

namespace Tmdt.Application.Features.InvoicesFeature.Queries
{
    public class GetInvoiceByIdQuery : IRequest<InvoiceResponse>
    {
        public int InvoiceId { get; set; }
        public GetInvoiceByIdQuery(int invoiceId)
        {
            InvoiceId = invoiceId;
        }
    }
}
