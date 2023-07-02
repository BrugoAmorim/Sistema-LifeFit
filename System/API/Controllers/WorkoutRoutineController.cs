using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutRoutineController : ControllerBase
    {
        Utils.WorkoutRountineUtils Workout = new Utils.WorkoutRountineUtils();
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

        [HttpGet("getmyroutine/{iduser}")]
        public ActionResult<List<Models.Response.MyRoutinesResponse>> get_MyWorkout(int iduser){

            try{
                List<Models.TbRotinaTreino> TbMyRoutines = IsValidRoutine.GetMyWorkout(iduser);

                List<Models.Response.MyRoutinesResponse> routs = new List<Models.Response.MyRoutinesResponse>();
                foreach(Models.TbRotinaTreino i in TbMyRoutines){

                    routs.Add(Workout.ConvertToRoutineRes(i));
                }

                return routs;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpDelete("deletemyroutine/{iduser}/{idroutine}")]
        public ActionResult<Models.Response.SuccessResponse> delete_MyWorkout(int iduser, int idroutine){

            try{

                IsValidRoutine.DeleteMyWorkout(iduser, idroutine);
                return new Models.Response.SuccessResponse("The Workout routine has been deleted", 200);
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}