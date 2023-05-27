using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Utils
{
    public class UserUtils
    {

        public Models.TbUsuario ConvertToTbUser(Models.Request.UserRequest reqUser){

            Models.TbUsuario tbUser = new Models.TbUsuario();
            tbUser.DsNome = reqUser.username;
            tbUser.DsEmail = reqUser.emailuser;
            tbUser.DsSenha = reqUser.newpassword;
            tbUser.DtContaCriada = DateTime.Now;
            tbUser.DtContaAtualizada = DateTime.Now;
            
            return tbUser;
        }

        public Models.Response.UserResponse ConvertToUserRes(Models.TbUsuario tbUser){

            Models.Response.UserResponse userRes = new Models.Response.UserResponse();
            userRes.iduser = tbUser.IdUsuario;
            userRes.nameuser = tbUser.DsNome;
            userRes.emailuser = tbUser.DsEmail;
            userRes.accountcreated = tbUser.DtContaCriada;
            userRes.accountupdated = tbUser.DtContaAtualizada;

            return userRes;
        }
    }
}