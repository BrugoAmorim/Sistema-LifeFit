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
    }
}