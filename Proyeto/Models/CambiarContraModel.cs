using System.ComponentModel.DataAnnotations;
namespace Proyeto.Models
{
    public class CambiarContraModel
    {
        public int Correo { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [Required]
    }
}
