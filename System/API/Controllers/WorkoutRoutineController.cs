using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutRoutineController
    {
        
        Business.WorkoutRountineBusiness IsValidRoutine = new Business.WorkoutRountineBusiness();

        [HttpPost("createroutine")]
        public ActionResult<Models.Response.WorkoutRoutineResponse> Create_Workout(Models.Request.WorkoutRoutineRequest routine){

            try{
                
                Models.Response.WorkoutRoutineResponse WorkoutCreated = IsValidRoutine.NewWorkout(routine);
                return WorkoutCreated;
            }
            catch(Models.Custom.CustomExeceptionExercise ex){

                return new BadRequestObjectResult(
                    new Models.Custom.CustomExeceptionExercise(ex.message, ex.jsonExercise)
                );
            }
            catch(Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}