using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.AdicionarConta;
using PacPay.Dominio.Excecoes;

namespace PacPay.Api.Controllers.Contas
{
    [Route("/[controller]")]
    [ApiController]
    public class Login(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginResponse>> Index(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                LoginResponse response = await _mediator.Send(request, cancellationToken);

                return Ok(response);
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