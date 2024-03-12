using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.AdicionarConta;

namespace PacPay.Api.Controllers.Conta
{
    [Route("/[controller]")]
    [ApiController]
    public class LoginController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request, CancellationToken cancellationToken)
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