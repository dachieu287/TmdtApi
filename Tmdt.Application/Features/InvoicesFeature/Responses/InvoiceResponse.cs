using System;
using System.Collections.Generic;

namespace Tmdt.Application.Features.InvoicesFeature.Responses
{
    public class InvoiceResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public IEnumerable<InvoiceDetailsResponse> InvoiceDetails { get; set; }
        public UserReponse User { get; set; }
        public class InvoiceDetailsResponse
        {
            public int InvoiceId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }

        public class UserReponse
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
    }
}
