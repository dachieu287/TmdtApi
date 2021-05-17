using MediatR;
using Microsoft.AspNetCore.Http;

namespace Tmdt.Application.Features.ProductsFeature.Commands
{
    public class AddProductCommand : IRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
