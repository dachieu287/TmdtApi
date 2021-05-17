using MediatR;
using System;
using System.Collections.Generic;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Enums;

namespace Tmdt.Application.Features.InvoicesFeature.Commands
{
    public class CreateInvoiceCommand : IRequest
    {
        public string UserId { get; set; }

        public CreateInvoiceCommand(string userId)
        {
            UserId = userId;
        }
    }
}
