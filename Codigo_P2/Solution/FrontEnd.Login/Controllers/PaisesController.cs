using FrontEnd.Login.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FrontEnd.Login.Controllers
{
    public class PaisesController : Controller
    {
        PaisServices services = new PaisServices();
        public IActionResult Index()
        {
            ViewBag.Tas = new Models.Foci { FocusId = 2121, FocusName = "Alguien" };
            ViewData["Aux"] = 582525;
            return View(services.ObtenerTodosPaises());
        }

        public IActionResult Xfilex()
        {
            string fileName = "NET-Microservices-Architecture-for-Containerized-NET-Applications.pdf";
            string fullPath = Path.GetFullPath(fileName);
            //Controller.Server.Map("NET-Microservices-Architecture-for-Containerized-NET-Applications.pdf")
            ViewData["Aux"] = fullPath; 
            
            return View();
        }

        public FileResult Xfiles() {

            string fileName = "NET-Microservices-Architecture-for-Containerized-NET-Applications.pdf";
            string fullPath = Path.GetFullPath(fileName);
            return File(fullPath, "application / pdf", "Containers.pdf");
        }
    }
}
