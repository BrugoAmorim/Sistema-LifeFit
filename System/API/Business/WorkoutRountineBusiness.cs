using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business
{
    public class WorkoutRountineBusiness
    {
        Database.WorkoutRoutineDatabase dbWorkout = new Database.WorkoutRoutineDatabase();
        Database.ExerciseDatabase dbExercise = new Database.ExerciseDatabase();
        Utils.WorkoutRountineUtils WorkoutUtils = new Utils.WorkoutRountineUtils();
        Utils.ExerciseUtils ExerciseUtils = new Utils.ExerciseUtils();

        public Models.Response.WorkoutRoutineResponse NewWorkout(Models.Request.WorkoutRoutineRequest req){;

            ValidateClassWorkout validNewRoutine = new ValidateClassWorkout();
            validNewRoutine.isValidRoutine(req);

            Models.TbRotinaTreino routine = dbWorkout.SaveRoutine(req);
            List<Models.TbExercicio> exercisesOfRoutine = dbExercise.GetExercises(routine.IdRotina);

            Models.Response.WorkoutRoutineResponse BoxRes = WorkoutUtils.ConvertTbToResRoutine(routine);
            List<Models.Response.ExerciseResponse> lt = new List<Models.Response.ExerciseResponse>();

            foreach(Models.TbExercicio e in exercisesOfRoutine){

                lt.Add(ExerciseUtils.ConvertTbtoResExercise(e));
            }

            BoxRes.exercises = lt;
            return BoxRes;
        }
    
        public List<Models.TbRotinaTreino> GetMyWorkout(int iduser){

            List<Models.TbRotinaTreino> Workouts = dbWorkout.GetMyWorkouts(iduser);
            Database.UserDatabase dbUser = new Database.UserDatabase();

            if(dbUser.UserExist(iduser) == null)
                throw new ArgumentException("This user was not found");

            if(Workouts.Count == 0)
                throw new ArgumentException("You don't have any training created");            

            return Workouts;   
        }

    }
}