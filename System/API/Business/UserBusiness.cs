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
        Database.WorkoutRoutineDatabase dbWork = new Database.WorkoutRoutineDatabase();
        Database.UserDatabase DtUser = new Database.UserDatabase(); 
        public Models.Response.UserResponse CreateAccount(Models.Request.UserRequest req){

            validate.IsFieldsNull(req);

            if(!req.username.Trim().Contains(" ") == true)
                throw new ArgumentException("Put your first name and last name");

            if(!validate.IsEmailValid(req.emailuser) == true)
                throw new ArgumentException("These email is invalid");

            if(!DtUser.listUsers().Any(x => x.DsEmail == req.emailuser) == false)
                throw new ArgumentException("This email already being using");

            if(req.newpassword != req.confirmpassword)
                throw new ArgumentException("The passwords are not the same");

            if(!validate.IsValidPassword(req.newpassword) == true)
                throw new ArgumentException("The password need to have at least special character, a number, an upper letter and a lower letter");

            if(req.newpassword.Length > 40)
                throw new ArgumentException("The password is too long");

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

            Models.TbUsuario userdata = DtUser.UserExist(iduser);
            validate.IsValidIdUser(iduser);

            Models.Response.UserResponse res = UtilsUser.ConvertToUserRes(userdata);
            res.amountworkout = dbWork.GetMyWorkouts(iduser).Count;

            return res;
        }
    
        public void DeleteAllUserWorkout(int iduser){

            validate.IsValidIdUser(iduser);

            if(dbWork.GetMyWorkouts(iduser).Count <= 0)
                throw new ArgumentException("You have no exercise routine");

            dbWork.DeleteAllMyWorkout(iduser);
        }
    
        public void DeleteMyAccount(int iduser, string password){

            Models.TbUsuario userdata = DtUser.UserExist(iduser);
            if(userdata == null)
                throw new ArgumentException("This user was not found");

            if(userdata.DsSenha != password)
                throw new ArgumentException("The password is invalid");

            DtUser.DeleteAccount(iduser);
        }
    
        public void UpdateMyPassword(int iduser, Models.Request.UpdatePasswordRequest passwordReq){

            Models.TbUsuario user = DtUser.UserExist(iduser);

            if(user == null)
                throw new ArgumentException("This user was not found");

            if(user.DsSenha != passwordReq.password)
                throw new ArgumentException("The account password is incorrect");

            if(passwordReq.newpassword != passwordReq.confirmpassword)
                throw new ArgumentException("The entered passwords is not the same");

            if(!validate.IsValidPassword(passwordReq.newpassword) == true)
                throw new ArgumentException("The password need to have at least special character, a number, an upper letter and a lower letter");

            if(passwordReq.newpassword.Length > 40)
                throw new ArgumentException("The password is too long");

            DtUser.UpdatePassword(user, passwordReq.newpassword);
        }
    }
}