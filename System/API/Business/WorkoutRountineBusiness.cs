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
            Models.Response.WorkoutRoutineResponse BoxRes = Workout.ConvertTbToResRoutine(routine);

            List<Models.TbExercicio> exercisesOfRoutine = dbWorkout.GetExercises(routine.IdRotina);
            List<Models.Response.ExerciseResponse> lt = new List<Models.Response.ExerciseResponse>();

            foreach(Models.TbExercicio e in exercisesOfRoutine){

                lt.Add(Workout.ConvertTbtoResExercise(e));
            }

            BoxRes.exercises = lt;
            return BoxRes;
        }
    }
}