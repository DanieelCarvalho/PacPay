using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Operacoes.Deposito;

namespace PacPay.Api.Controladores.Operacoes
{
    [Route("/[controller]")]
    [ApiController]
    public class DepositoController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpPost]
        public async Task<OkObjectResult> Depositar(DepositoRequest depositoRequest, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(depositoRequest, cancellationToken);

                return Ok("Depósito realizado com sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}