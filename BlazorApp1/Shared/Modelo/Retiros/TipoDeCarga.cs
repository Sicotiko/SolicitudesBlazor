using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public enum TipoDeCarga
    {
        Todos,
        [Description("Paqueteria")]
        P,
        [Description("Documento")]
        D,
        [Description("Mixto")]
        M
    }
}
