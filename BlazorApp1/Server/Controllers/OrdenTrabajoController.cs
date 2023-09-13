using BlazorApp1.Server.Services;
using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.Modelo.OT;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenTrabajoController : ControllerBase
    {
        private readonly ServiceOrdenTrabajo serviceOrdenTrabajo;
        private readonly ListadoOrdenes ordenes;

        public OrdenTrabajoController(ServiceOrdenTrabajo serviceOrdenTrabajo, ListadoOrdenes ordenes)
        {
            this.serviceOrdenTrabajo = serviceOrdenTrabajo;
            this.ordenes = ordenes;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] OrdenViewModel ordenViewModel)
        {
            IActionResult actionResult = BadRequest();
            try
            {
                var orden = await serviceOrdenTrabajo.CreateOrdenTrabajoAsync(ordenViewModel);
                //ordenes.AddOrden(orden);
                actionResult = Ok(orden);
            }
            catch (ConnectionException ConnEx)
            {
                actionResult = StatusCode(900, ConnEx.Message);
            }
            catch (CredentialsException CredEx)
            {
                actionResult = StatusCode(901, CredEx.Message);
            }

            return actionResult;
        }

        [HttpPost("Cerrar")]
        public async Task<IActionResult> Cerrar([FromBody] OrdenViewModel ordenViewModel)
        {
            IActionResult actionResult = BadRequest();
            try
            {
                var okResult = await serviceOrdenTrabajo.CerrarOrdenAsync(ordenViewModel);
                //if (okResult)
                //    ordenes.DeleteOrden(ordenViewModel.OrdenDeTrabajo);
                actionResult = Ok(okResult);
            }
            catch (ConnectionException ConnEx)
            {
                actionResult = StatusCode(900, ConnEx.Message);
            }
            catch (CredentialsException CredEx)
            {
                actionResult = StatusCode(901, CredEx.Message);
            }

            return actionResult;
        }

        [HttpPost("Get")]
        public async Task<IActionResult> Traer([FromBody] FiltroBusquedaOrdenTrabajo filtro)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                actionResult = Ok(await serviceOrdenTrabajo.GetOrdenesAsync(filtro));
            }
            catch (ConnectionException ConnEx)
            {
                actionResult = StatusCode(900, ConnEx.Message);
            }
            catch (CredentialsException CredEx)
            {
                actionResult = StatusCode(901, CredEx.Message);
            }


            return actionResult;
        }
        [HttpPost("GetLocal")]
        public async Task<IActionResult> GetOrdenesLocal([FromBody] FiltroBusquedaOrdenTrabajo filtro)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                filtro.FechaDesde = filtro.FechaDesde.Date.ToUniversalTime();
                filtro.FechaHasta = filtro.FechaHasta.Date.ToUniversalTime();
                List<OrdenTrabajo> ordenTrabajos = new List<OrdenTrabajo>();
                await Task.Run(async () =>
                {
                    //var ss = ordenes.GetOrdenes();
                    ordenTrabajos = await serviceOrdenTrabajo.GetOrdenesAsync(filtro.FechaDesde, filtro.FechaHasta);
                });


                actionResult = Ok(ordenTrabajos);
            }
            catch (ConnectionException ConnEx)
            {
                actionResult = StatusCode(900, ConnEx.Message);
            }
            catch (CredentialsException CredEx)
            {
                actionResult = StatusCode(901, CredEx.Message);
            }


            return actionResult;
        }
        [HttpPost("BorrarLocal")]
        public async Task<IActionResult> BorrarOrdenesLocal(OrdenTrabajo orden)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                await Task.Run(() => { ordenes.DeleteOrden(orden); });
                actionResult = Ok();
            }
            catch (ConnectionException ConnEx)
            {
                actionResult = StatusCode(900, ConnEx.Message);
            }
            catch (CredentialsException CredEx)
            {
                actionResult = StatusCode(901, CredEx.Message);
            }


            return actionResult;
        }
    }
}

