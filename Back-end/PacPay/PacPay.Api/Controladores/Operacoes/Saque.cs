using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Operacoes.Saques;

namespace PacPay.Api.Controladores.Operacoes
{
    [Route("/[controller]")]
    [ApiController]
    public class Saque(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpPost]
        public async Task<OkObjectResult> Sacar(SaqueRequest saqueRequest, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(saqueRequest, cancellationToken);

                return Ok("Saque realizado com sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}