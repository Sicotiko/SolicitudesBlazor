using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public enum Clasificacion
    {
        [Description("CDP")]
        CDP,
        [Description("Sucursal")]
        Sucursal,
        [Description("Fijo")]
        Fijo,
        [Description("Eventual")]
        Eventual,
        [Description("Muelle")]
        Muelle,

    }
}
