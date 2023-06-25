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

        public List<Models.TbExercicio> GetExercises(int idRoutine){

            return ctx.TbExercicios.Where(x => x.IdRotina == idRoutine)
                                   .Include(x => x.IdDiaSemanaNavigation)
                                   .ToList();
        }
    }
}