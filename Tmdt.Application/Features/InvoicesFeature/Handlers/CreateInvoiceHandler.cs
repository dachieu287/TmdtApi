using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.InvoicesFeature.Commands;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Enums;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.InvoicesFeature.Handlers
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand>
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ICartService _cartService;

        public CreateInvoiceHandler(IInvoiceService invoiceService, ICartService cartService)
        {
            _invoiceService = invoiceService;
            _cartService = cartService;
        }
        public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartService.GetByUserId(request.UserId);
            var invoiceDetails = ApplicationMapper.Mapper.Map<IEnumerable<InvoiceDetails>>(cart);
            var invoice = new Invoice
            {
                UserId = request.UserId,
                OrderDate = DateTime.Now,
                Status = InvoiceStatus.Processing,
                TotalPrice = cart.Sum(c => c.Product.Price * c.Quantity),
                InvoiceDetails = invoiceDetails
            };
            await _invoiceService.AddAsync(invoice);
            await _cartService.DeleteRangeAsync(cart);
            return Unit.Value;
        }
    }
}
