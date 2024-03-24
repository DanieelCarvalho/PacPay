using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Contas.Criar;
using PacPay.Dominio.Excecoes;

namespace PacPay.Api.Controllers.Contas
{
    [Route("/[controller]")]
    [ApiController]
    public class Criar(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Index(CriarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(request, cancellationToken);

                return Created();
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