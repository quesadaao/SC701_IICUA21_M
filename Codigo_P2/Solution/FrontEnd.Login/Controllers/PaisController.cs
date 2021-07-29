using FrontEnd.Login.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Login.Controllers
{
    public class PaisController : Controller
    {
        PaisServices services = new PaisServices();
        public IActionResult Index()
        {
            return View(services.ObtenerTodos());
        }
    }
}
