using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessController : ControllerBase
    {
        Business.UserBusiness business = new Business.UserBusiness();

        // this function is only for tests
        [HttpGet("listUsers")]
        public List<Models.TbUsuario> getusers(){

            Models.DbLifeFitContext db = new Models.DbLifeFitContext();

            List<Models.TbUsuario> users = db.TbUsuarios.ToList();
            return users;
        }
    
        [HttpPost("createaccount")]
        public ActionResult<Models.Response.UserResponse> create_Account(Models.Request.UserRequest UserReq){

            try{
                Models.Response.UserResponse User = business.CreateAccount(UserReq);
                return User;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpPost("loginaccount")]
        public ActionResult<Models.Response.UserResponse> login_Account(Models.Request.LoginRequest UserLogin){

            try{
                Models.Response.UserResponse LoginUserRes = business.LoginAccount(UserLogin);
                return LoginUserRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}