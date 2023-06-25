using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Response
{
    public class MyRoutinesResponse
    {
        public int idRoutine { get; set; }
        public string Routinename { get; set; }
        public string Duration { get; set; }
        public DateTime RoutineCreated { get; set; }
    }
}