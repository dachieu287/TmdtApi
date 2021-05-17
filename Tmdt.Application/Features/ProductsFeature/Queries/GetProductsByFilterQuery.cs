using MediatR;
using Tmdt.Application.Features.ProductsFeature.Responses;

namespace Tmdt.Application.Features.ProductsFeature.Queries
{
    public class GetProductsByFilterQuery : IRequest<ProductsPagedResponse>
    {
        public string Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        /*public GetProductsByFilterQuery(string search, int pageNumber, int pageSize)
        {
            Search = search;
            PageNumber = pageNumber;
            PageSize = pageSize < 1 ? 1 : (pageSize > 12 ? 12 : pageSize);
        }*/
    }
}
