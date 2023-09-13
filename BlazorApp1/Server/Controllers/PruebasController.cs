using BlazorApp1.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebasController : ControllerBase
    {
        private readonly ServiceRetiro serviceRetiro;
        private ListadoOrdenes listadoOrdenes { get; set; }
        private readonly ServiceOrdenTrabajo serviceOrdenTrabajo;
        public PruebasController(ServiceRetiro serviceRetiro, ListadoOrdenes listadoOrdenes, ServiceOrdenTrabajo serviceOrdenTrabajo)
        {
            this.serviceRetiro = serviceRetiro;
            this.listadoOrdenes = listadoOrdenes;
            this.serviceOrdenTrabajo = serviceOrdenTrabajo;
        }



    }
}
