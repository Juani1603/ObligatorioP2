using LogicaNegocio;
using LogicaNegocio.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    public class PasajeController : Controller
    {
        [HttpPost]
        public IActionResult RegistrarPasaje(string numeroVuelo, DateTime fecha, int tipoEquipaje)
        {
            try
            {
                string correo = HttpContext.Session.GetString("correo");

                if (string.IsNullOrEmpty(correo))
                {
                    TempData["Mensaje"] = "Debe iniciar sesión para comprar un pasaje.";
                }

                // Obtener cliente y vuelo
                Cliente cliente = Sistema.Instancia.GetClientePorCorreo(correo);
                Vuelo vuelo = Sistema.Instancia.GetVueloPorNumeroVuelo(numeroVuelo);

                if (cliente != null && vuelo != null && fecha != null)
                {
                    Pasaje pasaje = new Pasaje(vuelo, fecha, cliente, (Equipaje)tipoEquipaje);

                    Sistema.Instancia.AltaPasaje(pasaje);

                    TempData["Mensaje"] = "Pasaje registrado correctamente.";
                }
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = ex.Message;
                return RedirectToAction("DetallesVuelo", "Vuelo", new { numeroVuelo = numeroVuelo });
            }
            return RedirectToAction("VerPasajes");
        }

        public IActionResult VerPasajes()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                List<Pasaje> pasajesCliente = new List<Pasaje>();
                string rol = HttpContext.Session.GetString("rol");

                try
                {
                    if (rol == "Admin")
                    {
                        pasajesCliente = Sistema.Instancia.Pasajes;
                        return View(pasajesCliente);
                    }

                    Cliente clienteEnSesion = Sistema.Instancia.GetClientePorCorreo(HttpContext.Session.GetString("correo"));

                    if (clienteEnSesion != null && rol == "Cliente")
                    {
                        pasajesCliente = Sistema.Instancia.BuscarPasajesPorCliente(clienteEnSesion);
                    }

                    if (pasajesCliente == null)
                    {
                        ViewBag.Mensaje = "No hay pasajes listados.";
                    }
                    pasajesCliente.Sort();
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                }
                return View(pasajesCliente);
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
