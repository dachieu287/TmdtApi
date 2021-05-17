using System.Collections.Generic;
using System.Threading.Tasks;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Interfaces.Base;

namespace Tmdt.Domain.Interfaces
{
    public interface IInvoiceService : IService<Invoice>
    {
        Task<IEnumerable<Invoice>> GetByUserIdAsync(string userId);
        Task<IEnumerable<Invoice>> GetByFilter(int pageNumber, int pageSize);
        Task<int> GetTotalInvoice();
    }
}
