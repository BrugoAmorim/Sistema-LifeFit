using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Custom
{
    public class CustomExercExerciseUpdt : Exception
    {
        public string message { get; set; }
        public Models.Request.WorkoutUpdateRequest.exerciseUpdate Exer { get; set; }

        public CustomExercExerciseUpdt(string message, Models.Request.WorkoutUpdateRequest.exerciseUpdate exer){

            this.message = message;
            this.Exer = exer;
        }
    }
}