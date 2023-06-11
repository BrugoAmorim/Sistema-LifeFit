using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class LoginRequest
    {
        public string emailuser { get; set; }
        public string passworduser { get; set; }
    }
}