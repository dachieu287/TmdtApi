using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmdt.Domain.Enums
{
    public class InvoiceStatus
    {
        public const string Processing = "Processing";
        public const string Shipping = "Shipping";
        public const string Done = "Done";
        public const string Cancelled = "Cancelled";
    }
}
