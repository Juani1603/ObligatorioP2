using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;
using System.Diagnostics;

namespace Obligatorio.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string contrasena)
        {
            try
            {
                string rol = Sistema.Instancia.Login(correo, contrasena);
                if (!string.IsNullOrEmpty(rol))
                {
                    HttpContext.Session.SetString("rol", rol);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Mensaje"] = "Credenciales incorrectas.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
