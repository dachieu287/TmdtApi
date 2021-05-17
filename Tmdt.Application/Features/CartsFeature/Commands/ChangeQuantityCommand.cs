using MediatR;

namespace Tmdt.Application.Features.CartsFeature.Commands
{
    public class ChangeQuantityCommand : IRequest
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public bool Increment { get; set; }
    }
}
