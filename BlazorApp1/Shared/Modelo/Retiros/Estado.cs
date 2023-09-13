using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public enum Estado
    {
        Todos,
        [Description("Pendientes y Asignadas")]
        PEND_ASIG,
        [Description("Pendientes")]
        PEND,
        [Description("Asignadas")]
        ASIG,
        [Description("Efectuada")]
        EFEC,
        [Description("No Efectuada")]
        NOEF,
        [Description("Rechazada")]
        RECH,
        [Description("Pendientes y Rechazadas")]
        PEND_RECH,
        [Description("Cancelada")]
        CANC,

    }
}
