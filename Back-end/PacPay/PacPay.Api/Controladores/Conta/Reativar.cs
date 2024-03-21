using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Contas.Reativacao;

namespace PacPay.Api.Controladores.Conta
{
    [Route("/[controller]")]
    [ApiController]
    public class Reativar(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Index(ReativarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(request, cancellationToken);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}