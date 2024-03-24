using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Contas.Buscar;
using PacPay.Dominio.Excecoes;

namespace PacPay.Api.Controladores.Contas
{
    [Route("/[controller]")]
    [ApiController]
    public class Buscar(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BuscarResponse>> Index(CancellationToken cancellationToken)
        {
            try
            {
                BuscarResponse buscaRespons = await _mediator.Send(new BuscarRequest(), cancellationToken);

                return Ok(buscaRespons);
            }
            catch (Excecao ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}