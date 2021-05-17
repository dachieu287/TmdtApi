using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmdt.Application.Features.ProductsFeature.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int ProductId { get; set; }
        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
