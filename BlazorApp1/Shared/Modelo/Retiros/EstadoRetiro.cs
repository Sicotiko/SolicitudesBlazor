using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public static class EstadoRetiro
    {
        public const string Todos = "";
        public const string Pendientes_Y_Asignados = "PEND_ASIG";
        public const string Pendientes = "PEND";
        public const string Asignada = "ASIG";
        public const string Efectuada = "EFEC";
        public const string No_Efectuada = "NOEF";
        public const string Rechazada = "RECH";
        public const string Pendientes_Y_Rechazadas = "PEND_RECH";
        public const string Cancelada = "CANC";
    }
}
