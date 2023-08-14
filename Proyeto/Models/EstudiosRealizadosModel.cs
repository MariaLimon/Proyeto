namespace Proyeto.Models
{
    public class EstudiosRealizadosModel
    {
        public int IdEstudiosRealizados { get; set; }
        public int Matri_NoEmpl { get; set; }
        public string NombreCurso { get; set; }
        public string Duracion { get; set; }
        public string Institucion { get; set; } 
        public string Descripcion { get; set; }
        public string? UrlDocumento { get; set; } 
        public int IdAutor1 { get; set; }
        public virtual AutorModel? Autor1 { get; set; }
    }
}
