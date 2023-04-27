using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipoMovilesController : ControllerBase
    {

        [HttpPost("GetMovilesDisponibles")]
        public async Task<IActionResult> GetMovilesDisponibles([FromBody] Usuario usuario)
        {
            IActionResult actionResult = BadRequest();

            try
            {
                actionResult = Ok(await Management.Moviles.Disponibles.GetMovilesDisponibles(usuario));
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
