using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Response
{
    public class ErrorResponse
    {
        public string message { get; set; }
        public int error { get; set; }

        public ErrorResponse(string message, int error){

            this.message = message;
            this.error = error;
        }
    }
}