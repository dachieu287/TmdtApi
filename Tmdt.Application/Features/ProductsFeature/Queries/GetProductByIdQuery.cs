using MediatR;
using Tmdt.Application.Features.ProductsFeature.Responses;

namespace Tmdt.Application.Features.ProductsFeature.Queries
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
