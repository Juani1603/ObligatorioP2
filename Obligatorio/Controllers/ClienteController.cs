using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult RegistrarCliente()
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult RegistrarCliente(ClienteOcasional cliente)
        {
            try
            {
                Sistema.Instancia.AltaClienteOcasional(cliente);
                HttpContext.Session.SetString("rol", cliente.Rol);
                HttpContext.Session.SetString("correo", cliente.Correo);
                TempData["Mensaje"] = "Registro exitoso.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public IActionResult VerPerfil()
        {
            string correo = HttpContext.Session.GetString("correo");
            try
            {
                if (!string.IsNullOrEmpty(correo))
                {
                    Usuario usuario= Sistema.Instancia.GetUsuarioEnSesion(correo);
                    return View(usuario);
                }
                else
                {
                    TempData["Mensaje"] = "No se encontró el correo.";
                }
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = ex.Message;
            }

            return View();
        }
    }
}
