using BlazorApp1.Shared.Modelo.Comunas;
using BlazorApp1.Shared.Modelo.Sucursales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Utilities
{
    public static class Sucursales
    {

        public static async Task<List<Sucursal>> GetSucursalesAsync()
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            await Task.Run(() =>
            {
                sucursales.Add(new Sucursal { Nombre = "ALONSO DE CORDOVA", CodigoCliente = "86405946-01", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "APOQUINDO", CodigoCliente = "86405964-27", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "APUMANQUE", CodigoCliente = "47800372-07", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "CANTAGALLO", CodigoCliente = "47800372-12", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "EL GOLF", CodigoCliente = "47800372-66", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "ESCUELA MILITAR", CodigoCliente = "47800372-68", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "FLEMING (EX PADRE HURTADO)", CodigoCliente = "90000007-13", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "IRARRAZAVAL", CodigoCliente = "90000007-11", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "LA DEHESA", CodigoCliente = "47800372-48", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "LOS LEONES", CodigoCliente = "00000570-37", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "MACUL", CodigoCliente = "47800372-90", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "NUEVA TOBALABA", CodigoCliente = "44300095-46", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "PANORAMICO", CodigoCliente = "44300095-09", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "PARQUE ARAUCO", CodigoCliente = "44300095-10", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "PEÑALOLEN", CodigoCliente = "44300095-15", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "PLAZA PEDRO DE VALDIVIA", CodigoCliente = "44300095-21", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "PRINCIPE DE GALES", CodigoCliente = "11000263-88", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "SUECIA", CodigoCliente = "44300095-40", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "TAJAMAR", CodigoCliente = "28200243-12", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "VICUÑA MACKENNA", CodigoCliente = "44300095-63", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "VILLA LA REINA", CodigoCliente = "44300095-64", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "VITACURA", CodigoCliente = "22900154-70", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "BUIN", CodigoCliente = "47800372-26", NombreSector = NombreSector.NorteExtra });
                sucursales.Add(new Sucursal { Nombre = "CURACAVI", CodigoCliente = "86405964-21", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "GRAN AVENIDA", CodigoCliente = "47800372-41", NombreSector = NombreSector.NorteExtra });
                sucursales.Add(new Sucursal { Nombre = "INTERMODAL LA CISTERNA", CodigoCliente = "47800372-79", NombreSector = NombreSector.NorteExtra });
                sucursales.Add(new Sucursal { Nombre = "LA FLORIDA", CodigoCliente = "47800372-49", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "LA PINTANA", CodigoCliente = "47800372-51", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "LOS CERRILLOS", CodigoCliente = "86403055-19", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "MAIPU PAJARITOS", CodigoCliente = "86405946-06", NombreSector = NombreSector.SantiagoExtra });
                sucursales.Add(new Sucursal { Nombre = "MALL PLAZA OESTE", CodigoCliente = "11000263-86", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "MALL PLAZA TOBALABA", CodigoCliente = "900034559", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "TALAGANTE", CodigoCliente = "44300095-41", NombreSector = NombreSector.NorteExtra });
                sucursales.Add(new Sucursal { Nombre = "MELIPILLA", CodigoCliente = "86405946-11", NombreSector = NombreSector.SantiagoExtra });
                sucursales.Add(new Sucursal { Nombre = "PAINE", CodigoCliente = "44300095-07", NombreSector = NombreSector.NorteExtra });
                sucursales.Add(new Sucursal { Nombre = "PEÑAFLOR", CodigoCliente = "44300095-14", NombreSector = NombreSector.SantiagoExtra });
                sucursales.Add(new Sucursal { Nombre = "PIRQUE", CodigoCliente = "44300095-18", NombreSector = NombreSector.NorteExtra });
                sucursales.Add(new Sucursal { Nombre = "PLAZA PUENTE ALTO", CodigoCliente = "90000007-03", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "PUENTE ALTO", CodigoCliente = "11000263-89", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "SAN BERNARDO", CodigoCliente = "28200243-05", NombreSector = NombreSector.SantiagoExtra });
                sucursales.Add(new Sucursal { Nombre = "SAN JOAQUIN", CodigoCliente = "86406119-11", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "PADRE HURTADO", CodigoCliente = "40300526-57", NombreSector = NombreSector.Oriente });
                sucursales.Add(new Sucursal { Nombre = "AEROPUERTO C.A.M.B.", CodigoCliente = "519169", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "CARGA EXPOSICION", CodigoCliente = "86406091-13", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "COLINA", CodigoCliente = "47800372-37", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "HUECHURABA", CodigoCliente = "47800372-43", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "LAMPA", CodigoCliente = "52900212-92", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "MALL PLAZA NORTE", CodigoCliente = "47800372-65", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "PASEO ESTACION", CodigoCliente = "44300095-12", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "PATRONATO", CodigoCliente = "44300095-13", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "QUILICURA", CodigoCliente = "11000263-95", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "QUINTA NORMAL", CodigoCliente = "11000263-97", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "RENCA", CodigoCliente = "86406119-10", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "VIVACETA", CodigoCliente = "47800372-76", NombreSector = NombreSector.Norte });
                sucursales.Add(new Sucursal { Nombre = "AMUNATEGUI", CodigoCliente = "90000007-02", NombreSector = NombreSector.Santiago });
                sucursales.Add(new Sucursal { Nombre = "AV. MATTA", CodigoCliente = "47800372-08", NombreSector = NombreSector.Santiago });
                sucursales.Add(new Sucursal { Nombre = "MAC-IVER", CodigoCliente = "90000007-04", NombreSector = NombreSector.Santiago });
                sucursales.Add(new Sucursal { Nombre = "METRO UNIVERSIDAD DE CHILE", CodigoCliente = "12400010-83", NombreSector = NombreSector.Santiago });
                sucursales.Add(new Sucursal { Nombre = "MONEDA", CodigoCliente = "28200243-10", NombreSector = NombreSector.Santiago });
                sucursales.Add(new Sucursal { Nombre = "PLAZA DE ARMAS", CodigoCliente = "44300095-20", NombreSector = NombreSector.Santiago });
                sucursales.Add(new Sucursal { Nombre = "SANTIAGO SAN MARTIN", CodigoCliente = "86405964-58", NombreSector = NombreSector.Santiago });
                sucursales.Add(new Sucursal { Nombre = "TENDERINI", CodigoCliente = "44300095-44", NombreSector = NombreSector.Santiago });
                sucursales.Add(new Sucursal { Nombre = "TRIBUNALES", CodigoCliente = "44300095-50", NombreSector = NombreSector.Santiago });

            });

            return sucursales;
        }

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
            result.Add("AMUNATEGUI", "90000007-02");
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
        public static KeyValuePair<string, string> GetSucursal(string Codigo)
        {
            return GetSucursales().Where(dic => dic.Value == Codigo).First();
        }

        public static Dictionary<string, string> GetSucursalesBySector(SectorName sectorName)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

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
