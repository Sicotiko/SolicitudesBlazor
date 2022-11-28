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
        public Retiro _retiro { get; private set; }
        public Usuario _usuario { get; private set; }

        RetiroToAssign(Retiro retiro,Usuario usuario)
        {
            _retiro = retiro;
            _usuario = usuario;
        }
    }
}
