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

            if (correo == "Cliente" && HttpContext.Session.GetString("rol") != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(correo))
                    {
                        Cliente cliente = Sistema.Instancia.GetClientePorCorreo(correo);
                        if (cliente != null)
                        {
                            return View(cliente);
                        }
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
            return RedirectToAction("Index", "Home");   
        }

        public IActionResult VerTodosLosClientes()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                if (HttpContext.Session.GetString("rol") == "Admin")
                {
                    IEnumerable<Cliente> clientes = new List<Cliente>();

                    try
                    {
                        clientes = Sistema.Instancia.TodosLosClientes();

                        if (clientes == null || clientes.Count() < 0)
                        {
                            TempData["Mensaje"] = "No hay clientes en la lista.";
                            return View();
                        }
                    }
                    catch (Exception ex)
                    {
                        TempData["Mensaje"] = ex.Message;
                    }
                    return View(clientes);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        public IActionResult EditarCliente()
        {
            return View();
        }
    }
}
