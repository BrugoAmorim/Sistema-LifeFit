using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Models.Custom
{
    public class CustomExeceptionExercise : Exception
    {
        public string message { get; set; }
        
        public Models.Request.ExercisesRequest jsonExercise { get; set; }

        public CustomExeceptionExercise(string message, Models.Request.ExercisesRequest details){
            
            this.message = message;
            jsonExercise = details;
        }
    }
}