using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmdt.Domain.Entities;

namespace Tmdt.Infrastructure.Persistence.Data.Config
{
    class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => new { c.UserId, c.ProductId });
        }
    }
}
