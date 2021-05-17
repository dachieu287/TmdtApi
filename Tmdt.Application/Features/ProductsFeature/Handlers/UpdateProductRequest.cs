using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tmdt.Application.Features.ProductsFeature.Commands;
using Tmdt.Application.Mappers;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Interfaces;

namespace Tmdt.Application.Features.ProductsFeature.Handlers
{
    public class UpdateProductRequest : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductService _productRepository;

        public UpdateProductRequest(IProductService productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productOld = await _productRepository.GetByIdAsync(request.Id);
            var product =  ApplicationMapper.Mapper.Map<Product>(request);
            product.ImageUrl = productOld.ImageUrl;
            if (request.Image != null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", product.ImageUrl ?? "");
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                string newFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                newFileName += Path.GetExtension(request.Image.FileName);

                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", newFileName);

                using (var stream = File.Create(filePath))
                {
                    await request.Image.CopyToAsync(stream);
                }
                product.ImageUrl = newFileName;
                
            }
            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
