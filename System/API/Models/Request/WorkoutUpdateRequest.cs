using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class WorkoutUpdateRequest
    {
        public string routinename { get; set; }
        public string duration { get; set; }
        public List<WorkoutUpdateRequest.exerciseUpdate> exs { get; set; }

        public class exerciseUpdate{
            
            public int idexercise { get; set; }
            public string exercise { get; set; }
            public string seriesandrepeats { get; set; }
            public string restTime{ get; set; }
            public string warmingLoad { get; set; }
            public string maximumLoad { get; set; }
            public int idweekDay { get; set; }
        }
    }
}