using MediatR;
using Microsoft.AspNetCore.Mvc;
using PacPay.App.CasosDeUso.Contas.CriarConta;

namespace PacPay.Api.Controllers.Conta
{
    [Route("/[controller]")]
    [ApiController]
    public class CriarController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


       
        [HttpPost]
       
        public async Task<ActionResult<CriarContaResponse>> CriarConta(CriarContaRequest request, CancellationToken cancellationToken)
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