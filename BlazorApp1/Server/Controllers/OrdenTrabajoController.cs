using BlazorApp1.Server.Controllers.OT;
using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdenTrabajoController : ControllerBase
    {
        private readonly IOrdenTrabajoRepo ordenTrabajoRepo;

        public OrdenTrabajoController(IOrdenTrabajoRepo ordenTrabajoRepo)
        {
            this.ordenTrabajoRepo = ordenTrabajoRepo;
        }

        [HttpPost("Crear/{Movil:int}")]
        public async Task<IActionResult> Crear(int Movil, [FromBody] Usuario usuario)
        {
            IActionResult actionResult = BadRequest();
            try
            {
                actionResult = Ok(await ordenTrabajoRepo.CreateOrden(Movil, usuario));
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
        public async Task<IActionResult> Cerrar([FromBody] OrdenToClose ordenToClose)
        {
            IActionResult actionResult = BadRequest();
            try
            {
                actionResult = Ok(await ordenTrabajoRepo.CloseOrden(ordenToClose.ordenTrabajo, ordenToClose.usuario));
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

        [HttpPost("Get/{Movil:int}/{Estado}/{DiaDesde:int}/{MesDesde:int}/{AnioDesde:int}/{DiaHasta:int}/{MesHasta:int}/{AnioHasta:int}")]
        public async Task<IActionResult> Traer(int Movil, string Estado, int DiaDesde, int MesDesde, int AnioDesde,
                                               int DiaHasta, int MesHasta, int AnioHasta, [FromBody] Usuario usuario)
        {
            IActionResult actionResult = BadRequest();
            DateTime Desde = DateTime.Parse($"{DiaDesde:00}/{MesDesde:00}/{AnioDesde}");
            DateTime Hasta = DateTime.Parse($"{DiaHasta:00}/{MesHasta:00}/{AnioHasta}");

            try
            {
                Estado = Estado.Replace("_", " ");
                actionResult = Ok(await ordenTrabajoRepo.GetOrdenes(Movil, $"{Estado}", Desde, Hasta, usuario));
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

        //[HttpPost("ExportXLS")]
        //public async Task<IActionResult> Export([FromBody] List<Shared.Modelo.OT.OrdenTrabajo> Ordenes)
        //{

        //}
    }
}
