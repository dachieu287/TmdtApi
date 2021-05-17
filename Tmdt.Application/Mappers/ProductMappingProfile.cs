using AutoMapper;
using Tmdt.Application.Features.ProductsFeature.Commands;
using Tmdt.Application.Features.ProductsFeature.Responses;
using Tmdt.Domain.Entities;

namespace Tmdt.Application.Mappers
{
    class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<Product, ProductsPagedResponse.Product>();
            CreateMap<AddProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
