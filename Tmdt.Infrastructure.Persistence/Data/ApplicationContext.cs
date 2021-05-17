using Microsoft.EntityFrameworkCore;
using Tmdt.Domain.Entities;
using Tmdt.Infrastructure.Persistence.Data.Config;

namespace Tmdt.Infrastructure.Persistence.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .ApplyConfiguration(new CartConfig())
                .ApplyConfiguration(new InvoiceDetailsConfig());
        }
    }
}
