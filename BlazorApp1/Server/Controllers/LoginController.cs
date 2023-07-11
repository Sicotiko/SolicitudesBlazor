using BlazorApp1.Shared.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("Auth")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                var _movilesDisponibles = await Management.Moviles.Disponibles.GetMovilesDisponibles(usuario);
                Sesion sesion = new Sesion();
                sesion.Rol = "RadioOperador";
                sesion.MovilesDisponibles = JsonConvert.SerializeObject(usuario);
                

                if (usuario.UserInBase64.Equals("EMORALESV") || usuario.UserInBase64.Equals("emoralesv"))
                    sesion.Rol += " Super";

                actionResult = Ok(sesion);

            }
            catch (Exception ex)
            {
                actionResult = Unauthorized(ex.Message);
            }

            return actionResult;
        }

    }
}
