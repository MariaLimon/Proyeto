using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Proyeto.Controllers
{
    public class MateriaImpartidaController : Controller
    {
        MateriaImpartidaDatos _datos = new MateriaImpartidaDatos();
        private IHostingEnvironment Environment;
        public MateriaImpartidaController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public ActionResult Index()
        {
            List<MateriaImpartidaModel> lista = _datos.Listar();
            return View(lista);
        }



        public ActionResult Crear()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Docente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(IFormFile Archivo, [Bind("IdMateria, Matricula, Carrera, Materia, Grupo, FechaCuatri, UrlDocumento, IdAutor1")] MateriaImpartidaModel materiaImpartida)
        {
            try
            {
                string rutasitio = this.Environment.WebRootPath;
                string uploads = Path.Combine(rutasitio, "uploads");
                Random rnd = new Random();
                int r = rnd.Next();
                string nombreArchivo = r.ToString() + "_" + Archivo.FileName;
                string filePath = Path.Combine(uploads, nombreArchivo);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Archivo.CopyToAsync(fileStream);
                }
                materiaImpartida.UrlDocumento = "/uploads/" + nombreArchivo;
                int autorId = Convert.ToInt32(HttpContext.Session.GetString("autor"));
                materiaImpartida.IdAutor1 = autorId;

                if (ModelState.IsValid)
                {
                    _datos.Guardar(materiaImpartida);
                    return RedirectToAction(nameof(Index));
                }
                return View(materiaImpartida);
            }
            catch
            {
                return View();
            }
        }





        public ActionResult Detalle(int id)
        {
            MateriaImpartidaModel materiaImpartida = _datos.Obtener(id);
            return View(materiaImpartida);
        }

        
       

        
        public ActionResult Editar(int id)
        {
            MateriaImpartidaModel materiaImpartida = _datos.Obtener(id);
            return View(materiaImpartida);
        }

        [Authorize(Roles ="Admin, Docente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(IFormFile Archivo, int id, [Bind("IdMateria, Matricula, Carrera, Materia, Grupo, FechaCuatri, UrlDocumento, IdAutor1")] MateriaImpartidaModel materiaImpartida)
        {
            try
            {
                if (Archivo != null)
                {
                    string rutasitio = this.Environment.WebRootPath;
                    string uploads = Path.Combine(rutasitio, "uploads");
                    Random rnd = new Random();
                    int r = rnd.Next();
                    string nombreArchivo = r.ToString() + "_" + Archivo.FileName;
                    string filePath = Path.Combine(uploads, nombreArchivo);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Archivo.CopyToAsync(fileStream);
                    }
                    materiaImpartida.UrlDocumento = "/uploads/" + nombreArchivo;
                }
                ModelState.Remove("Archivo");


                if (ModelState.IsValid)
                {
                    _datos.Editar(materiaImpartida);
                    return RedirectToAction(nameof(Index));
                }
                return View(materiaImpartida);
                
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin, Docente")]
        public ActionResult Eliminar(int id)
        {
            MateriaImpartidaModel materiaImpartida = _datos.Obtener(id);
            return View(materiaImpartida);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, [Bind("IdMateria, Matricula, Carrera, Materia, Grupo, FechaCuatri, UrlDocumento, IdAutor1")] MateriaImpartidaModel materiaImpartida)
        {
            try
            {
               
                    _datos.Eliminar(id);
                    return RedirectToAction(nameof(Index));
               
            }
                
            catch
            {
                return View();
            }
        }
    }
}
