using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmdt.Application.Features.InvoicesFeature.Commands;
using Tmdt.Application.Features.InvoicesFeature.Responses;
using Tmdt.Domain.Entities;

namespace Tmdt.Application.Mappers
{
    class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Cart, InvoiceDetails>()
                .ForMember(dest => dest.ProductName, options => options.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, options => options.MapFrom(src => src.Product.Price));
            CreateMap<Invoice, InvoiceResponse>();
            CreateMap<InvoiceDetails, InvoiceResponse.InvoiceDetailsResponse>();
                
        }
    }
}
