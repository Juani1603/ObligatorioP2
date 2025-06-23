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

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("rol")))
                {
                    TempData["Mensaje"] = "Debe iniciar sesión para comprar un pasaje.";
                }

                // Obtener cliente y vuelo
                Cliente cliente = Sistema.Instancia.GetClientePorCorreo(correo);
                Vuelo vuelo = Sistema.Instancia.GetVueloPorNumeroVuelo(numeroVuelo);

                if (cliente != null && vuelo != null && fecha != DateTime.MinValue)
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
                IEnumerable<Pasaje> pasajesCliente = new List<Pasaje>();
                string rol = HttpContext.Session.GetString("rol");

                try
                {
                    if (rol == "Admin")
                    {
                        pasajesCliente = Sistema.Instancia.Pasajes;
                        if (pasajesCliente != null && pasajesCliente.Count() > 0)
                        {
                            return View(pasajesCliente);
                        } else
                        {
                            ViewBag.Mensaje = "No hay pasajes listados.";
                        }
                    }

                    Cliente clienteEnSesion = Sistema.Instancia.GetClientePorCorreo(HttpContext.Session.GetString("correo"));

                    if (clienteEnSesion != null && rol == "Cliente")
                    {
                        pasajesCliente = Sistema.Instancia.BuscarPasajesPorCliente(clienteEnSesion);

                        if (pasajesCliente == null || pasajesCliente.Count() == 0)
                        {
                            ViewBag.Mensaje = "No hay pasajes listados.";
                            return View();
                        }
                    }

                    List<Pasaje> pasajes = pasajesCliente.ToList();
                    pasajes.Sort();
                    return View(pasajes);
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                }
                return View();
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
