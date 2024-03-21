using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Contas.Atualizacao;

namespace PacPay.Api.Controladores.Conta
{
    [Route("/[controller]")]
    [ApiController]
    public class Atualizar(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpPatch]
        public async Task<ActionResult<AtualizarResponse>> Index(AtualizarRequest atualizarRequest, CancellationToken cancellationToken)
        {
            try
            {
                AtualizarResponse atualizarResponse = await _mediator.Send(atualizarRequest, cancellationToken);

                return Ok(atualizarResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}