using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    public class VueloController : Controller
    {
        public IActionResult ListadoDeVuelos()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Cliente")
                {
                    IEnumerable<Vuelo> vuelos = new List<Vuelo>();
                    try
                    {
                        vuelos = Sistema.Instancia.Vuelos;
                        if (vuelos == null || vuelos.Count() == 0)
                        {
                            ViewBag.Mensaje = "No hay vuelos listados.";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                    }
                    return View(vuelos);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        public IActionResult BuscarVuelosPorRuta()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Cliente")
                {
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        //Buscar vuelos por ruta
        [HttpPost]
        public IActionResult BuscarVuelosPorRuta(string codigoIATAsalida, string codigoIATAllegada)
        {
            IEnumerable<Vuelo> vuelosPorRuta = new List<Vuelo>();

            if (string.IsNullOrEmpty(codigoIATAsalida) && string.IsNullOrEmpty(codigoIATAllegada))
            {
                ViewBag.Mensaje = "Debe introducir al menos un código IATA.";
                return View();
            }

            try
            {
                vuelosPorRuta = Sistema.Instancia.BuscarVuelosPorRuta(codigoIATAsalida, codigoIATAllegada);

                if (vuelosPorRuta == null || vuelosPorRuta.Count() == 0)
                {
                    ViewBag.Mensaje = "No se encontraron vuelos con los criterios ingresados.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return View(vuelosPorRuta);
        }

        public IActionResult DetallesVuelo(string numeroVuelo)
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Cliente")
                {
                    Vuelo vuelo = null;
                    try
                    {
                        vuelo = Sistema.Instancia.GetVueloPorNumeroVuelo(numeroVuelo);

                        if (vuelo == null)
                        {
                            ViewBag.Mensaje = "No se encontró el vuelo con ese número.";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                    }
                    return View(vuelo);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
