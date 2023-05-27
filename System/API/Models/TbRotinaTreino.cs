using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TbRotinaTreino
{
    public int IdRotina { get; set; }

    public string DsNomeRotina { get; set; }

    public string DsTempoDuracao { get; set; }

    public DateTime DtRotinaCriada { get; set; }

    public int? IdUsuario { get; set; }

    public virtual TbUsuario IdUsuarioNavigation { get; set; }

    public virtual ICollection<TbExercicio> TbExercicios { get; } = new List<TbExercicio>();
}
