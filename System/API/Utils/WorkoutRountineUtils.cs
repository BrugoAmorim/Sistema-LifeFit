using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Utils
{
    public class WorkoutRountineUtils
    {
    
        public Models.TbRotinaTreino ConvertReqToTbRoutine(Models.Request.WorkoutRoutineRequest req){

            Models.TbRotinaTreino tb = new Models.TbRotinaTreino();
            tb.DsNomeRotina = req.routinename;
            tb.DsTempoDuracao = req.duration;
            tb.DtRotinaCriada = DateTime.Now;
            tb.IdUsuario = req.iduser;

            return tb;
        }
    
        public Models.Response.WorkoutRoutineResponse ConvertTbToResRoutine(Models.TbRotinaTreino req, List<Models.TbExercicio> exers){

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

            Utils.ExerciseUtils Exer = new ExerciseUtils();
            List<Models.Response.ExerciseResponse> lt = new List<Models.Response.ExerciseResponse>();

            foreach(Models.TbExercicio e in exers){

                lt.Add(Exer.ConvertTbtoResExercise(e));
            }

            routine.exercises = lt;
            return routine;
        }
    
        public Models.Response.MyRoutinesResponse ConvertToRoutineRes(Models.TbRotinaTreino TbRout){

            Models.Response.MyRoutinesResponse Routin = new Models.Response.MyRoutinesResponse();
            Routin.idRoutine = TbRout.IdRotina;
            Routin.Routinename = TbRout.DsNomeRotina;
            Routin.Duration = TbRout.DsTempoDuracao;
            Routin.RoutineCreated = TbRout.DtRotinaCriada;

            return Routin;
        }
    
    }
}