using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Contas.CriarConta;

namespace PacPay.Api.Controllers.Conta
{
    [Route("/[controller]")]
    [ApiController]
    public class Criar(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CriarConta(CriarContaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(request, cancellationToken);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}