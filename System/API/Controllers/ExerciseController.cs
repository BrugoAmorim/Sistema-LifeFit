using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        Utils.ExerciseUtils ExerUtils = new Utils.ExerciseUtils();
        Business.ExerciseBusiness  ExerciseBusiness = new Business.ExerciseBusiness();

        [HttpGet("getexercises/{idroutine}")]
        public ActionResult<List<Models.Response.ExerciseResponse>> get_ExercisesRoutine(int idroutine){

            try{

                List<Models.TbExercicio> exs = ExerciseBusiness.getExercise(idroutine);

                List<Models.Response.ExerciseResponse> exsRes = new List<Models.Response.ExerciseResponse>();
                foreach(Models.TbExercicio e in exs){

                    exsRes.Add(ExerUtils.ConvertTbtoResExercise(e));
                }

                return exsRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpDelete("deletexercise/{iduser}/{idroutine}/{idexer}")]
        public ActionResult<Models.Response.SuccessResponse> deleteExercise(int iduser, int idroutine, int idexer){

            try{

                Business.ExerciseBusiness validation = new Business.ExerciseBusiness();
                validation.delExercise(idexer, idroutine, iduser);

                return new Models.Response.SuccessResponse("This exercise has been deleted", 200); 
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}