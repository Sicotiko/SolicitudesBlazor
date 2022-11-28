using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Management.OT
{
    public class OrdenTrabajoStatic
    {
        private static OrdenTrabajoStatic instance;
        private static Dictionary<string, string> OrdenTrabajoAM;
        private static Dictionary<string, string> OrdenTrabajoPM;

        protected OrdenTrabajoStatic()
        {
            OrdenTrabajoAM = new Dictionary<string, string>();
            OrdenTrabajoPM = new Dictionary<string, string>();
        }

        public static string SearchByMovilInAm(string Movil)
        {
            string result;

            if (instance == null)
            {
                instance = new OrdenTrabajoStatic();
            }

            if (OrdenTrabajoAM.TryGetValue(Movil, out result))
                return result;
            else
                return null;
        }
        public static string SearchByMovilInPm(string Movil)
        {
            string result;

            if (instance == null)
            {
                instance = new OrdenTrabajoStatic();
            }

            if (OrdenTrabajoPM.TryGetValue(Movil, out result))
                return result;
            else
                return null;
        }
        public static void AddToAm(string Movil,string OrdenTrabajo)
        {
            if (instance == null)
            {
                instance = new OrdenTrabajoStatic();
            }
            OrdenTrabajoAM.Add(Movil, OrdenTrabajo);
        }
        public static void AddToPm(string Movil, string OrdenTrabajo)
        {
            if (instance == null)
            {
                instance = new OrdenTrabajoStatic();
            }
            OrdenTrabajoPM.Add(Movil, OrdenTrabajo);
        }

    }
}
