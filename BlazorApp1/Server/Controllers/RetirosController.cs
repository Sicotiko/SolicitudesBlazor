using BlazorApp1.Server.Services;
using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.Modelo.Retiros;
using BlazorApp1.Shared.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetirosController : ControllerBase
    {
        private readonly ServiceRetiro serviceRetiro;
        private ListadoOrdenes listadoOrdenes { get; set; }
        private readonly ServiceOrdenTrabajo serviceOrdenTrabajo;
        private readonly ServiceComuna serviceComuna;

        public RetirosController(ServiceRetiro serviceRetiro, ListadoOrdenes listadoOrdenes, ServiceOrdenTrabajo serviceOrdenTrabajo, ServiceComuna serviceComuna)
        {
            this.serviceRetiro = serviceRetiro;
            this.listadoOrdenes = listadoOrdenes;
            this.serviceOrdenTrabajo = serviceOrdenTrabajo;
            this.serviceComuna = serviceComuna;
        }

        [HttpPost("Asignar")]
        public async Task<IActionResult> Asignar([FromBody] RetiroToAssign retiroToAssign)
        {
            IActionResult actionResult = BadRequest();

            try
            {

                //OrdenTrabajo? ote;

                //var cod = retiroToAssign.retiro.Movil.Codigo;
                //var com = retiroToAssign.retiro.Comuna;
                //var tp = retiroToAssign.retiro.TipoHorario;
                //var fc = DateTime.Now.Date.ToUniversalTime();

                //var or = listadoOrdenes.GetOrdenes();

                //OrdenTrabajo? orden = listadoOrdenes.GetOrdenes().FirstOrDefault(o => o.Movil.Codigo == retiroToAssign.retiro.Movil.Codigo &&
                //                                                       o.Comuna.CodigoPostal == retiroToAssign.retiro.Comuna.CodigoPostal &&
                //                                                       o.TipoHorario == retiroToAssign.retiro.TipoHorario &&
                //                                                       o.Fecha.Date.ToUniversalTime() == DateTime.Now.Date.ToUniversalTime());
                OrdenTrabajo? orden = await serviceOrdenTrabajo.GetOrdenAsync(o => o.Movil.Codigo == retiroToAssign.retiro.Movil.Codigo &&
                                                                              o.TipoHorario == retiroToAssign.retiro.TipoHorario &&
                                                                              o.Fecha.Year == DateTime.Now.Year &&
                                                                              o.Fecha.Month == DateTime.Now.Month &&
                                                                              o.Fecha.Day == DateTime.Now.Day &&
                                                                              !o.Cerrada);

                if (orden != null)
                    retiroToAssign.retiro.OrdenTrabajo = orden;
                else
                {

                    retiroToAssign.retiro.OrdenTrabajo = await serviceOrdenTrabajo.CreateOrdenTrabajoAsync(new Shared.Modelo.OT.OrdenViewModel
                    {
                        OrdenDeTrabajo = new Shared.Modelo.OT.OrdenTrabajo
                        {
                            Clasificacion = retiroToAssign.retiro.Clasificacion,
                            Comuna = retiroToAssign.retiro.Comuna,
                            Fecha = DateTime.Now.Date.ToUniversalTime(),
                            Movil = retiroToAssign.retiro.Movil,
                            SectorName = retiroToAssign.retiro.NombreSector,
                            TipoHorario = retiroToAssign.retiro.TipoHorario
                        },
                        Usuario = retiroToAssign.usuario
                    });

                    //listadoOrdenes.AddOrden(retiroToAssign.retiro.OrdenTrabajo);
                }

                await serviceRetiro.Asignar(retiroToAssign);
                actionResult = Ok();
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

        [HttpPost("GetRetiros")]
        public async Task<IActionResult> GetRetiros([FromBody] FiltroBusquedaRetiros filtro)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                filtro.FechaDesde = filtro.FechaDesde.ToUniversalTime();
                filtro.Hasta = filtro.Hasta.ToUniversalTime();
                IEnumerable<Retiro> listadoRetiros = await serviceRetiro.GetRetirosAsync(filtro);
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
        [HttpPost("GetRetirosPorSector")]
        public async Task<IActionResult> GetRetirosPorSector([FromBody] FiltroBusquedaRetiros filtro)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                filtro.FechaDesde = filtro.FechaDesde.ToUniversalTime();
                filtro.Hasta = filtro.Hasta.ToUniversalTime();
                List<Retiro> retiros = new List<Retiro>();
                var comunas = await serviceComuna.GetSomeAsync(com => com.NombreSector == filtro.NombreSector);
                foreach (var comuna in comunas)
                {
                    await Task.Run(async () =>
                    {

                        filtro.Poblacion = comuna.CodigoPostal;
                        retiros.AddRange(await serviceRetiro.GetRetirosAsync(filtro));
                    });
                }

                actionResult = Ok(retiros.AsEnumerable());
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


    }
}
