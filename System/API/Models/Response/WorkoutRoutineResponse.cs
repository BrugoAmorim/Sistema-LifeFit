using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Response
{
    public class WorkoutRoutineResponse
    {
    
        public int idworkoutroutine { get; set; }
        public string routinename { get; set; }
        public string duration { get; set; }
        public int? iduser { get; set; }
        public string username { get; set; }
        public DateTime dtcreated { get; set; }
        public List<Models.Response.ExerciseResponse> exercises { get; set; }
    }
}