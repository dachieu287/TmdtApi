using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmdt.Application.Features.CartsFeature.Responses
{
    public class GetCartTotalResponse
    {
        public int TotalItem { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
