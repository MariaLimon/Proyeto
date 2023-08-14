using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyeto.Models
{
    public class MateriaImpartidaModel
    {
        public int IdMateria { get; set; }
        public int Matricula { get; set;}
        public string Carrera { get; set;}
        public string Materia { get; set;}
        public string Grupo { get; set;}
        public string FechaCuatri { get; set;}
        public string? UrlDocumento { get; set;}
        public int IdAutor1 { get; set;}

    }
}
