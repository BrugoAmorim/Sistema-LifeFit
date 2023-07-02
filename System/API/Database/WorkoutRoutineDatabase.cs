using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class WorkoutRoutineDatabase
    {
        Models.DbLifeFitContext ctx = new Models.DbLifeFitContext();
        Utils.WorkoutRountineUtils workout = new Utils.WorkoutRountineUtils();
        Utils.ExerciseUtils exerciseUtils = new Utils.ExerciseUtils();

        public Models.TbRotinaTreino SaveRoutine(Models.Request.WorkoutRoutineRequest req){

            Models.TbRotinaTreino routineWorkout = workout.ConvertReqToTbRoutine(req);
            ctx.TbRotinaTreinos.Add(routineWorkout);
            ctx.SaveChanges();

            foreach(Models.Request.ExercisesRequest i in req.exercise){

                Models.TbExercicio exercise = exerciseUtils.ConvertReqToTbExercise(i, routineWorkout.IdRotina);
                ctx.TbExercicios.Add(exercise);
                ctx.SaveChanges();
            }

            return GetWorkoutRoutine(routineWorkout.IdRotina);
        }

        public Models.TbRotinaTreino GetWorkoutRoutine(int id){

            return ctx.TbRotinaTreinos.Include(x => x.IdUsuarioNavigation).FirstOrDefault(x => x.IdRotina == id);
        }
    
        public List<Models.TbRotinaTreino> GetMyWorkouts(int iduser){

            return ctx.TbRotinaTreinos.Where(x => x.IdUsuario == iduser).ToList();
        }

        public Models.TbRotinaTreino GetSpecificWorkout(int iduser, int idroutine){

            return ctx.TbRotinaTreinos.FirstOrDefault(x => x.IdUsuario == iduser && x.IdRotina == idroutine);
        }
    
        public void DeleteMyWorkout(int idroutine){

            Models.TbRotinaTreino workoutRoutine = ctx.TbRotinaTreinos.First(x => x.IdRotina == idroutine);
            List<Models.TbExercicio> exercises = ctx.TbExercicios
                                                    .Where(x => x.IdRotina == workoutRoutine.IdRotina)
                                                    .ToList();    
        
            foreach(Models.TbExercicio item in exercises){

                ctx.TbExercicios.Remove(item);
                ctx.SaveChanges();
            }

            ctx.TbRotinaTreinos.Remove(workoutRoutine);
            ctx.SaveChanges();
        }
    
        public Models.TbRotinaTreino UpdateMyWorkout(int idroutine, Models.Request.WorkoutUpdateRequest req){

            Models.TbRotinaTreino Work = GetWorkoutRoutine(idroutine);
            Work.DsNomeRotina = req.routinename;
            Work.DsTempoDuracao = req.duration;

            ctx.SaveChanges();
            return Work;
        }
    }
}