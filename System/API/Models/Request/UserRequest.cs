using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class UserRequest
    {
        public string username { get; set; }
        public string emailuser { get; set; }
        public string newpassword { get; set; }
        public string confirmpassword { get; set; }
    }
}