using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.ProductsFeature.Queries;
using Tmdt.Application.Features.ProductsFeature.Responses;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.ProductsFeature.Handlers
{
    public class GetProductByFilterHandler : IRequestHandler<GetProductsByFilterQuery, ProductsPagedResponse>
    {
        private readonly IProductService _productRepository;

        public GetProductByFilterHandler(IProductService productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductsPagedResponse> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByFilter(request.Search, request.PageNumber, request.PageSize);
            var totalProduct = await _productRepository.GetTotalProductsByFilter(request.Search);

            var productsPaged = ApplicationMapper.Mapper.Map<IEnumerable<ProductsPagedResponse.Product>>(products);

            var response = new ProductsPagedResponse
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecords = totalProduct,
                TotalPages = Convert.ToInt32(Math.Ceiling((double)totalProduct / request.PageSize)),
                Products = productsPaged
            };

            return response;
        }
    }
}
