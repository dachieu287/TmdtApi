using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.ProductsFeature.Commands;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.ProductsFeature.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _productRepository;

        public DeleteProductHandler(IProductService productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            await _productRepository.DeleteAsync(product);
            return Unit.Value;
        }
    }
}
