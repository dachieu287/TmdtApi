using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmdt.Application.Features.InvoicesFeature.Responses
{
    public class BaseReponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
