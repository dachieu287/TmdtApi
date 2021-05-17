using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Interfaces;
using Tmdt.Infrastructure.Persistence.Data;
using Tmdt.Infrastructure.Persistence.Services.Base;

namespace Tmdt.Infrastructure.Persistence.Services
{
    public class InvoiceService : Service<Invoice>, IInvoiceService
    {
        public InvoiceService(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Invoice>> GetByFilter(int pageNumber, int pageSize)
        {
            return await _context.Invoices
                .OrderByDescending(o => o.OrderDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetByUserIdAsync(string userId)
        {
            return await _context.Invoices
                .Where(i => i.UserId == userId)
                .Include(i => i.InvoiceDetails)
                .OrderByDescending(i => i.OrderDate)
                .ToListAsync();
        }

        public async Task<int> GetTotalInvoice()
        {
            return await _context.Invoices.CountAsync();
        }

        public new async Task<Invoice> GetByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.InvoiceDetails)
                .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
