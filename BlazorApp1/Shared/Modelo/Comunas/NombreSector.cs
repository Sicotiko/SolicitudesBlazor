using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Comunas
{
    public enum NombreSector
    {
        [Description("Norte")]
        Norte,
        [Description("Norte Extra")]
        NorteExtra,
        [Description("Santiago")]
        Santiago,
        [Description("Santiago Extra")]
        SantiagoExtra,
        [Description("San Antonio")]
        SanAntonio,
        [Description("Oriente")]
        Oriente
    }
}
