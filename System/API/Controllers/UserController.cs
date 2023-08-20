using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        Business.UserBusiness userBusiness = new Business.UserBusiness();

        [HttpGet("GetmyData/{iduser}")]
        public ActionResult<Models.Response.UserResponse> GetUserData(int iduser){

            try{
                Models.Response.UserResponse boxRes = userBusiness.GetUserData(iduser);
                return boxRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpDelete("DeleteAllWorkout/{iduser}")]
        public ActionResult<Models.Response.SuccessResponse> DeleteAllUserWorkout(int iduser){

            try{
                userBusiness.DeleteAllUserWorkout(iduser);
                return new Models.Response.SuccessResponse("you deleted all your exercise routines", 200);
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpDelete("DeleteMyAccount/{iduser}")]
        public ActionResult<Models.Response.SuccessResponse> deleteMyAccount(int iduser, string password){

            try{
                userBusiness.DeleteMyAccount(iduser, password);
                return new Models.Response.SuccessResponse("Account has been deleted", 200);
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}