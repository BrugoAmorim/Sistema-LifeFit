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
        Database.UserDatabase userDb = new Database.UserDatabase();
        Utils.WorkoutRountineUtils WorkoutUtils = new Utils.WorkoutRountineUtils();
        Utils.ExerciseUtils ExerciseUtils = new Utils.ExerciseUtils();

        public Models.Response.WorkoutRoutineResponse NewWorkout(Models.Request.WorkoutRoutineRequest req){;

            ValidateClassWorkout validNewRoutine = new ValidateClassWorkout();
            validNewRoutine.isValidRoutine(req);

            Models.TbRotinaTreino routine = dbWorkout.SaveRoutine(req);
            List<Models.TbExercicio> Exs = dbExercise.GetExercises(routine.IdRotina);

            Models.Response.WorkoutRoutineResponse BoxRes = WorkoutUtils.ConvertTbToResRoutine(routine, Exs);
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

        public void DeleteMyWorkout(int iduser, int idroutine){

            Models.TbRotinaTreino workout = dbWorkout.GetSpecificWorkout(iduser, idroutine);

            if(userDb.UserExist(iduser) == null)
                throw new ArgumentException("This user is not exist");

            if(workout == null)
                throw new ArgumentException("This workout routine was not found");

            dbWorkout.DeleteMyWorkout(idroutine);
        }
    
        public Models.Response.WorkoutRoutineResponse UpdateMyWorkout(int iduser, int idroutine, Models.Request.WorkoutUpdateRequest req){

            if(userDb.UserExist(iduser) == null)   
                throw new ArgumentException("This user is invalid");

            Models.TbRotinaTreino rout = dbWorkout.GetWorkoutRoutine(idroutine);
            if(rout == null)
                throw new ArgumentException("This workout routine was not found");

            if(rout.IdUsuario != iduser)
                throw new ArgumentException("This workout routine is invalid");

            if(req.exs.Count == 0)
                throw new ArgumentException("You need to add at least exercise");

            if(string.IsNullOrEmpty(req.routinename))
                throw new ArgumentException("The Routinename field is invalid");

            if(string.IsNullOrEmpty(req.duration))
                throw new ArgumentException("The Duration field is invalid");

            foreach(Models.Request.WorkoutUpdateRequest.exerciseUpdate ex in req.exs){

                Database.WeekDayDatabase daysDb = new Database.WeekDayDatabase();

                if(ex.idexercise > 0 && dbExercise.GetSpecificExercise(ex.idexercise, idroutine) == null)
                    throw new Models.Custom.CustomExercExerciseUpdt("This Exercise was not found", ex);

                if(string.IsNullOrEmpty(ex.exercise.Trim()))
                    throw new Models.Custom.CustomExercExerciseUpdt("The Exercise field is invalid", ex);
            
                if(string.IsNullOrEmpty(ex.seriesandrepeats.Trim()))
                    throw new Models.Custom.CustomExercExerciseUpdt("The Seriesandrepeats field is invalid", ex);
            
                if(string.IsNullOrEmpty(ex.restTime.Trim()))
                    throw new Models.Custom.CustomExercExerciseUpdt("The RestTime field is invalid", ex);
            
                if(string.IsNullOrEmpty(ex.warmingLoad.Trim()))
                    throw new Models.Custom.CustomExercExerciseUpdt("The WarmingLoad field is invalid", ex);
            
                if(string.IsNullOrEmpty(ex.maximumLoad.Trim()))
                    throw new Models.Custom.CustomExercExerciseUpdt("The MaximumLoad field is invalid", ex);

                if(daysDb.getWeekDay(ex.idweekDay) == null)
                    throw new Models.Custom.CustomExercExerciseUpdt("This WeekDay is invalid", ex);

                if(ex.idexercise > 0)
                    dbExercise.ChangeExercise(ex);
                else if(ex.idexercise <= 0)
                    dbExercise.CreateExercise(idroutine, ex); 
            
            }
        
            Models.TbRotinaTreino ChangedWorkout = dbWorkout.UpdateMyWorkout(idroutine, req);
            List<Models.TbExercicio> Exs = dbExercise.GetExercises(ChangedWorkout.IdRotina);

            Models.Response.WorkoutRoutineResponse BoxRes = WorkoutUtils.ConvertTbToResRoutine(ChangedWorkout, Exs);
            return BoxRes;   
        }
    }
}