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

            return listUsers().FirstOrDefault(x => x.DsEmail == email);
        }

        public Models.TbUsuario UserExist(int iduser){

            return listUsers().FirstOrDefault(x => x.IdUsuario == iduser);
        }

        public void DeleteAccount(int iduser){

            WorkoutRoutineDatabase dbWorkout = new WorkoutRoutineDatabase();

            Models.TbUsuario userdata = ctx.TbUsuarios.First(x => x.IdUsuario == iduser);
            dbWorkout.DeleteAllMyWorkout(userdata.IdUsuario);

            ctx.TbUsuarios.Remove(userdata);
            ctx.SaveChanges();
        }
    }
}