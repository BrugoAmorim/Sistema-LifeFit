using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Database
{
    public class WeekDayDatabase
    {
        Models.DbLifeFitContext ctx = new Models.DbLifeFitContext();

        public Models.TbDiaSemana getWeekDay(int idweekday){

            return ctx.TbDiaSemanas.FirstOrDefault(x => x.IdDiaSemana == idweekday);
        }
    }
}