using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business
{
    public class UserBusiness
    {
        
        ValidateClassUser validate = new ValidateClassUser();
        Utils.UserUtils UtilsUser = new Utils.UserUtils();
        Database.UserDatabase DtUser = new Database.UserDatabase(); 
        public Models.Response.UserResponse CreateAccount(Models.Request.UserRequest req){

            validate.IsFieldsNull(req);

            if(!req.username.Contains(" ") == true)
                throw new ArgumentException("put your first name and last name");

            if(!validate.IsEmailValid(req.emailuser) == true)
                throw new ArgumentException("These email is invalid");

            if(req.newpassword != req.confirmpassword)
                throw new ArgumentException("The passwords are not the same");

            if(!validate.IsValidPassword(req.newpassword) == true)
                throw new ArgumentException("These password is invalid");
     
            Models.TbUsuario TbUser = UtilsUser.ConvertToTbUser(req);
            Models.TbUsuario CreatedUser = DtUser.addNewUser(TbUser);
        
            return UtilsUser.ConvertToUserRes(CreatedUser);
        }
    }
}