using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Utils
{
    public class ExerciseUtils
    {
        public Models.TbExercicio ConvertReqToTbExercise(Models.Request.ExercisesRequest ex, int idroutine){

            Models.TbExercicio tbexercise = new Models.TbExercicio();
            tbexercise.DsExercicio = ex.exercise;
            tbexercise.DsSeriesERepeticoes = ex.seriesandrepeats;
            tbexercise.DsTempoDescanso = ex.restTime;
            tbexercise.DsCargaAquecimento = ex.warmingLoad;
            tbexercise.DsCargaMaxima = ex.maximumLoad;
            tbexercise.IdDiaSemana = ex.idweekDay;
            tbexercise.IdRotina = idroutine;

            return tbexercise;
        }   

        public Models.Response.ExerciseResponse ConvertTbtoResExercise(Models.TbExercicio ex){

            Models.Response.ExerciseResponse exRes = new Models.Response.ExerciseResponse();
            exRes.idexercise = ex.IdExercicio;
            exRes.exercise = ex.DsExercicio;
            exRes.seriesandrepeats = ex.DsSeriesERepeticoes;
            exRes.restTime = ex.DsTempoDescanso;
            exRes.warmingLoad = ex.DsCargaAquecimento;
            exRes.maximumLoad = ex.DsCargaMaxima;
            exRes.weekday = ex.IdDiaSemanaNavigation.DsDiaSemana;
            exRes.idroutine = ex.IdRotina;

            return exRes;
        }
    }
}