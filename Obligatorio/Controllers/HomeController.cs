using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                string correo = HttpContext.Session.GetString("correo");
                //Muestra el correo en la página de inicio
                return View(model: correo);
            }
            return View();
        }

        //Anonimo: Login
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return View();
            }
            return RedirectToAction("Index");
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
                    HttpContext.Session.SetString("correo", correo);
                    TempData["Mensaje"] = "Inicio de sesión exitoso";
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

        //Usuario logeado: Logout
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Login");
        }
    }
}
