using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyeto.datos;
using Proyeto.Models;

namespace Proyeto.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioAutorDatos _datos = new UsuarioAutorDatos();
        AutorDatos _datosAutor = new AutorDatos();
        UsuarioDatos _datosUsuario = new UsuarioDatos();
        NivelEstudioDatos _datosNivel = new NivelEstudioDatos();



        public IActionResult Reporte()
        {
           List <UsuarioAutorModel> listaUs = _datos.Consultar();
            return View(listaUs);
        }


        public IActionResult Index()
        {
            List<UsuarioAutorModel> listaUs = _datos.Consultar();
            return View(listaUs);
        }

        public IActionResult Crear()
        {
            var lista = _datosNivel.Listar();
          
            ViewData["IdNivelEstudios1"] = new SelectList(lista, "NivelEstudiosId", "NombreNivel");
            return View();
        }

        // POST: datosCompletos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdAutor,Nombre,ApePaterno,ApeMaterno,Matricula,NumEmpleado,TipoCuenta,NumTelefono,FechaNaci,CuerpoAcademico,AreaEstudios,IdNivelEstudios1")] AutorModel autor, [Bind("NombreUsuario, Correo, Contrasena, EsAdmin")] UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                autor = _datosAutor.Guardar(autor);

                usuario.IdAutor1 = autor.IdAutor;
                _datosUsuario.GuardarUsuario(usuario);

                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdNivelEstudios1"] = new SelectList(_context.NivelEstudios, "NivelEstudiosId", "NivelEstudiosId", autor.IdNivelEstudios1);
            return View(autor);
        }




        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = _datosAutor.Obtener((int)id);
            if (autor == null)
            {
                return NotFound();
            }
            var usuario = _datosUsuario.ObtenerByAutor(autor.IdAutor);
            usuario.Autor = autor;
            usuario.IdAutor1 = autor.IdAutor;

            var lista = _datosNivel.Listar();
            ViewData["IdNivelEstudios1"] = new SelectList(lista, "NivelEstudiosId", "NombreNivel");

            return View(usuario);
        }

        // POST: datosCompletos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdAutor,Nombre,ApePaterno,ApeMaterno,Matricula,NumEmpleado,TipoCuenta,NumTelefono,FechaNaci,CuerpoAcademico,AreaEstudios,IdNivelEstudios1")] AutorModel autor, [Bind("NombreUsuario, Correo, Contrasena, EsAdmin")] UsuarioModel usuario)
        {
            if (id != autor.IdAutor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var usResult =  _datosUsuario.Obtener(usuario.NombreUsuario);
                    usResult.Correo = usuario.Correo;
                    _datosAutor.Editar(autor);
                    _datosUsuario.Editar(usResult);

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdNivelEstudios1"] = new SelectList(_context.NivelEstudios, "NivelEstudiosId", "NivelEstudiosId", autor.IdNivelEstudios1);
            return View(autor);
        }


        public ActionResult Detalle(int id)
        {
            var autor = _datosAutor.Obtener((int)id);
            var usuario = _datosUsuario.ObtenerByAutor(autor.IdAutor);
            usuario.Autor = autor;
            usuario.IdAutor1 = autor.IdAutor;


            return View(usuario);
        }

        public ActionResult Eliminar(int id)
        {
            var autor = _datosAutor.Obtener((int)id);
            var usuario = _datosUsuario.ObtenerByAutor(autor.IdAutor);
            usuario.Autor = autor;
            usuario.IdAutor1 = autor.IdAutor;


            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, [Bind("IdAutor,Nombre,ApePaterno,ApeMaterno,Matricula,NumEmpleado,TipoCuenta,NumTelefono,FechaNaci,CuerpoAcademico,AreaEstudios,IdNivelEstudios1")] AutorModel autor)
        {
            try
            {
                UsuarioModel us = _datosUsuario.ObtenerByAutor((int)id);
                bool respuesta = _datosUsuario.Eliminar(us.NombreUsuario);               
                if(respuesta==true)
                {
                    _datosAutor.Eliminar(id);
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
