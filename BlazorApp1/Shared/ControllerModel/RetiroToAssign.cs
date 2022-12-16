using BlazorApp1.Shared.Modelo.Retiros;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.ControllerModel
{
    public class RetiroToAssign
    {
        public Retiro retiro { get; private set; }
        public Usuario usuario { get; private set; }

        public RetiroToAssign(Retiro retiro,Usuario usuario)
        {
            this.retiro = retiro;
            this.usuario = usuario;
        }
    }
}
