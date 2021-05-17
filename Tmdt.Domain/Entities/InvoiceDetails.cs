using System.ComponentModel.DataAnnotations.Schema;
using Tmdt.Domain.Entities.Base;

namespace Tmdt.Domain.Entities
{
    [Table("InvoiceDetails")]
    public class InvoiceDetails : Entity
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}
