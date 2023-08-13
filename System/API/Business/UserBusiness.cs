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
                throw new ArgumentException("Put your first name and last name");

            if(!validate.IsEmailValid(req.emailuser) == true)
                throw new ArgumentException("These email is invalid");

            if(!DtUser.listUsers().Any(x => x.DsEmail == req.emailuser) == false)
                throw new ArgumentException("This email already being using");

            if(req.newpassword != req.confirmpassword)
                throw new ArgumentException("The passwords are not the same");

            if(!validate.IsValidPassword(req.newpassword) == true)
                throw new ArgumentException("These password is invalid");

            Models.TbUsuario TbUser = UtilsUser.ConvertToTbUser(req);
            Models.TbUsuario CreatedUser = DtUser.addNewUser(TbUser);
        
            return UtilsUser.ConvertToUserRes(CreatedUser);
        }

        public Models.Response.UserResponse LoginAccount(Models.Request.LoginRequest reqLogin){

            if(string.IsNullOrEmpty(reqLogin.emailuser))
                throw new ArgumentException("The Email field is invalid");

            if(reqLogin.passworduser.Length < 8)
                throw new ArgumentException("These password is invalid");

            if(!validate.IsEmailValid(reqLogin.emailuser) == true)
                throw new ArgumentException("These email is invalid");

            Models.TbUsuario tbUser = DtUser.FirstUser(reqLogin.emailuser);

            if(tbUser == null)
                throw new ArgumentException("This account was not found");

            if(tbUser.DsSenha != reqLogin.passworduser)
                throw new ArgumentException("Password is incorrect");

            return UtilsUser.ConvertToUserRes(tbUser);
        }
    
        public Models.Response.UserResponse GetUserData(int iduser){

            Database.WorkoutRoutineDatabase dbWork = new Database.WorkoutRoutineDatabase();

            Models.TbUsuario userdata = DtUser.UserExist(iduser);
            if(userdata == null)
                throw new ArgumentException("This user was not found");

            Models.Response.UserResponse res = UtilsUser.ConvertToUserRes(userdata);
            res.amountworkout = dbWork.GetMyWorkouts(iduser).Count;

            return res;
        }
    }
}