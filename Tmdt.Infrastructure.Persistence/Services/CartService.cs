using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmdt.Domain.Entities;
using Tmdt.Domain.Interfaces;
using Tmdt.Infrastructure.Persistence.Data;
using Tmdt.Infrastructure.Persistence.Services.Base;

namespace Tmdt.Infrastructure.Persistence.Services
{
    public class CartService : Service<Cart>, ICartService
    {
        public CartService(ApplicationContext context) : base(context)
        {
        }

        public new async Task AddAsync(Cart entity)
        {
            var  cart = await _context.Carts.FindAsync(entity.UserId, entity.ProductId);
            if (cart != null)
            {
                cart.Quantity += entity.Quantity;
            }
            else
            {
                cart = new()
                {
                    UserId = entity.UserId,
                    ProductId = entity.ProductId,
                    Quantity = entity.Quantity
                };
                _context.Carts.Add(cart);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<Cart> cart)
        {
            _context.Carts.RemoveRange(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetByIdAsync(string userId, int productId)
        {
            var cartItem = await _context.Carts.FindAsync(userId, productId);
            return cartItem;
        }

        public async Task<IReadOnlyList<Cart>> GetByUserId(string userId)
        {
            return await _context.Carts
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ToListAsync();
        }
    }
}
