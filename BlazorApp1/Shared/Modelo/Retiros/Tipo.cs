using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public enum Tipo
    {
        [Description("Propias y Recibidas")]
        PROP_RECI,
        [Description("Propias")]
        PROP,
        [Description("Recibidas")]
        RECI,
        [Description("Ordenadas")]
        ORDE,
        Todos,

    }
}
