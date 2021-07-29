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
    }
}
