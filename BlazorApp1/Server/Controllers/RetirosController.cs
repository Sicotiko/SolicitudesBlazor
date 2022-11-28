using BlazorApp1.Server.Controllers.Retiros;
using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Modelo.Retiros;
using BlazorApp1.Shared.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RetirosController : ControllerBase
    {
        private readonly IRetirosRepo _retirosRepo; 

        public RetirosController(IRetirosRepo retirosRepo)
        {
            _retirosRepo = retirosRepo;
        }

        [HttpPost("Asignar")]
        public IActionResult Asignar([FromBody] RetiroToAssign retiroToAssign)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                _retirosRepo.AsignarRetiroAsync(retiroToAssign._retiro, retiroToAssign._usuario);
                actionResult = Ok();
            }
            catch (System.Exception ex)
            {
                actionResult = BadRequest($"No se logro asignar el retiro: {ex.Message} : {ex.InnerException}");
            }

            return actionResult;
        }

        [HttpGet("GetRetiros/{TipoEntrada:string}/{Comuna:string}/{EstadoRetiro:string}/{FechaDesde:datetime}/{FechaHasta:datetime}")]
        public async Task<IActionResult> GetRetiros([FromBody] Usuario usuario, string TipoEntrada,string Comuna,string EstadoRetiro,
                                                        DateTime FechaDesde, DateTime FechaHasta)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                IEnumerable listadoRetiros = await _retirosRepo.GetRetirosAsync(TipoEntrada, Comuna, FechaDesde, FechaHasta, usuario, EstadoRetiro);
                actionResult = Ok(listadoRetiros);
            }catch(Exception ex)
            {
                actionResult = BadRequest($"No se logro obtener retiros: {ex.Message} : {ex.InnerException}");
            }

            return actionResult;
        }

        [HttpGet("GetDetalle/{NumeroRetiro:int}")]
        public async Task<IActionResult> GetDetalle([FromBody] Usuario usuario,int NumeroRetiro)
        {
            IActionResult actionResult= BadRequest();

            try
            {
                Retiro retiro = await _retirosRepo.GetDetalleAsync(NumeroRetiro, usuario);
                actionResult = Ok(retiro);
            }catch(Exception ex)
            {
                actionResult = BadRequest($"No se logro obtener el detalle: {ex.Message} : {ex.InnerException}");
            }

            return actionResult;
        }

        [HttpGet("ReporteSucursal/{FechaSolicitud:datetime}")]
        public async Task<IActionResult> ReporteSucursal([FromBody] Usuario usuario, DateTime FechaSolicitud)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                IEnumerable<Retiro> retiros = await _retirosRepo.GetReporteSucursalesAsync(FechaSolicitud, usuario);
                actionResult = Ok(retiros);
            }catch(Exception ex)
            {
                actionResult = BadRequest($"No se logro obtener el reporte: {ex.Message} : {ex.InnerException}");
            }

            return actionResult;
        }

    }
}
