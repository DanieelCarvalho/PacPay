using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Operacoes.Historico;

namespace PacPay.Api.Controladores.Operacoes
{
    [Route("/[controller]")]
    [ApiController]
    public class Historico(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpGet("{numeroDaPagina}")]
        public async Task<IActionResult> PegarHistorico(int numeroDaPagina, CancellationToken cancellationToken)
        {
            try
            {
                HistoricoRequest historicoRequest = new(numeroDaPagina);

                List<HistoricoResponse> response = await _mediator.Send(historicoRequest, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}