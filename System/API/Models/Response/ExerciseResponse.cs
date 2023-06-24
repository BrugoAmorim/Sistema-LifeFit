using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Response
{
    public class ExerciseResponse
    {
        public int idexercise { get; set; }
        public string exercise { get; set; }
        public string seriesandrepeats { get; set; }
        public string restTime{ get; set; }
        public string warmingLoad { get; set; }
        public string maximumLoad { get; set; }
        public string weekday { get; set; }
        public int idroutine { get; set; }
    }
}