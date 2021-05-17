using System.Collections.Generic;
using System.Threading.Tasks;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Interfaces.Base;

namespace Tmdt.Domain.Interfaces
{
    public interface IProductService : IService<Product>
    {
        Task<IReadOnlyList<Product>> GetProductsByFilter(string search, int pageNumber, int pageSize);
        Task<int> GetTotalProductsByFilter(string search);
    }
}
