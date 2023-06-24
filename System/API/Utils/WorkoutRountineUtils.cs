using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Utils
{
    public class WorkoutRountineUtils
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
    
        public Models.TbRotinaTreino ConvertReqToTbRoutine(Models.Request.WorkoutRoutineRequest req){

            Models.TbRotinaTreino tb = new Models.TbRotinaTreino();
            tb.DsNomeRotina = req.routinename;
            tb.DsTempoDuracao = req.duration;
            tb.DtRotinaCriada = DateTime.Now;
            tb.IdUsuario = req.iduser;

            return tb;
        }
    
        public Models.Response.WorkoutRoutineResponse ConvertTbToResRoutine(Models.TbRotinaTreino req){

            Models.Response.WorkoutRoutineResponse routine = new Models.Response.WorkoutRoutineResponse(); 
            routine.idworkoutroutine = req.IdRotina;
            routine.routinename = req.DsNomeRotina;
            routine.duration = req.DsTempoDuracao;
            routine.dtcreated = req.DtRotinaCriada;

            if(req.IdUsuario == null){
                routine.iduser = 0;
                routine.username = "Anonymous user";
            }
            else{
                routine.iduser = req.IdUsuario;
                routine.username = req.IdUsuarioNavigation.DsNome;    
            }

            return routine;
        }
    }
}