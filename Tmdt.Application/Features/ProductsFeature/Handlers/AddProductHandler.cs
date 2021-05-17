using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.ProductsFeature.Commands;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.ProductsFeature.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IProductService _productRepository;

        public AddProductHandler(IProductService productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            fileName += Path.GetExtension(request.Image.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);
            using (var stream = File.Create(filePath))
            {
                await request.Image.CopyToAsync(stream);
            }

            var product = ApplicationMapper.Mapper.Map<Product>(request);
            product.ImageUrl = fileName;
            await _productRepository.AddAsync(product);

            return Unit.Value;
        }
    }
}
