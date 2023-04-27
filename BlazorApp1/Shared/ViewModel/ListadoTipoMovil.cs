using BlazorApp1.Shared.Modelo.Moviles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.ViewModel
{
    public class ListadoTipoMovil
    {
        public List<TipoMovil> TipoMoviles { get; set; } = new List<TipoMovil>();
    }
}
