using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.AdicionarConta;

namespace PacPay.Api.Controllers.Contas
{
    [Route("/[controller]")]
    [ApiController]
    public class Login(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> Index(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                LoginResponse response = await _mediator.Send(request, cancellationToken);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}