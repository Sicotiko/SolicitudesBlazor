using BlazorApp1.Server.Services;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ServiceMovil serviceMovil;

        public LoginController(ServiceMovil serviceMovil)
        {
            this.serviceMovil = serviceMovil;
        }


        [HttpPost("Auth")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            IActionResult actionResult = BadRequest();

            try
            {

                var moviles = await serviceMovil.GetMovilesDisponibles(usuario);

                Sesion sesion = new Sesion();
                sesion.Rol = "RadioOperador";
                sesion.Nombre = usuario.UserInBase64;
                sesion.MovilesDisponibles = JsonConvert.SerializeObject(moviles);


                if (usuario.UserInBase64.Equals("EMORALESV") || usuario.UserInBase64.Equals("emoralesv"))
                    sesion.Rol = "Super";

                actionResult = Ok(sesion);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actionResult = Unauthorized("Comprueba tus Credenciales o VPN \r" + ex.Message + " : " + ex.InnerException?.Message);
            }

            return actionResult;
        }

    }
}
