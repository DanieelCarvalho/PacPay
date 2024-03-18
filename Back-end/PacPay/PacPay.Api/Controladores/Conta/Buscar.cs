using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Contas.Buscar;

namespace PacPay.Api.Controladores.Conta
{
    [Route("/[controller]")]
    [ApiController]
    public class Buscar(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<BuscaResponse>> Busca(CancellationToken cancellationToken)
        {
            try
            {
                BuscaResponse buscaRespons = await _mediator.Send(new BuscaRequest(), cancellationToken);

                return Ok(buscaRespons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}