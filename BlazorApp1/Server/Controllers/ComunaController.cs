using BlazorApp1.Server.Services;
using BlazorApp1.Shared.Modelo.Comunas;
using BlazorApp1.Shared.Modelo.OT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunaController : ControllerBase
    {
        private readonly ServiceComuna serviceComuna;

        public ComunaController(ServiceComuna serviceComuna)
        {
            this.serviceComuna = serviceComuna;
        }

        [HttpPost("GetBySector")]
        public async Task<IActionResult> GetBySector([FromBody] NombreSector nombreSector)
        {
            IActionResult actionResult = NotFound();
            try
            {
                var list = await serviceComuna.GetSomeAsync(c => c.NombreSector == nombreSector);
                actionResult = Ok(list);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest($"{ex.Message} : {ex.InnerException?.Message} ");
            }
            return actionResult;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult actionResult = NotFound();
            try
            {
                var list = await serviceComuna.GetAllAsync();
                actionResult = Ok(list);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest($"{ex.Message} : {ex.InnerException?.Message} ");
            }
            return actionResult;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Comuna comuna)
        {
            IActionResult actionResult = NotFound();
            try
            {
                var list = await serviceComuna.UpdateAsync(comuna);
                actionResult = Ok(list);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest($"{ex.Message} : {ex.InnerException?.Message} ");
            }
            return actionResult;
        }
    }
}
