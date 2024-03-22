using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Contas.Desativacao;

namespace PacPay.Api.Controladores.Conta
{
    [Route("/[controller]")]
    [ApiController]
    public class Desativar(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<DesativarResponse>> Index(DesativarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                DesativarResponse response = await _mediator.Send(request, cancellationToken);

                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}