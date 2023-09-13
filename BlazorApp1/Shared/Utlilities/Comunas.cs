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

        //public static async Task<List<Comuna>> GetTotalComunasAsync()
        //{
        //    List<Comuna> list = new List<Comuna>();
        //    await Task.Run(() =>
        //    {
        //        list.Add(new Comuna { Nombre = "Colina", CodigoPostal = "9340000", NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "Lampa", CodigoPostal = "9380000", NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "TilTil", CodigoPostal = "9420000", NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "Pirque", CodigoPostal = "9480000", NombreSector = NombreSector.NorteExtra });
        //        list.Add(new Comuna { Nombre = "Puente Alto", CodigoPostal = "8150000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "San José de Maipo", CodigoPostal = "9460000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "Buin", CodigoPostal = "9500000", NombreSector = NombreSector.NorteExtra });
        //        list.Add(new Comuna { Nombre = "Calera de Tango", CodigoPostal = "9560000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "Paine", CodigoPostal = "9540000", NombreSector = NombreSector.NorteExtra });
        //        list.Add(new Comuna { Nombre = "San Bernardo", CodigoPostal = "8050000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "Alhué", CodigoPostal = "9650000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "Curacaví", CodigoPostal = "9630000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "María Pinto", CodigoPostal = "9620000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "Melipilla", CodigoPostal = "9580000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "San Pedro", CodigoPostal = "9660000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "Cerrillos", CodigoPostal = "9200000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Cerro Navia", CodigoPostal = "9080000", NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "Conchalí", CodigoPostal = "8540000", NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "El Bosque", CodigoPostal = "8010000", NombreSector = NombreSector.NorteExtra });
        //        list.Add(new Comuna { Nombre = "Estación Central", CodigoPostal = "9160000", NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "Huechuraba", CodigoPostal = "8580000", NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "Independencia", CodigoPostal = "8380000", NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "La Cisterna", CodigoPostal = "7970000", NombreSector = NombreSector.NorteExtra });
        //        list.Add(new Comuna { Nombre = "La Florida", CodigoPostal = "8240000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "La Granja", CodigoPostal = "8780000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "La Pintana", CodigoPostal = "8820000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "La Reina", CodigoPostal = "7850000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Las Condes", CodigoPostal = "7550000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Lo Barnechea", CodigoPostal = "7690000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Lo Espejo", CodigoPostal = "9120000" , NombreSector = NombreSector.NorteExtra });
        //        list.Add(new Comuna { Nombre = "Lo Prado", CodigoPostal = "8980000" , NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "Macul", CodigoPostal = "7810000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Maipú", CodigoPostal = "9250000" , NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Ñuñoa", CodigoPostal = "7750000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Pedro Aguirre Cerda", CodigoPostal = "8460000" , NombreSector = NombreSector.NorteExtra  });
        //        list.Add(new Comuna { Nombre = "Peñalolén", CodigoPostal = "7910000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Providencia", CodigoPostal = "7500000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Pudahuel", CodigoPostal = "9020000" , NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "Quilicura", CodigoPostal = "8700000" , NombreSector = NombreSector.Norte});
        //        list.Add(new Comuna { Nombre = "Quinta Normal", CodigoPostal = "8500000" , NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "Recoleta", CodigoPostal = "8420000" , NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "Renca", CodigoPostal = "8640000" , NombreSector = NombreSector.Norte });
        //        list.Add(new Comuna { Nombre = "San Joaquín", CodigoPostal = "8940000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "San Miguel", CodigoPostal = "8900000", NombreSector = NombreSector.NorteExtra });
        //        list.Add(new Comuna { Nombre = "San Ramón", CodigoPostal = "8860000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Santiago", CodigoPostal = "8320000", NombreSector = NombreSector.Santiago });
        //        list.Add(new Comuna { Nombre = "Vitacura", CodigoPostal = "7630000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "El Monte", CodigoPostal = "9810000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "Isla de Maipo", CodigoPostal = "9790000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "Padre Hurtado", CodigoPostal = "9710000", NombreSector = NombreSector.Oriente });
        //        list.Add(new Comuna { Nombre = "Peñaflor", CodigoPostal = "9750000", NombreSector = NombreSector.SantiagoExtra });
        //        list.Add(new Comuna { Nombre = "Talagante", CodigoPostal = "9670000", NombreSector = NombreSector.NorteExtra });
        //        list.Add(new Comuna { Nombre = "San Antonio", CodigoPostal = "2660000", NombreSector = NombreSector.SanAntonio });
        //        list.Add(new Comuna { Nombre = "Algarrobo", CodigoPostal = "2710000", NombreSector = NombreSector.SanAntonio });
        //        list.Add(new Comuna { Nombre = "Cartagena", CodigoPostal = "2680000", NombreSector = NombreSector.SanAntonio });
        //        list.Add(new Comuna { Nombre = "El Tabo", CodigoPostal = "2690000", NombreSector = NombreSector.SanAntonio });
        //        list.Add(new Comuna { Nombre = "El Quisco", CodigoPostal = "2700000", NombreSector = NombreSector.SanAntonio });
        //        list.Add(new Comuna { Nombre = "Santo Domingo", CodigoPostal = "2720000", NombreSector = NombreSector.SanAntonio });
        //    });

        //    return list;
        //}
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

        private static Dictionary<string, string> GetComunasSanAntonio()
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
        private static Dictionary<string, string> GetComunasSantiago()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("Santiago", "8320000");

            return result;
        }
        private static Dictionary<string, string> GetComunasNorte()
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
