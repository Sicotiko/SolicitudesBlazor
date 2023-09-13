using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public enum ConIncidencia
    {
        Ambas,
        [Description("Si")]
        S,
        [Description("No")]
        N
    }
}
