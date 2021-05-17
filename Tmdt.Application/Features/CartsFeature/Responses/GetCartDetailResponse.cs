using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmdt.Domain.Entities;

namespace Tmdt.Application.Features.CartsFeature.Responses
{
    public class GetCartDetailResponse
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
