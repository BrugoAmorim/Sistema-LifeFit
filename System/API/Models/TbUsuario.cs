using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TbUsuario
{
    public int IdUsuario { get; set; }

    public string DsNome { get; set; }

    public string DsEmail { get; set; }

    public string DsSenha { get; set; }

    public DateTime DtContaCriada { get; set; }

    public DateTime DtContaAtualizada { get; set; }

    public virtual ICollection<TbRotinaTreino> TbRotinaTreinos { get; } = new List<TbRotinaTreino>();
}
