using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;
using Proyeto.Recursos;

/*
namespace Proyeto.Controllers
{
    public class CambiarContrasena : Controller
    {
        public class CambiarContraController
        {
            UsuarioDatos LogR = new UsuarioDatos();
            public IActionResult CambiarContrasena()
            {
                return View();
            }
            [HttpPost]
            public IActionResult CambiarContrasena(string Correo, string Contrasena)
            {
                
                bool respuesta =  LogR.CambiarContrasena(Correo, Utilidades.EncriptarClave(Contrasena));
                if (!respuesta)
                {
                    ViewData["Mensaje"] = "El correo no existe";
                    return View();
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
        }
    }
    
}
*/