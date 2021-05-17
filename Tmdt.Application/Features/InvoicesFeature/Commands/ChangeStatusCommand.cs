using MediatR;
using Tmdt.Application.Features.InvoicesFeature.Responses;

namespace Tmdt.Application.Features.InvoicesFeature.Commands
{
    public class ChangeStatusCommand : IRequest<BaseReponse>
    {
        public int InvoiceId { get; set; }
        public string Status { get; set; }
    }
}
