using LogicaNegocio;
using LogicaNegocio.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    public class PasajeController : Controller
    {
        [HttpPost]
        public IActionResult RegistrarPasaje(string NumeroVuelo, DateTime Fecha, int tipoEquipaje)
        {
            try
            {
                string correo = HttpContext.Session.GetString("correo");

                if (string.IsNullOrEmpty(correo))
                {
                    TempData["Mensaje"] = "Debe iniciar sesión para comprar un pasaje.";
                }

                // Obtener cliente y vuelo
                Usuario usuario = Sistema.Instancia.GetUsuarioEnSesion(correo);
                Vuelo vuelo = Sistema.Instancia.GetVueloPorNumeroVuelo(NumeroVuelo);

                if (usuario is Cliente cliente){

                    Pasaje pasaje = new Pasaje(vuelo, Fecha, cliente, (Equipaje)tipoEquipaje);

                    Sistema.Instancia.AltaPasaje(pasaje);

                    TempData["Mensaje"] = "Pasaje registrado correctamente.";
                }
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = ex.Message;
                return RedirectToAction("DetallesVuelo", "Vuelo", new { numeroVuelo = NumeroVuelo });
            }
            return RedirectToAction("VerPasajes");
        }

        public IActionResult VerPasajes()
        {
            List<Pasaje> pasajesCliente = new List<Pasaje>();
            Usuario usuarioEnSesion = Sistema.Instancia.GetUsuarioEnSesion(HttpContext.Session.GetString("correo"));

            try
            {
                if (usuarioEnSesion is Cliente cliente)
                {
                    pasajesCliente = Sistema.Instancia.BuscarPasajesPorCliente(cliente);
                }
                
                if (pasajesCliente == null)
                {
                    ViewBag.Mensaje = "De momento tienes pasajes comprados.";
                }
                pasajesCliente.Sort();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View(pasajesCliente);
        }
    }
}
