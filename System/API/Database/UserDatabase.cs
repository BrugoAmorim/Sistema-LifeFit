using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Database
{
    public class UserDatabase
    {
        
        Models.DbLifeFitContext ctx = new Models.DbLifeFitContext();

        public Models.TbUsuario addNewUser(Models.TbUsuario newuser){

            ctx.TbUsuarios.Add(newuser);
            ctx.SaveChanges();

            return newuser;
        }

        public List<Models.TbUsuario> listUsers(){

            return ctx.TbUsuarios.ToList();
        }

        public Models.TbUsuario FirstUser(string email){

            Models.TbUsuario userData = listUsers().FirstOrDefault(x => x.DsEmail == email);
            return userData;
        }
    }
}