using System.ComponentModel.DataAnnotations.Schema;
using Tmdt.Domain.Entities.Base;

namespace Tmdt.Domain.Entities
{
    [Table("Cart")]
    public class Cart : Entity
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
