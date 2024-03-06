using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.AdicionarConta;

namespace PacPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CriarContaResponse>> CreateUser(CriarContaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                CriarContaResponse response = await _mediator.Send(request, cancellationToken);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}