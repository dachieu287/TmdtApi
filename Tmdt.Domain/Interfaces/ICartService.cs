using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Interfaces.Base;

namespace Tmdt.Domain.Interfaces
{
    public interface ICartService : IService<Cart>
    {
        Task<IReadOnlyList<Cart>> GetByUserId(string userId);
        Task<Cart> GetByIdAsync(string userId, int productId);
        Task DeleteRangeAsync(IEnumerable<Cart> cart);
    }
}
