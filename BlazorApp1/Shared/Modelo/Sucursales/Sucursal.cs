using BlazorApp1.Shared.Modelo.Comunas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Sucursales
{
    public class Sucursal
    {
        private string nombre = string.Empty;
        private string codigoCliente = string.Empty;
        private NombreSector nombreSector;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string CodigoCliente
        {
            get { return codigoCliente; }
            set { codigoCliente = value; }
        }
        public NombreSector NombreSector
        {
            get { return nombreSector; }
            set { nombreSector = value; }
        }
    }
}
