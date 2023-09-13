using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Comunas
{
    public class Comuna
    {
        private int _id;
        private string nombre = string.Empty;
        private int codigoPostal;
        private int codigoPostalMax;
        private NombreSector nombreSector;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }
        public NombreSector NombreSector
        {
            get { return nombreSector; }
            set { nombreSector = value; }
        }

        public int CodigoPostalMax { get => codigoPostalMax; set => codigoPostalMax = value; }
    }
}
