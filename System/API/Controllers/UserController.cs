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
    }
}