using BlazorApp1.Shared.Modelo.Comunas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Utilities
{
    public static class Sucursales
    {
        public static Dictionary<string, string> GetSucursales()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            result.Add("ALONSO DE CORDOVA", "86405946-01");
            result.Add("APOQUINDO", "86405964-27");
            result.Add("APUMANQUE", "47800372-07");
            result.Add("CANTAGALLO", "47800372-12");
            result.Add("EL GOLF", "47800372-66");
            result.Add("ESCUELA MILITAR", "47800372-68");
            result.Add("FLEMING (EX PADRE HURTADO)", "90000007-13");
            result.Add("GRECIA", "47800372-42");
            result.Add("IRARRAZAVAL", "90000007-11");
            result.Add("LA DEHESA", "47800372-48");
            result.Add("LOS LEONES", "00000570-37");
            result.Add("MACUL", "47800372-90");
            result.Add("NUEVA TOBALABA", "44300095-46");
            result.Add("PANORAMICO", "44300095-09");
            result.Add("PARQUE ARAUCO", "44300095-10");
            result.Add("PEÑALOLEN", "44300095-15");
            result.Add("PLAZA PEDRO DE VALDIVIA", "44300095-21");
            result.Add("PRINCIPE DE GALES", "11000263-88");
            result.Add("SUECIA", "44300095-40");
            result.Add("TAJAMAR", "28200243-12");
            result.Add("VICUÑA MACKENNA", "44300095-63");
            result.Add("VILLA LA REINA", "44300095-64");
            result.Add("VITACURA", "22900154-70");
            result.Add("BUIN", "47800372-26");
            result.Add("CURACAVI", "86405964-21");
            result.Add("GRAN AVENIDA", "47800372-41");
            result.Add("INTERMODAL LA CISTERNA", "47800372-79");
            result.Add("LA FLORIDA", "47800372-49");
            result.Add("LA PINTANA", "47800372-51");
            result.Add("LOS CERRILLOS", "86403055-19");
            result.Add("MAIPU PAJARITOS", "86405946-06");
            result.Add("MALL PLAZA OESTE", "11000263-86");
            result.Add("MALL PLAZA TOBALABA", "900034559");
            result.Add("TALAGANTE", "44300095-41");
            result.Add("MELIPILLA", "86405946-11");
            result.Add("PAINE", "44300095-07");
            result.Add("PEÑAFLOR", "44300095-14");
            result.Add("PIRQUE", "44300095-18");
            result.Add("PLAZA PUENTE ALTO", "90000007-03");
            result.Add("PUENTE ALTO", "11000263-89");
            result.Add("SAN BERNARDO", "28200243-05");
            result.Add("SAN JOAQUIN", "86406119-11");
            result.Add("PADRE HURTADO", "40300526-57");
            result.Add("AEROPUERTO C.A.M.B.", "519169");
            result.Add("CARGA EXPOSICION", "86406091-13");
            result.Add("COLINA", "47800372-37");
            result.Add("HUECHURABA", "47800372-43");
            result.Add("LAMPA", "52900212-92");
            result.Add("MALL PLAZA NORTE", "47800372-65");
            result.Add("PASEO ESTACION", "44300095-12");
            result.Add("PATRONATO", "44300095-13");
            result.Add("QUILICURA", "11000263-95");
            result.Add("QUINTA NORMAL", "11000263-97");
            result.Add("RENCA", "86406119-10");
            result.Add("VIVACETA", "47800372-76");
            result.Add("AMUNATEGUI", "90000007-02");//90000007-02
            result.Add("AV. MATTA", "47800372-08");
            result.Add("MAC-IVER", "90000007-04");
            result.Add("METRO UNIVERSIDAD DE CHILE", "12400010-83");
            result.Add("MONEDA", "28200243-10");
            result.Add("PLAZA DE ARMAS", "44300095-20");
            result.Add("SANTIAGO SAN MARTIN", "86405964-58");
            result.Add("TENDERINI", "44300095-44");
            result.Add("TRIBUNALES", "44300095-50");
            return result;
        }
        public static KeyValuePair<string,string> GetSucursal(string Codigo)
        {
            return GetSucursales().Where(dic => dic.Value == Codigo).First();
        }

        public static Dictionary<string,string> GetSucursalesBySector(SectorName sectorName)
        {
            Dictionary<string,string> result = new Dictionary<string,string>();

            switch (sectorName)
            {
                case SectorName.Santiago:
                    result.Add("AMUNATEGUI", "90000007-02");
                    result.Add("AV. MATTA", "47800372-08");
                    result.Add("MAC-IVER", "90000007-04");
                    result.Add("METRO UNIVERSIDAD DE CHILE", "12400010-83");
                    result.Add("MONEDA", "28200243-10");
                    result.Add("PLAZA DE ARMAS", "44300095-20");
                    result.Add("SANTIAGO SAN MARTIN", "86405964-58");
                    result.Add("TENDERINI", "44300095-44");
                    result.Add("TRIBUNALES", "44300095-50");
                    break;
                case SectorName.Oriente:
                    result.Add("ALONSO DE CORDOVA", "86405946-01");
                    result.Add("APOQUINDO", "86405964-27");
                    result.Add("APUMANQUE", "47800372-07");
                    result.Add("CANTAGALLO", "47800372-12");
                    result.Add("EL GOLF", "47800372-66");
                    result.Add("ESCUELA MILITAR", "47800372-68");
                    result.Add("FLEMING (EX PADRE HURTADO)", "90000007-13");
                    result.Add("GRECIA", "47800372-42");
                    result.Add("IRARRAZAVAL", "90000007-11");
                    result.Add("LA DEHESA", "47800372-48");
                    result.Add("LOS LEONES", "00000570-37");
                    result.Add("MACUL", "47800372-90");
                    result.Add("NUEVA TOBALABA", "44300095-46");
                    result.Add("PANORAMICO", "44300095-09");
                    result.Add("PARQUE ARAUCO", "44300095-10");
                    result.Add("PEÑALOLEN", "44300095-15");
                    result.Add("PLAZA PEDRO DE VALDIVIA", "44300095-21");
                    result.Add("PRINCIPE DE GALES", "11000263-88");
                    result.Add("SUECIA", "44300095-40");
                    result.Add("TAJAMAR", "28200243-12");
                    result.Add("VICUÑA MACKENNA", "44300095-63");
                    result.Add("VILLA LA REINA", "44300095-64");
                    result.Add("VITACURA", "22900154-70");
                    break;
                case SectorName.Sur:
                    result.Add("BUIN", "47800372-26");
                    result.Add("CURACAVI", "86405964-21");
                    result.Add("GRAN AVENIDA", "47800372-41");
                    result.Add("INTERMODAL LA CISTERNA", "47800372-79");
                    result.Add("LA FLORIDA", "47800372-49");
                    result.Add("LA PINTANA", "47800372-51");
                    result.Add("LOS CERRILLOS", "86403055-19");
                    result.Add("MAIPU PAJARITOS", "86405946-06");
                    result.Add("MALL PLAZA OESTE", "11000263-86");
                    result.Add("MALL PLAZA TOBALABA", "900034559");
                    result.Add("TALAGANTE", "44300095-41");
                    result.Add("MELIPILLA", "86405946-11");
                    result.Add("PAINE", "44300095-07");
                    result.Add("PEÑAFLOR", "44300095-14");
                    result.Add("PIRQUE", "44300095-18");
                    result.Add("PLAZA PUENTE ALTO", "90000007-03");
                    result.Add("PUENTE ALTO", "11000263-89");
                    result.Add("SAN BERNARDO", "28200243-05");
                    result.Add("SAN JOAQUIN", "86406119-11");
                    result.Add("PADRE HURTADO", "40300526-57");
                    break;
                case SectorName.Norte:
                    result.Add("AEROPUERTO C.A.M.B.", "519169");
                    result.Add("CARGA EXPOSICION", "86406091-13");
                    result.Add("COLINA", "47800372-37");
                    result.Add("HUECHURABA", "47800372-43");
                    result.Add("LAMPA", "52900212-92");
                    result.Add("MALL PLAZA NORTE", "47800372-65");
                    result.Add("PASEO ESTACION", "44300095-12");
                    result.Add("PATRONATO", "44300095-13");
                    result.Add("QUILICURA", "11000263-95");
                    result.Add("QUINTA NORMAL", "11000263-97");
                    result.Add("RENCA", "86406119-10");
                    result.Add("VIVACETA", "47800372-76");
                    break;

            }

            return result;
        }
    }
}
