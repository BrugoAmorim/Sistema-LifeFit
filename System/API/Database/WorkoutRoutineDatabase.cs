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
        public Models.TbRotinaTreino SaveRoutine(Models.Request.WorkoutRoutineRequest req){

            Models.TbRotinaTreino routineWorkout = workout.ConvertReqToTbRoutine(req);
            ctx.TbRotinaTreinos.Add(routineWorkout);
            ctx.SaveChanges();

            foreach(Models.Request.ExercisesRequest i in req.exercise){

                Models.TbExercicio exercise = workout.ConvertReqToTbExercise(i, routineWorkout.IdRotina);
                ctx.TbExercicios.Add(exercise);
                ctx.SaveChanges();
            }

            return GetWorkoutRoutine(routineWorkout.IdRotina);
        }

        public Models.TbRotinaTreino GetWorkoutRoutine(int id){

            return ctx.TbRotinaTreinos.Include(x => x.IdUsuarioNavigation).First(x => x.IdRotina == id);
        }

        public List<Models.TbExercicio> GetExercises(int idRoutine){

            return ctx.TbExercicios.Where(x => x.IdRotina == idRoutine)
                                   .Include(x => x.IdDiaSemanaNavigation)
                                   .ToList();
        }
    
        public List<Models.TbRotinaTreino> GetMyWorkouts(int iduser){

            return ctx.TbRotinaTreinos.Where(x => x.IdUsuario == iduser).ToList();
        }
    }
}