using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Moviles
{
    public class TipoMovil
    {
        private string _Codigo = string.Empty;
        private string _Nombre = string.Empty;
        private string _Tipo = string.Empty;

        public string Codigo { get { return this._Codigo; } private set { this._Codigo = value; } }
        public string Nombre { get { return this._Nombre; } private set { this._Nombre = value; } }
        public string Tipo { get { return this._Tipo; } private set { this._Tipo = value; } }

        public TipoMovil(string Codigo, string Nombre, string Tipo)
        {
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.Tipo = Tipo;
        }
    }
}
