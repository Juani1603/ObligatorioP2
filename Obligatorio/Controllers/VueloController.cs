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
            List<Vuelo> vuelosPorRuta = new List<Vuelo>();

            if (string.IsNullOrEmpty(codigoIATAsalida) && string.IsNullOrEmpty(codigoIATAllegada))
            {
                ViewBag.Mensaje = "Debe introducir al menos un código IATA";
            }

            try
            {
                //Listas temporales para encontrar vuelos
                List<Vuelo> vuelosSalida = new List<Vuelo>();
                List<Vuelo> vuelosLlegada = new List<Vuelo>();

                if (!string.IsNullOrEmpty(codigoIATAsalida))
                {
                    vuelosSalida = Sistema.Instancia.MostrarVuelosEnAeropuerto(codigoIATAsalida);
                }

                if (!string.IsNullOrEmpty(codigoIATAllegada))
                {
                    vuelosLlegada = Sistema.Instancia.MostrarVuelosEnAeropuerto(codigoIATAllegada);
                }

                foreach (Vuelo vuelo in vuelosSalida)
                {
                    if (!vuelosPorRuta.Contains(vuelo))
                    {
                        vuelosPorRuta.Add(vuelo);
                    }
                }

                foreach (Vuelo vuelo in vuelosLlegada)
                {
                    if (!vuelosPorRuta.Contains(vuelo))
                    {
                        vuelosPorRuta.Add(vuelo);
                    }
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
