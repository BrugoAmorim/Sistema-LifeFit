using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business
{
    public class WorkoutRountineBusiness
    {
        Utils.WorkoutRountineUtils Workout = new Utils.WorkoutRountineUtils();
        Database.WorkoutRoutineDatabase dbWorkout = new Database.WorkoutRoutineDatabase();

        public Models.Response.WorkoutRoutineResponse NewWorkout(Models.Request.WorkoutRoutineRequest req){;

            ValidateClassWorkout validNewRoutine = new ValidateClassWorkout();
            validNewRoutine.isValidRoutine(req);

            Models.TbRotinaTreino routine = dbWorkout.SaveRoutine(req);
            List<Models.TbExercicio> exercisesOfRoutine = dbWorkout.GetExercises(routine.IdRotina);

            Models.Response.WorkoutRoutineResponse BoxRes = Workout.ConvertTbToResRoutine(routine);
            List<Models.Response.ExerciseResponse> lt = new List<Models.Response.ExerciseResponse>();

            foreach(Models.TbExercicio e in exercisesOfRoutine){

                lt.Add(Workout.ConvertTbtoResExercise(e));
            }

            BoxRes.exercises = lt;
            return BoxRes;
        }
    
        public List<Models.TbRotinaTreino> GetMyWorkout(int iduser){

            Database.UserDatabase dbUser = new Database.UserDatabase();
            List<Models.TbRotinaTreino> Workouts = dbWorkout.GetMyWorkouts(iduser);

            if(dbUser.UserExist(iduser) == null)
                throw new ArgumentException("This user was not found");

            if(Workouts.Count == 0)
                throw new ArgumentException("You don't have any training created");            

            return Workouts;   
        }
    }
}