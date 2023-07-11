using BlazorApp1.Shared.Modelo.Moviles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.User
{
    public class Sesion
    {
        public string Nombre { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public PersonalConfig ConfiguracionPersonal { get; set; }
        public string MovilesDisponibles { get; set; }

    }
}
