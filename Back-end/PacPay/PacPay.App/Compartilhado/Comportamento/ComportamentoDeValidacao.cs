using FluentValidation;
using MediatR;

namespace PacPay.App.Compartilhado.Comportamento
{
    internal class ComportamentoDeValidacaor<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validadores) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validadores = validadores;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validadores.Any()) return await next();

            var contexto = new ValidationContext<TRequest>(request);
            if (_validadores.Any())
            {
                contexto = new ValidationContext<TRequest>(request);
                var resultado = await Task.WhenAll(_validadores.Select(v => v.ValidateAsync(contexto, cancellationToken)));

                var falhas = resultado.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (falhas.Count != 0)
                {
                    throw new ValidationException(falhas);
                }
            }

            return await next();
        }
    }
}