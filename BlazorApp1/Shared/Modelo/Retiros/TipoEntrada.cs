using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public enum TipoEntrada
    {
        Todos,
        [Description("Sac")]
        SAC,
        [Description("TConecta")]
        TCONECTA,
        [Description("Valija")]
        VALIJA,
        [Description("Courier")]
        COURIER,
        [Description("Fichero")]
        FCLI
    }
}
