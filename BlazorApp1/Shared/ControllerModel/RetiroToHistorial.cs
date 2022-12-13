using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.ControllerModel
{
    public class RetiroToHistorial
    {
        public string CodigoCliente { get; private set; }

        public Usuario usuario { get; private set; }
        public RetiroToHistorial(string CodigoCliente, Usuario usuario)
        {
            this.usuario = usuario;
            this.CodigoCliente = CodigoCliente;
        }
    }
}
