using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TbExercicio
{
    public int IdExercicio { get; set; }

    public string DsSeriesERepeticoes { get; set; }

    public string DsExercicio { get; set; }

    public string DsTempoDescanso { get; set; }

    public string DsCargaAquecimento { get; set; }

    public string DsCargaMaxima { get; set; }

    public int? IdDiaSemana { get; set; }

    public int IdRotina { get; set; }

    public virtual TbDiaSemana IdDiaSemanaNavigation { get; set; }

    public virtual TbRotinaTreino IdRotinaNavigation { get; set; }
}
