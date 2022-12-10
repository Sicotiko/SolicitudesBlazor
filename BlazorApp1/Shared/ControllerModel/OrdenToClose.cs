using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.ControllerModel
{
    public class OrdenToClose
    {
        public OrdenTrabajo ordenTrabajo { get; private set; }
        public Usuario usuario { get; private set; }

        public OrdenToClose(OrdenTrabajo ordenTrabajo, Usuario usuario)
        {
            this.ordenTrabajo = ordenTrabajo;
            this.usuario = usuario;
        }
    }
}
