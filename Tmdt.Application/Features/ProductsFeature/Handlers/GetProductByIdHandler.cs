using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.ProductsFeature.Queries;
using Tmdt.Application.Features.ProductsFeature.Responses;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.ProductsFeature.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductService _productRepository;

        public GetProductByIdHandler(IProductService productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            var productResponse = ApplicationMapper.Mapper.Map<ProductResponse>(product);
            return productResponse;
        }
    }
}
