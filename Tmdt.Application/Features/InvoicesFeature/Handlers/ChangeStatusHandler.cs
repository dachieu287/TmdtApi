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
    public class ChangeStatusHandler : IRequestHandler<ChangeStatusCommand, BaseReponse>
    {
        private readonly IInvoiceService _invoiceService;

        public ChangeStatusHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public async Task<BaseReponse> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceService.GetByIdAsync(request.InvoiceId);

            if (invoice == null)
            {
                return new BaseReponse
                {
                    Succeeded = false,
                    Message = $"Không có mã hóa đơn { request.InvoiceId }"
                };
            }

            if (request.Status != InvoiceStatus.Processing && request.Status != InvoiceStatus.Shipping && request.Status != InvoiceStatus.Done && request.Status != InvoiceStatus.Cancelled)
            {
                return new BaseReponse
                {
                    Succeeded = false,
                    Message = $"Trạng thái không hợp lệ"
                };
            }

            invoice.Status = request.Status;
            await _invoiceService.UpdateAsync(invoice);
            return new BaseReponse
            {
                Succeeded = true,
                Message = $"Thành công"
            };
        }
    }
}
