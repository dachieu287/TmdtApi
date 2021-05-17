using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmdt.Application.Features.InvoicesFeature.Responses
{
    public class GetInvoicesByFilterResponse 
    { 
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<InvoiceResponse> Invoices { get; set; }
    }
}
