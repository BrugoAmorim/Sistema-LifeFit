using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Response
{
    public class UserResponse
    {
        
        public int iduser { get; set; }
        public string nameuser { get; set; }
        public string emailuser { get; set; }
        public DateTime accountcreated { get; set; }
        public DateTime accountupdated { get; set; }
        public int amountworkout { get; set; }
    }
}