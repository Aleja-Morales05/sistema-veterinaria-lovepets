using System;
using System.Collections.Generic;

namespace FinalWeb.Models;

public partial class Mascota
{
    public int Id { get; set; }

    public decimal? Niup { get; set; }

    public string? Nombre { get; set; }

    public string? Raza { get; set; }

    public string? Animal { get; set; }

    public int? Cliente { get; set; }

    public string? Genero { get; set; }

    public string? Peso { get; set; }

    public int? Tratamiento { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? Veterinario { get; set; }

    public virtual Cliente? ClienteNavigation { get; set; }

    public virtual Tratamiento? TratamientoNavigation { get; set; }

    public virtual Empleado? VeterinarioNavigation { get; set; }
}
