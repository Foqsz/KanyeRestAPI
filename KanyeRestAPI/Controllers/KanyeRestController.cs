using KanyeRestAPI.Response;
using KanyeRestAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace KanyeRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KanyeRestController : ControllerBase
    {
        private readonly IKanyeRestService _kanyeRestService;

        public KanyeRestController(IKanyeRestService kanyeRestService)
        {
            _kanyeRestService = kanyeRestService;
        }

        /// <summary>
        /// Retorna uma fala aleatória do Kanye West.
        /// </summary>
        /// <returns>Uma fala aleatória do Kanye West.</returns>
        /// <response code="200">Fala do Kanye West retornada com sucesso.</response>
        /// <response code="404">Não foi possível obter uma fala do Kanye West.</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Retorna uma fala aleatória do Kanye West",
                          Description = "Gere uma fala aleatória do Kanye West!")]
        [ProducesResponseType(typeof(KanyeRestResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> GetKanyeRest()
        {
            var kanyeRestResponse = await _kanyeRestService.GetKanyeRestRandom();

            if (kanyeRestResponse is null)
            {
                return NotFound(new { message = "Erro ao obter uma fala do Kanye West." });
            }

            return Ok(new { KanyeWestAPI = kanyeRestResponse });
        }
    }
}
