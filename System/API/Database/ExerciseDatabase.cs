using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class ExerciseDatabase
    {
        Models.DbLifeFitContext ctx = new Models.DbLifeFitContext();
        Utils.ExerciseUtils exerciseUtils = new Utils.ExerciseUtils();

        public List<Models.TbExercicio> GetExercises(int idRoutine){

            return ctx.TbExercicios.Where(x => x.IdRotina == idRoutine)
                                   .Include(x => x.IdDiaSemanaNavigation)
                                   .ToList();
        }

        public void CreateExercise(int idroutine, Models.Request.WorkoutUpdateRequest.exerciseUpdate exReq){

            Models.TbExercicio tb = exerciseUtils.ConvertExerUpToTbExercise(idroutine, exReq);

            ctx.TbExercicios.Add(tb);
            ctx.SaveChanges();
        }

        public void ChangeExercise(Models.Request.WorkoutUpdateRequest.exerciseUpdate exReq){

            Models.TbExercicio updateEx = ctx.TbExercicios.First(x => x.IdExercicio == exReq.idexercise);
            updateEx.DsExercicio = exReq.exercise;
            updateEx.DsTempoDescanso = exReq.restTime;
            updateEx.DsSeriesERepeticoes = exReq.seriesandrepeats;
            updateEx.DsCargaAquecimento = exReq.warmingLoad;
            updateEx.DsCargaMaxima = exReq.maximumLoad;
            updateEx.IdDiaSemana = exReq.idweekDay;
        
            ctx.SaveChanges();
        }

        public Models.TbExercicio GetSpecificExercise(int idExer, int idroutine){

            return ctx.TbExercicios.FirstOrDefault(x => x.IdExercicio == idExer && x.IdRotina == idroutine);
        }

        public void DeleteExercise(int idexer){

            Models.TbExercicio Ex = ctx.TbExercicios.First(x => x.IdExercicio == idexer);
            
            ctx.TbExercicios.Remove(Ex);
            ctx.SaveChanges();
        }
    }
}