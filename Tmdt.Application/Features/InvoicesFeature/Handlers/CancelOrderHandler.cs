using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.InvoicesFeature.Commands;
using Tmdt.Application.Features.InvoicesFeature.Responses;
using Tmdt.Domain.Enums;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.InvoicesFeature.Handlers
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, CancelOrderResponse>
    {
        private readonly IInvoiceService _invoiceService;

        public CancelOrderHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public async Task<CancelOrderResponse> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceService.GetByIdAsync(request.InvoiceId);
            if (invoice == null)
            {
                return new CancelOrderResponse
                {
                    Succeeded = false,
                    Message = "Không có mã đơn hàng này"
                };
            }

            if (invoice.Status != InvoiceStatus.Processing)
            {
                return new CancelOrderResponse
                {
                    Succeeded = false,
                    Message = $"Hóa đơn đã xử lý không thể hủy",
                };
            }

            invoice.Status = InvoiceStatus.Cancelled;
            await _invoiceService.UpdateAsync(invoice);

            return new CancelOrderResponse
            {
                Succeeded = true,
                Message = $"Hủy đơn hàng thành công"
            };
        }
    }
}
