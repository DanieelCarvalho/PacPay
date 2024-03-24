using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Operacoes.Depositar;
using PacPay.Dominio.Excecoes;

namespace PacPay.Api.Controladores.Operacoes
{
    [Route("/[controller]")]
    [ApiController]
    public class Deposito(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Depositar(DepositarRequest depositoRequest, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(depositoRequest, cancellationToken);

                return NoContent();
            }
            catch (Excecao ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}