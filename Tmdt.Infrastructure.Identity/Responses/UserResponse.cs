using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmdt.Infrastructure.Identity.Responses
{
    public class UserResponse
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
