using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.OT
{
    public enum Estado
    {
        [Description("No Cerradas")]
        NO_CERRADAS,
        [Description("Provisional")]
        PROVISIONAL,
        [Description("Definitiva")]
        DEFINITIVA,
        [Description("Cerrada")]
        CERRADA
    }
}
