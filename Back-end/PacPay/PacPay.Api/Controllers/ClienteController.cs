using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.AdicionarCliente;

namespace PacPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AdicionarClienteResponse>> CreateUser(AdicionarClienteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                AdicionarClienteResponse response = await _mediator.Send(request, cancellationToken);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}