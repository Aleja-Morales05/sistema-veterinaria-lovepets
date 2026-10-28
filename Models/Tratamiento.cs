using System;
using System.Collections.Generic;

namespace FinalWeb.Models;

public partial class Tratamiento
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public int? Cantidad { get; set; }

    public string? Precio { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
