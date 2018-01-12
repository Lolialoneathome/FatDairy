using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Auth
{
    public class AppUser : IAppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
