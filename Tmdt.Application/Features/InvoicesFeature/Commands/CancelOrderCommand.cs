using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmdt.Application.Features.InvoicesFeature.Responses;

namespace Tmdt.Application.Features.InvoicesFeature.Commands
{
    public class CancelOrderCommand : IRequest<CancelOrderResponse>
    {
        public int InvoiceId { get; set; }
        public CancelOrderCommand(int invoiceId)
        {
            InvoiceId = invoiceId;
        }
    }
}
