using FrontEnd.Login.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Login.ViewComponents
{
    public class TasViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> Invoke()
        {
            PaisServices services = new PaisServices();
            return View(services.ObtenerTodos());
        }
    }
}
