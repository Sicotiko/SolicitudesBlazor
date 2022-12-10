﻿using BlazorApp1.Server.Controllers.Retiros;
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
        public async Task<IActionResult> Asignar([FromBody] RetiroToAssign retiroToAssign)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                await _retirosRepo.AsignarRetiroAsync(retiroToAssign._retiro, retiroToAssign._usuario);
                actionResult = Ok();
            }
            catch (System.Exception ex)
            {
                actionResult = BadRequest($"No se logro asignar el retiro: {ex.Message} : {ex.InnerException}");
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

                IEnumerable listadoRetiros = await _retirosRepo.GetRetirosAsync(TipoEntrada, Comuna, FechaDesde, FechaHasta, usuario, EstadoRetiro);
                actionResult = Ok(listadoRetiros);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest($"No se logro obtener retiros: {ex.Message} : {ex.InnerException}");
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
            catch (Exception ex)
            {
                actionResult = BadRequest($"No se logro obtener retiros: {ex.Message} : {ex.InnerException}");
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
            catch (Exception ex)
            {
                actionResult = BadRequest($"No se logro obtener el detalle: {ex.Message} : {ex.InnerException}");
            }

            return actionResult;
        }

        [HttpPost("ReporteSucursal/{dia}/{mes}/{anio}")]
        public async Task<IActionResult> ReporteSucursal([FromBody] Usuario usuario, string dia,string mes,string anio)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                DateTime FechaSolicitud = DateTime.Parse($"{dia}/{mes}/{anio}");
                IEnumerable<Retiro> retiros = await _retirosRepo.GetReporteSucursalesAsync(FechaSolicitud, usuario);
                actionResult = Ok(retiros);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest($"No se logro obtener el reporte: {ex.Message} : {ex.InnerException}");
            }

            return actionResult;
        }

    }
}
