using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class WorkoutRoutineRequest
    {
        public string routinename { get; set;}
        public string duration { get; set; }
        public int? iduser { get; set; }
        public List<Models.Request.ExercisesRequest> exercise { get; set; }

    }
}