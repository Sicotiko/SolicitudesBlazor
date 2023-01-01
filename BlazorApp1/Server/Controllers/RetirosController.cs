using BlazorApp1.Server.Controllers.Retiros;
using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Excepciones;
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
        public async Task<IActionResult> Asignar([FromBody] RetiroToAssign retiroToAssign)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                await _retirosRepo.AsignarRetiroAsync(retiroToAssign.retiro, retiroToAssign.usuario);
                actionResult = Ok();
            }
            catch (ConnectionException ConnEx)
            {
                actionResult = StatusCode(502,ConnEx.Message); //badGateway
            }
            catch (CredentialsException CredEx)
            {
                actionResult = Unauthorized(CredEx.Message);
            }

            return actionResult;
        }

        [HttpPost("GetRetiros/{TipoEntrada}/{Comuna}/{EstadoRetiro}/{diaDesde}/{mesDesde}/{anioDesde}/{diaHasta}/{mesHasta}/{anioHasta}")]
        public async Task<IActionResult> GetRetiros(string TipoEntrada, string Comuna, string EstadoRetiro,
                                                    string diaDesde, string mesDesde, string anioDesde,
                                                    string diaHasta, string mesHasta, string anioHasta,
                                                    [FromBody] Usuario usuario)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                DateTime FechaDesde = DateTime.Parse($"{diaDesde}/{mesDesde}/{anioDesde}");
                DateTime FechaHasta = DateTime.Parse($"{diaHasta}/{mesHasta}/{anioHasta}");
                if (EstadoRetiro == "TODOS")
                    EstadoRetiro = "";
                TipoEntrada = TipoEntrada == "TODOS" ? "" : TipoEntrada;

                IEnumerable listadoRetiros = await _retirosRepo.GetRetirosAsync(TipoEntrada, Comuna, FechaDesde, FechaHasta, usuario, EstadoRetiro);
                actionResult = Ok(listadoRetiros);
            }
            catch (ConnectionException ConnEx)
            {
                actionResult = StatusCode(502, ConnEx.Message); //badGateway
            }
            catch (CredentialsException CredEx)
            {
                actionResult = Unauthorized(CredEx.Message);
            }

            return actionResult;
        }
        [HttpPost("GetRetirosByMovil/{TipoEntrada}/{Movil}/{EstadoRetiro}/{diaDesde}/{mesDesde}/{anioDesde}/{diaHasta}/{mesHasta}/{anioHasta}")]
        public async Task<IActionResult> GetRetirosByMovil(string TipoEntrada, string EstadoRetiro,
                                                           string diaDesde, string mesDesde, string anioDesde,
                                                           string diaHasta, string mesHasta, string anioHasta,
                                                           string Movil, [FromBody] Usuario usuario)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                DateTime FechaDesde = DateTime.Parse($"{diaDesde}/{mesDesde}/{anioDesde}");
                DateTime FechaHasta = DateTime.Parse($"{diaHasta}/{mesHasta}/{anioHasta}");

                IEnumerable listadoRetiros = await _retirosRepo.GetRetirosAsync(TipoEntrada, "", FechaDesde, FechaHasta, usuario, EstadoRetiro, Movil: Movil);
                actionResult = Ok(listadoRetiros);
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

        [HttpPost("GetRetirosByCliente/{diaDesde}/{mesDesde}/{anioDesde}/{diaHasta}/{mesHasta}/{anioHasta}")]
        public async Task<IActionResult> GetRetirosByCliente(string diaDesde, string mesDesde, string anioDesde,
                                                             string diaHasta, string mesHasta, string anioHasta,
                                                             [FromBody] RetiroToHistorial retiroToHistorial)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                DateTime FechaDesde = DateTime.Parse($"{diaDesde}/{mesDesde}/{anioDesde}");
                DateTime FechaHasta = DateTime.Parse($"{diaHasta}/{mesHasta}/{anioHasta}");

                IEnumerable listadoRetiros = await _retirosRepo.GetRetirosAsync("", retiroToHistorial.CodigoComuna, FechaDesde, FechaHasta, retiroToHistorial.usuario, Cliente: retiroToHistorial.CodigoCliente);
                actionResult = Ok(listadoRetiros);
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

        [HttpPost("GetDetalle/{NumeroRetiro:int}")]
        public async Task<IActionResult> GetDetalle([FromBody] Usuario usuario, int NumeroRetiro)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                Retiro retiro = await _retirosRepo.GetDetalleAsync(NumeroRetiro, usuario);
                actionResult = Ok(retiro);
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

        [HttpPost("ReporteSucursal/{dia}/{mes}/{anio}")]
        public async Task<IActionResult> ReporteSucursal([FromBody] Usuario usuario, string dia, string mes, string anio)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                DateTime FechaSolicitud = DateTime.Parse($"{dia}/{mes}/{anio}");
                IEnumerable<Retiro> retiros = await _retirosRepo.GetReporteSucursalesAsync(FechaSolicitud, usuario);
                actionResult = Ok(retiros);
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
