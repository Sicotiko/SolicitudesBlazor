using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Comunas
{
    public enum SectorName
    {
        Norte,
        Sur,
        Oriente,
        Santiago,
        San_Antonio
    }
    public class Sector
    {
        private string nombre = string.Empty;
        private List<Comuna> comunas = new List<Comuna>();
        private Dictionary<string,string> sucursales = new Dictionary<string,string>();

        public string Nombre
        {
            get { return nombre; }
            private set { nombre = value; }
        }
        public List<Comuna> Comunas
        {
            get { return comunas; }
            private set { comunas = value; }
        }
        public Dictionary<string,string> Sucursales
        {
            get { return sucursales; }
            private set { sucursales = value; }
        }
        public Sector(SectorName NombreSector)
        {
            Comunas = new List<Comuna>();
            Nombre = NombreSector.ToString();


            Dictionary<string, string> dicComunas = Utilities.Comunas.GetComunasPorSector(NombreSector);
            foreach (KeyValuePair<string,string> dicComuna in dicComunas)
            {
                Comuna comuna = new Comuna();
                comuna.Nombre = dicComuna.Key;
                comuna.CodigoPostal = dicComuna.Value;
                Comunas.Add(comuna);
            }
        }
        public Sector(SectorName NombreSector, bool Sucursal = false)
        {
            Nombre = NombreSector.ToString();
            Sucursales = Utilities.Sucursales.GetSucursalesBySector(NombreSector);
        }
        public static List<Sector> GetSectoresDefault()
        {
            List<Sector> list = new List<Sector>();
            list.Add(new Sector(SectorName.Norte));
            list.Add(new Sector(SectorName.Sur));
            list.Add(new Sector(SectorName.Oriente));
            list.Add(new Sector(SectorName.Santiago));
            list.Add(new Sector(SectorName.San_Antonio));
            return list;
        }
        public static List<Sector> GetSectoresConSucursales()
        {
            List<Sector> list = new List<Sector>();
            list.Add(new Sector(SectorName.Norte,false));
            list.Add(new Sector(SectorName.Sur, false));
            list.Add(new Sector(SectorName.Oriente, false));
            list.Add(new Sector(SectorName.Santiago, false));
            list.Add(new Sector(SectorName.San_Antonio, false));
            return list;
        }
    }
}
