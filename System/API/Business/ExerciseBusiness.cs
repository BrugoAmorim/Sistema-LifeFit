using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business
{
    public class ExerciseBusiness
    {
        Database.WorkoutRoutineDatabase dbWorkout = new Database.WorkoutRoutineDatabase();
        Database.ExerciseDatabase dbExercise = new Database.ExerciseDatabase();

        public List<Models.TbExercicio> getExercise(int idRoutine){

            Models.TbRotinaTreino Wkt = dbWorkout.GetWorkoutRoutine(idRoutine);

            if(Wkt == null)
                throw new ArgumentException("This Routine is not exist or was not found");

            return dbExercise.GetExercises(idRoutine);
        }

        public void delExercise(int idexer, int idroutine, int iduser){

            Database.UserDatabase dbUser = new Database.UserDatabase();

            Models.TbUsuario user = dbUser.UserExist(iduser);
            if(user == null)
                throw new ArgumentException("This user was not found");

            Models.TbRotinaTreino rount = dbWorkout.GetSpecificWorkout(user.IdUsuario, idroutine);
            if(rount == null)
                throw new ArgumentException("This workout routine was not found");

            Models.TbExercicio ex = dbExercise.GetSpecificExercise(idexer, rount.IdRotina);
            if(ex == null)
                throw new ArgumentException("This exercise was not found");

            dbExercise.DeleteExercise(idexer);   
        }
    }
}