using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Proyeto.Models;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public record CambiarContraModel(int Correo, [property: Required] string Contrasena)
{
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}

