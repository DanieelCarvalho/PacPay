using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Contas.Atualizar;
using PacPay.Dominio.Excecoes;

namespace PacPay.Api.Controladores.Contas
{
    [Route("/[controller]")]
    [ApiController]
    public class Atualizar(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Index(AtualizarRequest atualizarRequest, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(atualizarRequest, cancellationToken);

                return NoContent();
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