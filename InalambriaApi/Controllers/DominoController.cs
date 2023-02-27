using InalambriaApi.Business.Core.Business.Domino;
using InalambriaApi.Business.Core.Business.Middleware;
using InalambriaApi.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InalambriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DominoController : ControllerBase
    {
        private readonly DominoBusiness dominoBusiness;
        public DominoController(DominoBusiness dominoBusiness) {
            this.dominoBusiness = dominoBusiness;
        }
        [HttpGet]        
        public async Task<IActionResult> Healthcheck()
        {
            return Ok("Todo va bien:");
        }

        [HttpPost("entrada")]
        [AuthorizationMiddleware]
        public async Task<IActionResult> Prueba([FromBody] List<DominoToken> lista)
        {
            if(lista.Count < 2 || lista.Count > 6)
            {
                return BadRequest("Numero de fichas no válido");
            }
            var result = dominoBusiness.DataInTokens(lista);
            if (result == null) return StatusCode(200, "La cadena de fichas no es válida");
            return StatusCode(200, result);
        }
    }
}
