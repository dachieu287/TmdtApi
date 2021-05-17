using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Tmdt.Application.Features.CartsFeature.Commands;
using Tmdt.Application.Features.CartsFeature.Responses;
using Tmdt.Domain.Entities;

namespace Tmdt.Application.Mappers
{
    class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<AddToCartCommand, Cart>();
            CreateMap<IEnumerable<Cart>, GetCartTotalResponse>()
                .ForMember(dest => dest.TotalPrice, options => options.MapFrom(src => src.Sum(c => c.Quantity * c.Product.Price)))
                .ForMember(dest => dest.TotalItem, options => options.MapFrom(src => src.Sum(c => c.Quantity)));
            CreateMap<Cart, GetCartDetailResponse>();
        }
    }
}
