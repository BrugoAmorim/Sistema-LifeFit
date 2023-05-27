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
    }
}