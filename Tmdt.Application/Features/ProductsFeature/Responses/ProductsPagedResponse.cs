using System.Collections.Generic;

namespace Tmdt.Application.Features.ProductsFeature.Responses
{
    public class ProductsPagedResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}
