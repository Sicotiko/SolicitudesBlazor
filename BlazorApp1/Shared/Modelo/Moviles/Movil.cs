using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Moviles
{
    public class Movil
    {
        private int _id;
        private int _Codigo = 0;
        private string _Nombre = string.Empty;
        private string _Tipo = string.Empty;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Codigo { get { return this._Codigo; } set { this._Codigo = value; } }
        public string Nombre { get { return this._Nombre; } set { this._Nombre = value; } }
        public string Tipo { get { return this._Tipo; } set { this._Tipo = value; } }

        public Movil(int Codigo, string Nombre, string Tipo)
        {
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.Tipo = Tipo;
        }
        public Movil()
        {
        }
    }
}
