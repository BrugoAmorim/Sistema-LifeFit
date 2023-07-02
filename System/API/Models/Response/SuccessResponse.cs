using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Response
{
    public class SuccessResponse
    {
        public string message { get; set; }
        public int code { get; set; }

        public SuccessResponse(string message, int code){

            this.message = message;
            this.code = code;
        }
    }
}