using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyeto.Models;

public partial class CategoriaModel
{
    [Display(Name = "nuevo titulo")]
    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

}
