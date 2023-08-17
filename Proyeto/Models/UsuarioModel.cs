//using Microsoft.Build.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Proyeto.Models;

public partial class UsuarioModel
{
    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Contrasena { get; set; } = null!;

    public int? IdAutor1 { get; set; }

    public int? EsAdmin { get; set; }

    public RolModel refRol { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]

    public virtual AutorModel? Autor { get; set; }
}
