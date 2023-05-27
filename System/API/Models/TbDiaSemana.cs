using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TbDiaSemana
{
    public int IdDiaSemana { get; set; }

    public string DsDiaSemana { get; set; }

    public virtual ICollection<TbExercicio> TbExercicios { get; } = new List<TbExercicio>();
}
