using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Moviles
{
    public class Movil
    {
        private string numero = string.Empty;

        public string Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }
    }
}
