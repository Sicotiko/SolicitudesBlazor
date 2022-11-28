using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Comunas
{
    public class Comuna
    {
        private string nombre = string.Empty;
        private string codigoPostal = string.Empty;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }
    }
}
