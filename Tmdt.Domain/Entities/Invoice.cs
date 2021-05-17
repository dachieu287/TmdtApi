using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Tmdt.Domain.Entities.Base;

namespace Tmdt.Domain.Entities
{
    [Table("Invoice")]
    public class Invoice : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        //public User User { get; set; }
        public IEnumerable<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
