using BlazorApp1.Shared.Modelo.Comunas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Utilities
{
    public static class Comunas
    {

        public static Dictionary<string, string> GetComunas()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            result.Add("Colina", "9340000");
            result.Add("Lampa", "9380000");
            result.Add("TilTil", "9420000");
            result.Add("Pirque", "9480000");
            result.Add("Puente Alto", "8150000");
            result.Add("San José de Maipo", "9460000");
            result.Add("Buin", "9500000");
            result.Add("Calera de Tango", "9560000");
            result.Add("Paine", "9540000");
            result.Add("San Bernardo", "8050000");
            result.Add("Alhué", "9650000");
            result.Add("Curacaví", "9630000");
            result.Add("María Pinto", "9620000");
            result.Add("Melipilla", "9580000");
            result.Add("San Pedro", "9660000");
            result.Add("Cerrillos", "9200000");
            result.Add("Cerro Navia", "9080000");
            result.Add("Conchalí", "8540000");
            result.Add("El Bosque", "8010000");
            result.Add("Estación Central", "9160000");
            result.Add("Huechuraba", "8580000");
            result.Add("Independencia", "8380000");
            result.Add("La Cisterna", "7970000");
            result.Add("La Florida", "8240000");
            result.Add("La Granja", "8780000");
            result.Add("La Pintana", "8820000");
            result.Add("La Reina", "7850000"); //o
            result.Add("Las Condes", "7550000"); //o
            result.Add("Lo Barnechea", "7690000"); //o
            result.Add("Lo Espejo", "9120000");
            result.Add("Lo Prado", "8980000");
            result.Add("Macul", "7810000"); //o
            result.Add("Maipú", "9250000");
            result.Add("Ñuñoa", "7750000"); //o
            result.Add("Pedro Aguirre Cerda", "8460000");
            result.Add("Peñalolén", "7910000"); //o
            result.Add("Providencia", "7500000"); //o
            result.Add("Pudahuel", "9020000");
            result.Add("Quilicura", "8700000");
            result.Add("Quinta Normal", "8500000");
            result.Add("Recoleta", "8420000");
            result.Add("Renca", "8640000");
            result.Add("San Joaquín", "8940000");
            result.Add("San Miguel", "8900000");
            result.Add("San Ramón", "8860000");
            result.Add("Santiago", "8320000");
            result.Add("Vitacura", "7630000"); //o
            result.Add("El Monte", "9810000");
            result.Add("Isla de Maipo", "9790000");
            result.Add("Padre Hurtado", "9710000");
            result.Add("Peñaflor", "9750000");
            result.Add("Talagante", "9670000");
            result.Add("San Antonio", "2660000");
            result.Add("Algarrobo", "2710000");
            result.Add("Cartagena", "2680000");
            result.Add("El Tabo", "2690000");
            result.Add("El Quisco", "2700000");
            result.Add("Santo Domingo", "2720000");
            return result;
        }

        public static Dictionary<string, string> GetComunasPorSector(SectorName NombreSector)
        {
            switch (NombreSector)
            {
                case SectorName.Oriente:
                    return GetComunasOriente();
                case SectorName.Santiago:
                    return GetComunasSantiago();
                case SectorName.Norte:
                    return GetComunasNorte();
                case SectorName.Sur:
                    return GetComunasSur();
                case SectorName.San_Antonio:
                    return GetComunasSanAntonio();
                default:
                    return GetComunas();
            }
        }

        private static Dictionary<string,string> GetComunasSanAntonio()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("San Antonio", "2660000");
            result.Add("Algarrobo", "2710000");
            result.Add("Cartagena", "2680000");
            result.Add("El Tabo", "2690000");
            result.Add("El Quisco", "2700000");
            result.Add("Santo Domingo", "2720000");
            return result;
        }
        private static Dictionary<string,string> GetComunasSantiago()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("Santiago", "8320000");

            return result;
        }
        private static Dictionary<string,string> GetComunasNorte()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("Independencia", "8380000");
            result.Add("Recoleta", "8420000");
            result.Add("Quinta Normal", "8500000");
            result.Add("Conchalí", "8540000");
            result.Add("Huechuraba", "8580000");
            result.Add("Renca", "8640000");
            result.Add("Quilicura", "8700000");
            result.Add("Lo Prado", "8980000");
            result.Add("Pudahuel", "9020000");
            result.Add("Cerro Navia", "9080000");
            result.Add("Estación Central", "9160000");
            result.Add("Colina", "9340000");
            result.Add("Lampa", "9380000");
            result.Add("TilTil", "9420000");
            return result;
        }
        private static Dictionary<string, string> GetComunasSur()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("La Cisterna", "7970000");
            result.Add("El Bosque", "8010000");
            result.Add("San Bernardo", "8050000");
            result.Add("Puente Alto", "8150000");
            result.Add("La Florida", "8240000");
            result.Add("Pedro Aguirre Cerda", "8460000");
            result.Add("La Granja", "8780000");
            result.Add("La Pintana", "8820000");
            result.Add("San Ramón", "8860000");
            result.Add("San Miguel", "8900000");
            result.Add("San Joaquín", "8940000");
            result.Add("Lo Espejo", "9120000");
            result.Add("Cerrillos", "9200000");
            result.Add("Maipú", "9250000");
            result.Add("San José de Maipo", "9460000");
            result.Add("Pirque", "9480000");
            result.Add("Buin", "9500000");
            result.Add("Paine", "9540000");
            result.Add("Calera de Tango", "9560000");
            result.Add("Melipilla", "9580000");
            result.Add("María Pinto", "9620000");
            result.Add("Curacaví", "9630000");
            result.Add("Alhué", "9650000");
            result.Add("San Pedro", "9660000");
            result.Add("Talagante", "9670000");
            result.Add("Padre Hurtado", "9710000");
            result.Add("Peñaflor", "9750000");
            result.Add("Isla de Maipo", "9790000");
            result.Add("El Monte", "9810000");

            return result;
        }
        private static Dictionary<string, string> GetComunasOriente()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("Providencia", "7500000");
            result.Add("Las Condes", "7550000");
            result.Add("Vitacura", "7630000");
            result.Add("Lo Barnechea", "7690000");
            result.Add("Ñuñoa", "7750000");
            result.Add("Macul", "7810000");
            result.Add("La Reina", "7850000");
            result.Add("Peñalolén", "7910000");
            return result;
        }
    }
}
