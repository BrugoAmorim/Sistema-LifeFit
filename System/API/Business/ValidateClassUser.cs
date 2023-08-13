using System;
using System.Text.RegularExpressions;

namespace API.Business
{
    public class ValidateClassUser
    {

        public bool IsEmailValid(string email){

            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"; 
            
            Regex regex = new Regex(pattern);
            Match match = regex.Match(email);

            return match.Success;
        }

        public void IsFieldsNull(Models.Request.UserRequest req){

            if(string.IsNullOrEmpty(req.emailuser))
                throw new ArgumentException("The Email Field is invalid");

            if(string.IsNullOrEmpty(req.username))
                throw new ArgumentException("The Username Field is invalid");

            if(string.IsNullOrEmpty(req.newpassword))
                throw new ArgumentException("The Password Field is invalid");
            
            if(string.IsNullOrEmpty(req.confirmpassword))
                throw new ArgumentException("The ConfirmPassword Field is invalid");
        }

        public bool IsValidPassword(string password){

            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            Regex regex = new Regex(pattern);
            bool isValid = regex.IsMatch(password);

            return isValid;
        }
                   
    }
}