using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Login.Servicios
{
    public class PaisServices
    {
        public List<string> ObtenerTodos() {
            return new List<string>() { "Ghana", "Japon", "Costa Rica", "Ecuador", "Argentina" };
        }

        public List<Models.Pais> ObtenerTodosPaises()
        {
            return new List<Models.Pais>() { new Models.Pais { Id = 1, Nombre = "Ghana" },
                                             new Models.Pais { Id = 2, Nombre = "Japon" },
                                             new Models.Pais { Id = 3, Nombre = "Costa Rica" },
                                             new Models.Pais { Id = 4, Nombre = "Ecuador" },
                                             new Models.Pais { Id = 5, Nombre = "Argentina" }};
        }
    }
}
