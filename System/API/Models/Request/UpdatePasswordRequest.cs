using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class UpdatePasswordRequest
    {
        public string password { get; set; }
        public string newpassword { get; set; }
        public string confirmpassword { get; set; }
    }
}