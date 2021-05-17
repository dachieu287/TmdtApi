using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmdt.Domain.Entities;

namespace Tmdt.Infrastructure.Persistence.Data.Config
{
    class InvoiceDetailsConfig : IEntityTypeConfiguration<InvoiceDetails>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetails> builder)
        {
            builder.HasKey(i => new { i.InvoiceId, i.ProductId });
        }
    }
}
